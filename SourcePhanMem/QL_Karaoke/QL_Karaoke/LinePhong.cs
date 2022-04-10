using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Karaoke
{
    public class LinePhong
    {
        public int Gio { get; set; }
        public int Phut { get; set; }

        public LinePhong()
        {

        }
        public LinePhong(double thoiGian)
        {
            var tg = LayGio(thoiGian);
            Gio = (int)tg;
            Phut = (int)((tg - Math.Truncate(tg)) * 60);
        }
        public double LayGio (double thoiGian)
        {
            return Math.Round(thoiGian, 1);
        }
        public override string ToString()
        {
            return string.Format("{0} : {1}", Gio, Phut);
        }
        public int ThanhTien(double thoiGian,int donGia)
        {
            return (int)(LayGio(thoiGian) * donGia);
        }
    }
}
