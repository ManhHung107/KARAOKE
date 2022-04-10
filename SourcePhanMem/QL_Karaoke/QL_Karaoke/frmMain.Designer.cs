
namespace QL_Karaoke
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBot = new System.Windows.Forms.Panel();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.mnsMain = new System.Windows.Forms.MenuStrip();
            this.heThongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doiMatKhauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dangXuatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMucToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhapHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loaiPhongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PhongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donViTinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhaCungCapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banHangToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thongKeBaoCaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tonKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.congNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.troGiupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.grbContent = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.ptbTat = new System.Windows.Forms.PictureBox();
            this.ptbThuNho = new System.Windows.Forms.PictureBox();
            this.ptbPhongTo = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlBot.SuspendLayout();
            this.mnsMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbThuNho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPhongTo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBot
            // 
            this.pnlBot.Controls.Add(this.button1);
            this.pnlBot.Controls.Add(this.lblNhanVien);
            this.pnlBot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBot.Location = new System.Drawing.Point(0, 762);
            this.pnlBot.Name = "pnlBot";
            this.pnlBot.Size = new System.Drawing.Size(1340, 30);
            this.pnlBot.TabIndex = 2;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVien.ForeColor = System.Drawing.Color.Black;
            this.lblNhanVien.Location = new System.Drawing.Point(12, 3);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(52, 17);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "label1";
            // 
            // mnsMain
            // 
            this.mnsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heThongToolStripMenuItem,
            this.danhMucToolStripMenuItem,
            this.banHangToolStripMenuItem1,
            this.thongKeBaoCaoToolStripMenuItem,
            this.troGiupToolStripMenuItem});
            this.mnsMain.Location = new System.Drawing.Point(0, 34);
            this.mnsMain.Name = "mnsMain";
            this.mnsMain.Size = new System.Drawing.Size(1340, 24);
            this.mnsMain.TabIndex = 4;
            this.mnsMain.Text = "menuStrip1";
            // 
            // heThongToolStripMenuItem
            // 
            this.heThongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doiMatKhauToolStripMenuItem,
            this.dangXuatToolStripMenuItem,
            this.thoatToolStripMenuItem});
            this.heThongToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.factory_256;
            this.heThongToolStripMenuItem.Name = "heThongToolStripMenuItem";
            this.heThongToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.heThongToolStripMenuItem.Text = "Hệ Thống";
            // 
            // doiMatKhauToolStripMenuItem
            // 
            this.doiMatKhauToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.icons8_Password_50px;
            this.doiMatKhauToolStripMenuItem.Name = "doiMatKhauToolStripMenuItem";
            this.doiMatKhauToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.doiMatKhauToolStripMenuItem.Text = "Đổi mật khẩu";
            this.doiMatKhauToolStripMenuItem.Click += new System.EventHandler(this.doiMatKhauToolStripMenuItem_Click);
            // 
            // dangXuatToolStripMenuItem
            // 
            this.dangXuatToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.Logout;
            this.dangXuatToolStripMenuItem.Name = "dangXuatToolStripMenuItem";
            this.dangXuatToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.dangXuatToolStripMenuItem.Text = "Đăng xuất";
            this.dangXuatToolStripMenuItem.Click += new System.EventHandler(this.dangXuatToolStripMenuItem_Click);
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.Exit1;
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // danhMucToolStripMenuItem
            // 
            this.danhMucToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhapHangToolStripMenuItem,
            this.loaiPhongToolStripMenuItem,
            this.PhongToolStripMenuItem,
            this.matHangToolStripMenuItem,
            this.donViTinhToolStripMenuItem,
            this.nhaCungCapToolStripMenuItem});
            this.danhMucToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.icons8_Menu_64px;
            this.danhMucToolStripMenuItem.Name = "danhMucToolStripMenuItem";
            this.danhMucToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.danhMucToolStripMenuItem.Text = "Danh mục";
            // 
            // nhapHangToolStripMenuItem
            // 
            this.nhapHangToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.icons8_Trolley_52px;
            this.nhapHangToolStripMenuItem.Name = "nhapHangToolStripMenuItem";
            this.nhapHangToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.nhapHangToolStripMenuItem.Text = "Nhập hàng";
            this.nhapHangToolStripMenuItem.Click += new System.EventHandler(this.nhapHangToolStripMenuItem_Click);
            // 
            // loaiPhongToolStripMenuItem
            // 
            this.loaiPhongToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.app_type_catalog_512px_GREY1;
            this.loaiPhongToolStripMenuItem.Name = "loaiPhongToolStripMenuItem";
            this.loaiPhongToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.loaiPhongToolStripMenuItem.Text = "Loại phòng";
            this.loaiPhongToolStripMenuItem.Click += new System.EventHandler(this.loaiPhongToolStripMenuItem_Click);
            // 
            // PhongToolStripMenuItem
            // 
            this.PhongToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.images1;
            this.PhongToolStripMenuItem.Name = "PhongToolStripMenuItem";
            this.PhongToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.PhongToolStripMenuItem.Text = "Phòng";
            this.PhongToolStripMenuItem.Click += new System.EventHandler(this.PhongToolStripMenuItem_Click);
            // 
            // matHangToolStripMenuItem
            // 
            this.matHangToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.icons8_Gift_50px;
            this.matHangToolStripMenuItem.Name = "matHangToolStripMenuItem";
            this.matHangToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.matHangToolStripMenuItem.Text = "Mặt hàng";
            this.matHangToolStripMenuItem.Click += new System.EventHandler(this.matHangToolStripMenuItem_Click);
            // 
            // donViTinhToolStripMenuItem
            // 
            this.donViTinhToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.dvtinh;
            this.donViTinhToolStripMenuItem.Name = "donViTinhToolStripMenuItem";
            this.donViTinhToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.donViTinhToolStripMenuItem.Text = "Đơn vị tính";
            this.donViTinhToolStripMenuItem.Click += new System.EventHandler(this.donViTinhToolStripMenuItem_Click);
            // 
            // nhaCungCapToolStripMenuItem
            // 
            this.nhaCungCapToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.delivery18;
            this.nhaCungCapToolStripMenuItem.Name = "nhaCungCapToolStripMenuItem";
            this.nhaCungCapToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.nhaCungCapToolStripMenuItem.Text = "Nhà cung cấp";
            this.nhaCungCapToolStripMenuItem.Click += new System.EventHandler(this.nhaCungCapToolStripMenuItem_Click);
            // 
            // banHangToolStripMenuItem1
            // 
            this.banHangToolStripMenuItem1.Image = global::QL_Karaoke.Properties.Resources.icons8_Typewriter_With_Paper_50px;
            this.banHangToolStripMenuItem1.Name = "banHangToolStripMenuItem1";
            this.banHangToolStripMenuItem1.Size = new System.Drawing.Size(87, 20);
            this.banHangToolStripMenuItem1.Text = "Bán Hàng";
            this.banHangToolStripMenuItem1.Click += new System.EventHandler(this.banHangToolStripMenuItem1_Click);
            // 
            // thongKeBaoCaoToolStripMenuItem
            // 
            this.thongKeBaoCaoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tonKhoToolStripMenuItem,
            this.congNoToolStripMenuItem,
            this.doanhThuToolStripMenuItem});
            this.thongKeBaoCaoToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.ThongKe;
            this.thongKeBaoCaoToolStripMenuItem.Name = "thongKeBaoCaoToolStripMenuItem";
            this.thongKeBaoCaoToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.thongKeBaoCaoToolStripMenuItem.Text = "Thống Kê - Báo Cáo";
            // 
            // tonKhoToolStripMenuItem
            // 
            this.tonKhoToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.TonKho;
            this.tonKhoToolStripMenuItem.Name = "tonKhoToolStripMenuItem";
            this.tonKhoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.tonKhoToolStripMenuItem.Text = "Tồn kho";
            this.tonKhoToolStripMenuItem.Click += new System.EventHandler(this.tonKhoToolStripMenuItem_Click);
            // 
            // congNoToolStripMenuItem
            // 
            this.congNoToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.DVT;
            this.congNoToolStripMenuItem.Name = "congNoToolStripMenuItem";
            this.congNoToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.congNoToolStripMenuItem.Text = "Công nợ";
            this.congNoToolStripMenuItem.Click += new System.EventHandler(this.congNoToolStripMenuItem_Click);
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.dvtinh1;
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.doanhThuToolStripMenuItem.Text = "Doanh thu";
            this.doanhThuToolStripMenuItem.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
            // 
            // troGiupToolStripMenuItem
            // 
            this.troGiupToolStripMenuItem.Image = global::QL_Karaoke.Properties.Resources.TroGiup;
            this.troGiupToolStripMenuItem.Name = "troGiupToolStripMenuItem";
            this.troGiupToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.troGiupToolStripMenuItem.Text = "Trợ Giúp";
            // 
            // pnlRight
            // 
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(1330, 58);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(10, 704);
            this.pnlRight.TabIndex = 6;
            // 
            // grbContent
            // 
            this.grbContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbContent.Location = new System.Drawing.Point(10, 58);
            this.grbContent.Name = "grbContent";
            this.grbContent.Size = new System.Drawing.Size(1320, 704);
            this.grbContent.TabIndex = 7;
            this.grbContent.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "KARAOKE QUÊN ĐƯỜNG VỀ NHÀ";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.ptbTat);
            this.pnlTop.Controls.Add(this.ptbThuNho);
            this.pnlTop.Controls.Add(this.ptbPhongTo);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1340, 34);
            this.pnlTop.TabIndex = 8;
            this.pnlTop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseDoubleClick);
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            // 
            // ptbTat
            // 
            this.ptbTat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbTat.BackColor = System.Drawing.Color.Black;
            this.ptbTat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbTat.Image = global::QL_Karaoke.Properties.Resources.Exit;
            this.ptbTat.Location = new System.Drawing.Point(1308, 3);
            this.ptbTat.Name = "ptbTat";
            this.ptbTat.Size = new System.Drawing.Size(22, 22);
            this.ptbTat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbTat.TabIndex = 0;
            this.ptbTat.TabStop = false;
            this.ptbTat.Click += new System.EventHandler(this.ptbTat_Click);
            // 
            // ptbThuNho
            // 
            this.ptbThuNho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbThuNho.BackColor = System.Drawing.Color.Black;
            this.ptbThuNho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbThuNho.Image = global::QL_Karaoke.Properties.Resources.ThuXuong;
            this.ptbThuNho.Location = new System.Drawing.Point(1240, 3);
            this.ptbThuNho.Name = "ptbThuNho";
            this.ptbThuNho.Size = new System.Drawing.Size(22, 22);
            this.ptbThuNho.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbThuNho.TabIndex = 1;
            this.ptbThuNho.TabStop = false;
            this.ptbThuNho.Click += new System.EventHandler(this.ptbThuNho_Click);
            // 
            // ptbPhongTo
            // 
            this.ptbPhongTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbPhongTo.BackColor = System.Drawing.Color.Black;
            this.ptbPhongTo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbPhongTo.Image = global::QL_Karaoke.Properties.Resources.PhongTo;
            this.ptbPhongTo.Location = new System.Drawing.Point(1274, 3);
            this.ptbPhongTo.Name = "ptbPhongTo";
            this.ptbPhongTo.Size = new System.Drawing.Size(22, 22);
            this.ptbPhongTo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbPhongTo.TabIndex = 1;
            this.ptbPhongTo.TabStop = false;
            this.ptbPhongTo.Click += new System.EventHandler(this.ptbPhongTo_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 58);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(10, 704);
            this.pnlLeft.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(1200, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Quản lý";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1340, 792);
            this.Controls.Add(this.grbContent);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlBot);
            this.Controls.Add(this.mnsMain);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Karaoke";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlBot.ResumeLayout(false);
            this.pnlBot.PerformLayout();
            this.mnsMain.ResumeLayout(false);
            this.mnsMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbThuNho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPhongTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlBot;
        private System.Windows.Forms.MenuStrip mnsMain;
        private System.Windows.Forms.ToolStripMenuItem danhMucToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhapHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongKeBaoCaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem troGiupToolStripMenuItem;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.GroupBox grbContent;
        private System.Windows.Forms.PictureBox ptbTat;
        private System.Windows.Forms.PictureBox ptbThuNho;
        private System.Windows.Forms.PictureBox ptbPhongTo;
        private System.Windows.Forms.ToolStripMenuItem banHangToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loaiPhongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PhongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donViTinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhaCungCapToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ToolStripMenuItem tonKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem congNoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heThongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doiMatKhauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dangXuatToolStripMenuItem;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Button button1;
    }
}