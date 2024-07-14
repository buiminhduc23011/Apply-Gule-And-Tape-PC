using Apply_Gule_And_Tape_PC.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Apply_Gule_And_Tape_PC

{
    /// <summary>
    /// Interaction logic for Manual.xaml
    /// </summary>
    /// 
    

    public partial class Manual : UserControl
    {
        private DispatcherTimer timer;
        Common Common = new Common();
        Update_Screen ud = new Update_Screen();
        PLC plc = new PLC();
        private static bool is_Forcus = false;
        public Manual()
        {
            InitializeComponent();
            Loaded += Manual_Loaded;  // Thêm sự kiện Loaded
            Unloaded += Manual_Unloaded;
            
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

        private void Manual_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            timer.Start();
            foreach (var button in Common.FindVisualChildren<Button>(this))
            {
                button.AddHandler(TouchDownEvent, new EventHandler<TouchEventArgs>(Button_TouchDown), true);
                button.AddHandler(TouchUpEvent, new EventHandler<TouchEventArgs>(Button_TouchUp), true);
                button.AddHandler(TouchLeaveEvent, new EventHandler<TouchEventArgs>(Button_TouchLeave), true);
                button.Click += Button_Click;
            }
            foreach (var textBox in Common.FindVisualChildren<TextBox>(this))
            {
                textBox.PreviewTextInput += PreviewTextInput;
                textBox.TextChanged += TextBox_TextChanged;
                // Đăng ký sự kiện GotFocus
                textBox.GotFocus += TextBox_GotFocus;
                textBox.LostFocus += TextBox_LostFocus;
            }
        }
        private void Manual_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
        private void Update_Screen()
        {
            ud.bt_Blue(Org_X_RB, Data.Org_X_RB, false);
            ud.bt_Blue(Org_Y_RB, Data.Org_Y_RB, false);
            ud.bt_Blue(Org_Z_RB, Data.Org_Z_RB, false);
            ud.bt_Blue(J_P_X_RB, Data.J_P_X_RB, false);
            ud.bt_Blue(J_N_X_RB, Data.J_N_X_RB, false);
            ud.bt_Blue(J_P_Y_RB, Data.J_P_Y_RB, false);
            ud.bt_Blue(J_N_Y_RB, Data.J_N_Y_RB, false);
            ud.bt_Blue(J_P_Z_RB, Data.J_P_Z_RB, false);
            ud.bt_Blue(J_N_Z_RB, Data.J_N_Z_RB, false);
            ud.bt_Blue(ON_X_RB, Data.ON_X_RB, false);
            ud.bt_Blue(ON_Y_RB, Data.ON_Y_RB, false);
            ud.bt_Blue(ON_Z_RB, Data.ON_Z_RB, false);
            ud.bt_Blue(ON_Gule, Data.ON_Gule, false);
            ud.bt_Blue(OFF_Gule, Data.ON_Gule, true);
            // Manual PLC2
            ud.bt_Blue(Org_X_Base, Data.Org_X_Base, false);
            ud.bt_Blue(Org_Y_Base, Data.Org_Y_Base, false);
            ud.bt_Blue(Org_Xoay, Data.Org_Xoay, false);
            ud.bt_Blue(J_P_X_Base, Data.J_P_X_Base, false);
            ud.bt_Blue(J_N_X_Base, Data.J_N_X_Base, false);
            ud.bt_Blue(J_P_Y_Base, Data.J_P_Y_Base, false);
            ud.bt_Blue(J_N_Y_Base, Data.J_N_Y_Base, false);
            ud.bt_Blue(J_P_Rotate, Data.J_P_Rotate, false);
            ud.bt_Blue(J_N_Rotate, Data.J_N_Rotate, false);
            ud.bt_Blue(ON_X_Base, Data.ON_X_Base, false);
            ud.bt_Blue(ON_Y_Base, Data.ON_Y_Base, false);
            ud.bt_Blue(ON_Rotate, Data.ON_Rotate, false);
            ud.bt_Blue(ON_Cyl_Cut, Data.ON_Cyl_Cut, false);
            ud.bt_Blue(OFF_Cyl_Cut, Data.ON_Cyl_Cut, true);
            ud.bt_Blue(ON_Cut, Data.ON_Cut, false);
            ud.bt_Blue(ON_Cyl_Weld, Data.ON_Cyl_Weld, false);
            ud.bt_Blue(OFF_Cyl_Weld, Data.ON_Cyl_Weld, true);
            ud.bt_Blue(ON_Cyl_Press, Data.ON_Cyl_Press, false);
            ud.bt_Blue(OFF_Cyl_Press, Data.ON_Cyl_Press, true);
            ud.bt_Blue(ON_Cyl_Press_2, Data.ON_Cyl_Press_2, false);
            ud.bt_Blue(OFF_Cyl_Press_2, Data.ON_Cyl_Press_2, true);
            ud.bt_Blue(ON_Cyl_Center, Data.ON_Cyl_Center, false);
            ud.bt_Blue(OFF_Cyl_Center, Data.ON_Cyl_Center, true);

            if (!is_Forcus)
            {
                Vel_X_RB.Text = Data.Vel_X_RB.ToString();
                Vel_Y_RB.Text = Data.Vel_Y_RB.ToString();
                Vel_Z_RB.Text = Data.Vel_Z_RB.ToString();
                Vel_X_Base.Text = Data.Vel_X_Base.ToString();
                Vel_Y_Base.Text = Data.Vel_Y_Base.ToString();
                Vel_Rotate.Text = Data.Vel_Rotate.ToString();
            }
        }

        private void Button_TouchDown(object sender, TouchEventArgs e)
        {
            string buttonName = ((Button)sender).Name;
            if (buttonName != "")
            {
                if (Is_String(buttonName, "J_P", "J_N"))
                {
                    var data = new Dictionary<string, object>
                        {
                            { buttonName, true }
                        };
                    string jsonData = JsonConvert.SerializeObject(data);
                    plc.Write(jsonData);
                }
            }
        }
        private void Button_TouchUp(object sender, TouchEventArgs e)
        {
            string buttonName = ((Button)sender).Name;
            if (buttonName != "")
            {
                if (Is_String(buttonName, "J_P", "J_N"))
                {
                    var data = new Dictionary<string, object>
                        {
                            { buttonName, false }
                        };
                    string jsonData = JsonConvert.SerializeObject(data);
                    plc.Write(jsonData);
                }
            }
        }
        private void Button_TouchLeave(object sender, TouchEventArgs e)
        {
            string buttonName = ((Button)sender).Name;
            if (buttonName != "")
            {
                if (Is_String(buttonName, "J_P", "J_N"))
                {
                    var data = new Dictionary<string, object>
                        {
                            { buttonName, false }
                        };
                    string jsonData = JsonConvert.SerializeObject(data);
                    plc.Write(jsonData);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string buttonName = ((Button)sender).Name;
                if (buttonName != "")
                {
                    if (!Is_String(buttonName, "J_P", "J_N"))
                    {
                        bool newValue = !ColorChecker.IsColorEqual(((Button)sender).Background, Color.FromRgb(100, 149, 237));
                        var data = new Dictionary<string, object>
                        {
                            { buttonName, newValue }
                        };
                        string jsonData = JsonConvert.SerializeObject(data);
                        plc.Write(jsonData);
                    }

                }
            }
            catch
            {

            }
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            // If the text is null or empty, replace it with "0"
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
                textBox.SelectAll(); // Select all text to allow easy replacement
            }

            // Check for multiple dots and handle non-numeric characters
            if (e.Text == "." && textBox.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string textboxName = textBox.Name;

            if (double.TryParse(textBox.Text, out double doubleValue))
            {
                var data = new Dictionary<string, object>
                    {
                        { textboxName, doubleValue }
                    };

                string jsonData = JsonConvert.SerializeObject(data);
                plc.Write(jsonData);
            }
            else
            {
                // Xử lý khi không thể chuyển đổi sang kiểu double
            }
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            is_Forcus = true;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
            is_Forcus = false;
        }

        private static bool Is_String(string input, string Compari_1, string Compari_2)
        {
            return input.Contains(Compari_1) || input.Contains(Compari_2);
        }

    }

}
