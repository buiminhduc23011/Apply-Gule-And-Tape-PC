using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;

namespace Apply_Gule_And_Tape_PC.Class
{
    public class Items_Error
    {
        public int STT { get; set; }
        public string Content_ { get; set; }
        public string Time { get; set; }

    }
    public class Items_Alarm
    {
        public int STT { get; set; }
        public string Content_ { get; set; }
        public string Time { get; set; }
    }
    public class Link_Path
    {
        public string Setting = System.IO.Path.Combine("Path", "scnn.ini");
        public string Mode2 = System.IO.Path.Combine("Model", "Mode2.json");
        public string Mode3 = System.IO.Path.Combine("Model", "Mode3.json");
        public string Error = System.IO.Path.Combine("Path", "Error.json");
        public string Alarm = System.IO.Path.Combine("Path", "Alarm.json");
        public string List_Error = System.IO.Path.Combine("Path", "List_Error.ini");
        public string List_Alarm = System.IO.Path.Combine("Path", "List_Alarm.ini");
        public string User_List = System.IO.Path.Combine("Path", "UserCredentials.json");

    }
    public class ColorChecker
    {
        public static bool IsColorEqual(Brush brush, Color targetColor)
        {
            if (brush != null)
            {
                if (brush is SolidColorBrush solidColorBrush)
                {
                    Color brushColor = solidColorBrush.Color;
                    return brushColor.R == targetColor.R && brushColor.G == targetColor.G && brushColor.B == targetColor.B;
                }
                // Handle other types of brushes if needed
            }

            return false;
        }
    }
    public class Common
    {
        Link_Path linkpath = new Link_Path();
        public void Load_View_Mode2(DataGrid dataGrid)
        {
            List<DataView_Mode2> items = new List<DataView_Mode2>();
            int index = 1;
            try
            {
                string List_Show = File.ReadAllText(linkpath.Mode2);
                if (List_Show.Length > 0)
                {
                    JArray List_Show_array = JArray.Parse(List_Show);
                    foreach (JObject obj in List_Show_array)
                    {
                        items.Add(new DataView_Mode2 { STT = index, Model = (string)obj["Model"], RotoID = (string)obj["Code"] });
                        index++;
                    }
                    dataGrid.ItemsSource = items;
                }
            }
            catch
            {

            }
        }
        public void Load_View_Mode3(DataGrid dataGrid)
        {
            List<DataView_Mode3> items = new List<DataView_Mode3>();
            int index = 1;
            try
            {
                string List_Show = File.ReadAllText(linkpath.Mode3);
                if (List_Show.Length > 0)
                {
                    JArray List_Show_array = JArray.Parse(List_Show);
                    foreach (JObject obj in List_Show_array)
                    {
                        items.Add(new DataView_Mode3 { STT = index, Model = (string)obj["Model"], RotoID = (string)obj["Code"] });
                        index++;
                    }
                    dataGrid.ItemsSource = items;
                }
            }
            catch
            {

            }
        }
        public void SetEmptyTextBoxToZero(TextBox TextBox)
        {
            foreach (var textBox in FindVisualChildren<TextBox>(TextBox))
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    textBox.Text = "0";
                }
            }
        }
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
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
    }
}
