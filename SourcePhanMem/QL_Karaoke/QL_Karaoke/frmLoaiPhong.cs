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
    public partial class frmLoaiPhong : Form
    {
        public frmLoaiPhong(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }
        private DataClasses1DataContext db;
        private string nhanvien;
        private DataGridViewRow r;
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            ShowData();
            dgvLoaiPhong.Columns["id"].HeaderText = "Mã loại phòng";
            dgvLoaiPhong.Columns["id"].Width = 100;
            dgvLoaiPhong.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLoaiPhong.Columns["DonGia"].Width = 100;
            dgvLoaiPhong.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLoaiPhong.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvLoaiPhong.Columns["TenLoaiPhong"].HeaderText = "Tên Loại Phòng";
            dgvLoaiPhong.Columns["DonGia"].HeaderText = "Đơn giá";
            txtLoaiPhong.Select();
        }
        private void ShowData()
        {
            var rs = (from l in db.LoaiPhongs
                      select new
                      {
                          l.ID,
                          l.TenLoaiPhong,
                          l.DonGia
                      }).ToList();
            dgvLoaiPhong.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLoaiPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaiPhong.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Select();
                return;
            }
            var lp = new LoaiPhong();
            lp.TenLoaiPhong = txtLoaiPhong.Text;
            lp.DonGia = int.Parse(txtDonGia.Text);
            lp.NgayTao = DateTime.Now;
            lp.NguoiTao = nhanvien;
            db.LoaiPhongs.InsertOnSubmit(lp);
            db.SubmitChanges();
            ShowData();
            MessageBox.Show("Thêm mới loại phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtLoaiPhong.Text = null;
            txtDonGia.Text = null;
            txtLoaiPhong.Select();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r==null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng muốn cập nhật ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }           
            var lp = db.LoaiPhongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            lp.TenLoaiPhong = txtLoaiPhong.Text;
            lp.DonGia = int.Parse(txtDonGia.Text);
            lp.NgayCapNhat = DateTime.Now;
            lp.NguoiCapNhat = nhanvien;
            db.SubmitChanges();
            MessageBox.Show("Cập nhật loại phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
            txtLoaiPhong.Text = null;
            txtDonGia.Text = null;
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvLoaiPhong.Rows[e.RowIndex];
                txtLoaiPhong.Text = r.Cells["TenLoaiPhong"].Value.ToString();
                txtDonGia.Text = r.Cells["DonGia"].Value.ToString();


            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn thực sự muốn xóa loại phòng " + r.Cells["TenLoaiPhong"].Value.ToString() + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var lp = db.LoaiPhongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.SubmitChanges();
                    MessageBox.Show("Xóa loại phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                    txtLoaiPhong.Text = null;
                    txtDonGia.Text = null;
                    r = null;
                }
                catch
                {
                    MessageBox.Show("Xóa loại phòng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
