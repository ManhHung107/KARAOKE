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
    public partial class frmPhong : Form
    {
        public frmPhong(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }
        private DataClasses1DataContext db;
        private string nhanvien;
        private DataGridViewRow r;
        private void frmPhong_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            ShowData();
            dgvPhong.Columns["id"].Width = 100;
            dgvPhong.Columns["DonGia"].Width = 100;
            dgvPhong.Columns["SucChua"].Width = 100;
            dgvPhong.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhong.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPhong.Columns["SucChua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhong.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvPhong.Columns["id"].HeaderText = "Mã phòng";
            dgvPhong.Columns["TenPhong"].HeaderText = "Tên phòng";
            dgvPhong.Columns["TenLoaiPhong"].HeaderText = "Loại phòng";
            dgvPhong.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvPhong.Columns["SucChua"].HeaderText = "Sức chứa";



            cbbLoaiPhong.DataSource = db.LoaiPhongs;
            cbbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbbLoaiPhong.ValueMember = "ID";
            cbbLoaiPhong.SelectedIndex = -1;
            txtTenPhong.Select();
        }
        private void ShowData()
        {
            var rs = from p in db.Phongs
                     join l in db.LoaiPhongs
                     on p.IDLoaiPhong equals l.ID
                     select new
                     {
                         p.ID,
                         l.TenLoaiPhong,
                         p.TenPhong,
                         p.SucChua,
                         l.DonGia                       
                     };
            dgvPhong.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Select();
                return;
            }
            if (cbbLoaiPhong.SelectedIndex <0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtSucChua.Text)|| int.Parse(txtSucChua.Text)<=0)
            {
                MessageBox.Show("Sức chứa của phòng phải lớn hơn 0 ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSucChua.Select();
                return;
            }
            var p = new Phong();
            p.TenPhong = txtTenPhong.Text;
            p.IDLoaiPhong = int.Parse(cbbLoaiPhong.SelectedValue.ToString());
            p.SucChua = int.Parse(txtSucChua.Text);
            p.NgayTao = DateTime.Now;
            p.NguoiTao = nhanvien;
            db.Phongs.InsertOnSubmit(p);
            db.SubmitChanges();           
            MessageBox.Show("Thêm mới phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
            txtTenPhong.Text = null;
            txtSucChua.Text = null;
            cbbLoaiPhong.SelectedIndex = -1;

            txtTenPhong.Select();
        }

        private void txtSucChua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn thực sự muốn xóa phòng " + r.Cells["TenPhong"].Value.ToString() + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var p = db.Phongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.SubmitChanges();
                    MessageBox.Show("Xóa phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                    txtTenPhong.Text = null;
                    txtSucChua.Text = "0";
                    cbbLoaiPhong.SelectedIndex = -1;
                    r = null;
                }
                catch
                {
                    MessageBox.Show("Xóa phòng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvPhong.Rows[e.RowIndex];
                txtTenPhong.Text = r.Cells["TenPhong"].Value.ToString();
                txtSucChua.Text = r.Cells["SucChua"].Value.ToString();
                cbbLoaiPhong.Text = r.Cells["TenLoaiPhong"].Value.ToString();


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn phòng muốn cập nhật ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var p = db.Phongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            p.TenPhong = txtTenPhong.Text;
            p.SucChua = int.Parse(txtSucChua.Text);
            p.NgayCapNhat = DateTime.Now;
            p.NguoiCapNhat = nhanvien;
            db.SubmitChanges();
            MessageBox.Show("Cập nhật loại phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
            txtTenPhong.Text = null;
            txtSucChua.Text = null;
            cbbLoaiPhong.SelectedIndex = -1;
        }
    }
}
