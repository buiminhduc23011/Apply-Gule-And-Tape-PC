using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apply_Gule_And_Tape_PC.Class
{
    public class DataView_Mode3
    {
        public int STT { get; set; }
        public string Model { get; set; }
        public string RotoID { get; set; }
    }
    public class List_Model_Mode3
    {
        public string Model { get; set; }
        public string Code { get; set; }
        public float Pos_XBase_Start { get; set; }
        public float Pos_YBase_Start { get; set; }
        public float D_Roto { get; set; }
        public float L_Roto { get; set; }
        public float Dis_Step { get; set; }
        public float F_D { get; set; }
        public float K {  get; set; } // Số vòng quay thêm ở cuối
        public float OF_Xbase { get; set; } // Quay lại vị trí hàn
        public float OF_Rotate { get; set; } // Quay thêm để đúng điểm hàn
    }
    public class List_Model_Mode3_Temp
    {
        public string Model { get; set; }
        public string Code { get; set; }
        public float Pos_XBase_Start { get; set; }
        public float Pos_YBase_Start { get; set; }
        public float D_Roto { get; set; }
        public float L_Roto { get; set; }
        public float Dis_Step { get; set; }
        public float F_D { get; set; }
        public float K { get; set; } // Số vòng quay thêm ở cuối
        public float OF_Xbase { get; set; } // Quay lại vị trí hàn
        public float OF_Rotate { get; set; } // Quay thêm để đúng điểm hàn
    }
    public class Mode_3
    {
    }
}
