using Apply_Gule_And_Tape_PC.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Apply_Gule_And_Tape_PC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Auto Auto_Screen = new Auto();
        Manual Manual_Screen = new Manual();
        GPIO GPIO_Screen = new GPIO();
        History History_Screen = new History();
        Model Model_Screen = new Model();
        Setting Setting_Screen = new Setting();
        //
        Link_Path path = new Link_Path();
        int f_E = 0;
        int f_A = 0;
        int T_E = 0;
        int T_A = 0;
        //
        PLC PLC = new PLC();
        Update_Screen ud = new Update_Screen();
        //
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        //
        private DispatcherTimer Update_Status;
        private DispatcherTimer Update_Sys;
        //
        public static string UserName = "";
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Closing += MainWindow_Closing;
        }
        public static string GetMacAddress()
        {
            string macAddress = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up && !nic.Description.ToLower().Contains("virtual") && !nic.Description.ToLower().Contains("pseudo"))
                {
                    if (nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211) // Check if it's a Wi-Fi interface
                    {
                        byte[] macBytes = nic.GetPhysicalAddress().GetAddressBytes();
                        macAddress = string.Join(":", macBytes.Select(b => b.ToString("X2")));
                        break;
                    }

                }
            }
            return macAddress;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //
            PLC.StartTimer();
            Update_Status = new DispatcherTimer();
            Update_Status.Interval = TimeSpan.FromMilliseconds(100);
            Update_Status.Tick += Update_Status_Tick100ms;
            Update_Status.Start();
            //
            Update_Sys = new DispatcherTimer();
            Update_Sys.Interval = TimeSpan.FromMilliseconds(1000);
            Update_Sys.Tick += Update_Status_Tick1000ms;
            Update_Sys.Start();
            //
            Pannel_Monitor.Children.Add(Auto_Screen);
            bt_Auto.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Manual.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Model.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            //
            LanguageComboBox.SelectedIndex = 1;
            //
            //Reset Jig

        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PLC.StopTimer();
            Update_Status.Stop();
            Update_Sys.Stop();
        }
        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }
        private void Update_Status_Tick100ms(object sender, EventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                ud.bt_Blue(bt_Origin, Data.Flag_Org, false);
                ud.bt_Blue(bt_Reset, Data.Reset, false);
                txb_TayGap_Pos_X.Text = Data.Pos_X.ToString();
                txb_TayGap_Pos_Y.Text = Data.Pos_Y.ToString();
                txb_TayGap_Pos_Z.Text = Data.Pos_Z.ToString();
                txb_Base_Pos_X.Text = Data.Pos_XBase.ToString();
                txb_Base_Pos_Y.Text = Data.Pos_YBase.ToString();
                txb_Pos_Rotate.Text = Data.Pos_Rotate.ToString();
                if (Data.S_AM == true) lb_Mode.Content = "Tự Động";
                else lb_Mode.Content = "Bằng Tay";
            });
        }
        private void Update_Status_Tick1000ms(object sender, EventArgs e)
        {
            try
            {
                if (Data.Error > 0)
                {
                    f_E++;
                    if (f_E == 1)
                    {
                        Log_Error(Data.Error);
                        T_E = Data.Error;
                    }
                    if (T_E != Data.Error) { f_E = 0; }
                }
                else
                {
                    f_E = 0;
                }
                if (Data.Alarm > 0)
                {
                    f_A++;
                    if (f_A == 1)
                    {
                        Log_Alarm(Data.Alarm);
                        T_A = Data.Alarm;
                    }
                    if (T_A != Data.Alarm) { f_A = 0; }

                }
                else
                {
                    f_A = 0;
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
            System.DateTime dateTime = System.DateTime.Now;
            string formattedDate = dateTime.ToString("dd/MM/yyyy");
            lb_Day.Content = formattedDate;
            string formattedtime = dateTime.ToString("HH:mm:ss");
            lb_Time.Content = formattedtime;
            if (PLC.IsConnected) lb_Connect.Foreground = System.Windows.Media.Brushes.Green;
            else lb_Connect.Foreground = System.Windows.Media.Brushes.Red;
            //
            float cpuUsage = cpuCounter.NextValue();
            string formattedCpuUsage = cpuUsage.ToString("F2") + "%";
            Per_CPU.Content = formattedCpuUsage;

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

           
        private void Log_Error(int ErrorID)
        {
            System.DateTime dateTime = System.DateTime.Now;
            string formattedDate_ = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
            string json_ = File.ReadAllText(path.List_Error);
            string[] errorArray = json_.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string json = File.ReadAllText(path.Error);
                json = json.Remove(json.Length - 1);
                json = json + "," + "{\"Content_\": " + "\"" + errorArray[ErrorID - 1].Replace("\r", "").Replace("\n", "") + "\"," + "\"Time\": " + "\"" + formattedDate_ + "\"}" + "]";
                File.WriteAllText(path.Error, json);
            }
            catch (Exception ex)
            {
                string json = File.ReadAllText(path.Error);
                json = json.Remove(json.Length - 1);
                json = json + "," + "{\"Content_\": " + "\"" + "Lỗi Không Xác Định" + "\"," + "\"Time\": " + "\"" + formattedDate_ + "\"}" + "]";
                File.WriteAllText(path.Error, json);
                MessageBox.Show(ex.Message);
            }
        }
        private void Log_Alarm(int AlarmID)
        {
            System.DateTime dateTime = System.DateTime.Now;
            string formattedDate_ = dateTime.ToString("dd/MM/yyyy HH:mm:ss");
            string json_ = File.ReadAllText(path.List_Alarm);
            string[] errorArray = json_.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string json = File.ReadAllText(path.Alarm);
                json = json.Remove(json.Length - 1);
                json = json + "," + "{\"Content_\": " + "\"" + errorArray[AlarmID - 1].Replace("\r", "").Replace("\n", "") + "\"," + "\"Time\": " + "\"" + formattedDate_ + "\"}" + "]";
                File.WriteAllText(path.Alarm, json);
            }
            catch (Exception ex)
            {
                string json = File.ReadAllText(path.Alarm);
                json = json.Remove(json.Length - 1);
                json = json + "," + "{\"Content_\": " + "\"" + "Lỗi Không Xác Định" + "\"," + "\"Time\": " + "\"" + formattedDate_ + "\"}" + "]";
                File.WriteAllText(path.Alarm, json);
                MessageBox.Show(ex.Message);
            }
        }
        private DispatcherTimer logoutTimer;
        private DateTime lastActivityTime;
        private void LoginWindow_LoginSuccessful(object sender, EventArgs e)
        {
            lb_Name.Content = UserName;
            logoutTimer = new DispatcherTimer();
            logoutTimer.Interval = TimeSpan.FromMinutes(10);
            logoutTimer.Tick += LogoutTimer_Tick;
            Login();
        }
        private void LogoutTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan idleTime = DateTime.Now - lastActivityTime;
            if (idleTime >= TimeSpan.FromMinutes(10))
            {
                //Logout();
            }
        }
        private void Login()
        {
            lastActivityTime = DateTime.Now;
            logoutTimer.Start();
        }
        private void Logout()
        {
            UserName = "";
            lb_Name.Content = UserName;
        }
        private void TouchDownHandler(object sender, RoutedEventArgs e)
        {
            TouchEventArgs touchArgs = e as TouchEventArgs;
            if (touchArgs != null)
            {
                lastActivityTime = DateTime.Now;
            }
        }

        private void bt_Auto_Click(object sender, RoutedEventArgs e)
        {
            Pannel_Monitor.Children.Clear();
            Pannel_Monitor.Children.Add(Auto_Screen);
            bt_Auto.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
            bt_Manual.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Model.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void bt_Origin_Click(object sender, RoutedEventArgs e)
        {
            if (Data.S_AM == false)
            {
                var data = new Dictionary<string, object>
                        {
                            { "Org_All", true }
                        };
                string jsonData = JsonConvert.SerializeObject(data);
                PLC.Write(jsonData);
            }
            else
            {
                MessageBox.Show("Vui Lòng Chuyển Sang Chế Độ Bằng Tay");
            }
        }

        private void bt_Reset_Click(object sender, RoutedEventArgs e)
        {
            var data = new Dictionary<string, object>
                        {
                            { "Reset", true }
                        };
            string jsonData = JsonConvert.SerializeObject(data);
            PLC.Write(jsonData);
        }

        private void bt_Manual_Click(object sender, RoutedEventArgs e)
        {
                Pannel_Monitor.Children.Clear();
                Pannel_Monitor.Children.Add(Manual_Screen);
                bt_Auto.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_Manual.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
                bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_Model.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        }

        private void bt_GPIO_Click(object sender, RoutedEventArgs e)
        {
                Pannel_Monitor.Children.Clear();
                Pannel_Monitor.Children.Add(GPIO_Screen);
                bt_Auto.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_Manual.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
                bt_Model.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void bt_History_Click(object sender, RoutedEventArgs e)
        {
                Pannel_Monitor.Children.Clear();
                Pannel_Monitor.Children.Add(History_Screen);
                bt_Auto.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_Manual.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_History.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
                bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_Model.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        private void bt_Model_Click(object sender, RoutedEventArgs e)
        {
                if (UserName != "")
                {
                    Pannel_Monitor.Children.Clear();
                    Pannel_Monitor.Children.Add(Model_Screen);
                    bt_Auto.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    bt_Manual.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    bt_Model.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
                    bt_Setting.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }
                else
                {
                    MessageBox.Show("Vui Lòng Đăng Nhập");
                }
            
        }

        private void bt_Setting_Click(object sender, RoutedEventArgs e)
        {
          
                if (UserName != "")
                {
                    Pannel_Monitor.Children.Clear();
                    Pannel_Monitor.Children.Add(Setting_Screen);
                    bt_Auto.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    bt_Manual.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    bt_History.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    bt_GPIO.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    bt_Model.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    bt_Setting.Background = new SolidColorBrush(Color.FromRgb(100, 149, 237));
                }
                else
                {
                    MessageBox.Show("Vui Lòng Đăng Nhập");
                }
            
   
        }

        private void bt_Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.LoginSuccessful += LoginWindow_LoginSuccessful;
            loginWindow.ShowDialog();
        }

        private void bt_Logout_Click(object sender, RoutedEventArgs e)
        {
            Logout();
        }
    }
}
