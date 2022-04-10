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
    public partial class frmCongNo : Form
    {
        public frmCongNo()
        {
            InitializeComponent();
        }
        private DataClasses1DataContext db;
        private void frmCongNo_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            cbbNhaCungCap.DataSource = db.NCCs;
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "ID";
            cbbNhaCungCap.SelectedIndex = -1;

            btnThongKe.PerformClick();

            dgvThongKe.Columns["ngayGD"].HeaderText = "Ngày GD";
            dgvThongKe.Columns["NhaCC"].HeaderText = "Nhà cung cấp";
            dgvThongKe.Columns["TongTien"].HeaderText = "Tổng tiền";
            dgvThongKe.Columns["DaThanhToan"].HeaderText = "Đã thanh toán";
            dgvThongKe.Columns["ConLai"].HeaderText = "Còn nợ";

            dgvThongKe.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvThongKe.Columns["DaThanhToan"].DefaultCellStyle.Format = "N0";
            dgvThongKe.Columns["ConLai"].DefaultCellStyle.Format = "N0";

            dgvThongKe.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns["DaThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns["ConLai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvThongKe.Columns["NhaCC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvThongKe.Columns["IDNhaCC"].Visible = false;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var result = from hd in db.HoaDonNhaps.Where(x => x.DaNhap == 1 && x.TienThanhToan < (db.ChiTietHoaDonNhaps.Where(t => t.IDHoaDon == x.ID).Sum(y => y.SoLuong * y.DonGiaNhap)))
                         join ncc in db.NCCs on hd.IDNhaCC equals ncc.ID
                         join ct in db.ChiTietHoaDonNhaps.GroupBy(x => x.IDHoaDon)
                         on hd.ID equals ct.First().IDHoaDon
                         select new
                         {
                             ngayGD = DateTime.Parse(hd.NgayNhap.ToString()).ToString("dd/MM/yyyy"),
                             IDNhaCC = ncc.ID,
                             NhaCC = ncc.TenNCC,
                             TongTien = ct.Sum(x => x.SoLuong * x.DonGiaNhap),
                             DaThanhToan = hd.TienThanhToan,
                             ConLai = ct.Sum(x => x.SoLuong * x.DonGiaNhap) - hd.TienThanhToan
                         };
            if(cbbNhaCungCap.SelectedIndex >= 0)
            {
                dgvThongKe.DataSource = result.Where(x => x.IDNhaCC == int.Parse(cbbNhaCungCap.SelectedValue.ToString()));
            }
            dgvThongKe.DataSource = result; 
            var total = 0;
            if(result.Count() > 0)
            {
                total = (int)result.Sum(x => x.ConLai);
 
            }
            lblTongNo.Text = string.Format("Tổng nợ: {0:N0} VNĐ", total);



        }
    }
}
