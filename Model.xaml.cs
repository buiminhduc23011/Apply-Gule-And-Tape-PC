using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using IOPath = System.IO.Path;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Threading;
using Apply_Gule_And_Tape_PC.Class;
using Newtonsoft.Json;
using System.Windows.Media;
using System.Text.Json;
using MaterialDesignThemes.Wpf;
using Newtonsoft.Json.Linq;

namespace Apply_Gule_And_Tape_PC
{
    /// <summary>
    /// Interaction logic for Model.xaml
    /// </summary>
    ///


    public partial class Model : UserControl
    {
        Link_Path linkpath = new Link_Path();
        public ObservableCollection<FileInformation> FilesList { get; set; }
        Common Common = new Common();

        public Model()
        {
            InitializeComponent();
            Loaded += Model_Loaded;  // Thêm sự kiện Loaded
            Unloaded += Model_Unloaded;
        }
        private void YourMethod()
        {

            Models_Mode_2.AddHandler(DataGrid.SelectionChangedEvent, new SelectionChangedEventHandler(Model2_SelectionChanged));
            Models_Mode_3.AddHandler(DataGrid.SelectionChangedEvent, new SelectionChangedEventHandler(Model3_SelectionChanged));
        }

        private void Model2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRow = Models_Mode_2.SelectedItem as DataView_Mode2;
            if (selectedRow != null)
            {
                // Lấy dữ liệu từ hàng được chọn
                var data = selectedRow.Model;
                txb_ModelID2.Text = data.ToString();
                var data_ = selectedRow.RotoID;
                txb_RotoID2.Text = data_.ToString();
            }
        }
        private void Model3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRow = Models_Mode_3.SelectedItem as DataView_Mode3;
            if (selectedRow != null)
            {
                // Lấy dữ liệu từ hàng được chọn
                var data = selectedRow.Model;
                txb_ModelID3.Text = data.ToString();
                var data_ = selectedRow.RotoID;
                txb_RotoID3.Text = data_.ToString();
            }
        }

        private void Model_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var textBox in Common.FindVisualChildren<TextBox>(this))
            {
                textBox.TextChanged += TextBox_TextChanged;
            }
            //
            YourMethod();
            //
            ListModel1.LoadModel();
            Models_Mode_1.ItemsSource = ListModel1.FilesList;
            //
            Common.Load_View_Mode2(Models_Mode_2);
            Common.Load_View_Mode3(Models_Mode_3);
        }
        private void Model_Unloaded(object sender, RoutedEventArgs e)
        {

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string textboxName = textBox.Name;
            if (textboxName == "txb_ModelID2" || textboxName == "txb_RotoID2")
            {
                Fill_Value_Mode2();
            }
            if (textboxName == "txb_ModelID3" || textboxName == "txb_RotoID3")
            {
                Fill_Value_Mode3();
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
                        if ((string)obj["Model"] == txb_ModelID2.Text & (string)obj["Code"] == txb_RotoID2.Text)
                        {
                            txb_ModelID2.Text = (string)obj["Model"];
                            txb_RotoID2.Text = (string)obj["Code"];
                            txb_TGXStart2.Text = (string)obj["Pos_X_Start"];
                            txb_TGZStart2.Text = (string)obj["Pos_Z_Start"];
                            txb_DRoto2.Text = (string)obj["D_Roto"];
                            txb_LRoto2.Text = (string)obj["L_Roto"];
                            txb_Dis_Step2.Text = (string)obj["Dis_Step"];
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
                        if ((string)obj["Model"] == txb_ModelID3.Text & (string)obj["Code"] == txb_RotoID3.Text)
                        {
                            txb_ModelID3.Text = (string)obj["Model"];
                            txb_RotoID3.Text = (string)obj["Code"];
                            txb_BaseXStart3.Text = (string)obj["Pos_XBase_Start"];
                            txb_BaseYStart3.Text = (string)obj["Pos_YBase_Start"];
                            txb_DRoto3.Text = (string)obj["D_Roto"];
                            txb_LRoto3.Text = (string)obj["L_Roto"];
                            txb_Dis_Step3.Text = (string)obj["Dis_Step"];
                            txb_F_D3.Text =  (string)obj["F_D"];
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void Save_Model2()
        {
            List_Model_Mode2 List_Model2 = new List_Model_Mode2();
            List_Model2.Model = txb_ModelID2.Text;
            List_Model2.Code = txb_RotoID2.Text;
            List_Model2.Pos_X_Start = float.Parse(txb_TGXStart2.Text);
            List_Model2.Pos_Z_Start = float.Parse(txb_TGZStart2.Text);
            List_Model2.D_Roto = float.Parse(txb_DRoto2.Text);
            List_Model2.L_Roto = float.Parse(txb_LRoto2.Text);
            List_Model2.Dis_Step = float.Parse(txb_Dis_Step2.Text);
            string list_Model2_Json = JsonConvert.SerializeObject(List_Model2);
            try
            {
                string json = File.ReadAllText(linkpath.Mode2);
                var options = new JsonSerializerOptions { ReadCommentHandling = JsonCommentHandling.Skip };
                var data = System.Text.Json.JsonSerializer.Deserialize<List_Model_Mode2_Temp[]>(json, options);
                float flag = 0;
                foreach (var item in data)
                {
                    if (item.Model == txb_ModelID2.Text || item.Code == txb_RotoID2.Text)
                    {
                        item.Model = txb_ModelID2.Text;
                        item.Code = txb_RotoID2.Text;
                        item.Pos_X_Start = float.Parse(txb_TGXStart2.Text);
                        item.Pos_Z_Start = float.Parse(txb_TGZStart2.Text);
                        item.D_Roto = float.Parse(txb_DRoto2.Text);
                        item.L_Roto = float.Parse(txb_LRoto2.Text);
                        item.Dis_Step = float.Parse(txb_Dis_Step2.Text);
                        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                        string newJsonString = System.Text.Json.JsonSerializer.Serialize(data, jsonOptions);
                        File.WriteAllText(linkpath.Mode2, newJsonString);
                        MessageBox.Show("Đã Lưu Thành Công");
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    json = json.Remove(json.Length - 1);
                    json = json + "," + list_Model2_Json + "]";
                    File.WriteAllText(linkpath.Mode2, json);
                    MessageBox.Show("Đã Lưu Và Tạo Model Mới Thành Công");
                }
            }
            catch
            {
                string json_;
                json_ = "[" + list_Model2_Json + "]";
                File.WriteAllText(linkpath.Mode2, json_);
                MessageBox.Show("Đã Lưu Và Tạo Model Mới Thành Công");
            }
            Common.Load_View_Mode2(Models_Mode_2);
        }
        private void Save_Model3()
        {
            List_Model_Mode3 List_Model3 = new List_Model_Mode3();
            List_Model3.Model = txb_ModelID3.Text;
            List_Model3.Code = txb_RotoID3.Text;
            List_Model3.Pos_XBase_Start = float.Parse(txb_BaseXStart3.Text);
            List_Model3.Pos_YBase_Start = float.Parse(txb_BaseYStart3.Text);
            List_Model3.D_Roto = float.Parse(txb_DRoto3.Text);
            List_Model3.L_Roto = float.Parse(txb_LRoto3.Text);
            List_Model3.Dis_Step = float.Parse(txb_Dis_Step3.Text);
            List_Model3.F_D = float.Parse(txb_F_D3.Text);
            string list_Model3_Json = JsonConvert.SerializeObject(List_Model3);
            try
            {
                string json = File.ReadAllText(linkpath.Mode3);
                var options = new JsonSerializerOptions { ReadCommentHandling = JsonCommentHandling.Skip };
                var data = System.Text.Json.JsonSerializer.Deserialize<List_Model_Mode3_Temp[]>(json, options);
                float flag = 0;
                foreach (var item in data)
                {
                    if (item.Model == txb_ModelID3.Text || item.Code == txb_RotoID3.Text)
                    {
                        item.Model = txb_ModelID3.Text;
                        item.Code = txb_RotoID3.Text;
                        item.Pos_XBase_Start = float.Parse(txb_BaseXStart3.Text);
                        item.Pos_YBase_Start = float.Parse(txb_BaseYStart3.Text);
                        item.D_Roto = float.Parse(txb_DRoto3.Text);
                        item.L_Roto = float.Parse(txb_LRoto3.Text);
                        item.Dis_Step = float.Parse(txb_Dis_Step3.Text);
                        item.F_D = float.Parse(txb_F_D3.Text);
                        var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                        string newJsonString = System.Text.Json.JsonSerializer.Serialize(data, jsonOptions);
                        File.WriteAllText(linkpath.Mode3, newJsonString);
                        MessageBox.Show("Đã Lưu Thành Công");
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    json = json.Remove(json.Length - 1);
                    json = json + "," + list_Model3_Json + "]";
                    File.WriteAllText(linkpath.Mode3, json);
                    MessageBox.Show("Đã Lưu Và Tạo Model Mới Thành Công");
                }
            }
            catch
            {
                string json_;
                json_ = "[" + list_Model3_Json + "]";
                File.WriteAllText(linkpath.Mode3, json_);
                MessageBox.Show("Đã Lưu Và Tạo Model Mới Thành Công");
            }
            Common.Load_View_Mode3(Models_Mode_3);
        }
        private void Clear_Model2()
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mã Model: " + txb_ModelID2.Text + " và mã Roto: " + txb_RotoID2.Text + " ?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes & txb_ModelID2.Text.Length > 0 & txb_RotoID2.Text.Length > 0)
            {

                string json = File.ReadAllText(linkpath.Mode2);
                var options = new JsonSerializerOptions { ReadCommentHandling = JsonCommentHandling.Skip };
                var data = System.Text.Json.JsonSerializer.Deserialize<List_Model_Mode2_Temp[]>(json, options);

                var newData = new List<List_Model_Mode2_Temp>();

                foreach (var item in data)
                {
                    if (item.Model != txb_ModelID2.Text || item.Code != txb_RotoID2.Text)
                    {
                        newData.Add(item);
                    }
                }
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string newJsonString = System.Text.Json.JsonSerializer.Serialize(newData, jsonOptions);
                // Write back to file
                File.WriteAllText(linkpath.Mode2, newJsonString);
                Common.Load_View_Mode2(Models_Mode_2);
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã Model: " + txb_ModelID2.Text + " và mã Roto: " + txb_RotoID2.Text + " cần xóa");
            }

        }
        private void Clear_Model3()
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa mã Model: " + txb_ModelID3.Text + " và mã Roto: " + txb_RotoID3.Text + " ?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes & txb_ModelID3.Text.Length > 0 & txb_RotoID3.Text.Length > 0)
            {

                string json = File.ReadAllText(linkpath.Mode3);
                var options = new JsonSerializerOptions { ReadCommentHandling = JsonCommentHandling.Skip };
                var data = System.Text.Json.JsonSerializer.Deserialize<List_Model_Mode3_Temp[]>(json, options);

                var newData = new List<List_Model_Mode3_Temp>();

                foreach (var item in data)
                {
                    if (item.Model != txb_ModelID3.Text || item.Code != txb_RotoID3.Text)
                    {
                        newData.Add(item);
                    }
                }
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string newJsonString = System.Text.Json.JsonSerializer.Serialize(newData, jsonOptions);
                // Write back to file
                File.WriteAllText(linkpath.Mode3, newJsonString);
                Common.Load_View_Mode3(Models_Mode_3);
            }
            else
            {
                MessageBox.Show("Không tìm thấy mã Model: " + txb_ModelID3.Text + " và mã Roto: " + txb_RotoID3.Text + " cần xóa");
            }

        }

        private void Set_Pos_Mode2_Click(object sender, RoutedEventArgs e)
        {
            txb_TGXStart2.Text = Data.Pos_X.ToString();
            txb_TGZStart2.Text = Data.Pos_Z.ToString();
        }

        private void Set_Pos_Mode3_Click(object sender, RoutedEventArgs e)
        {
            txb_BaseXStart3.Text = Data.Pos_XBase.ToString();
            txb_BaseYStart3.Text = Data.Pos_YBase.ToString();
        }

        private void bt_Save_Model2_Click(object sender, RoutedEventArgs e)
        {
            Save_Model2();
        }

        private void bt_Clear_Model2_Click(object sender, RoutedEventArgs e)
        {
            
            Clear_Model2();
        }

        private void bt_Save_Model3_Click(object sender, RoutedEventArgs e)
        {
            Save_Model3();
        }

        private void bt_Clear_Model3_Click(object sender, RoutedEventArgs e)
        {
            Clear_Model3();
        }
    }
}
