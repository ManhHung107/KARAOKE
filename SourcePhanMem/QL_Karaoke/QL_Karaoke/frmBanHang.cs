using QL_Karaoke.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Karaoke
{
    public partial class frmBanHang : Form
    {
        public frmBanHang()
        {
            InitializeComponent();
        }
        private DataClasses1DataContext db;
        private ListView lv;
        private ImageList imgl;
        private string nhanvien = "admin";
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            var dsLoaiPhong = db.LoaiPhongs;
            foreach (var l in dsLoaiPhong)
            {
                TabPage tp = new TabPage(l.TenLoaiPhong);
                tp.Name = l.ID.ToString();
                tbcContent.Controls.Add(tp);
            }
            idLoaiPhong = db.LoaiPhongs.Min(x => x.ID);
            LoadPhong(idLoaiPhong, tabIndex);
            #region ds_mat_hang
            ShowMatHang();
            dgvDSMatHang.Columns["mahang"].Visible = false;
            dgvDSMatHang.Columns["isDichvu"].Visible = false;
            dgvDSMatHang.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvDSMatHang.Columns["dvt"].HeaderText = "ĐVT";
            dgvDSMatHang.Columns["tonkho"].HeaderText = "Tồn kho";
            dgvDSMatHang.Columns["dg"].HeaderText = "Giá";
            dgvDSMatHang.Columns["tonkho"].HeaderText = "Tồn";

            dgvDSMatHang.Columns["dvt"].Width = 50;
            dgvDSMatHang.Columns["dg"].Width = 70;
            dgvDSMatHang.Columns["tonkho"].Width = 70;
            dgvDSMatHang.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDSMatHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDSMatHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDSMatHang.Columns["tonkho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDSMatHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvDSMatHang.Columns["tonkho"].DefaultCellStyle.Format = "N0";
            #endregion
            ShowLSGD();
            dgvLSGD.Columns["idHoaDon"].Visible = false;
            dgvLSGD.Columns["phong"].HeaderText = "Phòng";
            dgvLSGD.Columns["tgBatDau"].HeaderText = "Bắt đầu";
            dgvLSGD.Columns["tgKetThuc"].HeaderText = "Kết thúc";
            dgvLSGD.Columns["sotien"].HeaderText = "Số tiền";
            dgvLSGD.Columns["sotien"].DefaultCellStyle.Format = "N0";

            dgvLSGD.Columns["tgBatDau"].Width = 200;
            dgvLSGD.Columns["tgKetThuc"].Width = 200;
            dgvLSGD.Columns["sotien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLSGD.Columns["sotien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;    


        }
        
        
        private void ShowChiTietHoaDon()
        {
            var rs = from ct in db.ChiTietHoaDonBanHangs.Where(x => x.IDHoaDon == idHoaDon)
                     join h in db.MatHangs on ct.IDMatHang equals h.ID
                     join d in db.DonViTinhs on h.IDDVT equals d.ID
                     select new
                     {
                         mahang = h.ID,
                         tenhang = h.TenMatHang,
                         dvt = d.TenDVT,
                         sl = ct.SL,
                         dg = ct.DonGia,
                         thanhtien = ct.SL * ct.DonGia
                     };
            dgvCTBanHang.DataSource = rs;
            dgvCTBanHang.Columns["mahang"].Visible = false;
            dgvCTBanHang.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvCTBanHang.Columns["dvt"].HeaderText = "ĐVT";
            dgvCTBanHang.Columns["sl"].HeaderText = "SL";
            dgvCTBanHang.Columns["dg"].HeaderText = "Giá";
            dgvCTBanHang.Columns["thanhtien"].HeaderText = "Thành tiền";

            dgvCTBanHang.Columns["sl"].Width = 30;
            dgvCTBanHang.Columns["dvt"].Width = 50;
            dgvCTBanHang.Columns["dg"].Width = 50;
            dgvCTBanHang.Columns["thanhtien"].Width = 100;
            dgvCTBanHang.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvCTBanHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCTBanHang.Columns["sl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCTBanHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTBanHang.Columns["thanhtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTBanHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvCTBanHang.Columns["thanhtien"].DefaultCellStyle.Format = "N0";
        }
        private void LoadPhong(int loaiphong, int tabIndex)
        {
            tbcContent.TabPages[tabIndex].Controls.Clear();

            lv = new ListView();
            lv.Dock = DockStyle.Fill;
            lv.SelectedIndexChanged += lv_SelectedIndexChanged;
            imgl = new ImageList();
            imgl.ImageSize = new Size(256, 128);
            imgl.Images.Add(Properties.Resources.PhongTrong);
            imgl.Images.Add(Properties.Resources.PhongCoKhach);
            lv.LargeImageList = imgl;

            var dsPhong = db.Phongs.Where(x => x.IDLoaiPhong == loaiphong);
            foreach (var p in dsPhong)
            {
                if (p.TrangThai == 1)
                {
                    lv.Items.Add(new ListViewItem { ImageIndex = 1, Text = p.TenPhong, Name = p.ID.ToString(), Tag = true });

                }
                else
                {
                    lv.Items.Add(new ListViewItem { ImageIndex = 0, Text = p.TenPhong, Name = p.ID.ToString(), Tag = false });
                }

            }
            tbcContent.TabPages[tabIndex].Controls.Add(lv);
        }
        int idLoaiPhong = 0;
        private string tenphong;
        private long idHoaDon = 0;
        private int idPhong = 0;
        private int tabIndex = 0;
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = lv.SelectedIndices;
            if (idx.Count > 0)
            {
                idPhong = int.Parse(lv.SelectedItems[0].Name);
                tenphong = lv.SelectedItems[0].Text.ToUpper();
                lblPhongDangChon.Text = tenphong;
                if ((bool)lv.SelectedItems[0].Tag)
                {
                    btnBatDau.Enabled = false;
                    btnKetThuc.Enabled = true;
                    var hd = db.HoaDonBanHangs.FirstOrDefault(x => x.IDHoaDon == db.HoaDonBanHangs.Where(y => y.IDPhong == idPhong).Max(z => z.IDHoaDon));
                    idHoaDon = hd.IDHoaDon;
                   
                    mtbKetThuc.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    mtbBatDau.Text = ((DateTime)hd.ThoiGianBDau).ToString("dd/MM/yyyy HH:mm");
                    ShowChiTietHoaDon();
                }
                else
                {
                    
                    dgvCTBanHang.DataSource = null;
                    mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    btnBatDau.Enabled = true;
                    btnKetThuc.Enabled = false;
                }


            }
        }

        private void ShowMatHang()
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
                          join h in db.MatHangs.Where(x => (x.IdCha == null || x.IdCha <= 0))on ct.First().mahang equals h.ID
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
                          join h in db.MatHangs.Where(x => x.IdCha == null || x.IdCha <= 0 && x.isDichVu==false)
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
                                tonkho =(int) (p.soluong - (t==null?0:t.soluong))
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
                          join h in db.MatHangs.Where(x => x.IdCha > 0&& x.isDichVu == false)
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
                                tonkho = (int)(nc.soluong-(x==null?0:x.slxuat))
                            };
            #endregion

            var tonkhoHang = tonKhoCha.Concat(tonKhoCon).OrderBy(x=>x.tenhang);
            var dichvu = from h in db.MatHangs.Where(x => x.isDichVu == true)
                         join d in db.DonViTinhs on h.IDDVT equals d.ID
                         select new
                         {
                             mahang = h.ID,
                             tenhang = h.TenMatHang,
                             isDichvu = 1,
                             dvt = d.TenDVT,
                             dg = h.DonGiaBan,
                             tonkho = 0
                         };
            dgvDSMatHang.DataSource = tonkhoHang.Concat(dichvu).OrderBy(x => x.tenhang).OrderBy(x=>x.isDichvu);

        }

        private void dgvDSMatHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng để tiếp tục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.RowIndex < 0)
            {
                return;
            }
            var phong = db.Phongs.SingleOrDefault(x => x.ID == idPhong);
            if (phong.TrangThai == 1)
            {
                var r = dgvDSMatHang.Rows[e.RowIndex];
                new frmOrder(idHoaDon, tenphong, r).ShowDialog();
                ShowMatHang();
                ShowChiTietHoaDon();
            }

        }
        private void tbcContent_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            idLoaiPhong = int.Parse(tbcContent.SelectedTab.Name);
            tabIndex = tbcContent.SelectedIndex;
            LoadPhong(idLoaiPhong, tabIndex);

        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            try
            {
                var p = db.Phongs.SingleOrDefault(x => x.ID == idPhong);
                var lp = db.LoaiPhongs.SingleOrDefault(x => x.ID == p.IDLoaiPhong);
                var od = new HoaDonBanHang();
                od.IDPhong = idPhong;
                od.IDNguoiBan = 1;
                od.ThoiGianBDau = DateTime.ParseExact(mtbBatDau.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                od.NgayTao = DateTime.Now;
                od.NguoiTao = nhanvien;
                od.DonGiaPhong = lp.DonGia;
                db.HoaDonBanHangs.InsertOnSubmit(od);
                db.SubmitChanges();

                
                p.TrangThai = 1;
                db.SubmitChanges();
                LoadPhong(idLoaiPhong, tabIndex);
                btnBatDau.Enabled = false;
                btnKetThuc.Enabled = true;
                MessageBox.Show("Gọi phòng thành công","Successfully",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Gọi phòng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            try
            {
               


                var hd = db.HoaDonBanHangs.SingleOrDefault(x => x.IDHoaDon == idHoaDon);
                hd.ThoiGianKThuc = DateTime.ParseExact(mtbKetThuc.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                db.SubmitChanges();

                var p = db.Phongs.SingleOrDefault(x => x.ID == idPhong);
                p.TrangThai = 0;
                db.SubmitChanges();

                LoadPhong(idLoaiPhong, tabIndex);
                mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                btnBatDau.Enabled = true;
                btnKetThuc.Enabled = false;
                MessageBox.Show("Thanh toán phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowLSGD();
                idHoaDon = hd.IDHoaDon;
                InHoaDon();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi:"+ex.Message,"Thanh toán phòng thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLSGD()
        {
            var result = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGianKThuc != null)
                         join p in db.Phongs on hd.IDPhong equals p.ID
                         join ct in db.ChiTietHoaDonBanHangs.GroupBy(t => t.IDHoaDon)
                         on hd.IDHoaDon equals ct.First().IDHoaDon
                         select new
                         {
                             idHoaDon = hd.IDHoaDon,
                             phong = p.TenPhong,
                             tgBatDau = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             tgKetThuc = DateTime.Parse(hd.ThoiGianKThuc.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             sotien = ((TimeSpan)((DateTime)hd.ThoiGianKThuc -  (DateTime)hd.ThoiGianBDau)).TotalHours * hd.DonGiaPhong + ct.Sum(x=>x.SL*x.DonGia)
                         };
            dgvLSGD.DataSource = result;
        }        
        private void dgvLSGD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                idHoaDon = long.Parse(dgvLSGD.Rows[e.RowIndex].Cells["idHoaDon"].Value.ToString());
                InHoaDon();
            }    
        }
        private void InHoaDon()
        {
            pddHoaDon.Document = pdHoaDon;
            pddHoaDon.ShowDialog();
        }

        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var tencuahang = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "tencuahang").giatri;
            var diachi = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "diachi").giatri;
            var phone = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "phone").giatri;

            var hd = db.HoaDonBanHangs.SingleOrDefault(x => x.IDHoaDon == idHoaDon);

            var w = pdHoaDon.DefaultPageSettings.PaperSize.Width;
            #region dau_hoa_don
            e.Graphics.DrawString(tencuahang.ToUpper(),
                                  new Font("Courier New", 15, FontStyle.Bold),
                                  Brushes.Black, new Point(50, 20)
                                 );
            e.Graphics.DrawString(string.Format("HD{0}", hd.IDHoaDon),
                                  new Font("Courier New", 12, FontStyle.Bold),
                                  Brushes.Black, new Point(w / 2 + 200, 20)
                                 );
            e.Graphics.DrawString(string.Format("{0} - {1}", diachi, phone),
                                  new Font("Courier New", 10, FontStyle.Bold),
                                  Brushes.Black, new Point(50, 45)
                                 );
            e.Graphics.DrawString(string.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm")),
                                  new Font("Courier New", 12, FontStyle.Bold),
                                  Brushes.Black, new Point(w / 2 + 200, 45)
                                 );
            Pen blackPen = new Pen(Color.Black, 1);
            var y = 70;

            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);
            y += 10;
            e.Graphics.DrawString(string.Format("Giờ bắt đầu: {0}", ((DateTime)hd.ThoiGianBDau).ToString("dd/MM/yyyy HH:mm")),
                                  new Font("Courier New", 10, FontStyle.Bold),
                                  Brushes.Black, new Point(10, y)
                                 );
            e.Graphics.DrawString(string.Format("Giờ kết thúc: {0}", ((DateTime)hd.ThoiGianKThuc).ToString("dd/MM/yyyy HH:mm")),
                                  new Font("Courier New", 10, FontStyle.Bold),
                                  Brushes.Black, new Point(w / 2, y)
                                 );
            y += 20;
            int sum = 0;
            var tgsd = ((DateTime)hd.ThoiGianKThuc - (DateTime)hd.ThoiGianBDau).TotalMinutes;
            var gio = (int)(tgsd / 60);
            var phut = tgsd % 60;

            var tienphong = (int)Math.Round((double)(tgsd / 60 * hd.DonGiaPhong) / 1000, 3) * 1000;
            sum += tienphong;
            e.Graphics.DrawString(string.Format("Thời gian sử dụng: {0}:{1}", gio, phut ),
                                  new Font("Courier New", 10, FontStyle.Bold),
                                  Brushes.Black, new Point(10, y)
                                 );
            e.Graphics.DrawString(string.Format("Thành tiền: {0:N0} VNĐ", tienphong),
                                  new Font("Courier New", 10, FontStyle.Bold),
                                  Brushes.Black, new Point(w / 2, y)
                                 );

            y += 20;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);
            #endregion

            y += 10;
            e.Graphics.DrawString("STT", new Font("Courier New", 10, FontStyle.Bold),Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("Mặt hàng dịch vụ", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(50, y));
            e.Graphics.DrawString("SL", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString("Đơn giá", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
            e.Graphics.DrawString("Thành tiền", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            var result = from ct in db.ChiTietHoaDonBanHangs.Where(x => x.IDHoaDon == idHoaDon)
                         join h in db.MatHangs on ct.IDMatHang equals h.ID
                         join dv in db.DonViTinhs on h.IDDVT equals dv.ID
                         select new
                         {
                             TenMatHang = h.TenMatHang,
                             DVT = dv.TenDVT,
                             SL = (int)ct.SL,
                             DG = (int)ct.DonGia,
                             ThanhTien = ct.SL * ct.DonGia
                         };
            int i = 1;
            y += 20;
            foreach (var l in result )
            {
                sum += l.SL * l.DG;
                e.Graphics.DrawString(string.Format("{0}", i++), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString(l.TenMatHang, new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.SL), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.DG), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2 +100, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.ThanhTien), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
                y += 20;
            }
            y += 40;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);

            y += 20;
            e.Graphics.DrawString(string.Format("Tổng tiền: {0:N0} VNĐ", sum), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            y += 40;
            e.Graphics.DrawString("Xin chân thành cám ơn sự ủng hộ của quý khách!", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));


        }
    }
}
