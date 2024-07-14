using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using IOPath = System.IO.Path;
using System.Windows.Threading;
using Apply_Gule_And_Tape_PC.Class;
using Newtonsoft.Json;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;
using System.Security.AccessControl;
using System.Windows.Controls.Primitives;

namespace Apply_Gule_And_Tape_PC
{
    /// <summary>
    /// Interaction logic for Auto.xaml
    /// </summary>
    /// 


    public partial class Auto : UserControl
    {
        List<FloatStatusElement> arrayList = new List<FloatStatusElement>();
        Common Common = new Common();
        Link_Path linkpath = new Link_Path();
        Update_Screen update = new Update_Screen();
        private int processingCounter = 0;
        private bool flag = false;
        private bool flag_Send = false;
        private DispatcherTimer timer;
        PLC plc = new PLC();

        static bool[] ByteToBits(uint value)
        {
            bool[] bits = new bool[10];

            for (int i = 0; i < 8; i++)
            {
                bits[i] = (value & (1 << i)) != 0;
            }
            return bits;
        }
        public Auto()
        {
            InitializeComponent();
            Loaded += Auto_Loaded;  // Thêm sự kiện Loaded
            Unloaded += Auto_Unloaded;
        }
        private void Auto_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var txb in FindVisualChildren<TextBox>(this))
            {
                txb.TextChanged += Txb_TextChanged;
            }
            foreach (var dataGrid in FindVisualChildren<DataGrid>(this))
            {
                dataGrid.SelectionChanged += DataGrid_SelectionChanged;
            }
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;
            timer.Start();
            //
            ListModel1.LoadModel();
            List_Models_Gule_Load_Cover.ItemsSource = ListModel1.FilesList;
            //
            Common.Load_View_Mode2(list_Mode2);
            Common.Load_View_Mode3(list_Mode3);
            //
            var data = new
            {
                M1_Jig1 = false,
                M1_Jig2 = false

            };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
            //
            txb_IDcode_Mode1.Text = "";
            txb_IDcode_Mode2.Text = "";
            txb_IDcode_Mode3.Text = "";
        }
        private void Auto_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string gridName = ((DataGrid)sender).Name;

            if (gridName == "List_Models_Gule_Load_Cover")
            {
                var selectedRow = List_Models_Gule_Load_Cover.SelectedItem as FileInformation;
                if (selectedRow != null)
                {
                    var data = selectedRow.Model;
                    txb_IDcode_Mode1.Text = data.ToString().Replace(".txt", string.Empty);
                    var data_send = new
                    {
                        M1_Jig1 = false,
                        M1_Jig2 = false,
                    };
                    string jsonData = JsonConvert.SerializeObject(data_send);
                    plc.Write(jsonData);
                }
            }
            if (gridName == "list_Mode2")
            {
                var selectedRow = list_Mode2.SelectedItem as DataView_Mode2;
                if (selectedRow != null)
                {
                    var data = selectedRow.Model;
                    txb_IDcode_Mode2.Text = data.ToString();
                }
            }

            if (gridName == "list_Mode3")
            {
                var selectedRow = list_Mode3.SelectedItem as DataView_Mode3;
                if (selectedRow != null)
                {
                    var data = selectedRow.Model;
                    txb_IDcode_Mode3.Text = data.ToString();
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {


            try
            {
                if (Data.ON_Mode1 == true)
                {
                    if (Data.M1_Req == true && flag == false)
                    {
                        processingCounter += 1;
                        plc.Write(Mode_1.Parse_Data(programListBox, 100, processingCounter));
                        flag = true;
                    }
                }
                else
                {
                    processingCounter = 0;
                }
                if (Data.M1_Req == false)
                {
                    flag = false;
                }

                Dispatcher.Invoke(() =>
                {
                    Update_Screen();
                });
            }
            catch
            {

            }
        }
        private void Update_Screen()
        {
            update.bt_Blue(bt_Mode1, Data.ON_Mode1, false);
            update.bt_Blue(bt_Mode2, Data.ON_Mode2, false);
            update.bt_Blue(bt_Mode3, Data.ON_Mode3, false);
            update.bt_Blue(M1_Jig1, Data.M1_Jig1, false);
            update.bt_Blue(M1_Jig2, Data.M1_Jig2, false);
            Change_Background_Listbox(Data.G_Step);
            bool[] S_Machine = ByteToBits(Data.S_Machine);
            update.Lable(Smachine0, S_Machine[0]);
            update.Lable(Smachine1, S_Machine[1]);
            update.Lable(Smachine2, S_Machine[2]);
            update.Lable(Smachine3, S_Machine[3]);
            update.Lable(Smachine4, S_Machine[4]);
            update.Lable(Smachine5, S_Machine[5]);
            update.Lable(Smachine6, S_Machine[6]);
        }
        private void Change_Background_Listbox(int Line)
        {
            try
            {
                for (int i = 0; i < programListBox.Items.Count; i++)
                {
                    ListBoxItem listBoxItem = programListBox.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;

                    if (listBoxItem != null)
                    {
                        if (i == Line - 1)
                        {
                            listBoxItem.Background = new SolidColorBrush(Color.FromRgb(196, 196, 210));
                            listBoxItem.IsSelected = true;
                            programListBox.ScrollIntoView(programListBox.Items[i]);
                        }
                        else
                        {
                            listBoxItem.Background = Brushes.White;
                            listBoxItem.IsSelected = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }
                else
                {
                    var result = FindVisualChildren<T>(child);
                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            yield return item;
                        }
                    }
                }
            }
        }
        private void Button_TouchDown(object sender, TouchEventArgs e)
        {
            string buttonName = ((Button)sender).Name;
        }

        private void Button_TouchLeave(object sender, TouchEventArgs e)
        {
            string buttonName = ((Button)sender).Name;
        }

        private void Send_GCode()
        {
            foreach (var item in programListBox.Items)
            {
                string line = item.ToString();
                string[] words = line.Split(' ');
                double xValue = 0f;
                double yValue = 0f;
                double zValue = 0f;

                // Lặp qua từng từ để lấy giá trị X, Y, Z
                foreach (string word in words)
                {
                    if (word.StartsWith("X"))
                    {
                        xValue = double.Parse(word.Substring(1));
                    }
                    else if (word.StartsWith("Y"))
                    {
                        yValue = double.Parse(word.Substring(1));
                    }
                    else if (word.StartsWith("Z"))
                    {
                        zValue = double.Parse(word.Substring(1));
                    }
                }
                arrayList.Add(new FloatStatusElement { X = xValue, Y = yValue, Z = zValue, Buf_Status = 0 });
            }
            var data = new
            {
                ON_Mode1 = true,
            };
            string Send = JsonConvert.SerializeObject(data);
            plc.Write(Send);
        }
        private void Handel_Mode1_Jig1()
        {
            if (Data.ON_Mode1 == false)
            {

                if (!Data.M1_Jig1 && !Data.M1_Jig2)
                {
                    Load_Model1();
                    for (int i = 0; i < programListBox.Items.Count; i++)
                    {
                        string prefixToRemove = "System.Windows.Controls.ListBoxItem: ";
                        string inputString = programListBox.Items[i].ToString().Trim();

                        if (inputString.StartsWith(prefixToRemove))
                        {
                            inputString = inputString.Substring(prefixToRemove.Length);
                        }
                        inputString = AddValue(inputString, "X", Data.J1_X_Of);
                        inputString = AddValue(inputString, "Y", Data.J1_Y_Of);
                        inputString = AddValue(inputString, "Z", Data.J1_Z_Of);

                        // Cập nhật giá trị trong ListBox
                        programListBox.Items[i] = inputString;
                    }
                }
                else if (!Data.M1_Jig1 && Data.M1_Jig2)
                {
                    Load_Model1();
                    for (int i = 0; i < programListBox.Items.Count; i++)
                    {
                        string prefixToRemove = "System.Windows.Controls.ListBoxItem: ";
                        string inputString = programListBox.Items[i].ToString().Trim();

                        if (inputString.StartsWith(prefixToRemove))
                        {
                            inputString = inputString.Substring(prefixToRemove.Length);
                        }
                        inputString = AddValue(inputString, "X", Data.J1_X_Of);
                        inputString = AddValue(inputString, "Y", Data.J1_Y_Of);
                        inputString = AddValue(inputString, "Z", Data.J1_Z_Of);

                        // Cập nhật giá trị trong ListBox
                        programListBox.Items[i] = inputString;
                    }
                    int x = programListBox.Items.Count;
                    // Insert Pos Origin Jig 2
                    ListBoxItem listBoxItem_ = new ListBoxItem();
                    listBoxItem_.Content = "G00 X" + Data.J2_X_Of.ToString() + " Y" + Data.J2_Y_Of.ToString() + " Z" + "0.0";
                    programListBox.Items.Add(listBoxItem_);
                    for (int i = 0; i < x; i++)
                    {
                        string prefixToRemove = "System.Windows.Controls.ListBoxItem: ";
                        string inputString = programListBox.Items[i].ToString().Trim();

                        if (inputString.StartsWith(prefixToRemove))
                        {
                            inputString = inputString.Substring(prefixToRemove.Length);
                        }
                        inputString = AddValue(inputString, "X", Data.J2_X_Of - Data.J1_X_Of);
                        inputString = AddValue(inputString, "Y", 0);
                        inputString = AddValue(inputString, "Z", 0);

                        ListBoxItem listBoxItem = new ListBoxItem();
                        listBoxItem.Content = inputString;
                        // Cập nhật giá trị trong ListBox
                        programListBox.Items.Add(listBoxItem);
                    }
                }
                else if (Data.M1_Jig1 && Data.M1_Jig2)
                {
                    Load_Model1();
                    for (int i = 0; i < programListBox.Items.Count; i++)
                    {
                        string prefixToRemove = "System.Windows.Controls.ListBoxItem: ";
                        string inputString = programListBox.Items[i].ToString().Trim();

                        if (inputString.StartsWith(prefixToRemove))
                        {
                            inputString = inputString.Substring(prefixToRemove.Length);
                        }
                        inputString = AddValue(inputString, "X", Data.J2_X_Of);
                        inputString = AddValue(inputString, "Y", Data.J2_Y_Of);
                        inputString = AddValue(inputString, "Z", Data.J2_Z_Of);

                        ListBoxItem listBoxItem = new ListBoxItem();
                        listBoxItem.Content = inputString;
                        programListBox.Items[i] = inputString;
                    }
                }
                else { Load_Model1(); }

                var data = new
                {
                    M1_Jig1 = !Data.M1_Jig1
                };
                string jsonData = JsonConvert.SerializeObject(data);
                plc.Write(jsonData);
            }
            else
            {
                MessageBox.Show("Máy Đang Thực Hiện Quy Trình, Vui Lòng Đợi");
            }
        }
        private void Handel_Mode1_Jig2()
        {
            if (Data.ON_Mode1 == false)
            {

                if (!Data.M1_Jig1 && !Data.M1_Jig2)
                {
                    Load_Model1();
                    for (int i = 0; i < programListBox.Items.Count; i++)
                    {
                        string prefixToRemove = "System.Windows.Controls.ListBoxItem: ";
                        string inputString = programListBox.Items[i].ToString().Trim();

                        if (inputString.StartsWith(prefixToRemove))
                        {
                            inputString = inputString.Substring(prefixToRemove.Length);
                        }
                        inputString = AddValue(inputString, "X", Data.J2_X_Of);
                        inputString = AddValue(inputString, "Y", Data.J2_Y_Of);
                        inputString = AddValue(inputString, "Z", Data.J2_Z_Of);

                        // Cập nhật giá trị trong ListBox
                        programListBox.Items[i] = inputString;
                    }
                }
                else if (Data.M1_Jig1 && !Data.M1_Jig2)
                {
                    Load_Model1();
                    for (int i = 0; i < programListBox.Items.Count; i++)
                    {
                        string prefixToRemove = "System.Windows.Controls.ListBoxItem: ";
                        string inputString = programListBox.Items[i].ToString().Trim();

                        if (inputString.StartsWith(prefixToRemove))
                        {
                            inputString = inputString.Substring(prefixToRemove.Length);
                        }
                        inputString = AddValue(inputString, "X", Data.J1_X_Of);
                        inputString = AddValue(inputString, "Y", Data.J1_Y_Of);
                        inputString = AddValue(inputString, "Z", Data.J1_Z_Of);

                        // Cập nhật giá trị trong ListBox
                        programListBox.Items[i] = inputString;
                    }
                    int x = programListBox.Items.Count;
                    ListBoxItem listBoxItem_ = new ListBoxItem();
                    listBoxItem_.Content = "G00 X" + Data.J2_X_Of.ToString() + " Y" + Data.J2_Y_Of.ToString() + " Z" + "0.0";
                    programListBox.Items.Add(listBoxItem_);
                    for (int i = 0; i < x; i++)
                    {
                        string prefixToRemove = "System.Windows.Controls.ListBoxItem: ";
                        string inputString = programListBox.Items[i].ToString().Trim();

                        if (inputString.StartsWith(prefixToRemove))
                        {
                            inputString = inputString.Substring(prefixToRemove.Length);
                        }
                        inputString = AddValue(inputString, "X", Data.J2_X_Of - Data.J1_X_Of);
                        inputString = AddValue(inputString, "Y", 0);
                        inputString = AddValue(inputString, "Z", 0);

                        ListBoxItem listBoxItem = new ListBoxItem();
                        listBoxItem.Content = inputString;
                        // Cập nhật giá trị trong ListBox
                        programListBox.Items.Add(listBoxItem);
                    }
                }
                else if (Data.M1_Jig1 && Data.M1_Jig2)
                {
                    Load_Model1();
                    for (int i = 0; i < programListBox.Items.Count; i++)
                    {
                        string prefixToRemove = "System.Windows.Controls.ListBoxItem: ";
                        string inputString = programListBox.Items[i].ToString().Trim();

                        if (inputString.StartsWith(prefixToRemove))
                        {
                            inputString = inputString.Substring(prefixToRemove.Length);
                        }
                        inputString = AddValue(inputString, "X", Data.J1_X_Of);
                        inputString = AddValue(inputString, "Y", Data.J1_Y_Of);
                        inputString = AddValue(inputString, "Z", Data.J1_Z_Of);

                        ListBoxItem listBoxItem = new ListBoxItem();
                        listBoxItem.Content = inputString;
                        programListBox.Items[i] = inputString;
                    }
                }
                else { Load_Model1(); }

                var data = new
                {
                    M1_Jig2 = !Data.M1_Jig2
                };
                string jsonData = JsonConvert.SerializeObject(data);
                plc.Write(jsonData);
            }
            else
            {
                MessageBox.Show("Máy Đang Thực Hiện Quy Trình, Vui Lòng Đợi");
            }
        }
        static string AddValue(string input, string key, double addend)
        {
            // Tìm giá trị sau key sử dụng biểu thức chính quy
            string pattern = $@"{key}(-?[\d.]+)";
            Regex regex = new Regex(pattern);

            Match match = regex.Match(input);

            if (match.Success)
            {
                // Lấy giá trị số từ match
                string valueString = match.Groups[1].Value;

                // Chuyển đổi giá trị số thành double
                if (double.TryParse(valueString, out double value))
                {
                    // Cộng thêm giá trị
                    double newValue = value + addend;

                    // Thay thế giá trị cũ bằng giá trị mới
                    return regex.Replace(input, $"{key}{newValue:F3}");
                }
            }

            // Nếu không tìm thấy, trả về chuỗi không thay đổi
            return input;
        }
        private void Txb_TextChanged(object sender, TextChangedEventArgs e)
        {
            string txbName = ((TextBox)sender).Name;


            if (txbName == "txb_IDcode_Mode1")
            {

                Load_Model1();
            }

            if (txbName == "txb_IDcode_Mode2")
            {
                if (txb_IDcode_Mode2.Text != "")
                {
                    Fill_Value_Mode2();
                }
                else
                {
                    M2_XStart.Text = "";
                    M2_ZStart.Text = "";
                    M2_LRoto.Text = "";
                    M2_DRoto.Text = "";
                    M2_Dis_Step.Text = "";
                    M2_Speed_Step.Text = "";
                }

            }
            if (txbName == "txb_IDcode_Mode3")
            {
                if (txb_IDcode_Mode3.Text != "")
                {
                    Fill_Value_Mode3();
                }
                else
                {
                    M3_BaseXStart.Text = "";
                    M3_BaseYStart.Text = "";
                    M3_LRoto.Text = "";
                    M3_DRoto.Text = "";
                    M3_Dis_Step.Text = "";
                    M3_F_D.Text = "";
                    txb_XBase_OF_Han.Text = "";
                    txb_Rotate_OF_Han.Text = "";
                }    
            }
        }
        private void Load_Model1()
        {
            string filePath;
            string folderPath = "Model\\List_Model_Mode_1";
            if (Directory.Exists(folderPath))
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    filePath = IOPath.GetFileName(file);
                    filePath = filePath.Replace(".txt", string.Empty);
                    if (filePath == txb_IDcode_Mode1.Text)
                    {
                        programListBox.Items.Clear();
                        string[] lines = File.ReadAllLines(file);
                        int i = 0;
                        foreach (string line in lines)
                        {
                            ListBoxItem listBoxItem = new ListBoxItem();
                            if (i < 10)
                            {
                                listBoxItem.Content = "G0" + i + " " + line;
                            }
                            else
                            {
                                listBoxItem.Content = "G" + i + " " + line;
                            }
                            programListBox.Items.Add(listBoxItem);
                            i++;
                        }
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Không Tồn Tại Model");
            }
        }
        private void Fill_Value_Mode2()
        {
            try
            {
                string json = File.ReadAllText(linkpath.Mode2);
                if (json.Length > 0)
                {
                    JArray jsonArray = JArray.Parse(json);
                    foreach (JObject obj in jsonArray)
                    {
                        if ((string)obj["Model"] == txb_IDcode_Mode2.Text)
                        {
                            M2_XStart.Text = (string)obj["Pos_X_Start"];
                            M2_ZStart.Text = (string)obj["Pos_Z_Start"];
                            M2_LRoto.Text = (string)obj["L_Roto"];
                            M2_DRoto.Text = (string)obj["D_Roto"];
                            M2_Dis_Step.Text = (string)obj["Dis_Step"];
                            M2_Speed_Step.Text = (string)obj["Speed"];
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void Fill_Value_Mode3()
        {
            try
            {
                string json = File.ReadAllText(linkpath.Mode3);
                if (json.Length > 0)
                {
                    JArray jsonArray = JArray.Parse(json);
                    foreach (JObject obj in jsonArray)
                    {
                        if ((string)obj["Model"] == txb_IDcode_Mode3.Text)
                        {
                            M3_BaseXStart.Text = (string)obj["Pos_XBase_Start"];
                            M3_BaseYStart.Text = (string)obj["Pos_YBase_Start"];
                            M3_LRoto.Text = (string)obj["L_Roto"];
                            M3_DRoto.Text = (string)obj["D_Roto"];
                            M3_Dis_Step.Text = (string)obj["Dis_Step"];
                            M3_F_D.Text = (string)obj["F_D"];
                            txb_N_Rotate.Text = (string)obj["K"];
                            txb_XBase_OF_Han.Text = string.Format("{0:F3}", (double)obj["OF_Xbase"]);
                            txb_Rotate_OF_Han.Text = string.Format("{0:F3}", (double)obj["OF_Rotate"]);
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void bt_Mode1_Click(object sender, RoutedEventArgs e)
        {
           // Mode_1.Parse_Data(programListBox, 100, 1);
            if (PLC.IsConnected)
            {
                if (txb_IDcode_Mode1.Text != "")
                {
                    if (Data.S_Machine == 127)
                    {
                        if(!Data.M1_Jig1 && !Data.M1_Jig2)
                        {
                            MessageBox.Show("Vui Lòng Chọn Jig!!!");
                        }    
                        else
                        {
                            if (Data.ON_Mode2 == false || Data.ON_Mode3 == false)
                            {
                                if (Data.ON_Mode1 == false)
                                {
                                    Send_GCode();
                                }
                                else
                                {
                                    MessageBoxResult result = MessageBox.Show("Xác Nhận Reset Chu Trình", "Warring", MessageBoxButton.OKCancel);
                                    if (result == MessageBoxResult.OK)
                                    {
                                        var data = new
                                        {
                                            ON_Mode1 = false,
                                        };
                                        string Send = JsonConvert.SerializeObject(data);
                                        plc.Write(Send);
                                        Thread.Sleep(1000);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Máy Đang Thực Hiện Chế Độ Khác, Vui Lòng Đợi!!!");
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Về Gốc Máy!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui Lòng Chọn Model!!!");
                }
            }
            else
            {

            }
        }

        private void M1_Jig1_Click(object sender, RoutedEventArgs e)
        {
            if (PLC.IsConnected)
            {
                Load_Model1();
                if (programListBox.Items.Count >= 2)
                {
                    Handel_Mode1_Jig1();
                }
                else
                {
                    MessageBox.Show("Vui Lòng Chọn Model!!!");
                }
            }    
             else
            {

            }    
        }

        private void M1_Jig2_Click(object sender, RoutedEventArgs e)
        {
            if(PLC.IsConnected)
            {

                Load_Model1();
                if (programListBox.Items.Count >= 2)
                {
                    Handel_Mode1_Jig2();
                }
                else
                {
                    MessageBox.Show("Vui Lòng Chọn Model!!!");
                }
            }    
            else
            {

            }    
        }

        private void bt_Mode2_Click(object sender, RoutedEventArgs e)
        {
            if(PLC.IsConnected)
            {
                if (txb_IDcode_Mode2.Text != "")
                {
                    if (Data.S_Machine == 127)
                    {
                        if (Data.ON_Mode1 == false || Data.ON_Mode3 == false)
                        {
                            var data = new
                            {
                                M2_X_Start = float.Parse(M2_XStart.Text),
                                M2_Z_Start = float.Parse(M2_ZStart.Text),
                                M2_L_Roto = float.Parse(M2_LRoto.Text),
                                M2_D_Roto = float.Parse(M2_DRoto.Text),
                                M2_Dis_Step = float.Parse(M2_Dis_Step.Text),
                                M2_Speed = float.Parse(M2_Speed_Step.Text),
                                ON_Mode2 = true,
                            };
                            string Send = JsonConvert.SerializeObject(data);
                            plc.Write(Send);
                        }
                        else
                        {
                            MessageBox.Show("Máy Đang Thực Hiện Chế Độ Khác, Vui Lòng Đợi!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Về Gốc Máy!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui Lòng Chọn Model!!!");
                }
            }    
            else
            {

            }    
        }

        private void bt_Mode3_Click(object sender, RoutedEventArgs e)
        {
            if(PLC.IsConnected)
            {
                if (txb_IDcode_Mode3.Text != "")
                {
                    if (Data.S_Machine == 127)
                    {
                        if (Data.ON_Mode1 == false || Data.ON_Mode2 == false)
                        {
                            var data = new
                            {
                                M3_XBase_Start = float.Parse(M3_BaseXStart.Text),
                                M3_YBase_Start = float.Parse(M3_BaseYStart.Text),
                                M3_L_Roto = float.Parse(M3_LRoto.Text),
                                M3_D_Roto = float.Parse(M3_DRoto.Text),
                                M3_Dis_Step = float.Parse(M3_Dis_Step.Text),
                                M3_F_D = float.Parse(M3_F_D.Text),
                                N_Rotate = float.Parse(txb_N_Rotate.Text),
                                OF_Xbase = float.Parse(txb_XBase_OF_Han.Text),
                                OF_Rotate = float.Parse(txb_Rotate_OF_Han.Text),
                                ON_Mode3 = true,
                            };
                            string Send = JsonConvert.SerializeObject(data);
                            plc.Write(Send);
                        }
                        else
                        {
                            MessageBox.Show("Máy Đang Thực Hiện Chế Độ Khác, Vui Lòng Đợi!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Về Gốc Máy!!!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui Lòng Chọn Model!!!");
                }
            }
            else
            {

            }
        }
    }
}