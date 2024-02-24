using Apply_Gule_And_Tape_PC.Class;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Apply_Gule_And_Tape_PC
{
    /// <summary>
    /// Interaction logic for GPIO.xaml
    /// </summary>
    public partial class GPIO : UserControl
    {
        private DispatcherTimer timer;
        Update_Screen update = new Update_Screen();
        public GPIO()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Dispatcher.Invoke(() =>
                {
                    Update_IO();
                  /*  Debug.Content = Data.IB0.ToString()
                    + "/" + Data.IB1.ToString()
                    + "/" + Data.IB2.ToString()
                    + "/" + Data.IB3.ToString()
                    + "/" + Data.IB4.ToString()
                    + "/" + Data.IB5.ToString()
                    + "/" + Data.IB6.ToString()
                    + "/" + Data.IB7.ToString()
                    + "/" + Data.QB0.ToString()
                    + "/" + Data.QB1.ToString()
                    + "/" + Data.QB2.ToString()
                    + "/" + Data.QB3.ToString()
                    + "/" + Data.QB4.ToString()
                    + "/" + Data.QB5.ToString()
                    + "/" + Data.QB6.ToString()
                    + "/" + Data.QB7.ToString(); */
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        void Update_IO()
        {
            bool[] I0 = ByteToBits(Data.IB0);
            update.Inout(I0_0, I0[0]);
            update.Inout(I0_1, I0[1]);
            update.Inout(I0_2, I0[2]);
            update.Inout(I0_3, I0[3]);
            update.Inout(I0_4, I0[4]);
            update.Inout(I0_5, I0[5]);
            update.Inout(I0_6, I0[6]);
            update.Inout(I0_7, I0[7]);
            //
            bool[] I1 = ByteToBits(Data.IB1);
            update.Inout(I1_0, I1[0]);
            update.Inout(I1_1, I1[1]);
            update.Inout(I1_2, I1[2]);
            update.Inout(I1_3, I1[3]);
            update.Inout(I1_4, I1[4]);
            update.Inout(I1_5, I1[5]);
            update.Inout(I1_6, I1[6]);
            update.Inout(I1_7, I1[7]);
            //
            bool[] I2 = ByteToBits(Data.IB2);
            update.Inout(I2_0, I2[0]);
            update.Inout(I2_1, I2[1]);
            update.Inout(I2_2, I2[2]);
            update.Inout(I2_3, I2[3]);
            update.Inout(I2_4, I2[4]);
            update.Inout(I2_5, I2[5]);
            update.Inout(I2_6, I2[6]);
            update.Inout(I2_7, I2[7]);
            bool[] I3 = ByteToBits(Data.IB3);
            update.Inout(I3_0, I3[0]);
            update.Inout(I3_1, I3[1]);
            update.Inout(I3_2, I3[2]);
            update.Inout(I3_3, I3[3]);
            update.Inout(I3_4, I3[4]);
            update.Inout(I3_5, I3[5]);
            update.Inout(I3_6, I3[6]);
            update.Inout(I3_7, I3[7]);
            //
            bool[] I4 = ByteToBits(Data.IB4);
            update.Inout(I4_0, I4[0]);
            update.Inout(I4_1, I4[1]);
            update.Inout(I4_2, I4[2]);
            update.Inout(I4_3, I4[3]);
            update.Inout(I4_4, I4[4]);
            update.Inout(I4_5, I4[5]);
            update.Inout(I4_6, I4[6]);
            update.Inout(I4_7, I4[7]);
            //
            bool[] I5 = ByteToBits(Data.IB5);
            update.Inout(I5_0, I5[0]);
            update.Inout(I5_1, I5[1]);
            update.Inout(I5_2, I5[2]);
            update.Inout(I5_3, I5[3]);
            update.Inout(I5_4, I5[4]);
            update.Inout(I5_5, I5[5]);
            update.Inout(I5_6, I5[6]);
            update.Inout(I5_7, I5[7]);
            //
            bool[] I6 = ByteToBits(Data.IB6);
            update.Inout(I6_0, I6[0]);
            update.Inout(I6_1, I6[1]);
            update.Inout(I6_2, I6[2]);
            update.Inout(I6_3, I6[3]);
            update.Inout(I6_4, I6[4]);
            update.Inout(I6_5, I6[5]);
            update.Inout(I6_6, I6[6]);
            update.Inout(I6_7, I6[7]);
            //
            bool[] I7 = ByteToBits(Data.IB7);
            update.Inout(I7_0, I7[0]);
            update.Inout(I7_1, I7[1]);
            update.Inout(I7_2, I7[2]);
            update.Inout(I7_3, I7[3]);
            update.Inout(I7_4, I7[4]);
            update.Inout(I7_5, I7[5]);
            update.Inout(I7_6, I7[6]);
            update.Inout(I7_7, I7[7]);
            //
            bool[] Q0 = ByteToBits(Data.QB0);
            update.Inout(Q0_0, Q0[0]);
            update.Inout(Q0_1, Q0[1]);
            update.Inout(Q0_2, Q0[2]);
            update.Inout(Q0_3, Q0[3]);
            update.Inout(Q0_4, Q0[4]);
            update.Inout(Q0_5, Q0[5]);
            update.Inout(Q0_6, Q0[6]);
            update.Inout(Q0_7, Q0[7]);
            //
            bool[] Q1 = ByteToBits(Data.QB1);
            update.Inout(Q1_0, Q1[0]);
            update.Inout(Q1_1, Q1[1]);
            update.Inout(Q1_2, Q1[2]);
            update.Inout(Q1_3, Q1[3]);
            update.Inout(Q1_4, Q1[4]);
            update.Inout(Q1_5, Q1[5]);
            update.Inout(Q1_6, Q1[6]);
            update.Inout(Q1_7, Q1[7]);
            //
            bool[] Q2 = ByteToBits(Data.QB2);
            update.Inout(Q2_0, Q2[0]);
            update.Inout(Q2_1, Q2[1]);
            update.Inout(Q2_2, Q2[2]);
            update.Inout(Q2_3, Q2[3]);
            update.Inout(Q2_4, Q2[4]);
            update.Inout(Q2_5, Q2[5]);
            update.Inout(Q2_6, Q2[6]);
            update.Inout(Q2_7, Q2[7]);
            //
            bool[] Q3 = ByteToBits(Data.QB3);
            update.Inout(Q3_0, Q3[0]);
            update.Inout(Q3_1, Q3[1]);
            update.Inout(Q3_2, Q3[2]);
            update.Inout(Q3_3, Q3[3]);
            update.Inout(Q3_4, Q3[4]);
            update.Inout(Q3_5, Q3[5]);
            update.Inout(Q3_6, Q3[6]);
            update.Inout(Q3_7, Q3[7]);
            //
            bool[] Q4 = ByteToBits(Data.QB4);
            update.Inout(Q4_0, Q4[0]);
            update.Inout(Q4_1, Q4[1]);
            update.Inout(Q4_2, Q4[2]);
            update.Inout(Q4_3, Q4[3]);
            update.Inout(Q4_4, Q4[4]);
            update.Inout(Q4_5, Q4[5]);
            update.Inout(Q4_6, Q4[6]);
            update.Inout(Q4_7, Q4[7]);
            //
            bool[] Q5 = ByteToBits(Data.QB5);
            update.Inout(Q5_0, Q5[0]);
            update.Inout(Q5_1, Q5[1]);
            update.Inout(Q5_2, Q5[2]);
            update.Inout(Q5_3, Q5[3]);
            update.Inout(Q5_4, Q5[4]);
            update.Inout(Q5_5, Q5[5]);
            update.Inout(Q5_6, Q5[6]);
            update.Inout(Q5_7, Q5[7]);
            //
            bool[] Q6 = ByteToBits(Data.QB6);
            update.Inout(Q6_0, Q6[0]);
            update.Inout(Q6_1, Q6[1]);
            update.Inout(Q6_2, Q6[2]);
            update.Inout(Q6_3, Q6[3]);
            update.Inout(Q6_4, Q6[4]);
            update.Inout(Q6_5, Q6[5]);
            update.Inout(Q6_6, Q6[6]);
            update.Inout(Q6_7, Q6[7]);
            //
            bool[] Q7 = ByteToBits(Data.QB7);
            update.Inout(Q7_0, Q7[0]);
            update.Inout(Q7_1, Q7[1]);
            update.Inout(Q7_2, Q7[2]);
            update.Inout(Q7_3, Q7[3]);
            update.Inout(Q7_4, Q7[4]);
            update.Inout(Q7_5, Q7[5]);
            update.Inout(Q7_6, Q7[6]);
            update.Inout(Q7_7, Q7[7]);
        }
        static bool[] ByteToBits(uint value)
        {
            bool[] bits = new bool[10];

            for (int i = 0; i < 8; i++)
            {
                bits[i] = (value & (1 << i)) != 0;
            }
            return bits;
        }

    }
}
