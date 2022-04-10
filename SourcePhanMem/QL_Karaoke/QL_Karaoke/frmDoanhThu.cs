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
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
        }
        private DataClasses1DataContext db;
        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            mtbTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy 00:01");
            mtbDenNgay.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            btnThongKe.PerformClick();

            dgvTKDoanhThu.Columns["NgayGD"].HeaderText = "Ngày GD";
            dgvTKDoanhThu.Columns["Mathang"].HeaderText = "Mặt hàng";
            dgvTKDoanhThu.Columns["ThanhTien"].HeaderText = "Thành tiền";

            dgvTKDoanhThu.Columns["MaHang"].Visible = false;

            dgvTKDoanhThu.Columns["DG"].DefaultCellStyle.Format = "N0";
            dgvTKDoanhThu.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            dgvTKDoanhThu.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTKDoanhThu.Columns["DG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTKDoanhThu.Columns["DVT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTKDoanhThu.Columns["SL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvTKDoanhThu.Columns["Mathang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            LoadData();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string TuKhoa = null;
            DateTime tuNgay, toiNgay;
            try
            {
                tuNgay = DateTime.ParseExact(mtbTuNgay.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                toiNgay = DateTime.ParseExact(mtbDenNgay.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                if (toiNgay <= tuNgay)
                {
                    MessageBox.Show("Thời gian không hợp lệ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thời gian không hợp lệ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ckbPhong.Checked && !ckbMatHang.Checked && !ckbDichVu.Checked)
            {
                MessageBox.Show("vui lòng chọn điều kiện lọc thống kê", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<LineHang> result = new List<LineHang>();

            if (cbbItem.SelectedIndex >= 0)
            {
                TuKhoa = cbbItem.SelectedValue.ToString();
            }
            if (ckbPhong.Checked)
            {
                result.AddRange(ThongKePhong(tuNgay, toiNgay, TuKhoa));
            }
            if (ckbMatHang.Checked)
            {
                result.AddRange(ThongKeHang(tuNgay, toiNgay, TuKhoa));
            }
            if (ckbDichVu.Checked)
            {
                result.AddRange(ThongKeDichVu(tuNgay, toiNgay, TuKhoa));
            }
            var total = result.Sum(x => x.ThanhTien);
            lblTongTien.Text = string.Format("Tổng tiền: {0:N0} VNĐ", total);
            dgvTKDoanhThu.DataSource = result.OrderBy(x => x.NgayGD).ToList();
            TuKhoa = null;
        }
        private List<LineHang> ThongKePhong(DateTime tuNgay, DateTime toiNgay, string TuKhoa)
        {
            var result = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGianKThuc != null && x.ThoiGianBDau >= tuNgay && x.ThoiGianBDau <= toiNgay)
                         join p in db.Phongs on hd.IDPhong equals p.ID
                         select new LineHang
                         {
                             NgayGD = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             MaHang = Convert.ToString(p.ID),
                             Mathang = p.TenPhong,
                             DVT = "Giờ",
                             DG = (int)hd.DonGiaPhong,
                             SL = new LinePhong(((DateTime)hd.ThoiGianKThuc - (DateTime)hd.ThoiGianBDau).TotalHours).ToString(),
                             ThanhTien = (int)new LinePhong().ThanhTien(((DateTime)hd.ThoiGianKThuc - (DateTime)hd.ThoiGianBDau).TotalHours, (int)hd.DonGiaPhong)
                         };
            if (!string.IsNullOrEmpty(TuKhoa))
            {
                return result.ToList().Where(x => x.MaHang == TuKhoa).ToList();
            }
            return result.ToList();
        }
        private List<LineHang> ThongKeHang(DateTime tuNgay, DateTime toiNgay, string TuKhoa)
        {
            var result = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGianKThuc != null && x.ThoiGianBDau >= tuNgay && x.ThoiGianBDau <= toiNgay)
                         join ct in db.ChiTietHoaDonBanHangs on hd.IDHoaDon equals ct.IDHoaDon
                         join h in db.MatHangs.Where(x => x.isDichVu == false) on ct.IDMatHang equals h.ID
                         join dv in db.DonViTinhs on h.IDDVT equals dv.ID
                         select new LineHang
                         {
                             NgayGD = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             MaHang = Convert.ToString(h.ID),
                             Mathang = h.TenMatHang,
                             DVT = dv.TenDVT,
                             SL = Convert.ToString(ct.SL),
                             DG = (int)ct.DonGia,
                             ThanhTien = (int)(ct.SL * ct.DonGia)
                         };
            if (!string.IsNullOrEmpty(TuKhoa))
            {
                return result.ToList().Where(x => x.MaHang == TuKhoa).ToList();
            }
            return result.ToList();
        }
        private List<LineHang> ThongKeDichVu(DateTime tuNgay, DateTime toiNgay, string TuKhoa)
        {
            var result = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGianKThuc != null && x.ThoiGianBDau >= tuNgay && x.ThoiGianBDau <= toiNgay)
                         join ct in db.ChiTietHoaDonBanHangs on hd.IDHoaDon equals ct.IDHoaDon
                         join h in db.MatHangs.Where(x => x.isDichVu == true) on ct.IDMatHang equals h.ID
                         join dv in db.DonViTinhs on h.IDDVT equals dv.ID
                         select new LineHang
                         {
                             NgayGD = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             MaHang = Convert.ToString(h.ID),
                             Mathang = h.TenMatHang,
                             DVT = dv.TenDVT,
                             SL = Convert.ToString(ct.SL),
                             DG = (int)ct.DonGia,
                             ThanhTien = (int)(ct.SL * ct.DonGia)
                         };
            if (!string.IsNullOrEmpty(TuKhoa))
            {
                return result.ToList().Where(x => x.MaHang == TuKhoa).ToList();
            }
            return result.ToList();
        }

        private void LoadData()
        {
            List<LineHang> source = new List<LineHang>();
            if (ckbDichVu.Checked)
            {
                var result = from h in db.MatHangs.Where(x => x.isDichVu == true)
                             join d in db.DonViTinhs on h.IDDVT equals d.ID
                             select new LineHang
                             {
                                 MaHang = h.ID.ToString(),
                                 Mathang = h.TenMatHang + " -[" + d.TenDVT + "]"
                             };
                source.AddRange(result);
            }
            if (ckbMatHang.Checked)
            {
                var result = from h in db.MatHangs.Where(x => x.isDichVu == false)
                             join d in db.DonViTinhs on h.IDDVT equals d.ID
                             select new LineHang
                             {
                                 MaHang = h.ID.ToString(),
                                 Mathang = h.TenMatHang + " -[" + d.TenDVT + "]"
                             };
                source.AddRange(result);
            }
            if (ckbPhong.Checked)
            {
                var result = from p in db.Phongs
                             select new LineHang
                             {
                                 MaHang = p.ID.ToString(),
                                 Mathang = p.TenPhong
                             };
                source.AddRange(result);
            }
            cbbItem.DataSource = source;
            cbbItem.DisplayMember = "Mathang";
            cbbItem.ValueMember = "MaHang";
            cbbItem.SelectedIndex = -1;
        }

        private void ckbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTatCa.Checked)
            {
                ckbDichVu.Checked = ckbMatHang.Checked = ckbPhong.Checked = true;
            }
            if (!ckbTatCa.Checked && ckbPhong.Checked && ckbMatHang.Checked && ckbDichVu.Checked)
            {
                ckbDichVu.Checked = ckbMatHang.Checked = ckbPhong.Checked = false;
            }
        }
        private void ckbBaThangCon_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPhong.Checked && ckbMatHang.Checked && ckbDichVu.Checked)
            {
                ckbTatCa.Checked = true;
            }
            if (!ckbPhong.Checked || !ckbMatHang.Checked || !ckbDichVu.Checked)
            {
                ckbTatCa.Checked = false;
            }
            LoadData();
        }
    }
}
