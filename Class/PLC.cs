using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading;
using System.Windows;
using System.IO;

namespace Apply_Gule_And_Tape_PC.Class
{
    public class PLC
    {
        static string Task = "PLC Task: ";
        Link_Path path = new Link_Path();
        public static dynamic data_;
        public static bool flag = false;
        private static HttpClient client = new HttpClient();
        public static bool IsConnected;
        public static string Hostting_;
        private System.Threading.Timer timer;
        private readonly object timerLock = new object();
        //
        public static string PLC_Read;
        public static string PLC_Write;
        private int Flag_PLC;


        public void StartTimer()
        {
            timer = new System.Threading.Timer(Timer_Tick, null, 0, 200);
            string json = File.ReadAllText(path.Setting);
            var data_Setting = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            PLC_Read = data_Setting["PLC_Read"];
            PLC_Write = data_Setting["PLC_Write"];
        }

        public void StopTimer()
        {
            lock (timerLock)
            {
                timer?.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }

        private async void Timer_Tick(object state)
        {
            if (Flag_PLC > 3)
            {
                IsConnected = false;
            }
            else
            {
                IsConnected = true;
            }    
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string response = await client.GetStringAsync("http://" + PLC_Read + "/api/data");
                    data_ = JsonConvert.DeserializeObject<dynamic>(response);
                    if (data_ != null)
                    {
                        Parse_Data(data_);
                    }
                    Flag_PLC = 0;
                }
            }
            catch
            {
                Flag_PLC++;
            }
        }

        private void Parse_Data(dynamic data)
        {
            try
            {
                // Input
                Data.IB0 = data.IB0;
                Data.IB1 = data.IB1;
                Data.IB2 = data.IB2;
                Data.IB3 = data.IB3;
                Data.IB4 = data.IB4;
                Data.IB5 = data.IB5;
                Data.IB6 = data.IB6;
                Data.IB7 = data.IB7;

                // Output
                Data.QB0 = data.QB0;
                Data.QB1 = data.QB1;
                Data.QB2 = data.QB2;
                Data.QB3 = data.QB3;
                Data.QB4 = data.QB4;
                Data.QB5 = data.QB5;
                Data.QB6 = data.QB6;
                Data.QB7 = data.QB7;
                //
                Data.Pos_X = data.Pos_X;
                Data.Pos_Y = data.Pos_Y;
                Data.Pos_Z = data.Pos_Z;
                Data.Pos_XBase = data.Pos_XBase;
                Data.Pos_YBase = data.Pos_YBase;
                Data.Pos_Rotate = data.Pos_Rotate;
                Data.Flag_Org = data.Flag_Org;
                Data.Error = data.Error;
                Data.Alarm = data.Alarm;
                Data.S_Machine = data.S_Machine;
                Data.S_AM = data.S_AM;
                //Ctr
                Data.Reset = data.Reset;
                // Manual PLC1
                Data.Org_X_RB = data.Org_X_RB;
                Data.Org_Y_RB = data.Org_Y_RB;
                Data.Org_Z_RB = data.Org_Z_RB;
                Data.J_P_X_RB = data.J_P_X_RB;
                Data.J_N_X_RB = data.J_N_X_RB;
                Data.Vel_X_RB = data.Vel_X_RB;
                Data.J_P_Y_RB = data.J_P_Y_RB;
                Data.J_N_Y_RB = data.J_N_Y_RB;
                Data.Vel_Y_RB = data.Vel_Y_RB;
                Data.J_P_Z_RB = data.J_P_Z_RB;
                Data.J_N_Z_RB = data.J_N_Z_RB;
                Data.Vel_Z_RB = data.Vel_Z_RB;
                Data.ON_X_RB = data.ON_X_RB;
                Data.ON_Y_RB = data.ON_Y_RB;
                Data.ON_Z_RB = data.ON_Z_RB;
                Data.ON_Gule = data.ON_Gule;
                Data.OFF_Gule = data.OFF_Gule;

                // Manual PLC2
                Data.Org_X_Base = data.Org_X_Base;
                Data.Org_Y_Base = data.Org_Y_Base;
                Data.Org_Xoay = data.Org_Xoay;
                Data.J_P_X_Base = data.J_P_X_Base;
                Data.J_N_X_Base = data.J_N_X_Base;
                Data.Vel_X_Base = data.Vel_X_Base;
                Data.J_P_Y_Base = data.J_P_Y_Base;
                Data.J_N_Y_Base = data.J_N_Y_Base;
                Data.Vel_Y_Base = data.Vel_Y_Base;
                Data.J_P_Rotate = data.J_P_Rotate;
                Data.J_N_Rotate = data.J_N_Rotate;
                Data.Vel_Rotate = data.Vel_Rotate;
                Data.ON_X_Base = data.ON_X_Base;
                Data.ON_Y_Base = data.ON_Y_Base;
                Data.ON_Rotate = data.ON_Rotate;
                Data.ON_Cyl_Cut = data.ON_Cyl_Cut;
                Data.OFF_Cyl_Cut = data.OFF_Cyl_Cut;
                Data.ON_Cut = data.ON_Cut;
                Data.ON_Cyl_Weld = data.ON_Cyl_Weld;
                Data.OFF_Cyl_Weld = data.OFF_Cyl_Weld;
                Data.ON_Cyl_Press = data.ON_Cyl_Press;
                Data.OFF_Cyl_Press = data.OFF_Cyl_Press;
                Data.ON_Cyl_Press_2 = data.ON_Cyl_Press_2;
                Data.OFF_Cyl_Press_2 = data.OFF_Cyl_Press_2;
                Data.ON_Cyl_Center = data.ON_Cyl_Center;
                Data.OFF_Cyl_Center = data.OFF_Cyl_Center;

                // Model 1
                Data.ON_Mode1 = data.ON_Mode1;
                Data.M1_Req = data.M1_Req;
                Data.M1_Jig1 = data.M1_Jig1;
                Data.M1_Jig2 = data.M1_Jig2;
                Data.Step_Target = data.Step_Target;
                Data.Step_Process_Target = data.Step_Process_Target;
                Data.G_Step = data.G_Step;
                //Mode2
                Data.ON_Mode2 = data.ON_Mode2;
                //Mode2
                Data.ON_Mode3 = data.ON_Mode3;
                //Para
                Data.J1_X_Of = data.J1_X_Of;
                Data.J1_Y_Of = data.J1_Y_Of;
                Data.J1_Z_Of = data.J1_Z_Of;
                Data.J2_X_Of = data.J2_X_Of;
                Data.J2_Y_Of = data.J2_Y_Of;
                Data.J2_Z_Of = data.J2_Z_Of;
                //
                Data.Off_Buzzer = data.Off_Buzzer;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public async void Write(string jsonData)
        {
            try
            {
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://" + PLC_Write + "/api/Control_PLC_1", content);
                //var responseContent = await response.Content.ReadAsStringAsync();
            }
            catch
            {

            }
        }
    }
}
