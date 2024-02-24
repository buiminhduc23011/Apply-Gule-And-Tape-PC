using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Apply_Gule_And_Tape_PC.Class;

namespace Apply_Gule_And_Tape_PC
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static string Username = "";
        public string Password = "";
        Link_Path path = new Link_Path();
        public bool Is_Login = false;
        public event EventHandler LoginSuccessful;
        public class Data
        {
            public string Name { get; set; }
        }
        public LoginWindow()
        {
            InitializeComponent();
            string json_ = File.ReadAllText(path.User_List);
            List<Data> dataList = JsonConvert.DeserializeObject<List<Data>>(json_);

            List<string> names = dataList.Select(item => item.Name).ToList();
            txtUsername.ItemsSource = names;
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Username = txtUsername.Text;
            Password = txtPassword.Password;

            try
            {
                string json = File.ReadAllText(path.User_List);
                if (json.Length > 0)
                {
                    JArray jsonArray = JArray.Parse(json);
                    foreach (JObject obj in jsonArray)
                    {
                        if ((string)obj["Name"] == Username && (string)obj["Pass"] == Password)
                        {
                            Is_Login = true;
                            MainWindow.UserName = Username;
                            LoginSuccessful?.Invoke(this, EventArgs.Empty);
                            Close();
                            break;
                        }
                    }
                    if (!Is_Login) MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng");
                    else
                    {
                    }
                }
            }
            catch { }
        }
    }
}
