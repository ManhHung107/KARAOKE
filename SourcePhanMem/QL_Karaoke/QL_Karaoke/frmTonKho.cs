using QL_Karaoke.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Karaoke
{
    public partial class frmTonKho : Form
    {
        public frmTonKho()
        {
            InitializeComponent();
        }
        private DataClasses1DataContext db;
        private void frmTonKho_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            btnThongKe.PerformClick();

            dgvTonKho.Columns["mahang"].HeaderText = "Mã hàng";
            dgvTonKho.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvTonKho.Columns["dvt"].HeaderText = "ĐVT";
            dgvTonKho.Columns["tonkho"].HeaderText = "Tồn kho";

            dgvTonKho.Columns["isDichVu"].Visible = false;
            dgvTonKho.Columns["dg"].Visible = false;

            dgvTonKho.Columns["mahang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTonKho.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTonKho.Columns["tonkho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvTonKho.Columns["tonkho"].DefaultCellStyle.Format = "N0";

            dgvTonKho.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }
        

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if(rbtTatca.Checked)
            {
                ThongKe(1);
                return;
            }    
            if(rbtdaHet.Checked)
            {
                ThongKe(0);
                return;
            }    
            if(rbtGanHet.Checked)
            {
                ThongKe(-1);
                return;
            }
            
        }
        private void ThongKe(int dieuKien)
        {
            #region ton_kho_cha
            var details = from ct in db.ChiTietHoaDonNhaps
                          join hd in db.HoaDonNhaps.Where(x => x.DaNhap == 1)
                          on ct.IDHoaDon equals hd.ID
                          select new
                          {
                              mahang = ct.IDMatHang,
                              sl = ct.SoLuong
                          };

            var nhapCha = from ct in details.GroupBy(x => x.mahang)
                          join h in db.MatHangs.Where(x => x.IdCha == null || x.IdCha <= 0) on ct.First().mahang equals h.ID
                          join d in db.DonViTinhs on h.IDDVT equals d.ID
                          select new
                          {

                              mahang = ct.First().mahang,
                              tenhang = h.TenMatHang,
                              dvt = d.TenDVT,
                              dg = h.DonGiaBan,
                              soluong = ct.Sum(x => x.sl)
                          };

            var xuatCha = from p in db.ChiTietHoaDonBanHangs.GroupBy(x => x.IDMatHang)
                          join h in db.MatHangs.Where(x => x.IdCha == null || x.IdCha <= 0 && x.isDichVu == false)
                          on p.First().IDMatHang equals h.ID
                          select new
                          {
                              mahang = h.ID,
                              soluong = p.Sum(x => x.SL)
                          };

            var xuatQuyRaCha = from ct in db.ChiTietHoaDonBanHangs.GroupBy(x => x.IDMatHang)
                               join h in db.MatHangs.Where(x => x.IdCha >= 0) on ct.First().IDMatHang equals h.ID
                               select new
                               {
                                   mahang = (int)h.IdCha,
                                   soluong = ct.Sum(x => x.SL) % h.Tile == 0 ? ct.Sum(x => x.SL) / h.Tile : ct.Sum(x => x.SL) / h.Tile + 1
                               };

            var tongXuatCha = from xc in xuatCha.Union(xuatQuyRaCha).GroupBy(x => x.mahang)
                              select new
                              {
                                  mahang = xc.First().mahang,
                                  soluong = xc.Sum(x => x.soluong)
                              };

            var tonKhoCha = from p in nhapCha
                            join q in tongXuatCha on p.mahang equals q.mahang into tmp
                            from t in tmp.DefaultIfEmpty()
                            select new
                            {
                                mahang = p.mahang,
                                tenhang = p.tenhang,
                                isDichvu = 0,
                                dvt = p.dvt,
                                dg = p.dg,
                                tonkho = (int)(p.soluong - (t == null ? 0 : t.soluong))
                            };
            #endregion

            #region ton_kho_con
            var nhapCon = from ct in nhapCha
                          join h in db.MatHangs on ct.mahang equals h.IdCha
                          join d in db.DonViTinhs on h.IDDVT equals d.ID
                          select new
                          {
                              mahang = h.ID,
                              tenhang = h.TenMatHang,
                              dvt = d.TenDVT,
                              dg = h.DonGiaBan,
                              soluong = ct.soluong * h.Tile
                          };

            var xuatConQuyTuCha = from xc in xuatCha
                                  join h in db.MatHangs.Where(x => x.IdCha > 0)
                                  on xc.mahang equals h.IdCha
                                  select new
                                  {
                                      mahang = h.ID,
                                      soluong = xc.soluong * h.Tile
                                  };

            var xuatCon = from ct in db.ChiTietHoaDonBanHangs.GroupBy(x => x.IDMatHang)
                          join h in db.MatHangs.Where(x => x.IdCha > 0 && x.isDichVu == false)
                          on ct.First().IDMatHang equals h.ID
                          select new
                          {
                              mahang = h.ID,
                              soluong = ct.Sum(x => x.SL)
                          };

            var tongXuatCon = from ct in xuatConQuyTuCha.Union(xuatCon).GroupBy(x => x.mahang)
                              select new
                              {
                                  mahang = ct.First().mahang,
                                  slxuat = ct.Sum(x => x.soluong)
                              };

            var tonKhoCon = from nc in nhapCon
                            join xc in tongXuatCon on nc.mahang equals xc.mahang into tmp
                            from x in tmp.DefaultIfEmpty()
                            select new
                            {
                                mahang = nc.mahang,
                                tenhang = nc.tenhang,
                                isDichvu = 0,
                                dvt = nc.dvt,
                                dg = nc.dg,
                                tonkho = (int)(nc.soluong - (x == null ? 0 : x.slxuat))
                            };
            #endregion

            var tonkhoHang = tonKhoCha.Concat(tonKhoCon).OrderBy(x => x.tenhang);

            if(dieuKien == 0)
            {
                var result = tonkhoHang.Where(x => x.tonkho == 0);
                dgvTonKho.DataSource = result;
                return;
            }  
            if(dieuKien == 1)
            {
                dgvTonKho.DataSource = tonkhoHang;
                return;
            }    
            if(dieuKien == -1)
            {
                var ganhet = int.Parse(db.CauHinhs.SingleOrDefault(x => x.tukhoa == "ganhet").giatri);
                var result = tonkhoHang.Where(x => x.tonkho <= ganhet && x.tonkho != 0);
                dgvTonKho.DataSource = result;
                return;
            }    
            

        }

    }
}
