using Apply_Gule_And_Tape_PC.Class;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Apply_Gule_And_Tape_PC
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : UserControl
    {
        Common Common = new Common();
        Link_Path path = new Link_Path();
        private DispatcherTimer timer;
        public History()
        {
            InitializeComponent();
            Loaded += History_Loaded;  // Thêm sự kiện Loaded
            Unloaded += History_Unloaded;
        }
        private void History_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            timer.Start();
            foreach (var button in Common.FindVisualChildren<Button>(this))
            {
                button.Click += Button_Click;
            }
            LoadErrs();
            LoadAls();
        }
        private void History_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if(Data.Alarm>0)
            {
                LoadAls();
            }
            if (Data.Error > 0)
            {
                LoadErrs();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string buttonName = ((Button)sender).Name;
                if (buttonName == "bt_Clear_Err")
                {
                    if (MainWindow.UserName != "")
                    {
                        Clear_Errs();
                        LoadErrs();
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Đăng Nhập");
                    }
                }
                if (buttonName == "bt_Clear_Al")
                {
                    if (MainWindow.UserName != "")
                    {
                        Clear_Al();
                        LoadAls();
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Đăng Nhập");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void LoadErrs()
        {
            List<Items_Error> items_E = new List<Items_Error>();
            int index = 1;
            try
            {
                string List_Show = File.ReadAllText(path.Error);
                if (List_Show.Length > 0)
                {
                    JArray List_Show_array = JArray.Parse(List_Show);
                    foreach (JObject obj in List_Show_array)

                    {
                        items_E.Add(new Items_Error { STT = index, Content_ = (string)obj["Content_"], Time = (string)obj["Time"] });
                        index++;
                    }
                    items_E.Reverse();
                    for (int i = 0; i < items_E.Count; i++)
                    {
                        items_E[i].STT = i + 1;
                    }
                    List_Error.ItemsSource = items_E;
                }
            }
            catch
            { }
        }
        private void LoadAls()
        {
            List<Items_Alarm> items_Al = new List<Items_Alarm>();
            int index = 1;
            try
            {
                string List_Show = File.ReadAllText(path.Alarm);
                if (List_Show.Length > 0)
                {
                    JArray List_Show_array = JArray.Parse(List_Show);
                    foreach (JObject obj in List_Show_array)
                    {
                        items_Al.Add(new Items_Alarm { STT = index, Content_ = (string)obj["Content_"], Time = (string)obj["Time"] });
                    }
                    items_Al.Reverse();
                    for (int i = 0; i < items_Al.Count; i++)
                    {
                        items_Al[i].STT = i + 1;
                    }
                    List_Alarm.ItemsSource = items_Al;
                }
                //
            }
            catch
            { }
        }
        private void Clear_Errs()
        {
            //
            string time = " ";
            string Err = "[" + "{\"Content_\": " + "\"" + " " + "\"," + "\"Time\": " + "\"" + time + "\"}" + "]";
            File.WriteAllText(path.Error, "");
            File.WriteAllText(path.Error, Err);
        }
        private void Clear_Al()
        {
            //
            string time = " ";
            string Err = "[" + "{\"Content_\": " + "\"" + " " + "\"," + "\"Time\": " + "\"" + time + "\"}" + "]";
            File.WriteAllText(path.Alarm, "");
            File.WriteAllText(path.Alarm, Err);
        }
    }
}
