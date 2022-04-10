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
    public partial class frmDonViTinh : Form
    {
        public frmDonViTinh(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }
        private DataClasses1DataContext db;
        private string nhanvien;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            ShowData();
            dgvDVT.Columns["id"].HeaderText = "Mã ĐVT";
            dgvDVT.Columns["id"].Width = 100;
            dgvDVT.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvDVT.Columns["TenDVT"].HeaderText = "Tên ĐVT";

            txtDVT.Select();
        }
        private void ShowData()
        {
            var rs = (from d in db.DonViTinhs
                      select new
                      {
                          d.ID,
                          d.TenDVT
                      }).ToList();
            dgvDVT.DataSource = rs;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }
        private DataGridViewRow r;
        private void dgvDVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());
             r = dgvDVT.Rows[e.RowIndex];
            //MessageBox.Show(r.Cells["TenDVT"].Value.ToString());
            txtDVT.Text = r.Cells["TenDVT"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(r==null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần cập nhật", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }   
            if(!string.IsNullOrEmpty(txtDVT.Text))
            {
                var dvt = db.DonViTinhs.SingleOrDefault(x => x.ID == int.Parse( r.Cells["id"].Value.ToString()));
                dvt.TenDVT = txtDVT.Text;
                dvt.NgayCapNhat = DateTime.Now;
                dvt.NguoiCapNhat = nhanvien;
                db.SubmitChanges();
                MessageBox.Show("Cập nhật đơn vị tính thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
                txtDVT.Text = null;
                r = null;
            }   
            else
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị tính", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(MessageBox.Show("Bạn thực sự muốn xóa đơn vị tính"+r.Cells["TenDVT"].Value.ToString()+"?","Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                var dvt = db.DonViTinhs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                db.SubmitChanges();
                MessageBox.Show("Xóa đơn vị tính thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
                txtDVT.Text = null;
                r = null;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtDVT.Text))
            {
                DonViTinh dvt = new DonViTinh();
                dvt.TenDVT = txtDVT.Text;
                dvt.NgayTao = DateTime.Now;
                dvt.NguoiTao = nhanvien;
                db.DonViTinhs.InsertOnSubmit(dvt);
                db.SubmitChanges();
                MessageBox.Show("Thêm mới đơn vị tính thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
                r = null;
                txtDVT.Text = null;
                
            } 
            else
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtDVT.Select();
        }
    }
}
