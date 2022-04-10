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
    public partial class frmCTHDNhap : Form
    {
        public frmCTHDNhap(long idHoaDon, byte danhapkho)
        {
            this.idHoaDon = idHoaDon;
            this.danhapkho = danhapkho;
            InitializeComponent();
        }
        private long idHoaDon;
        private byte danhapkho;
        private DataClasses1DataContext db;
        private void frmCTHDNhap_Load(object sender, EventArgs e)
        {

            db = new DataClasses1DataContext();
            var hd = db.HoaDonNhaps.SingleOrDefault(x => x.ID == idHoaDon);
            if(hd.DaNhap == 1)
            {
                btnThem.Enabled = btnXoa.Enabled = false;
            }    

            var rs = from h in db.MatHangs.Where(x=>(x.IdCha == null || x.IdCha<=0 )&& x.isDichVu == false)
                     join d in db.DonViTinhs on h.IDDVT equals d.ID
                     select new
                     {
                         TenMatHang = h.TenMatHang + " - " + d.TenDVT,
                         mahang = h.ID
                     };
            cbbMatHang.DataSource = rs;
            cbbMatHang.DisplayMember = "TenMatHang";
            cbbMatHang.ValueMember = "mahang";
            cbbMatHang.SelectedIndex = -1;
            ShowData();

            dgvCTHDNhap.Columns["idmathang"].Visible = false;
            dgvCTHDNhap.Columns["mathang"].HeaderText = "Tên mặt hàng";
            dgvCTHDNhap.Columns["dvt"].HeaderText = "Đơn vị tính";
            dgvCTHDNhap.Columns["sl"].HeaderText = "Số lượng";
            dgvCTHDNhap.Columns["dg"].HeaderText = "Đơn giá";
            dgvCTHDNhap.Columns["thanhtien"].HeaderText = "Thành tiền";

            dgvCTHDNhap.Columns["dvt"].Width = 100;
            dgvCTHDNhap.Columns["sl"].Width = 100;
            dgvCTHDNhap.Columns["dg"].Width = 100;
            dgvCTHDNhap.Columns["thanhtien"].Width = 100;

            dgvCTHDNhap.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvCTHDNhap.Columns["thanhtien"].DefaultCellStyle.Format = "N0";

            dgvCTHDNhap.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCTHDNhap.Columns["sl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCTHDNhap.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvCTHDNhap.Columns["thanhtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           
        }
        private void ShowData()
        {
            var rs = from c in db.ChiTietHoaDonNhaps.Where(x=>x.IDHoaDon == idHoaDon)
                     join h in db.MatHangs on c.IDMatHang equals h.ID
                     join d in db.DonViTinhs on h.IDDVT equals d.ID
                     select new
                     {
                         idmathang = h.ID,
                         mathang = h.TenMatHang,
                         DVT = d.TenDVT,
                         sl = c.SoLuong,
                         dg = c.DonGiaNhap,
                         thanhtien = c.SoLuong * c.DonGiaNhap
                     };
            dgvCTHDNhap.DataSource = rs;
            lblTongTien.Text = string.Format("Tổng tiền: {0:N0} VNĐ", rs.Sum(x => x.thanhtien));

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(cbbMatHang.SelectedIndex<0)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần nhập", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }   
            if(string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var ct = new ChiTietHoaDonNhap();
            ct.IDHoaDon = idHoaDon;
            var item = db.ChiTietHoaDonNhaps.FirstOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(cbbMatHang.SelectedValue.ToString()));
            if(item ==  null)
            {
                ct.IDMatHang = int.Parse(cbbMatHang.SelectedValue.ToString());
                ct.DonGiaNhap = int.Parse(txtDonGia.Text);
                ct.SoLuong = int.Parse(txtSoLuong.Text);
                db.ChiTietHoaDonNhaps.InsertOnSubmit(ct);
                db.SubmitChanges();
            }    
            else
            {
                item.SoLuong += int.Parse(txtSoLuong.Text);
                db.SubmitChanges();
            }    
            ShowData();
        }
        private DataGridViewRow r;
        private void dgvCTHDNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvCTHDNhap.Rows[e.RowIndex];
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(r==null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa khỏi phiếu nhập", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa mặt hàng: " + r.Cells["mathang"].Value.ToString() + "? ", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var item = db.ChiTietHoaDonNhaps.FirstOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(r.Cells["idmathang"].Value.ToString()));
                db.ChiTietHoaDonNhaps.DeleteOnSubmit(item); 
                db.SubmitChanges();
                MessageBox.Show("Xóa mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
            }    
        }

        private void rdbNhapKho_Click(object sender, EventArgs e)
        {
            if(rbtYeuCau.Checked)
            {
                txtThanhToan.Enabled = false;
                txtThanhToan.Text = "0";
            }    
            else
            {
                txtThanhToan.Enabled = true;
            }    
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(dgvCTHDNhap.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập mặt hàng vào hóa đơn trước khi tiếp tục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            var hd = db.HoaDonNhaps.SingleOrDefault(x => x.ID == idHoaDon);
            hd.TienThanhToan = int.Parse(txtThanhToan.Text);
            hd.DaNhap = rbtYeuCau.Checked ? (byte)0 : (byte)1;
            db.SubmitChanges();
            this.Dispose();
        }
    }
}
