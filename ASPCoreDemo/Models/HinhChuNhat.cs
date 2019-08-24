using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreDemo.Models
{
    public class HinhChuNhat
    {
        //Field
        private double dai;

        //C# fieild ==> Property
        public double Dai
        {
            get { return dai; }
            set
            {
                if (value > 0)
                    dai = value;
                else throw new Exception("Dài âm");
            }
        }

        //public double Dai1 { get => dai; set => dai = value; }

        //Automatic Property
        public double Rong { get; set; }

        //Property dạng get
        public double DienTich => Dai * Rong;
        public double ChuVi => 2 * (Dai + Rong);

        public string Xuat()
        {
            return $"HCN Dài {Dai}, rộng {Rong} có diện tích {DienTich}, chu vi {ChuVi}";
        }

        public override string ToString()
        {
            return $"HCN Dài {Dai}, rộng {Rong} có diện tích {DienTich}, chu vi {ChuVi}";
        }
    }
}
