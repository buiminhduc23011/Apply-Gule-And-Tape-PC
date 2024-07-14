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
using System.Windows.Controls.Primitives;

namespace Apply_Gule_And_Tape_PC
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : UserControl
    {
        Common Common = new Common();
        Link_Path path = new Link_Path();
        private DispatcherTimer timer;
        Update_Screen ud = new Update_Screen();
        PLC plc = new PLC();
        public Setting()
        {
            InitializeComponent();
            Loaded += Setting_Loaded;
            Unloaded += Setting_Unloaded;

        }
        private void Setting_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            timer.Start();
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
            timer.Stop();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
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
            ud.bt_Blue(bt_Off_Buzzer, Data.Off_Buzzer, false);
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

        private void bt_Off_Buzzer_Click(object sender, RoutedEventArgs e)
        {
            var data = new
            {
                Off_Buzzer = !Data.Off_Buzzer,
            };
            string jsonData = JsonConvert.SerializeObject(data);
            plc.Write(jsonData);
        }
    }
}
