#!/usr/bin/env python3
"""Convert G-code into Mode1 point format (X.. Y.. Z..) used by Apply Gule And Tape PC.

Output format: one line per point
    X<value> Y<value> Z<value>
"""

from __future__ import annotations

import argparse
import re
from pathlib import Path

# G-code numbers may appear as: 10, -10, 10.5, -0.25, .25, -.25, 10.
NUMBER_PATTERN = r"[+-]?(?:\d+\.\d*|\.\d+|\d+)"
AXIS_RE = re.compile(rf"([XYZ])\s*({NUMBER_PATTERN})", re.IGNORECASE)
COMMENT_RE = re.compile(r"\(.*?\)|;.*$")


def strip_comments(line: str) -> str:
    return COMMENT_RE.sub("", line).strip()


def parse_points(lines: list[str], default_z: float | None) -> list[tuple[float, float, float]]:
    points: list[tuple[float, float, float]] = []
    current_x: float | None = None
    current_y: float | None = None
    current_z: float | None = default_z

    for raw in lines:
        line = strip_comments(raw)
        if not line:
            continue

        matches = AXIS_RE.findall(line)
        if not matches:
            continue

        touched_xy = False
        for axis, value in matches:
            numeric = float(value)
            axis = axis.upper()
            if axis == "X":
                current_x = numeric
                touched_xy = True
            elif axis == "Y":
                current_y = numeric
                touched_xy = True
            elif axis == "Z":
                current_z = numeric

        if touched_xy:
            if current_x is None or current_y is None:
                # Skip until both X/Y are known.
                continue
            if current_z is None:
                current_z = 0.0
            points.append((current_x, current_y, current_z))

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

    args = parser.parse_args()

    if not args.input.exists():
        raise SystemExit(f"Input file not found: {args.input}")

    lines = args.input.read_text(encoding="utf-8", errors="ignore").splitlines()
    points = parse_points(lines, args.default_z)
    if not points:
        raise SystemExit("No X/Y/Z points were parsed from input G-code.")

    args.output.parent.mkdir(parents=True, exist_ok=True)
    args.output.write_text(format_points(points, args.decimals) + "\n", encoding="utf-8")
    print(f"Converted {len(points)} points -> {args.output}")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
