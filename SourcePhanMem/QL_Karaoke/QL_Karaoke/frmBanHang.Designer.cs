
namespace QL_Karaoke
{
    partial class frmBanHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBanHang));
            this.pnlControl = new System.Windows.Forms.Panel();
            this.dgvDSMatHang = new System.Windows.Forms.DataGridView();
            this.lblPhongDangChon = new System.Windows.Forms.Label();
            this.pnlOrder = new System.Windows.Forms.Panel();
            this.dgvCTBanHang = new System.Windows.Forms.DataGridView();
            this.pnlThoiGian = new System.Windows.Forms.Panel();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.mtbKetThuc = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mtbBatDau = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbcBanHang = new System.Windows.Forms.TabControl();
            this.tpBanHang = new System.Windows.Forms.TabPage();
            this.tbcContent = new System.Windows.Forms.TabControl();
            this.tpLSGD = new System.Windows.Forms.TabPage();
            this.dgvLSGD = new System.Windows.Forms.DataGridView();
            this.pdHoaDon = new System.Drawing.Printing.PrintDocument();
            this.pddHoaDon = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSMatHang)).BeginInit();
            this.pnlOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTBanHang)).BeginInit();
            this.pnlThoiGian.SuspendLayout();
            this.tbcBanHang.SuspendLayout();
            this.tpBanHang.SuspendLayout();
            this.tpLSGD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSGD)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.dgvDSMatHang);
            this.pnlControl.Controls.Add(this.lblPhongDangChon);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControl.Location = new System.Drawing.Point(910, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(483, 511);
            this.pnlControl.TabIndex = 1;
            // 
            // dgvDSMatHang
            // 
            this.dgvDSMatHang.AllowUserToAddRows = false;
            this.dgvDSMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDSMatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDSMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSMatHang.Location = new System.Drawing.Point(3, 22);
            this.dgvDSMatHang.MultiSelect = false;
            this.dgvDSMatHang.Name = "dgvDSMatHang";
            this.dgvDSMatHang.ReadOnly = true;
            this.dgvDSMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSMatHang.Size = new System.Drawing.Size(477, 486);
            this.dgvDSMatHang.TabIndex = 1;
            this.dgvDSMatHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSMatHang_CellDoubleClick);
            // 
            // lblPhongDangChon
            // 
            this.lblPhongDangChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhongDangChon.AutoSize = true;
            this.lblPhongDangChon.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.lblPhongDangChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhongDangChon.ForeColor = System.Drawing.Color.White;
            this.lblPhongDangChon.Location = new System.Drawing.Point(177, 12);
            this.lblPhongDangChon.Name = "lblPhongDangChon";
            this.lblPhongDangChon.Size = new System.Drawing.Size(13, 17);
            this.lblPhongDangChon.TabIndex = 0;
            this.lblPhongDangChon.Text = ".";
            this.lblPhongDangChon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlOrder
            // 
            this.pnlOrder.Controls.Add(this.dgvCTBanHang);
            this.pnlOrder.Controls.Add(this.pnlThoiGian);
            this.pnlOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOrder.Location = new System.Drawing.Point(0, 313);
            this.pnlOrder.Name = "pnlOrder";
            this.pnlOrder.Size = new System.Drawing.Size(910, 198);
            this.pnlOrder.TabIndex = 2;
            // 
            // dgvCTBanHang
            // 
            this.dgvCTBanHang.AllowUserToAddRows = false;
            this.dgvCTBanHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCTBanHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvCTBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTBanHang.Location = new System.Drawing.Point(258, 3);
            this.dgvCTBanHang.MultiSelect = false;
            this.dgvCTBanHang.Name = "dgvCTBanHang";
            this.dgvCTBanHang.ReadOnly = true;
            this.dgvCTBanHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCTBanHang.Size = new System.Drawing.Size(646, 192);
            this.dgvCTBanHang.TabIndex = 1;
            this.dgvCTBanHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSMatHang_CellDoubleClick);
            // 
            // pnlThoiGian
            // 
            this.pnlThoiGian.Controls.Add(this.btnBatDau);
            this.pnlThoiGian.Controls.Add(this.btnKetThuc);
            this.pnlThoiGian.Controls.Add(this.mtbKetThuc);
            this.pnlThoiGian.Controls.Add(this.label4);
            this.pnlThoiGian.Controls.Add(this.mtbBatDau);
            this.pnlThoiGian.Controls.Add(this.label3);
            this.pnlThoiGian.Location = new System.Drawing.Point(3, 6);
            this.pnlThoiGian.Name = "pnlThoiGian";
            this.pnlThoiGian.Size = new System.Drawing.Size(249, 180);
            this.pnlThoiGian.TabIndex = 2;
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnBatDau.Enabled = false;
            this.btnBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDau.ForeColor = System.Drawing.Color.White;
            this.btnBatDau.Location = new System.Drawing.Point(21, 135);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(99, 33);
            this.btnBatDau.TabIndex = 4;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnKetThuc.Enabled = false;
            this.btnKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetThuc.ForeColor = System.Drawing.Color.White;
            this.btnKetThuc.Location = new System.Drawing.Point(126, 135);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(99, 33);
            this.btnKetThuc.TabIndex = 4;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.UseVisualStyleBackColor = false;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // mtbKetThuc
            // 
            this.mtbKetThuc.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbKetThuc.Location = new System.Drawing.Point(77, 91);
            this.mtbKetThuc.Mask = "00/00/0000 90:00";
            this.mtbKetThuc.Name = "mtbKetThuc";
            this.mtbKetThuc.Size = new System.Drawing.Size(160, 20);
            this.mtbKetThuc.TabIndex = 3;
            this.mtbKetThuc.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kết thúc";
            // 
            // mtbBatDau
            // 
            this.mtbBatDau.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbBatDau.Location = new System.Drawing.Point(77, 35);
            this.mtbBatDau.Mask = "00/00/0000 90:00";
            this.mtbBatDau.Name = "mtbBatDau";
            this.mtbBatDau.Size = new System.Drawing.Size(160, 20);
            this.mtbBatDau.TabIndex = 3;
            this.mtbBatDau.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bắt đầu";
            // 
            // tbcBanHang
            // 
            this.tbcBanHang.Controls.Add(this.tpBanHang);
            this.tbcBanHang.Controls.Add(this.tpLSGD);
            this.tbcBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcBanHang.Location = new System.Drawing.Point(0, 0);
            this.tbcBanHang.Name = "tbcBanHang";
            this.tbcBanHang.SelectedIndex = 0;
            this.tbcBanHang.Size = new System.Drawing.Size(910, 313);
            this.tbcBanHang.TabIndex = 3;
            // 
            // tpBanHang
            // 
            this.tpBanHang.Controls.Add(this.tbcContent);
            this.tpBanHang.Location = new System.Drawing.Point(4, 22);
            this.tpBanHang.Name = "tpBanHang";
            this.tpBanHang.Padding = new System.Windows.Forms.Padding(3);
            this.tpBanHang.Size = new System.Drawing.Size(902, 287);
            this.tpBanHang.TabIndex = 0;
            this.tpBanHang.Text = "Bán Hàng";
            this.tpBanHang.UseVisualStyleBackColor = true;
            // 
            // tbcContent
            // 
            this.tbcContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcContent.Location = new System.Drawing.Point(3, 3);
            this.tbcContent.Name = "tbcContent";
            this.tbcContent.SelectedIndex = 0;
            this.tbcContent.Size = new System.Drawing.Size(896, 281);
            this.tbcContent.TabIndex = 1;
            this.tbcContent.SelectedIndexChanged += new System.EventHandler(this.tbcContent_SelectedIndexChanged_1);
            // 
            // tpLSGD
            // 
            this.tpLSGD.Controls.Add(this.dgvLSGD);
            this.tpLSGD.Location = new System.Drawing.Point(4, 22);
            this.tpLSGD.Name = "tpLSGD";
            this.tpLSGD.Padding = new System.Windows.Forms.Padding(3);
            this.tpLSGD.Size = new System.Drawing.Size(902, 404);
            this.tpLSGD.TabIndex = 1;
            this.tpLSGD.Text = "Lịch sử giao dịch";
            this.tpLSGD.UseVisualStyleBackColor = true;
            // 
            // dgvLSGD
            // 
            this.dgvLSGD.AllowUserToAddRows = false;
            this.dgvLSGD.AllowUserToDeleteRows = false;
            this.dgvLSGD.BackgroundColor = System.Drawing.Color.White;
            this.dgvLSGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLSGD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLSGD.Location = new System.Drawing.Point(3, 3);
            this.dgvLSGD.Name = "dgvLSGD";
            this.dgvLSGD.ReadOnly = true;
            this.dgvLSGD.Size = new System.Drawing.Size(896, 398);
            this.dgvLSGD.TabIndex = 2;
            this.dgvLSGD.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLSGD_CellDoubleClick);
            // 
            // pdHoaDon
            // 
            this.pdHoaDon.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdHoaDon_PrintPage);
            // 
            // pddHoaDon
            // 
            this.pddHoaDon.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.pddHoaDon.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.pddHoaDon.ClientSize = new System.Drawing.Size(400, 300);
            this.pddHoaDon.Enabled = true;
            this.pddHoaDon.Icon = ((System.Drawing.Icon)(resources.GetObject("pddHoaDon.Icon")));
            this.pddHoaDon.Name = "pddHoaDon";
            this.pddHoaDon.Visible = false;
            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1393, 511);
            this.Controls.Add(this.tbcBanHang);
            this.Controls.Add(this.pnlOrder);
            this.Controls.Add(this.pnlControl);
            this.Name = "frmBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBanHang";
            this.Load += new System.EventHandler(this.frmBanHang_Load);
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSMatHang)).EndInit();
            this.pnlOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTBanHang)).EndInit();
            this.pnlThoiGian.ResumeLayout(false);
            this.pnlThoiGian.PerformLayout();
            this.tbcBanHang.ResumeLayout(false);
            this.tpBanHang.ResumeLayout(false);
            this.tpLSGD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSGD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel pnlOrder;
        private System.Windows.Forms.Label lblPhongDangChon;
        private System.Windows.Forms.Panel pnlThoiGian;
        private System.Windows.Forms.MaskedTextBox mtbBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.MaskedTextBox mtbKetThuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDSMatHang;
        private System.Windows.Forms.DataGridView dgvCTBanHang;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.TabControl tbcBanHang;
        private System.Windows.Forms.TabPage tpBanHang;
        private System.Windows.Forms.TabControl tbcContent;
        private System.Windows.Forms.TabPage tpLSGD;
        private System.Windows.Forms.DataGridView dgvLSGD;
        private System.Drawing.Printing.PrintDocument pdHoaDon;
        private System.Windows.Forms.PrintPreviewDialog pddHoaDon;
    }
}