using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apply_Gule_And_Tape_PC.Class
{
    public class Data
    {
        // Input
        public static uint IB0 { get; set; }
        public static uint IB1 { get; set; }
        public static uint IB2 { get; set; }
        public static uint IB3 { get; set; }
        public static uint IB4 { get; set; }
        public static uint IB5 { get; set; }
        public static uint IB6 { get; set; }
        public static uint IB7 { get; set; }

        // Output
        public static uint QB0 { get; set; }
        public static uint QB1 { get; set; }
        public static uint QB2 { get; set; }
        public static uint QB3 { get; set; }
        public static uint QB4 { get; set; }
        public static uint QB5 { get; set; }
        public static uint QB6 { get; set; }
        public static uint QB7 { get; set; }
        // Machine Status
        public static double Pos_X { get; set; }
        public static double Pos_Y { get; set; }
        public static double Pos_Z { get; set; }
        public static double Pos_XBase { get; set; }
        public static double Pos_YBase { get; set; }
        public static double Pos_Rotate { get; set; }
        public static int Error { get; set; }
        public static int Alarm { get; set; }
        public static bool Flag_Org { get; set; }
        public static uint S_Machine { get; set; }
        public static bool S_AM { get; set; }

        //Ctr
        public static bool Reset { get; set; }
        // Manual PLC1
        public static bool Org_X_RB { get; set; }
        public static bool Org_Y_RB { get; set; }
        public static bool Org_Z_RB { get; set; }
        public static bool J_P_X_RB { get; set; }
        public static bool J_N_X_RB { get; set; }
        public static double Vel_X_RB { get; set; }
        public static bool J_P_Y_RB { get; set; }
        public static bool J_N_Y_RB { get; set; }
        public static double Vel_Y_RB { get; set; }
        public static bool J_P_Z_RB { get; set; }
        public static bool J_N_Z_RB { get; set; }
        public static double Vel_Z_RB { get; set; }
        public static bool ON_X_RB { get; set; }
        public static bool ON_Y_RB { get; set; }
        public static bool ON_Z_RB { get; set; }
        public static bool ON_Gule { get; set; }
        public static bool OFF_Gule { get; set; }

        // Manual PLC2
        public static bool Org_X_Base { get; set; }
        public static bool Org_Y_Base { get; set; }
        public static bool Org_Xoay { get; set; }
        public static bool J_P_X_Base { get; set; }
        public static bool J_N_X_Base { get; set; }
        public static double Vel_X_Base { get; set; }
        public static bool J_P_Y_Base { get; set; }
        public static bool J_N_Y_Base { get; set; }
        public static double Vel_Y_Base { get; set; }
        public static bool J_P_Rotate { get; set; }
        public static bool J_N_Rotate { get; set; }
        public static double Vel_Rotate { get; set; }
        public static double Vel_Brake { get; set; }
        public static bool ON_X_Base { get; set; }
        public static bool ON_Y_Base { get; set; }
        public static bool ON_Rotate { get; set; }
        public static bool ON_Cyl_Cut { get; set; }
        public static bool OFF_Cyl_Cut { get; set; }
        public static bool ON_Cut { get; set; }
        public static bool ON_Cyl_Weld { get; set; }
        public static bool OFF_Cyl_Weld { get; set; }
        public static bool ON_Cyl_Press { get; set; }
        public static bool OFF_Cyl_Press { get; set; }
        public static bool ON_Cyl_Press_2 { get; set; }
        public static bool OFF_Cyl_Press_2 { get; set; }
        public static bool ON_Cyl_Center { get; set; }
        public static bool OFF_Cyl_Center { get; set; }

        // Model 1
        public static bool ON_Mode1 { get; set; }
        public static bool M1_Req { get; set; }
        public static bool M1_Jig1 { get; set; }
        public static bool M1_Jig2 { get; set; }
        public static int Step_Target { get; set; }
        public static int Step_Process_Target { get; set; }
        public static int G_Step { get; set; }
        //Mode2
        public static bool ON_Mode2 { get; set; }
        //Mode3
        public static bool ON_Mode3 { get; set; }
        public static double J1_X_Of { get; set; }
        public static double J1_Y_Of { get; set; }
        public static double J1_Z_Of { get; set; }
        public static double J2_X_Of { get; set; }
        public static double J2_Y_Of { get; set; }
        public static double J2_Z_Of { get; set; }
        //Para
        public static bool Off_Buzzer { get; set; }
    }


}

