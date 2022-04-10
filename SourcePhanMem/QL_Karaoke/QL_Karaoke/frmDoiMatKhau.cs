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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau(NhanVien nv)
        {
            this.nv = nv;
            InitializeComponent();
        }
        private NhanVien nv;
        private DataClasses1DataContext db;
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            db = new DataClasses1DataContext();
            txtMatKhauHienTai.Select();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            #region rang_buoc
            if (string.IsNullOrEmpty(txtMatKhauHienTai.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại", "Chú ý!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauHienTai.Select();
                return;
            }    
            if(string.IsNullOrEmpty(txtMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Chú ý!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Select();
                return;
            }   
            if(!txtMatKhauMoi.Text.Equals(txtXacNhanMKMoi.Text))
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không trùng khớp", "Chú ý!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Select();
                return;
            }
            #endregion
            var tk = db.NhanViens.SingleOrDefault(x => x.Username == nv.Username && x.Password == txtMatKhauHienTai.Text);
            if(tk == null)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng", "Chú ý!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauHienTai.Select();
                return;
            }
            tk.Password = txtMatKhauMoi.Text;
            tk.NguoiCapNhap = nv.Username;
            tk.NgayCapNhat = DateTime.Now;
            db.SubmitChanges();
            MessageBox.Show("Đổi mật khẩu thành công", "Successfully!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            this.Dispose();
        }

        private void ptbTat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
