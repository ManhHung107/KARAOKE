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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public NhanVien nv;
        private void ptbTat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Select();
                return;
            }
            DataClasses1DataContext db = new DataClasses1DataContext();
            var tk = db.NhanViens.SingleOrDefault(x => x.Username == txtTaiKhoan.Text && x.Password == txtMatKhau.Text);
            if (tk != null)
            {
                nv = tk;
                this.Dispose();

            }   
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại tài khoản hoặc mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Select();
                return;
            }    
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtTaiKhoan.Select();
        }
    }
}
