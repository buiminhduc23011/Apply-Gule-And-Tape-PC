using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using IOPath = System.IO.Path;
using System.Windows;
using System.Windows.Controls;

namespace Apply_Gule_And_Tape_PC.Class
{

    public class FileInformation
    {
        public string Model { get; set; }
        public int STT { get; set; }
        public FileInformation(int STT_, string Model_)
        {
            STT = STT_;
            Model = Model_;
        }
    }
    public static class ListModel1
    {
        public static ObservableCollection<FileInformation> FilesList { get; private set; }

        public static void LoadModel()
        {
            FilesList = new ObservableCollection<FileInformation>();
            string folderPath = "Model\\List_Model_Mode_1";
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);
                int i = 1;
                foreach (string file in files)
                {
                    FilesList.Add(new FileInformation(i, IOPath.GetFileName(file)));
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Thư mục không tồn tại.");
            }
        }
    }
    public class FloatStatusElement
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public uint Buf_Status { get; set; }
    }
    public class MyData
    {
        public double Buf_X0 { get; set; }
        public double Buf_Y0 { get; set; }
        public double Buf_Z0 { get; set; }
        public uint Buf_Status0 { get; set; }
        public double Buf_X1 { get; set; }
        public double Buf_Y1 { get; set; }
        public double Buf_Z1 { get; set; }
        public uint Buf_Status1 { get; set; }
        public double Buf_X2 { get; set; }
        public double Buf_Y2 { get; set; }
        public double Buf_Z2 { get; set; }
        public uint Buf_Status2 { get; set; }
        public double Buf_X3 { get; set; }
        public double Buf_Y3 { get; set; }
        public double Buf_Z3 { get; set; }
        public uint Buf_Status3 { get; set; }
        public double Buf_X4 { get; set; }
        public double Buf_Y4 { get; set; }
        public double Buf_Z4 { get; set; }
        public uint Buf_Status4 { get; set; }
        public double Buf_X5 { get; set; }
        public double Buf_Y5 { get; set; }
        public double Buf_Z5 { get; set; }
        public uint Buf_Status5 { get; set; }
        public double Buf_X6 { get; set; }
        public double Buf_Y6 { get; set; }
        public double Buf_Z6 { get; set; }
        public uint Buf_Status6 { get; set; }
        public double Buf_X7 { get; set; }
        public double Buf_Y7 { get; set; }
        public double Buf_Z7 { get; set; }
        public uint Buf_Status7 { get; set; }
        public double Buf_X8 { get; set; }
        public double Buf_Y8 { get; set; }
        public double Buf_Z8 { get; set; }
        public uint Buf_Status8 { get; set; }
        public double Buf_X9 { get; set; }
        public double Buf_Y9 { get; set; }
        public double Buf_Z9 { get; set; }
        public uint Buf_Status9 { get; set; }
        public double Buf_X10 { get; set; }
        public double Buf_Y10 { get; set; }
        public double Buf_Z10 { get; set; }
        public uint Buf_Status10 { get; set; }
        public double Buf_X11 { get; set; }
        public double Buf_Y11 { get; set; }
        public double Buf_Z11 { get; set; }
        public uint Buf_Status11 { get; set; }
        public double Buf_X12 { get; set; }
        public double Buf_Y12 { get; set; }
        public double Buf_Z12 { get; set; }
        public uint Buf_Status12 { get; set; }
        public double Buf_X13 { get; set; }
        public double Buf_Y13 { get; set; }
        public double Buf_Z13 { get; set; }
        public uint Buf_Status13 { get; set; }
        public double Buf_X14 { get; set; }
        public double Buf_Y14 { get; set; }
        public double Buf_Z14 { get; set; }
        public uint Buf_Status14 { get; set; }
        public double Buf_X15 { get; set; }
        public double Buf_Y15 { get; set; }
        public double Buf_Z15 { get; set; }
        public uint Buf_Status15 { get; set; }
        public double Buf_X16 { get; set; }
        public double Buf_Y16 { get; set; }
        public double Buf_Z16 { get; set; }
        public uint Buf_Status16 { get; set; }
        public double Buf_X17 { get; set; }
        public double Buf_Y17 { get; set; }
        public double Buf_Z17 { get; set; }
        public uint Buf_Status17 { get; set; }
        public double Buf_X18 { get; set; }
        public double Buf_Y18 { get; set; }
        public double Buf_Z18 { get; set; }
        public uint Buf_Status18 { get; set; }
        public double Buf_X19 { get; set; }
        public double Buf_Y19 { get; set; }
        public double Buf_Z19 { get; set; }
        public uint Buf_Status19 { get; set; }
        public double Buf_X20 { get; set; }
        public double Buf_Y20 { get; set; }
        public double Buf_Z20 { get; set; }
        public uint Buf_Status20 { get; set; }
        public double Buf_X21 { get; set; }
        public double Buf_Y21 { get; set; }
        public double Buf_Z21 { get; set; }
        public uint Buf_Status21 { get; set; }
        public double Buf_X22 { get; set; }
        public double Buf_Y22 { get; set; }
        public double Buf_Z22 { get; set; }
        public uint Buf_Status22 { get; set; }
        public double Buf_X23 { get; set; }
        public double Buf_Y23 { get; set; }
        public double Buf_Z23 { get; set; }
        public uint Buf_Status23 { get; set; }
        public double Buf_X24 { get; set; }
        public double Buf_Y24 { get; set; }
        public double Buf_Z24 { get; set; }
        public uint Buf_Status24 { get; set; }
        public double Buf_X25 { get; set; }
        public double Buf_Y25 { get; set; }
        public double Buf_Z25 { get; set; }
        public uint Buf_Status25 { get; set; }
        public double Buf_X26 { get; set; }
        public double Buf_Y26 { get; set; }
        public double Buf_Z26 { get; set; }
        public uint Buf_Status26 { get; set; }
        public double Buf_X27 { get; set; }
        public double Buf_Y27 { get; set; }
        public double Buf_Z27 { get; set; }
        public uint Buf_Status27 { get; set; }
        public double Buf_X28 { get; set; }
        public double Buf_Y28 { get; set; }
        public double Buf_Z28 { get; set; }
        public uint Buf_Status28 { get; set; }
        public double Buf_X29 { get; set; }
        public double Buf_Y29 { get; set; }
        public double Buf_Z29 { get; set; }
        public uint Buf_Status29 { get; set; }
        public double Buf_X30 { get; set; }
        public double Buf_Y30 { get; set; }
        public double Buf_Z30 { get; set; }
        public uint Buf_Status30 { get; set; }
        public double Buf_X31 { get; set; }
        public double Buf_Y31 { get; set; }
        public double Buf_Z31 { get; set; }
        public uint Buf_Status31 { get; set; }
        public double Buf_X32 { get; set; }
        public double Buf_Y32 { get; set; }
        public double Buf_Z32 { get; set; }
        public uint Buf_Status32 { get; set; }
        public double Buf_X33 { get; set; }
        public double Buf_Y33 { get; set; }
        public double Buf_Z33 { get; set; }
        public uint Buf_Status33 { get; set; }
        public double Buf_X34 { get; set; }
        public double Buf_Y34 { get; set; }
        public double Buf_Z34 { get; set; }
        public uint Buf_Status34 { get; set; }
        public double Buf_X35 { get; set; }
        public double Buf_Y35 { get; set; }
        public double Buf_Z35 { get; set; }
        public uint Buf_Status35 { get; set; }
        public double Buf_X36 { get; set; }
        public double Buf_Y36 { get; set; }
        public double Buf_Z36 { get; set; }
        public uint Buf_Status36 { get; set; }
        public double Buf_X37 { get; set; }
        public double Buf_Y37 { get; set; }
        public double Buf_Z37 { get; set; }
        public uint Buf_Status37 { get; set; }
        public double Buf_X38 { get; set; }
        public double Buf_Y38 { get; set; }
        public double Buf_Z38 { get; set; }
        public uint Buf_Status38 { get; set; }
        public double Buf_X39 { get; set; }
        public double Buf_Y39 { get; set; }
        public double Buf_Z39 { get; set; }
        public uint Buf_Status39 { get; set; }
        public double Buf_X40 { get; set; }
        public double Buf_Y40 { get; set; }
        public double Buf_Z40 { get; set; }
        public uint Buf_Status40 { get; set; }
        public double Buf_X41 { get; set; }
        public double Buf_Y41 { get; set; }
        public double Buf_Z41 { get; set; }
        public uint Buf_Status41 { get; set; }
        public double Buf_X42 { get; set; }
        public double Buf_Y42 { get; set; }
        public double Buf_Z42 { get; set; }
        public uint Buf_Status42 { get; set; }
        public double Buf_X43 { get; set; }
        public double Buf_Y43 { get; set; }
        public double Buf_Z43 { get; set; }
        public uint Buf_Status43 { get; set; }
        public double Buf_X44 { get; set; }
        public double Buf_Y44 { get; set; }
        public double Buf_Z44 { get; set; }
        public uint Buf_Status44 { get; set; }
        public double Buf_X45 { get; set; }
        public double Buf_Y45 { get; set; }
        public double Buf_Z45 { get; set; }
        public uint Buf_Status45 { get; set; }
        public double Buf_X46 { get; set; }
        public double Buf_Y46 { get; set; }
        public double Buf_Z46 { get; set; }
        public uint Buf_Status46 { get; set; }
        public double Buf_X47 { get; set; }
        public double Buf_Y47 { get; set; }
        public double Buf_Z47 { get; set; }
        public uint Buf_Status47 { get; set; }
        public double Buf_X48 { get; set; }
        public double Buf_Y48 { get; set; }
        public double Buf_Z48 { get; set; }
        public uint Buf_Status48 { get; set; }
        public double Buf_X49 { get; set; }
        public double Buf_Y49 { get; set; }
        public double Buf_Z49 { get; set; }
        public uint Buf_Status49 { get; set; }
        public double Buf_X50 { get; set; }
        public double Buf_Y50 { get; set; }
        public double Buf_Z50 { get; set; }
        public uint Buf_Status50 { get; set; }
        public double Buf_X51 { get; set; }
        public double Buf_Y51 { get; set; }
        public double Buf_Z51 { get; set; }
        public uint Buf_Status51 { get; set; }
        public double Buf_X52 { get; set; }
        public double Buf_Y52 { get; set; }
        public double Buf_Z52 { get; set; }
        public uint Buf_Status52 { get; set; }
        public double Buf_X53 { get; set; }
        public double Buf_Y53 { get; set; }
        public double Buf_Z53 { get; set; }
        public uint Buf_Status53 { get; set; }
        public double Buf_X54 { get; set; }
        public double Buf_Y54 { get; set; }
        public double Buf_Z54 { get; set; }
        public uint Buf_Status54 { get; set; }
        public double Buf_X55 { get; set; }
        public double Buf_Y55 { get; set; }
        public double Buf_Z55 { get; set; }
        public uint Buf_Status55 { get; set; }
        public double Buf_X56 { get; set; }
        public double Buf_Y56 { get; set; }
        public double Buf_Z56 { get; set; }
        public uint Buf_Status56 { get; set; }
        public double Buf_X57 { get; set; }
        public double Buf_Y57 { get; set; }
        public double Buf_Z57 { get; set; }
        public uint Buf_Status57 { get; set; }
        public double Buf_X58 { get; set; }
        public double Buf_Y58 { get; set; }
        public double Buf_Z58 { get; set; }
        public uint Buf_Status58 { get; set; }
        public double Buf_X59 { get; set; }
        public double Buf_Y59 { get; set; }
        public double Buf_Z59 { get; set; }
        public uint Buf_Status59 { get; set; }
        public double Buf_X60 { get; set; }
        public double Buf_Y60 { get; set; }
        public double Buf_Z60 { get; set; }
        public uint Buf_Status60 { get; set; }
        public double Buf_X61 { get; set; }
        public double Buf_Y61 { get; set; }
        public double Buf_Z61 { get; set; }
        public uint Buf_Status61 { get; set; }
        public double Buf_X62 { get; set; }
        public double Buf_Y62 { get; set; }
        public double Buf_Z62 { get; set; }
        public uint Buf_Status62 { get; set; }
        public double Buf_X63 { get; set; }
        public double Buf_Y63 { get; set; }
        public double Buf_Z63 { get; set; }
        public uint Buf_Status63 { get; set; }
        public double Buf_X64 { get; set; }
        public double Buf_Y64 { get; set; }
        public double Buf_Z64 { get; set; }
        public uint Buf_Status64 { get; set; }
        public double Buf_X65 { get; set; }
        public double Buf_Y65 { get; set; }
        public double Buf_Z65 { get; set; }
        public uint Buf_Status65 { get; set; }
        public double Buf_X66 { get; set; }
        public double Buf_Y66 { get; set; }
        public double Buf_Z66 { get; set; }
        public uint Buf_Status66 { get; set; }
        public double Buf_X67 { get; set; }
        public double Buf_Y67 { get; set; }
        public double Buf_Z67 { get; set; }
        public uint Buf_Status67 { get; set; }
        public double Buf_X68 { get; set; }
        public double Buf_Y68 { get; set; }
        public double Buf_Z68 { get; set; }
        public uint Buf_Status68 { get; set; }
        public double Buf_X69 { get; set; }
        public double Buf_Y69 { get; set; }
        public double Buf_Z69 { get; set; }
        public uint Buf_Status69 { get; set; }
        public double Buf_X70 { get; set; }
        public double Buf_Y70 { get; set; }
        public double Buf_Z70 { get; set; }
        public uint Buf_Status70 { get; set; }
        public double Buf_X71 { get; set; }
        public double Buf_Y71 { get; set; }
        public double Buf_Z71 { get; set; }
        public uint Buf_Status71 { get; set; }
        public double Buf_X72 { get; set; }
        public double Buf_Y72 { get; set; }
        public double Buf_Z72 { get; set; }
        public uint Buf_Status72 { get; set; }
        public double Buf_X73 { get; set; }
        public double Buf_Y73 { get; set; }
        public double Buf_Z73 { get; set; }
        public uint Buf_Status73 { get; set; }
        public double Buf_X74 { get; set; }
        public double Buf_Y74 { get; set; }
        public double Buf_Z74 { get; set; }
        public uint Buf_Status74 { get; set; }
        public double Buf_X75 { get; set; }
        public double Buf_Y75 { get; set; }
        public double Buf_Z75 { get; set; }
        public uint Buf_Status75 { get; set; }
        public double Buf_X76 { get; set; }
        public double Buf_Y76 { get; set; }
        public double Buf_Z76 { get; set; }
        public uint Buf_Status76 { get; set; }
        public double Buf_X77 { get; set; }
        public double Buf_Y77 { get; set; }
        public double Buf_Z77 { get; set; }
        public uint Buf_Status77 { get; set; }
        public double Buf_X78 { get; set; }
        public double Buf_Y78 { get; set; }
        public double Buf_Z78 { get; set; }
        public uint Buf_Status78 { get; set; }
        public double Buf_X79 { get; set; }
        public double Buf_Y79 { get; set; }
        public double Buf_Z79 { get; set; }
        public uint Buf_Status79 { get; set; }
        public double Buf_X80 { get; set; }
        public double Buf_Y80 { get; set; }
        public double Buf_Z80 { get; set; }
        public uint Buf_Status80 { get; set; }
        public double Buf_X81 { get; set; }
        public double Buf_Y81 { get; set; }
        public double Buf_Z81 { get; set; }
        public uint Buf_Status81 { get; set; }
        public double Buf_X82 { get; set; }
        public double Buf_Y82 { get; set; }
        public double Buf_Z82 { get; set; }
        public uint Buf_Status82 { get; set; }
        public double Buf_X83 { get; set; }
        public double Buf_Y83 { get; set; }
        public double Buf_Z83 { get; set; }
        public uint Buf_Status83 { get; set; }
        public double Buf_X84 { get; set; }
        public double Buf_Y84 { get; set; }
        public double Buf_Z84 { get; set; }
        public uint Buf_Status84 { get; set; }
        public double Buf_X85 { get; set; }
        public double Buf_Y85 { get; set; }
        public double Buf_Z85 { get; set; }
        public uint Buf_Status85 { get; set; }
        public double Buf_X86 { get; set; }
        public double Buf_Y86 { get; set; }
        public double Buf_Z86 { get; set; }
        public uint Buf_Status86 { get; set; }
        public double Buf_X87 { get; set; }
        public double Buf_Y87 { get; set; }
        public double Buf_Z87 { get; set; }
        public uint Buf_Status87 { get; set; }
        public double Buf_X88 { get; set; }
        public double Buf_Y88 { get; set; }
        public double Buf_Z88 { get; set; }
        public uint Buf_Status88 { get; set; }
        public double Buf_X89 { get; set; }
        public double Buf_Y89 { get; set; }
        public double Buf_Z89 { get; set; }
        public uint Buf_Status89 { get; set; }
        public double Buf_X90 { get; set; }
        public double Buf_Y90 { get; set; }
        public double Buf_Z90 { get; set; }
        public uint Buf_Status90 { get; set; }
        public double Buf_X91 { get; set; }
        public double Buf_Y91 { get; set; }
        public double Buf_Z91 { get; set; }
        public uint Buf_Status91 { get; set; }
        public double Buf_X92 { get; set; }
        public double Buf_Y92 { get; set; }
        public double Buf_Z92 { get; set; }
        public uint Buf_Status92 { get; set; }
        public double Buf_X93 { get; set; }
        public double Buf_Y93 { get; set; }
        public double Buf_Z93 { get; set; }
        public uint Buf_Status93 { get; set; }
        public double Buf_X94 { get; set; }
        public double Buf_Y94 { get; set; }
        public double Buf_Z94 { get; set; }
        public uint Buf_Status94 { get; set; }
        public double Buf_X95 { get; set; }
        public double Buf_Y95 { get; set; }
        public double Buf_Z95 { get; set; }
        public uint Buf_Status95 { get; set; }
        public double Buf_X96 { get; set; }
        public double Buf_Y96 { get; set; }
        public double Buf_Z96 { get; set; }
        public uint Buf_Status96 { get; set; }
        public double Buf_X97 { get; set; }
        public double Buf_Y97 { get; set; }
        public double Buf_Z97 { get; set; }
        public uint Buf_Status97 { get; set; }
        public double Buf_X98 { get; set; }
        public double Buf_Y98 { get; set; }
        public double Buf_Z98 { get; set; }
        public uint Buf_Status98 { get; set; }
        public double Buf_X99 { get; set; }
        public double Buf_Y99 { get; set; }
        public double Buf_Z99 { get; set; }
        public uint Buf_Status99 { get; set; }

        public int Step_Target { get; set; }
        public int Step_Process_Target { get; set; }
        public bool M1_Req { get; set; }
    }
    public class Mode_1
    {
        public static double ExtractNumber(string input)
        {
            // Lấy các kí tự số và dấu chấm từ chuỗi
            string numberString = new string(input.Where(c => char.IsDigit(c) || c == '.').ToArray());

            // Thử chuyển đổi sang double
            if (double.TryParse(numberString, out double result))
            {
                // Kiểm tra xem có dấu trừ hay không
                if (input.Contains('-'))
                {
                    result = -result; // Nếu có, đảo ngược dấu
                }
                return result;
            }
            return 0.0;
        }
        public static string Parse_Data_(ListBox programListBox, int elementsget, int step)
        {
            MyData data = new MyData
            {
                Step_Target = programListBox.Items.Count,
                Step_Process_Target = step - 1,
                M1_Req = false
            };

            var elementsToProcess = programListBox.Items.Cast<object>().Skip((step - 1) * elementsget).Take(elementsget).ToList();

            for (int i = 0; i < Math.Min(elementsToProcess.Count, 71); i++)
            {
                string line = elementsToProcess[i].ToString();
                string[] words = line.Split(' ');

                double bufX = Mode_1.ExtractNumber(words[2]);
                double bufY = Mode_1.ExtractNumber(words[3]);
                double bufZ = Mode_1.ExtractNumber(words[4]);
                uint Buf_Status = 0;

                // Set the properties based on the counter
                typeof(MyData).GetProperty($"Buf_X{i}")?.SetValue(data, bufX);
                typeof(MyData).GetProperty($"Buf_Y{i}")?.SetValue(data, bufY);
                typeof(MyData).GetProperty($"Buf_Z{i}")?.SetValue(data, bufZ);
                typeof(MyData).GetProperty($"Buf_Status{i}")?.SetValue(data, Buf_Status);
            }

            return JsonConvert.SerializeObject(data);
        }

        public static string Parse_Data(ListBox programListBox, int elementsget, int step)
        {
            MyData data = new MyData
            {
                Buf_X0 = 0f,
                Buf_Y0 = 0f,
                Buf_Z0 = 0f,
                Buf_Status0 = 0,
                Buf_X1 = 0f,
                Buf_Y1 = 0f,
                Buf_Z1 = 0f,
                Buf_Status1 = 0,
                Buf_X2 = 0f,
                Buf_Y2 = 0f,
                Buf_Z2 = 0f,
                Buf_Status2 = 0,
                Buf_X3 = 0f,
                Buf_Y3 = 0f,
                Buf_Z3 = 0f,
                Buf_Status3 = 0,
                Buf_X4 = 0f,
                Buf_Y4 = 0f,
                Buf_Z4 = 0f,
                Buf_Status4 = 0,
                Buf_X5 = 0f,
                Buf_Y5 = 0f,
                Buf_Z5 = 0f,
                Buf_Status5 = 0,
                Buf_X6 = 0f,
                Buf_Y6 = 0f,
                Buf_Z6 = 0f,
                Buf_Status6 = 0,
                Buf_X7 = 0f,
                Buf_Y7 = 0f,
                Buf_Z7 = 0f,
                Buf_Status7 = 0,
                Buf_X8 = 0f,
                Buf_Y8 = 0f,
                Buf_Z8 = 0f,
                Buf_Status8 = 0,
                Buf_X9 = 0f,
                Buf_Y9 = 0f,
                Buf_Z9 = 0f,
                Buf_Status9 = 0,
                Buf_X10 = 0f,
                Buf_Y10 = 0f,
                Buf_Z10 = 0f,
                Buf_Status10 = 0,
                Buf_X11 = 0f,
                Buf_Y11 = 0f,
                Buf_Z11 = 0f,
                Buf_Status11 = 0,
                Buf_X12 = 0f,
                Buf_Y12 = 0f,
                Buf_Z12 = 0f,
                Buf_Status12 = 0,
                Buf_X13 = 0f,
                Buf_Y13 = 0f,
                Buf_Z13 = 0f,
                Buf_Status13 = 0,
                Buf_X14 = 0f,
                Buf_Y14 = 0f,
                Buf_Z14 = 0f,
                Buf_Status14 = 0,
                Buf_X15 = 0f,
                Buf_Y15 = 0f,
                Buf_Z15 = 0f,
                Buf_Status15 = 0,
                Buf_X16 = 0f,
                Buf_Y16 = 0f,
                Buf_Z16 = 0f,
                Buf_Status16 = 0,
                Buf_X17 = 0f,
                Buf_Y17 = 0f,
                Buf_Z17 = 0f,
                Buf_Status17 = 0,
                Buf_X18 = 0f,
                Buf_Y18 = 0f,
                Buf_Z18 = 0f,
                Buf_Status18 = 0,
                Buf_X19 = 0f,
                Buf_Y19 = 0f,
                Buf_Z19 = 0f,
                Buf_Status19 = 0,
                Buf_X20 = 0f,
                Buf_Y20 = 0f,
                Buf_Z20 = 0f,
                Buf_Status20 = 0,
                Buf_X21 = 0f,
                Buf_Y21 = 0f,
                Buf_Z21 = 0f,
                Buf_Status21 = 0,
                Buf_X22 = 0f,
                Buf_Y22 = 0f,
                Buf_Z22 = 0f,
                Buf_Status22 = 0,
                Buf_X23 = 0f,
                Buf_Y23 = 0f,
                Buf_Z23 = 0f,
                Buf_Status23 = 0,
                Buf_X24 = 0f,
                Buf_Y24 = 0f,
                Buf_Z24 = 0f,
                Buf_Status24 = 0,
                Buf_X25 = 0f,
                Buf_Y25 = 0f,
                Buf_Z25 = 0f,
                Buf_Status25 = 0,
                Buf_X26 = 0f,
                Buf_Y26 = 0f,
                Buf_Z26 = 0f,
                Buf_Status26 = 0,
                Buf_X27 = 0f,
                Buf_Y27 = 0f,
                Buf_Z27 = 0f,
                Buf_Status27 = 0,
                Buf_X28 = 0f,
                Buf_Y28 = 0f,
                Buf_Z28 = 0f,
                Buf_Status28 = 0,
                Buf_X29 = 0f,
                Buf_Y29 = 0f,
                Buf_Z29 = 0f,
                Buf_Status29 = 0,
                Buf_X30 = 0f,
                Buf_Y30 = 0f,
                Buf_Z30 = 0f,
                Buf_Status30 = 0,
                Buf_X31 = 0f,
                Buf_Y31 = 0f,
                Buf_Z31 = 0f,
                Buf_Status31 = 0,
                Buf_X32 = 0f,
                Buf_Y32 = 0f,
                Buf_Z32 = 0f,
                Buf_Status32 = 0,
                Buf_X33 = 0f,
                Buf_Y33 = 0f,
                Buf_Z33 = 0f,
                Buf_Status33 = 0,
                Buf_X34 = 0f,
                Buf_Y34 = 0f,
                Buf_Z34 = 0f,
                Buf_Status34 = 0,
                Buf_X35 = 0f,
                Buf_Y35 = 0f,
                Buf_Z35 = 0f,
                Buf_Status35 = 0,
                Buf_X36 = 0f,
                Buf_Y36 = 0f,
                Buf_Z36 = 0f,
                Buf_Status36 = 0,
                Buf_X37 = 0f,
                Buf_Y37 = 0f,
                Buf_Z37 = 0f,
                Buf_Status37 = 0,
                Buf_X38 = 0f,
                Buf_Y38 = 0f,
                Buf_Z38 = 0f,
                Buf_Status38 = 0,
                Buf_X39 = 0f,
                Buf_Y39 = 0f,
                Buf_Z39 = 0f,
                Buf_Status39 = 0,
                Buf_X40 = 0f,
                Buf_Y40 = 0f,
                Buf_Z40 = 0f,
                Buf_Status40 = 0,
                Buf_X41 = 0f,
                Buf_Y41 = 0f,
                Buf_Z41 = 0f,
                Buf_Status41 = 0,
                Buf_X42 = 0f,
                Buf_Y42 = 0f,
                Buf_Z42 = 0f,
                Buf_Status42 = 0,
                Buf_X43 = 0f,
                Buf_Y43 = 0f,
                Buf_Z43 = 0f,
                Buf_Status43 = 0,
                Buf_X44 = 0f,
                Buf_Y44 = 0f,
                Buf_Z44 = 0f,
                Buf_Status44 = 0,
                Buf_X45 = 0f,
                Buf_Y45 = 0f,
                Buf_Z45 = 0f,
                Buf_Status45 = 0,
                Buf_X46 = 0f,
                Buf_Y46 = 0f,
                Buf_Z46 = 0f,
                Buf_Status46 = 0,
                Buf_X47 = 0f,
                Buf_Y47 = 0f,
                Buf_Z47 = 0f,
                Buf_Status47 = 0,
                Buf_X48 = 0f,
                Buf_Y48 = 0f,
                Buf_Z48 = 0f,
                Buf_Status48 = 0,
                Buf_X49 = 0f,
                Buf_Y49 = 0f,
                Buf_Z49 = 0f,
                Buf_Status49 = 0,
                Buf_X50 = 0f,
                Buf_Y50 = 0f,
                Buf_Z50 = 0f,
                Buf_Status50 = 0,
                Buf_X51 = 0f,
                Buf_Y51 = 0f,
                Buf_Z51 = 0f,
                Buf_Status51 = 0,
                Buf_X52 = 0f,
                Buf_Y52 = 0f,
                Buf_Z52 = 0f,
                Buf_Status52 = 0,
                Buf_X53 = 0f,
                Buf_Y53 = 0f,
                Buf_Z53 = 0f,
                Buf_Status53 = 0,
                Buf_X54 = 0f,
                Buf_Y54 = 0f,
                Buf_Z54 = 0f,
                Buf_Status54 = 0,
                Buf_X55 = 0f,
                Buf_Y55 = 0f,
                Buf_Z55 = 0f,
                Buf_Status55 = 0,
                Buf_X56 = 0f,
                Buf_Y56 = 0f,
                Buf_Z56 = 0f,
                Buf_Status56 = 0,
                Buf_X57 = 0f,
                Buf_Y57 = 0f,
                Buf_Z57 = 0f,
                Buf_Status57 = 0,
                Buf_X58 = 0f,
                Buf_Y58 = 0f,
                Buf_Z58 = 0f,
                Buf_Status58 = 0,
                Buf_X59 = 0f,
                Buf_Y59 = 0f,
                Buf_Z59 = 0f,
                Buf_Status59 = 0,
                Buf_X60 = 0f,
                Buf_Y60 = 0f,
                Buf_Z60 = 0f,
                Buf_Status60 = 0,
                Buf_X61 = 0f,
                Buf_Y61 = 0f,
                Buf_Z61 = 0f,
                Buf_Status61 = 0,
                Buf_X62 = 0f,
                Buf_Y62 = 0f,
                Buf_Z62 = 0f,
                Buf_Status62 = 0,
                Buf_X63 = 0f,
                Buf_Y63 = 0f,
                Buf_Z63 = 0f,
                Buf_Status63 = 0,
                Buf_X64 = 0f,
                Buf_Y64 = 0f,
                Buf_Z64 = 0f,
                Buf_Status64 = 0,
                Buf_X65 = 0f,
                Buf_Y65 = 0f,
                Buf_Z65 = 0f,
                Buf_Status65 = 0,
                Buf_X66 = 0f,
                Buf_Y66 = 0f,
                Buf_Z66 = 0f,
                Buf_Status66 = 0,
                Buf_X67 = 0f,
                Buf_Y67 = 0f,
                Buf_Z67 = 0f,
                Buf_Status67 = 0,
                Buf_X68 = 0f,
                Buf_Y68 = 0f,
                Buf_Z68 = 0f,
                Buf_Status68 = 0,
                Buf_X69 = 0f,
                Buf_Y69 = 0f,
                Buf_Z69 = 0f,
                Buf_Status69 = 0,
                Buf_X70 = 0f,
                Buf_Y70 = 0f,
                Buf_Z70 = 0f,
                Buf_Status70 = 0,
                Buf_X71 = 0f,
                Buf_Y71 = 0f,
                Buf_Z71 = 0f,
                Buf_Status71 = 0,
                Buf_X72 = 0f,
                Buf_Y72 = 0f,
                Buf_Z72 = 0f,
                Buf_Status72 = 0,
                Buf_X73 = 0f,
                Buf_Y73 = 0f,
                Buf_Z73 = 0f,
                Buf_Status73 = 0,
                Buf_X74 = 0f,
                Buf_Y74 = 0f,
                Buf_Z74 = 0f,
                Buf_Status74 = 0,
                Buf_X75 = 0f,
                Buf_Y75 = 0f,
                Buf_Z75 = 0f,
                Buf_Status75 = 0,
                Buf_X76 = 0f,
                Buf_Y76 = 0f,
                Buf_Z76 = 0f,
                Buf_Status76 = 0,
                Buf_X77 = 0f,
                Buf_Y77 = 0f,
                Buf_Z77 = 0f,
                Buf_Status77 = 0,
                Buf_X78 = 0f,
                Buf_Y78 = 0f,
                Buf_Z78 = 0f,
                Buf_Status78 = 0,
                Buf_X79 = 0f,
                Buf_Y79 = 0f,
                Buf_Z79 = 0f,
                Buf_Status79 = 0,
                Buf_X80 = 0f,
                Buf_Y80 = 0f,
                Buf_Z80 = 0f,
                Buf_Status80 = 0,
                Buf_X81 = 0f,
                Buf_Y81 = 0f,
                Buf_Z81 = 0f,
                Buf_Status81 = 0,
                Buf_X82 = 0f,
                Buf_Y82 = 0f,
                Buf_Z82 = 0f,
                Buf_Status82 = 0,
                Buf_X83 = 0f,
                Buf_Y83 = 0f,
                Buf_Z83 = 0f,
                Buf_Status83 = 0,
                Buf_X84 = 0f,
                Buf_Y84 = 0f,
                Buf_Z84 = 0f,
                Buf_Status84 = 0,
                Buf_X85 = 0f,
                Buf_Y85 = 0f,
                Buf_Z85 = 0f,
                Buf_Status85 = 0,
                Buf_X86 = 0f,
                Buf_Y86 = 0f,
                Buf_Z86 = 0f,
                Buf_Status86 = 0,
                Buf_X87 = 0f,
                Buf_Y87 = 0f,
                Buf_Z87 = 0f,
                Buf_Status87 = 0,
                Buf_X88 = 0f,
                Buf_Y88 = 0f,
                Buf_Z88 = 0f,
                Buf_Status88 = 0,
                Buf_X89 = 0f,
                Buf_Y89 = 0f,
                Buf_Z89 = 0f,
                Buf_Status89 = 0,
                Buf_X90 = 0f,
                Buf_Y90 = 0f,
                Buf_Z90 = 0f,
                Buf_Status90 = 0,
                Buf_X91 = 0f,
                Buf_Y91 = 0f,
                Buf_Z91 = 0f,
                Buf_Status91 = 0,
                Buf_X92 = 0f,
                Buf_Y92 = 0f,
                Buf_Z92 = 0f,
                Buf_Status92 = 0,
                Buf_X93 = 0f,
                Buf_Y93 = 0f,
                Buf_Z93 = 0f,
                Buf_Status93 = 0,
                Buf_X94 = 0f,
                Buf_Y94 = 0f,
                Buf_Z94 = 0f,
                Buf_Status94 = 0,
                Buf_X95 = 0f,
                Buf_Y95 = 0f,
                Buf_Z95 = 0f,
                Buf_Status95 = 0,
                Buf_X96 = 0f,
                Buf_Y96 = 0f,
                Buf_Z96 = 0f,
                Buf_Status96 = 0,
                Buf_X97 = 0f,
                Buf_Y97 = 0f,
                Buf_Z97 = 0f,
                Buf_Status97 = 0,
                Buf_X98 = 0f,
                Buf_Y98 = 0f,
                Buf_Z98 = 0f,
                Buf_Status98 = 0,
                Buf_X99 = 0f,
                Buf_Y99 = 0f,
                Buf_Z99 = 0f,
                Buf_Status99 = 0,

                Step_Target = programListBox.Items.Count,
                Step_Process_Target = step - 1,
                M1_Req = false,
            };
            var elementsToProcess = programListBox.Items.Cast<object>().Skip((step - 1) * elementsget).Take(elementsget).ToList();
            for (int i = 0; i < elementsToProcess.Count; i++)
            {

                string line = elementsToProcess[i].ToString();
                int xIndex = line.IndexOf('X');
                int yIndex = line.IndexOf('Y');
                int zIndex = line.IndexOf('Z');

                // Kiểm tra xem có X, Y, Z không
                    double xValue, yValue, zValue;

                    double.TryParse(line.Substring(xIndex + 1, yIndex - xIndex - 1), out xValue);
                    double.TryParse(line.Substring(yIndex + 1, zIndex - yIndex - 1), out yValue);
                    double.TryParse(line.Substring(zIndex + 1), out zValue);

                    double bufX = xValue;
                    double bufY = yValue;
                    double bufZ = zValue;
                    uint Buf_Status = 0;
                   //MessageBox.Show(bufX.ToString() + " " +bufY.ToString() + " " + bufZ.ToString());

                    // Set the properties based on the counter
                    switch (i)
                    {
                        case 0:
                            data.Buf_X0 = bufX;
                            data.Buf_Y0 = bufY;
                            data.Buf_Z0 = bufZ;
                            data.Buf_Status0 = Buf_Status;
                            break;
                        case 1:
                            data.Buf_X1 = bufX;
                            data.Buf_Y1 = bufY;
                            data.Buf_Z1 = bufZ;
                            data.Buf_Status1 = Buf_Status;
                            break;
                        case 2:
                            data.Buf_X2 = bufX;
                            data.Buf_Y2 = bufY;
                            data.Buf_Z2 = bufZ;
                            data.Buf_Status2 = Buf_Status;
                            break;
                        case 3:
                            data.Buf_X3 = bufX;
                            data.Buf_Y3 = bufY;
                            data.Buf_Z3 = bufZ;
                            data.Buf_Status3 = Buf_Status;
                            break;
                        case 4:
                            data.Buf_X4 = bufX;
                            data.Buf_Y4 = bufY;
                            data.Buf_Z4 = bufZ;
                            data.Buf_Status4 = Buf_Status;
                            break;
                        case 5:
                            data.Buf_X5 = bufX;
                            data.Buf_Y5 = bufY;
                            data.Buf_Z5 = bufZ;
                            data.Buf_Status5 = Buf_Status;
                            break;
                        case 6:
                            data.Buf_X6 = bufX;
                            data.Buf_Y6 = bufY;
                            data.Buf_Z6 = bufZ;
                            data.Buf_Status6 = Buf_Status;
                            break;
                        case 7:
                            data.Buf_X7 = bufX;
                            data.Buf_Y7 = bufY;
                            data.Buf_Z7 = bufZ;
                            data.Buf_Status7 = Buf_Status;
                            break;
                        case 8:
                            data.Buf_X8 = bufX;
                            data.Buf_Y8 = bufY;
                            data.Buf_Z8 = bufZ;
                            data.Buf_Status8 = Buf_Status;
                            break;
                        case 9:
                            data.Buf_X9 = bufX;
                            data.Buf_Y9 = bufY;
                            data.Buf_Z9 = bufZ;
                            data.Buf_Status9 = Buf_Status;
                            break;
                        case 10:
                            data.Buf_X10 = bufX;
                            data.Buf_Y10 = bufY;
                            data.Buf_Z10 = bufZ;
                            data.Buf_Status10 = Buf_Status;
                            break;
                        case 11:
                            data.Buf_X11 = bufX;
                            data.Buf_Y11 = bufY;
                            data.Buf_Z11 = bufZ;
                            data.Buf_Status11 = Buf_Status;
                            break;
                        case 12:
                            data.Buf_X12 = bufX;
                            data.Buf_Y12 = bufY;
                            data.Buf_Z12 = bufZ;
                            data.Buf_Status12 = Buf_Status;
                            break;
                        case 13:
                            data.Buf_X13 = bufX;
                            data.Buf_Y13 = bufY;
                            data.Buf_Z13 = bufZ;
                            data.Buf_Status13 = Buf_Status;
                            break;
                        case 14:
                            data.Buf_X14 = bufX;
                            data.Buf_Y14 = bufY;
                            data.Buf_Z14 = bufZ;
                            data.Buf_Status14 = Buf_Status;
                            break;
                        case 15:
                            data.Buf_X15 = bufX;
                            data.Buf_Y15 = bufY;
                            data.Buf_Z15 = bufZ;
                            data.Buf_Status15 = Buf_Status;
                            break;
                        case 16:
                            data.Buf_X16 = bufX;
                            data.Buf_Y16 = bufY;
                            data.Buf_Z16 = bufZ;
                            data.Buf_Status16 = Buf_Status;
                            break;
                        case 17:
                            data.Buf_X17 = bufX;
                            data.Buf_Y17 = bufY;
                            data.Buf_Z17 = bufZ;
                            data.Buf_Status17 = Buf_Status;
                            break;
                        case 18:
                            data.Buf_X18 = bufX;
                            data.Buf_Y18 = bufY;
                            data.Buf_Z18 = bufZ;
                            data.Buf_Status18 = Buf_Status;
                            break;
                        case 19:
                            data.Buf_X19 = bufX;
                            data.Buf_Y19 = bufY;
                            data.Buf_Z19 = bufZ;
                            data.Buf_Status19 = Buf_Status;
                            break;
                        case 20:
                            data.Buf_X20 = bufX;
                            data.Buf_Y20 = bufY;
                            data.Buf_Z20 = bufZ;
                            data.Buf_Status20 = Buf_Status;
                            break;
                        case 21:
                            data.Buf_X21 = bufX;
                            data.Buf_Y21 = bufY;
                            data.Buf_Z21 = bufZ;
                            data.Buf_Status21 = Buf_Status;
                            break;
                        case 22:
                            data.Buf_X22 = bufX;
                            data.Buf_Y22 = bufY;
                            data.Buf_Z22 = bufZ;
                            data.Buf_Status22 = Buf_Status;
                            break;
                        case 23:
                            data.Buf_X23 = bufX;
                            data.Buf_Y23 = bufY;
                            data.Buf_Z23 = bufZ;
                            data.Buf_Status23 = Buf_Status;
                            break;
                        case 24:
                            data.Buf_X24 = bufX;
                            data.Buf_Y24 = bufY;
                            data.Buf_Z24 = bufZ;
                            data.Buf_Status24 = Buf_Status;
                            break;
                        case 25:
                            data.Buf_X25 = bufX;
                            data.Buf_Y25 = bufY;
                            data.Buf_Z25 = bufZ;
                            data.Buf_Status25 = Buf_Status;
                            break;
                        case 26:
                            data.Buf_X26 = bufX;
                            data.Buf_Y26 = bufY;
                            data.Buf_Z26 = bufZ;
                            data.Buf_Status26 = Buf_Status;
                            break;
                        case 27:
                            data.Buf_X27 = bufX;
                            data.Buf_Y27 = bufY;
                            data.Buf_Z27 = bufZ;
                            data.Buf_Status27 = Buf_Status;
                            break;
                        case 28:
                            data.Buf_X28 = bufX;
                            data.Buf_Y28 = bufY;
                            data.Buf_Z28 = bufZ;
                            data.Buf_Status28 = Buf_Status;
                            break;
                        case 29:
                            data.Buf_X29 = bufX;
                            data.Buf_Y29 = bufY;
                            data.Buf_Z29 = bufZ;
                            data.Buf_Status29 = Buf_Status;
                            break;
                        case 30:
                            data.Buf_X30 = bufX;
                            data.Buf_Y30 = bufY;
                            data.Buf_Z30 = bufZ;
                            data.Buf_Status30 = Buf_Status;
                            break;
                        case 31:
                            data.Buf_X31 = bufX;
                            data.Buf_Y31 = bufY;
                            data.Buf_Z31 = bufZ;
                            data.Buf_Status31 = Buf_Status;
                            break;
                        case 32:
                            data.Buf_X32 = bufX;
                            data.Buf_Y32 = bufY;
                            data.Buf_Z32 = bufZ;
                            data.Buf_Status32 = Buf_Status;
                            break;
                        case 33:
                            data.Buf_X33 = bufX;
                            data.Buf_Y33 = bufY;
                            data.Buf_Z33 = bufZ;
                            data.Buf_Status33 = Buf_Status;
                            break;
                        case 34:
                            data.Buf_X34 = bufX;
                            data.Buf_Y34 = bufY;
                            data.Buf_Z34 = bufZ;
                            data.Buf_Status34 = Buf_Status;
                            break;
                        case 35:
                            data.Buf_X35 = bufX;
                            data.Buf_Y35 = bufY;
                            data.Buf_Z35 = bufZ;
                            data.Buf_Status35 = Buf_Status;
                            break;
                        case 36:
                            data.Buf_X36 = bufX;
                            data.Buf_Y36 = bufY;
                            data.Buf_Z36 = bufZ;
                            data.Buf_Status36 = Buf_Status;
                            break;
                        case 37:
                            data.Buf_X37 = bufX;
                            data.Buf_Y37 = bufY;
                            data.Buf_Z37 = bufZ;
                            data.Buf_Status37 = Buf_Status;
                            break;
                        case 38:
                            data.Buf_X38 = bufX;
                            data.Buf_Y38 = bufY;
                            data.Buf_Z38 = bufZ;
                            data.Buf_Status38 = Buf_Status;
                            break;
                        case 39:
                            data.Buf_X39 = bufX;
                            data.Buf_Y39 = bufY;
                            data.Buf_Z39 = bufZ;
                            data.Buf_Status39 = Buf_Status;
                            break;
                        case 40:
                            data.Buf_X40 = bufX;
                            data.Buf_Y40 = bufY;
                            data.Buf_Z40 = bufZ;
                            data.Buf_Status40 = Buf_Status;
                            break;
                        case 41:
                            data.Buf_X41 = bufX;
                            data.Buf_Y41 = bufY;
                            data.Buf_Z41 = bufZ;
                            data.Buf_Status41 = Buf_Status;
                            break;
                        case 42:
                            data.Buf_X42 = bufX;
                            data.Buf_Y42 = bufY;
                            data.Buf_Z42 = bufZ;
                            data.Buf_Status42 = Buf_Status;
                            break;
                        case 43:
                            data.Buf_X43 = bufX;
                            data.Buf_Y43 = bufY;
                            data.Buf_Z43 = bufZ;
                            data.Buf_Status43 = Buf_Status;
                            break;
                        case 44:
                            data.Buf_X44 = bufX;
                            data.Buf_Y44 = bufY;
                            data.Buf_Z44 = bufZ;
                            data.Buf_Status44 = Buf_Status;
                            break;
                        case 45:
                            data.Buf_X45 = bufX;
                            data.Buf_Y45 = bufY;
                            data.Buf_Z45 = bufZ;
                            data.Buf_Status45 = Buf_Status;
                            break;
                        case 46:
                            data.Buf_X46 = bufX;
                            data.Buf_Y46 = bufY;
                            data.Buf_Z46 = bufZ;
                            data.Buf_Status46 = Buf_Status;
                            break;
                        case 47:
                            data.Buf_X47 = bufX;
                            data.Buf_Y47 = bufY;
                            data.Buf_Z47 = bufZ;
                            data.Buf_Status47 = Buf_Status;
                            break;
                        case 48:
                            data.Buf_X48 = bufX;
                            data.Buf_Y48 = bufY;
                            data.Buf_Z48 = bufZ;
                            data.Buf_Status48 = Buf_Status;
                            break;
                        case 49:
                            data.Buf_X49 = bufX;
                            data.Buf_Y49 = bufY;
                            data.Buf_Z49 = bufZ;
                            data.Buf_Status49 = Buf_Status;
                            break;
                        case 50:
                            data.Buf_X50 = bufX;
                            data.Buf_Y50 = bufY;
                            data.Buf_Z50 = bufZ;
                            data.Buf_Status50 = Buf_Status;
                            break;
                        case 51:
                            data.Buf_X51 = bufX;
                            data.Buf_Y51 = bufY;
                            data.Buf_Z51 = bufZ;
                            data.Buf_Status51 = Buf_Status;
                            break;
                        case 52:
                            data.Buf_X52 = bufX;
                            data.Buf_Y52 = bufY;
                            data.Buf_Z52 = bufZ;
                            data.Buf_Status52 = Buf_Status;
                            break;
                        case 53:
                            data.Buf_X53 = bufX;
                            data.Buf_Y53 = bufY;
                            data.Buf_Z53 = bufZ;
                            data.Buf_Status53 = Buf_Status;
                            break;
                        case 54:
                            data.Buf_X54 = bufX;
                            data.Buf_Y54 = bufY;
                            data.Buf_Z54 = bufZ;
                            data.Buf_Status54 = Buf_Status;
                            break;
                        case 55:
                            data.Buf_X55 = bufX;
                            data.Buf_Y55 = bufY;
                            data.Buf_Z55 = bufZ;
                            data.Buf_Status55 = Buf_Status;
                            break;
                        case 56:
                            data.Buf_X56 = bufX;
                            data.Buf_Y56 = bufY;
                            data.Buf_Z56 = bufZ;
                            data.Buf_Status56 = Buf_Status;
                            break;
                        case 57:
                            data.Buf_X57 = bufX;
                            data.Buf_Y57 = bufY;
                            data.Buf_Z57 = bufZ;
                            data.Buf_Status57 = Buf_Status;
                            break;
                        case 58:
                            data.Buf_X58 = bufX;
                            data.Buf_Y58 = bufY;
                            data.Buf_Z58 = bufZ;
                            data.Buf_Status58 = Buf_Status;
                            break;
                        case 59:
                            data.Buf_X59 = bufX;
                            data.Buf_Y59 = bufY;
                            data.Buf_Z59 = bufZ;
                            data.Buf_Status59 = Buf_Status;
                            break;
                        case 60:
                            data.Buf_X60 = bufX;
                            data.Buf_Y60 = bufY;
                            data.Buf_Z60 = bufZ;
                            data.Buf_Status60 = Buf_Status;
                            break;
                        case 61:
                            data.Buf_X61 = bufX;
                            data.Buf_Y61 = bufY;
                            data.Buf_Z61 = bufZ;
                            data.Buf_Status61 = Buf_Status;
                            break;
                        case 62:
                            data.Buf_X62 = bufX;
                            data.Buf_Y62 = bufY;
                            data.Buf_Z62 = bufZ;
                            data.Buf_Status62 = Buf_Status;
                            break;
                        case 63:
                            data.Buf_X63 = bufX;
                            data.Buf_Y63 = bufY;
                            data.Buf_Z63 = bufZ;
                            data.Buf_Status63 = Buf_Status;
                            break;
                        case 64:
                            data.Buf_X64 = bufX;
                            data.Buf_Y64 = bufY;
                            data.Buf_Z64 = bufZ;
                            data.Buf_Status64 = Buf_Status;
                            break;
                        case 65:
                            data.Buf_X65 = bufX;
                            data.Buf_Y65 = bufY;
                            data.Buf_Z65 = bufZ;
                            data.Buf_Status65 = Buf_Status;
                            break;
                        case 66:
                            data.Buf_X66 = bufX;
                            data.Buf_Y66 = bufY;
                            data.Buf_Z66 = bufZ;
                            data.Buf_Status66 = Buf_Status;
                            break;
                        case 67:
                            data.Buf_X67 = bufX;
                            data.Buf_Y67 = bufY;
                            data.Buf_Z67 = bufZ;
                            data.Buf_Status67 = Buf_Status;
                            break;
                        case 68:
                            data.Buf_X68 = bufX;
                            data.Buf_Y68 = bufY;
                            data.Buf_Z68 = bufZ;
                            data.Buf_Status68 = Buf_Status;
                            break;
                        case 69:
                            data.Buf_X69 = bufX;
                            data.Buf_Y69 = bufY;
                            data.Buf_Z69 = bufZ;
                            data.Buf_Status69 = Buf_Status;
                            break;
                        case 70:
                            data.Buf_X70 = bufX;
                            data.Buf_Y70 = bufY;
                            data.Buf_Z70 = bufZ;
                            data.Buf_Status70 = Buf_Status;
                            break;
                        case 71:
                            data.Buf_X71 = bufX;
                            data.Buf_Y71 = bufY;
                            data.Buf_Z71 = bufZ;
                            data.Buf_Status71 = Buf_Status;
                            break;
                        case 72:
                            data.Buf_X72 = bufX;
                            data.Buf_Y72 = bufY;
                            data.Buf_Z72 = bufZ;
                            data.Buf_Status72 = Buf_Status;
                            break;
                        case 73:
                            data.Buf_X73 = bufX;
                            data.Buf_Y73 = bufY;
                            data.Buf_Z73 = bufZ;
                            data.Buf_Status73 = Buf_Status;
                            break;
                        case 74:
                            data.Buf_X74 = bufX;
                            data.Buf_Y74 = bufY;
                            data.Buf_Z74 = bufZ;
                            data.Buf_Status74 = Buf_Status;
                            break;
                        case 75:
                            data.Buf_X75 = bufX;
                            data.Buf_Y75 = bufY;
                            data.Buf_Z75 = bufZ;
                            data.Buf_Status75 = Buf_Status;
                            break;
                        case 76:
                            data.Buf_X76 = bufX;
                            data.Buf_Y76 = bufY;
                            data.Buf_Z76 = bufZ;
                            data.Buf_Status76 = Buf_Status;
                            break;
                        case 77:
                            data.Buf_X77 = bufX;
                            data.Buf_Y77 = bufY;
                            data.Buf_Z77 = bufZ;
                            data.Buf_Status77 = Buf_Status;
                            break;
                        case 78:
                            data.Buf_X78 = bufX;
                            data.Buf_Y78 = bufY;
                            data.Buf_Z78 = bufZ;
                            data.Buf_Status78 = Buf_Status;
                            break;
                        case 79:
                            data.Buf_X79 = bufX;
                            data.Buf_Y79 = bufY;
                            data.Buf_Z79 = bufZ;
                            data.Buf_Status79 = Buf_Status;
                            break;
                        case 80:
                            data.Buf_X80 = bufX;
                            data.Buf_Y80 = bufY;
                            data.Buf_Z80 = bufZ;
                            data.Buf_Status80 = Buf_Status;
                            break;
                        case 81:
                            data.Buf_X81 = bufX;
                            data.Buf_Y81 = bufY;
                            data.Buf_Z81 = bufZ;
                            data.Buf_Status81 = Buf_Status;
                            break;
                        case 82:
                            data.Buf_X82 = bufX;
                            data.Buf_Y82 = bufY;
                            data.Buf_Z82 = bufZ;
                            data.Buf_Status82 = Buf_Status;
                            break;
                        case 83:
                            data.Buf_X83 = bufX;
                            data.Buf_Y83 = bufY;
                            data.Buf_Z83 = bufZ;
                            data.Buf_Status83 = Buf_Status;
                            break;
                        case 84:
                            data.Buf_X84 = bufX;
                            data.Buf_Y84 = bufY;
                            data.Buf_Z84 = bufZ;
                            data.Buf_Status84 = Buf_Status;
                            break;
                        case 85:
                            data.Buf_X85 = bufX;
                            data.Buf_Y85 = bufY;
                            data.Buf_Z85 = bufZ;
                            data.Buf_Status85 = Buf_Status;
                            break;
                        case 86:
                            data.Buf_X86 = bufX;
                            data.Buf_Y86 = bufY;
                            data.Buf_Z86 = bufZ;
                            data.Buf_Status86 = Buf_Status;
                            break;
                        case 87:
                            data.Buf_X87 = bufX;
                            data.Buf_Y87 = bufY;
                            data.Buf_Z87 = bufZ;
                            data.Buf_Status87 = Buf_Status;
                            break;
                        case 88:
                            data.Buf_X88 = bufX;
                            data.Buf_Y88 = bufY;
                            data.Buf_Z88 = bufZ;
                            data.Buf_Status88 = Buf_Status;
                            break;
                        case 89:
                            data.Buf_X89 = bufX;
                            data.Buf_Y89 = bufY;
                            data.Buf_Z89 = bufZ;
                            data.Buf_Status89 = Buf_Status;
                            break;
                        case 90:
                            data.Buf_X90 = bufX;
                            data.Buf_Y90 = bufY;
                            data.Buf_Z90 = bufZ;
                            data.Buf_Status90 = Buf_Status;
                            break;
                        case 91:
                            data.Buf_X91 = bufX;
                            data.Buf_Y91 = bufY;
                            data.Buf_Z91 = bufZ;
                            data.Buf_Status91 = Buf_Status;
                            break;
                        case 92:
                            data.Buf_X92 = bufX;
                            data.Buf_Y92 = bufY;
                            data.Buf_Z92 = bufZ;
                            data.Buf_Status92 = Buf_Status;
                            break;
                        case 93:
                            data.Buf_X93 = bufX;
                            data.Buf_Y93 = bufY;
                            data.Buf_Z93 = bufZ;
                            data.Buf_Status93 = Buf_Status;
                            break;
                        case 94:
                            data.Buf_X94 = bufX;
                            data.Buf_Y94 = bufY;
                            data.Buf_Z94 = bufZ;
                            data.Buf_Status94 = Buf_Status;
                            break;
                        case 95:
                            data.Buf_X95 = bufX;
                            data.Buf_Y95 = bufY;
                            data.Buf_Z95 = bufZ;
                            data.Buf_Status95 = Buf_Status;
                            break;
                        case 96:
                            data.Buf_X96 = bufX;
                            data.Buf_Y96 = bufY;
                            data.Buf_Z96 = bufZ;
                            data.Buf_Status96 = Buf_Status;
                            break;
                        case 97:
                            data.Buf_X97 = bufX;
                            data.Buf_Y97 = bufY;
                            data.Buf_Z97 = bufZ;
                            data.Buf_Status97 = Buf_Status;
                            break;
                        case 98:
                            data.Buf_X98 = bufX;
                            data.Buf_Y98 = bufY;
                            data.Buf_Z98 = bufZ;
                            data.Buf_Status98 = Buf_Status;
                            break;
                        case 99:
                            data.Buf_X99 = bufX;
                            data.Buf_Y99 = bufY;
                            data.Buf_Z99 = bufZ;
                            data.Buf_Status99 = Buf_Status;
                            break;


                    }
                }
            //MessageBox.Show(JsonConvert.SerializeObject(data));
            return JsonConvert.SerializeObject(data);
            

            }
        }
    }
