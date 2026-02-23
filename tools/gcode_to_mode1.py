#!/usr/bin/env python3
"""Convert G-code into Mode1 point format (X.. Y.. Z..) used by Apply Gule And Tape PC.

Output format: one line per point
    X<value> Y<value> Z<value>
"""

from __future__ import annotations

import argparse
import math
import re
from pathlib import Path

# G-code numbers may appear as: 10, -10, 10.5, -0.25, .25, -.25, 10.
NUMBER_PATTERN = r"[+-]?(?:\d+\.\d*|\.\d+|\d+)"
TOKEN_RE = re.compile(rf"([A-Za-z])\s*({NUMBER_PATTERN})")
COMMENT_RE = re.compile(r"\(.*?\)|;.*$")


def strip_comments(line: str) -> str:
    return COMMENT_RE.sub("", line).strip()


def normalize_angle(angle: float) -> float:
    while angle <= -math.pi:
        angle += 2 * math.pi
    while angle > math.pi:
        angle -= 2 * math.pi
    return angle


def interpolate_arc(
    start_x: float,
    start_y: float,
    start_z: float,
    end_x: float,
    end_y: float,
    end_z: float,
    i_offset: float,
    j_offset: float,
    clockwise: bool,
    arc_step: float,
) -> list[tuple[float, float, float]]:
    center_x = start_x + i_offset
    center_y = start_y + j_offset

    start_angle = math.atan2(start_y - center_y, start_x - center_x)
    end_angle = math.atan2(end_y - center_y, end_x - center_x)

    sweep = normalize_angle(end_angle - start_angle)
    if clockwise and sweep > 0:
        sweep -= 2 * math.pi
    elif not clockwise and sweep < 0:
        sweep += 2 * math.pi

    # Full circle case: endpoint equals startpoint but command is still an arc.
    if abs(sweep) < 1e-12 and abs(end_x - start_x) < 1e-9 and abs(end_y - start_y) < 1e-9:
        sweep = -2 * math.pi if clockwise else 2 * math.pi

    radius = math.hypot(start_x - center_x, start_y - center_y)
    arc_len = abs(sweep) * radius
    segments = max(2, int(math.ceil(arc_len / arc_step)))

    points: list[tuple[float, float, float]] = []
    for idx in range(1, segments + 1):
        t = idx / segments
        angle = start_angle + sweep * t
        x_val = center_x + radius * math.cos(angle)
        y_val = center_y + radius * math.sin(angle)
        z_val = start_z + (end_z - start_z) * t
        points.append((x_val, y_val, z_val))
    return points


def parse_points(
    lines: list[str], default_z: float | None, arc_step: float
) -> list[tuple[float, float, float]]:
    points: list[tuple[float, float, float]] = []

    current_x: float | None = None
    current_y: float | None = None
    current_z: float | None = default_z

    absolute_mode = True  # G90
    motion_mode = 1  # modal motion default G1

    for raw in lines:
        line = strip_comments(raw)
        if not line:
            continue

        values: dict[str, float] = {}
        g_codes: list[int] = []

        for letter, value in TOKEN_RE.findall(line):
            letter = letter.upper()
            number = float(value)
            if letter == "G":
                g_codes.append(int(round(number)))
            elif letter in {"X", "Y", "Z", "I", "J"}:
                values[letter] = number

        if not g_codes and not values:
            continue

        for g_code in g_codes:
            if g_code == 90:
                absolute_mode = True
            elif g_code == 91:
                absolute_mode = False
            elif g_code in {0, 1, 2, 3}:
                motion_mode = g_code

        if current_z is None:
            current_z = 0.0

        start_x = current_x
        start_y = current_y
        start_z = current_z

        x_touched = "X" in values
        y_touched = "Y" in values

        if absolute_mode:
            end_x = values.get("X", current_x)
            end_y = values.get("Y", current_y)
            end_z = values.get("Z", current_z)
        else:
            end_x = (current_x if current_x is not None else 0.0) + values.get("X", 0.0)
            end_y = (current_y if current_y is not None else 0.0) + values.get("Y", 0.0)
            end_z = current_z + values.get("Z", 0.0)

        if end_x is None:
            end_x = 0.0
        if end_y is None:
            end_y = 0.0

        current_x, current_y, current_z = end_x, end_y, end_z

        if motion_mode in {2, 3} and start_x is not None and start_y is not None:
            has_arc_center = "I" in values or "J" in values
            # Accept full-circle command where target may be omitted but I/J is provided.
            if has_arc_center:
                arc_points = interpolate_arc(
                    start_x=start_x,
                    start_y=start_y,
                    start_z=start_z,
                    end_x=end_x,
                    end_y=end_y,
                    end_z=end_z,
                    i_offset=values.get("I", 0.0),
                    j_offset=values.get("J", 0.0),
                    clockwise=motion_mode == 2,
                    arc_step=arc_step,
                )
                points.extend(arc_points)
                continue

        if x_touched or y_touched:
            points.append((end_x, end_y, end_z))

    return points


def format_points(points: list[tuple[float, float, float]], decimals: int) -> str:
    fmt = f"{{:.{decimals}f}}"
    return "\n".join(
        f"X{fmt.format(x)} Y{fmt.format(y)} Z{fmt.format(z)}" for x, y, z in points
    )


def main() -> int:
    parser = argparse.ArgumentParser(
        description="Convert G-code into Mode1 model text format for Apply Gule And Tape PC"
    )
    parser.add_argument("input", type=Path, help="Path to source G-code file (.nc, .gcode, .txt, ...)")
    parser.add_argument(
        "-o",
        "--output",
        type=Path,
        required=True,
        help="Output .txt path. Put this file into Model/List_Model_Mode_1",
    )
    parser.add_argument(
        "--default-z",
        type=float,
        default=None,
        help="Default Z value when the G-code line has X/Y but no Z and no prior Z (default: 0 when needed)",
    )
    parser.add_argument(
        "--decimals",
        type=int,
        default=3,
        help="Decimal places in output (default: 3)",
    )
    parser.add_argument(
        "--arc-step",
        type=float,
        default=1.0,
        help="Max segment length (mm) when approximating G2/G3 arcs (default: 1.0)",
    )

    args = parser.parse_args()

    if args.arc_step <= 0:
        raise SystemExit("--arc-step must be > 0")

    if not args.input.exists():
        raise SystemExit(f"Input file not found: {args.input}")

    lines = args.input.read_text(encoding="utf-8", errors="ignore").splitlines()
    points = parse_points(lines, args.default_z, args.arc_step)
    if not points:
        raise SystemExit("No X/Y/Z points were parsed from input G-code.")

    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(format_points(points, args.decimals) + "\n", encoding="utf-8")
    print(f"Converted {len(points)} points -> {args.output}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
