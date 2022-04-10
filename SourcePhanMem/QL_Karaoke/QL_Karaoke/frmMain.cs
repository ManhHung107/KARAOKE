using QL_Karaoke.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Karaoke
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private Boolean isMaximize = false;
        private void ptbTat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void ptbThuNho_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void ptbPhongTo_Click(object sender, EventArgs e)
        {
            if(!isMaximize)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }    
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
            isMaximize = !isMaximize;
        }


        
        private DataClasses1DataContext db;
        NhanVien nv;
        private void frmMain_Load(object sender, EventArgs e)
        {
            var f = new frmLogin();
            f.ShowDialog();
            
            nv = f.nv;
            if (nv != null)
            {
                frmBanHang fn = new frmBanHang();
                addForm(fn);
                lblNhanVien.Text = string.Format("Xin chào: {0}", nv.HoVaTen);
                db = new DataClasses1DataContext();
                if (nv.isAdmin is false)
                {
                    danhMucToolStripMenuItem.Visible = false;
                    thongKeBaoCaoToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                Application.Exit();
            }
            
        }
        #region Main_Show
        private void addForm(Form f)
        {
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            f.TopMost = true;
            grbContent.Controls.Clear();
            grbContent.Controls.Add(f);
            f.Show();
        }


        private void nhapHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNhapHang(nv.Username);
            addForm(f);
        }

        private void loaiPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmLoaiPhong(nv.Username);
            addForm(f);
        }

        private void PhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmPhong(nv.Username);
            addForm(f);
        }

        private void matHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmMatHang(nv.Username);
            addForm(f);
        }

        private void donViTinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDonViTinh(nv.Username);
            addForm(f);
        }

        private void nhaCungCapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNCC(nv.Username);
            addForm(f);
        }

        private void banHangToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var f = new frmBanHang();
            addForm(f);
        }
        private void tonKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmTonKho();
            addForm(f);
        }

        private void congNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmCongNo();
            addForm(f);
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDoanhThu();
            addForm(f);
        }
        private void pnlTop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ptbPhongTo_Click(null, null);
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void doiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDoiMatKhau(nv).ShowDialog();

        }
        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
            var f = new frmLogin();
            f.ShowDialog();

            nv = f.nv;
            if (nv != null)
            {
                frmBanHang fn = new frmBanHang();
                addForm(fn);
                lblNhanVien.Text = string.Format("Nhân viên: {0}", nv.HoVaTen);
                db = new DataClasses1DataContext();
                if (nv.isAdmin is false)
                {
                    danhMucToolStripMenuItem.Visible = false;
                    thongKeBaoCaoToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                Application.Exit();
            }
        }
        #endregion

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://localhost:44300/");
        }
    }
}
