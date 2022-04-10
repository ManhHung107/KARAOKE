
namespace QL_Karaoke
{
    partial class frmDoanhThu
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
            this.dgvTKDoanhThu = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbTuNgay = new System.Windows.Forms.MaskedTextBox();
            this.mtbDenNgay = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbItem = new System.Windows.Forms.ComboBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.ckbDichVu = new System.Windows.Forms.CheckBox();
            this.ckbMatHang = new System.Windows.Forms.CheckBox();
            this.ckbPhong = new System.Windows.Forms.CheckBox();
            this.ckbTatCa = new System.Windows.Forms.CheckBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTKDoanhThu
            // 
            this.dgvTKDoanhThu.AllowUserToAddRows = false;
            this.dgvTKDoanhThu.AllowUserToDeleteRows = false;
            this.dgvTKDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTKDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvTKDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTKDoanhThu.Location = new System.Drawing.Point(0, 128);
            this.dgvTKDoanhThu.Name = "dgvTKDoanhThu";
            this.dgvTKDoanhThu.ReadOnly = true;
            this.dgvTKDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTKDoanhThu.Size = new System.Drawing.Size(942, 406);
            this.dgvTKDoanhThu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(722, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "THỐNG KÊ DOANH THU";
            // 
            // mtbTuNgay
            // 
            this.mtbTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mtbTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbTuNgay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbTuNgay.Location = new System.Drawing.Point(577, 63);
            this.mtbTuNgay.Mask = "00/00/0000 90:00";
            this.mtbTuNgay.Name = "mtbTuNgay";
            this.mtbTuNgay.Size = new System.Drawing.Size(133, 20);
            this.mtbTuNgay.TabIndex = 1;
            this.mtbTuNgay.ValidatingType = typeof(System.DateTime);
            // 
            // mtbDenNgay
            // 
            this.mtbDenNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mtbDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDenNgay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbDenNgay.Location = new System.Drawing.Point(797, 63);
            this.mtbDenNgay.Mask = "00/00/0000 90:00";
            this.mtbDenNgay.Name = "mtbDenNgay";
            this.mtbDenNgay.Size = new System.Drawing.Size(133, 20);
            this.mtbDenNgay.TabIndex = 2;
            this.mtbDenNgay.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(518, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(723, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Đến ngày";
            // 
            // cbbItem
            // 
            this.cbbItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbItem.FormattingEnabled = true;
            this.cbbItem.Location = new System.Drawing.Point(577, 89);
            this.cbbItem.Name = "cbbItem";
            this.cbbItem.Size = new System.Drawing.Size(247, 21);
            this.cbbItem.TabIndex = 3;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(846, 89);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(84, 23);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // ckbDichVu
            // 
            this.ckbDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbDichVu.AutoSize = true;
            this.ckbDichVu.Checked = true;
            this.ckbDichVu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbDichVu.ForeColor = System.Drawing.Color.White;
            this.ckbDichVu.Location = new System.Drawing.Point(432, 90);
            this.ckbDichVu.Name = "ckbDichVu";
            this.ckbDichVu.Size = new System.Drawing.Size(70, 17);
            this.ckbDichVu.TabIndex = 8;
            this.ckbDichVu.Text = "Dịch vụ";
            this.ckbDichVu.UseVisualStyleBackColor = true;
            this.ckbDichVu.CheckedChanged += new System.EventHandler(this.ckbBaThangCon_CheckedChanged);
            // 
            // ckbMatHang
            // 
            this.ckbMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbMatHang.AutoSize = true;
            this.ckbMatHang.Checked = true;
            this.ckbMatHang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbMatHang.ForeColor = System.Drawing.Color.White;
            this.ckbMatHang.Location = new System.Drawing.Point(432, 67);
            this.ckbMatHang.Name = "ckbMatHang";
            this.ckbMatHang.Size = new System.Drawing.Size(79, 17);
            this.ckbMatHang.TabIndex = 8;
            this.ckbMatHang.Text = "Mặt hàng";
            this.ckbMatHang.UseVisualStyleBackColor = true;
            this.ckbMatHang.CheckedChanged += new System.EventHandler(this.ckbBaThangCon_CheckedChanged);
            // 
            // ckbPhong
            // 
            this.ckbPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbPhong.AutoSize = true;
            this.ckbPhong.Checked = true;
            this.ckbPhong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbPhong.ForeColor = System.Drawing.Color.White;
            this.ckbPhong.Location = new System.Drawing.Point(432, 45);
            this.ckbPhong.Name = "ckbPhong";
            this.ckbPhong.Size = new System.Drawing.Size(62, 17);
            this.ckbPhong.TabIndex = 8;
            this.ckbPhong.Text = "Phòng";
            this.ckbPhong.UseVisualStyleBackColor = true;
            this.ckbPhong.CheckedChanged += new System.EventHandler(this.ckbBaThangCon_CheckedChanged);
            // 
            // ckbTatCa
            // 
            this.ckbTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbTatCa.AutoSize = true;
            this.ckbTatCa.Checked = true;
            this.ckbTatCa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTatCa.ForeColor = System.Drawing.Color.White;
            this.ckbTatCa.Location = new System.Drawing.Point(414, 22);
            this.ckbTatCa.Name = "ckbTatCa";
            this.ckbTatCa.Size = new System.Drawing.Size(63, 17);
            this.ckbTatCa.TabIndex = 8;
            this.ckbTatCa.Text = "Tất cả";
            this.ckbTatCa.UseVisualStyleBackColor = true;
            this.ckbTatCa.CheckedChanged += new System.EventHandler(this.ckbTatCa_CheckedChanged);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Black;
            this.lblTongTien.Location = new System.Drawing.Point(23, 548);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(77, 17);
            this.lblTongTien.TabIndex = 4;
            this.lblTongTien.Text = "Tổng tiền";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_Karaoke.Properties.Resources.doanhthu;
            this.pictureBox1.Location = new System.Drawing.Point(48, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(312, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(942, 584);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ckbTatCa);
            this.Controls.Add(this.ckbPhong);
            this.Controls.Add(this.ckbMatHang);
            this.Controls.Add(this.ckbDichVu);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.cbbItem);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtbDenNgay);
            this.Controls.Add(this.mtbTuNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTKDoanhThu);
            this.Name = "frmDoanhThu";
            this.Text = "frmDoanhThu";
            this.Load += new System.EventHandler(this.frmDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTKDoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTKDoanhThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbTuNgay;
        private System.Windows.Forms.MaskedTextBox mtbDenNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbItem;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.CheckBox ckbDichVu;
        private System.Windows.Forms.CheckBox ckbMatHang;
        private System.Windows.Forms.CheckBox ckbPhong;
        private System.Windows.Forms.CheckBox ckbTatCa;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}