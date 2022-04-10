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
    public partial class frmNhapHang : Form
    {
        public frmNhapHang(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }
        private DataClasses1DataContext db;
        private string nhanvien;
        private DataGridViewRow r;
        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            mtbNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");

            cbbNhanVienNhap.DataSource = db.NhanViens ;
            cbbNhanVienNhap.DisplayMember = "HoVaTen";
            cbbNhanVienNhap.ValueMember = "Username";
            cbbNhanVienNhap.SelectedIndex = -1;

            cbbNCC.DataSource = db.NCCs;
            cbbNCC.DisplayMember = "TenNCC";
            cbbNCC.ValueMember = "id";
            cbbNCC.SelectedIndex = -1;
            ShowData();
            dgvHDNhap.Columns["danhap"].Visible = false;
            dgvHDNhap.Columns["id"].HeaderText = "ID phiếu";
            dgvHDNhap.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            dgvHDNhap.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
            dgvHDNhap.Columns["trangthai"].HeaderText = "Trạng thái";
            dgvHDNhap.Columns["tongtien"].HeaderText = "Tổng tiền";
            dgvHDNhap.Columns["dathanhtoan"].HeaderText = "Đã thanh toán";

            dgvHDNhap.Columns["id"].Width = 100;
            dgvHDNhap.Columns["NgayNhap"].Width = 100;
            dgvHDNhap.Columns["trangthai"].Width = 100;
            dgvHDNhap.Columns["tongtien"].Width = 100;
            dgvHDNhap.Columns["dathanhtoan"].Width = 100;

            dgvHDNhap.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHDNhap.Columns["trangthai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHDNhap.Columns["tongtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHDNhap.Columns["dathanhtoan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvHDNhap.Columns["tongtien"].DefaultCellStyle.Format = "N0";
            dgvHDNhap.Columns["dathanhtoan"].DefaultCellStyle.Format = "N0";
        }
        private void ShowData()
        {
            var rs = from o in db.HoaDonNhaps
                     join n in db.NCCs on o.IDNhaCC equals n.ID
                     join c in db.NhanViens on o.NhanVienNhap equals c.Username

                     select new
                     {
                         id = o.ID,
                         NgayNhap = o.NgayNhap,
                         TenNCC = n.TenNCC,
                         danhap = o.DaNhap,
                         trangthai = o.DaNhap == 1 ? "Đã nhập" : "Yêu cầu",
                         tongtien = db.ChiTietHoaDonNhaps.Where(x => x.IDHoaDon == o.ID).Sum(y => y.SoLuong * y.DonGiaNhap),
                         dathanhtoan = o.TienThanhToan
                     };
            dgvHDNhap.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime ngaynhap;
            try
            {
                ngaynhap = DateTime.ParseExact(mtbNgayNhap.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            }
            catch
            {
                MessageBox.Show("Ngày nhập không hợp lệ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if(cbbNhanVienNhap.SelectedIndex<0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên nhập hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbNCC.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var od = new HoaDonNhap();
                od.NhanVienNhap = cbbNhanVienNhap.SelectedValue.ToString();
                od.IDNhaCC = int.Parse(cbbNCC.SelectedValue.ToString());
                od.NgayNhap = ngaynhap;

                od.NgayTao = DateTime.Now;
                od.NguoiTao = nhanvien;
                

                db.HoaDonNhaps.InsertOnSubmit(od);
                db.SubmitChanges();
                
                var idHDNhap = db.HoaDonNhaps.Max(x => x.ID);
                new frmCTHDNhap(idHDNhap,0).ShowDialog();
                ShowData();
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi:" + ex.Message, "Tạo hóa đơn nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvHDNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                r = dgvHDNhap.Rows[e.RowIndex];
                byte danhapkho = r.Cells["danhap"].Value ==null ? (byte)0 : byte.Parse(r.Cells["danhap"].Value.ToString());
                new frmCTHDNhap(long.Parse(r.Cells["id"].Value.ToString()), danhapkho).ShowDialog();
                ShowData();
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
