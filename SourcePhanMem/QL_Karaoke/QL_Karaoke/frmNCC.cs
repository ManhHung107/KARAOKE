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
    public partial class frmNCC : Form
    {
        public frmNCC(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }
        private DataClasses1DataContext db;
        private string nhanvien;
        private DataGridViewRow r;
        private void frmNCC_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            ShowData();
            dgvNCC.Columns["id"].Visible = false;
            dgvNCC.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            dgvNCC.Columns["DienThoai"].HeaderText = "Số điện thoại";
            dgvNCC.Columns["DiaChi"].HeaderText = "Địa chỉ";

            dgvNCC.Columns["DiaChi"].Width = 200;
            dgvNCC.Columns["DienThoai"].Width = 200;
            dgvNCC.Columns["Email"].Width = 200;

            txtTenNCC.Select();
        }
        private void ShowData()
        {
            var rs = from n in db.NCCs
                     select new
                     {
                         n.ID,
                         n.TenNCC,
                         n.DienThoai,
                         n.Email,
                         n.DiaChi
                     };
            dgvNCC.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhà cung cấp ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSDT.Select();
                return;
            }          
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Select();
                return;
            }
            var n = new NCC();
            n.TenNCC = txtTenNCC.Text;
            n.DienThoai = txtSDT.Text;
            n.DiaChi = txtDiaChi.Text;
            n.Email = txtEmail.Text;
            n.NgayTao = DateTime.Now;
            n.NguoiTao = nhanvien;
            db.NCCs.InsertOnSubmit(n);
            db.SubmitChanges();
            MessageBox.Show("Thêm mới nhà cung cấp thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
            txtTenNCC.Text = null;
            txtSDT.Text = null;
            txtDiaChi.Text = null ;
            txtEmail.Text = null;
            txtTenNCC.Select();
        }

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvNCC.Rows[e.RowIndex];
                txtTenNCC.Text = r.Cells["TenNCC"].Value.ToString();
                txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = r.Cells["Email"].Value.ToString();
                txtSDT.Text = r.Cells["DienThoai"].Value.ToString();


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r==null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp muốn cập nhật ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }           
            var n = db.NCCs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            n.TenNCC = txtTenNCC.Text;
            n.DienThoai = txtSDT.Text;
            n.DiaChi = txtDiaChi.Text;
            n.Email = txtEmail.Text;
            n.NgayCapNhat = DateTime.Now;
            n.NguoiCapNhat = nhanvien;
            db.SubmitChanges();
            MessageBox.Show("Cập nhật nhà cung cấp thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
            txtTenNCC.Text = null;
            txtSDT.Text = null;
            txtDiaChi.Text = null;
            txtEmail.Text = null;
            r = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn thực sự muốn xóa nhà cung cấp " + r.Cells["TenNCC"].Value.ToString() + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var n = db.NCCs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.SubmitChanges();
                    MessageBox.Show("Xóa nhà cung cấp thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                catch
                {
                    MessageBox.Show("Xóa nhà cung cấp thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ShowData();
                txtTenNCC.Text = null;
                txtSDT.Text = null;
                txtDiaChi.Text = null;
                txtEmail.Text = null;
                r = null;
            }
        }
    }
}
