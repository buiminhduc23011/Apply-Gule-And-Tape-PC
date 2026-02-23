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

### Ví dụ

Input G-code:

```gcode
G0 X0 Y0 Z5
G1 X10 Y0
G1 X10 Y8 Z1.2
```

Output Mode 1:

```txt
X0.000 Y0.000 Z5.000
X10.000 Y0.000 Z5.000
X10.000 Y8.000 Z1.200
```

Sau khi tạo xong file `.txt`, mở phần mềm và chọn đúng Model ở chế độ Mode 1.
