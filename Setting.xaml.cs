using Apply_Gule_And_Tape_PC.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO.Ports;

namespace Apply_Gule_And_Tape_PC
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : UserControl
    {
        Common Common = new Common();
        Link_Path path = new Link_Path();
        string Ip_Port_Host;
        public Setting()
        {
            InitializeComponent();
            Loaded += Setting_Loaded;
            Unloaded += Setting_Unloaded;

        }
        private void Setting_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var button in Common.FindVisualChildren<Button>(this))
            {
                button.Click += Button_Click;
            }
            try
            {
                string json = File.ReadAllText(path.Setting);
                var data_Setting = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                txb_PLC_Read.Text = data_Setting["PLC_Read"];
                txb_PLC_Write.Text = data_Setting["PLC_Write"];

            }
            catch
            {

            }
        }
        private void Setting_Unloaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string buttonName = ((Button)sender).Name;
                if (buttonName == "bt_Save_Sys")
                {
                    object data_Setting = new
                    {
                        PLC_Read = txb_PLC_Read.Text,
                        PLC_Write = txb_PLC_Write.Text,
                    };
                    string json = System.Text.Json.JsonSerializer.Serialize(data_Setting);
                    File.WriteAllText(path.Setting, json);
                    PLC.PLC_Read = txb_PLC_Read.Text;
                    PLC.PLC_Write = txb_PLC_Write.Text;
                    MessageBox.Show("Đã Lưu Thành Công");
                }
            }
            catch
            {

            }
        }
    }
}
