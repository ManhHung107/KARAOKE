using QL_Karaoke.database;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QL_Karaoke
{
    public partial class frmMatHang : Form
    {
        public frmMatHang(string nv)
        {
            this.nhanvien = nv;
            InitializeComponent();
        }
        private DataClasses1DataContext db;
        private string nhanvien;
        private DataGridViewRow r;
        private void frmMatHang_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            cbbMatHangGoc.DataSource = db.MatHangs.Where(x => (x.IdCha == null || x.IdCha == -1));
            cbbMatHangGoc.DisplayMember = "TenMatHang";
            cbbMatHangGoc.ValueMember = "ID";
            cbbMatHangGoc.SelectedIndex = -1;

            ShowData();

            dgvMatHang.Columns["idcha"].Visible = false;
            dgvMatHang.Columns["tile"].Visible = false;
            dgvMatHang.Columns["id"].Width = 100;
            dgvMatHang.Columns["tendvt"].Width = 100;
            dgvMatHang.Columns["dongiaban"].Width = 100;
            dgvMatHang.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatHang.Columns["tendvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatHang.Columns["dongiaban"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMatHang.Columns["dongiaban"].DefaultCellStyle.Format = "N0";
            dgvMatHang.Columns["id"].HeaderText = "Mã hàng";
            dgvMatHang.Columns["tendvt"].HeaderText = "Tên DVT";
            dgvMatHang.Columns["dongiaban"].HeaderText = "Đơn giá";
            dgvMatHang.Columns["tenmathang"].HeaderText = "Tên mặt hàng";



            cbbDVT.DataSource = db.DonViTinhs;
            cbbDVT.DisplayMember = "TenDVT";
            cbbDVT.ValueMember = "ID";
            cbbDVT.SelectedIndex = -1;

            txtTenMatHang.Select();

        }
        private void ShowData()
        {
            var rs = from h in db.MatHangs
                     join d in db.DonViTinhs on h.IDDVT equals d.ID
                     select new
                     {
                         h.ID,
                         h.IdCha,
                         h.Tile,
                         h.TenMatHang,
                         d.TenDVT,
                         h.DonGiaBan
                     };
            dgvMatHang.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMatHang.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMatHang.Select();
                return;
            }
            if (cbbDVT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaBan.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Select();
                return;
            }
            int idcha = -1;
            int tile = 0;
            if (cbbMatHangGoc.SelectedIndex >= 0)
            {
                idcha = int.Parse(cbbMatHangGoc.SelectedValue.ToString());
                try
                {
                    tile = int.Parse(txtTiLe.Text);
                    if (tile <= 0)
                    {
                        MessageBox.Show("Tỉ lệ quy đổi phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTiLe.Select();
                        return;
                    }

                }
                catch
                {
                    MessageBox.Show("Tỉ lệ quy đổi không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTiLe.Select();
                    return;
                }
            }
            var mh = new MatHang();
            mh.TenMatHang = txtTenMatHang.Text;
            mh.IDDVT = int.Parse(cbbDVT.SelectedValue.ToString());
            mh.DonGiaBan = int.Parse(txtDonGiaBan.Text);
            mh.IdCha = idcha;
            mh.Tile = tile;
            mh.NgayTao = DateTime.Now;
            mh.NguoiTao = nhanvien;
            mh.isDichVu = rbtDichVu.Checked ? (bool)true : (bool)false;
            db.MatHangs.InsertOnSubmit(mh);
            db.SubmitChanges();
            cbbMatHangGoc.DataSource = db.MatHangs.Where(x => (x.IdCha == null || x.IdCha == -1));
            cbbMatHangGoc.DisplayMember = "TenMatHang";
            cbbMatHangGoc.ValueMember = "ID";
            cbbMatHangGoc.SelectedIndex = -1;
            ShowData();
            MessageBox.Show("Thêm mới mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTenMatHang.Text = null;
            txtDonGiaBan.Text = null;
            cbbMatHangGoc.SelectedIndex = -1;
            cbbDVT.SelectedIndex = -1;
            txtTenMatHang.Select();
        }

        private void txtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvMatHang.Rows[e.RowIndex];
                txtTenMatHang.Text = r.Cells["TenMatHang"].Value.ToString();
                cbbDVT.Text = r.Cells["TenDVT"].Value.ToString();
                txtDonGiaBan.Text = r.Cells["DonGiaBan"].Value.ToString();
                txtTiLe.Text = r.Cells["tile"].Value == null ? "0" : r.Cells["tile"].Value.ToString();
                if (r.Cells["idcha"].Value == null || r.Cells["idcha"].Value.ToString() == "-1")
                {
                    cbbMatHangGoc.SelectedIndex = -1;
                }
                else
                {
                    var item = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["idcha"].Value.ToString()));
                    cbbMatHangGoc.Text = item.TenMatHang;
                }

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng muốn cập nhật ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idcha = -1;
            int tile = 0;
            if (cbbMatHangGoc.SelectedIndex >= 0)
            {
                idcha = int.Parse(cbbMatHangGoc.SelectedValue.ToString());
                try
                {
                    tile = int.Parse(txtTiLe.Text);
                    if (tile <= 0)
                    {
                        MessageBox.Show("Tỉ lệ quy đổi phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTiLe.Select();
                        return;
                    }

                }
                catch
                {
                    MessageBox.Show("Tỉ lệ quy đổi không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTiLe.Select();
                    return;
                }
            }
            var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            mh.TenMatHang = txtTenMatHang.Text;
            mh.IDDVT = int.Parse(cbbDVT.SelectedValue.ToString());
            mh.IdCha = idcha;
            mh.Tile = tile;
            mh.DonGiaBan = int.Parse(txtDonGiaBan.Text);
            mh.NgayCapNhat = DateTime.Now;
            mh.NguoiCapNhat = nhanvien;
            mh.isDichVu = rbtDichVu.Checked ? (bool)true : (bool)false;
            db.SubmitChanges();
            ShowData();
            MessageBox.Show("Cập nhật mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtTenMatHang.Text = null;
            txtDonGiaBan.Text = null;
            cbbDVT.SelectedIndex = -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn thực sự muốn xóa mặt hàng" + r.Cells["tenmathang"].Value.ToString() + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    db.SubmitChanges();
                    MessageBox.Show("Xóa mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                    txtTenMatHang.Text = null;
                    txtDonGiaBan.Text = null;
                    cbbDVT.SelectedIndex = -1;
                    r = null;
                }
                catch
                {
                    MessageBox.Show("Xóa mặt hàng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtTiLe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rbtDichVu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMatHang.Checked)
            {
                cbbMatHangGoc.Enabled = true;
                txtTiLe.Enabled = true;
            }
            else
            {
                cbbMatHangGoc.Enabled = false;
                cbbMatHangGoc.SelectedIndex = -1;
                txtTiLe.Text = "0";
                txtTiLe.Enabled = false;
            }
        }
    }
}
