# Apply Gule And Tape PC

## Tool chuyển G-code sang định dạng Model Mode 1

Phần mềm đọc file model Mode 1 từ thư mục `Model/List_Model_Mode_1` với từng dòng dạng:

`X... Y... Z...`

Để tạo file này nhanh từ G-code, dùng script:

`tools/gcode_to_mode1.py`

### Cách dùng

```bash
python3 tools/gcode_to_mode1.py input.gcode -o Model/List_Model_Mode_1/MODEL_A.txt
```

Tùy chọn thêm:

- `--decimals 3`: số chữ số thập phân output.
- `--default-z 0`: nếu chưa có Z trước đó thì dùng giá trị này.
- `--arc-step 1.0`: bước nội suy tối đa (mm) cho cung tròn `G2/G3`.

### Nội suy cung tròn G2/G3

Tool có hỗ trợ chuyển cung tròn (clockwise/counterclockwise) sang nhiều điểm XY trung gian để bám đúng đường cong.

- Hỗ trợ mode tọa độ `G90` (tuyệt đối) và `G91` (gia số).
- Với cung `G2/G3`, tool dùng tâm `I/J` để nội suy ra các điểm con.
- Giá trị `Z` sẽ nội suy tuyến tính từ đầu cung tới cuối cung.

### Ví dụ

Input G-code:

```gcode
G0 X0 Y0 Z5
G1 X10 Y0
G3 X10 Y10 I0 J5
```

Output Mode 1 (rút gọn):

```txt
X0.000 Y0.000 Z5.000
X10.000 Y0.000 Z5.000
X9.024 Y0.096 Z5.000
...
X10.000 Y10.000 Z5.000
```

Sau khi tạo xong file `.txt`, mở phần mềm và chọn đúng Model ở chế độ Mode 1.
