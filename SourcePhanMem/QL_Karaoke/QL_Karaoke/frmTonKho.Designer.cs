
namespace QL_Karaoke
{
    partial class frmTonKho
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
            this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtTatca = new System.Windows.Forms.RadioButton();
            this.rbtGanHet = new System.Windows.Forms.RadioButton();
            this.rbtdaHet = new System.Windows.Forms.RadioButton();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTonKho
            // 
            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.AllowUserToDeleteRows = false;
            this.dgvTonKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonKho.Location = new System.Drawing.Point(0, 122);
            this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTonKho.Size = new System.Drawing.Size(1075, 495);
            this.dgvTonKho.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(854, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "THỐNG KÊ TỒN KHO";
            // 
            // rbtTatca
            // 
            this.rbtTatca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtTatca.AutoSize = true;
            this.rbtTatca.Checked = true;
            this.rbtTatca.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtTatca.ForeColor = System.Drawing.Color.White;
            this.rbtTatca.Location = new System.Drawing.Point(771, 56);
            this.rbtTatca.Name = "rbtTatca";
            this.rbtTatca.Size = new System.Drawing.Size(143, 17);
            this.rbtTatca.TabIndex = 2;
            this.rbtTatca.TabStop = true;
            this.rbtTatca.Text = "Tất cả các mặt hàng";
            this.rbtTatca.UseVisualStyleBackColor = true;
            // 
            // rbtGanHet
            // 
            this.rbtGanHet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtGanHet.AutoSize = true;
            this.rbtGanHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtGanHet.ForeColor = System.Drawing.Color.White;
            this.rbtGanHet.Location = new System.Drawing.Point(771, 79);
            this.rbtGanHet.Name = "rbtGanHet";
            this.rbtGanHet.Size = new System.Drawing.Size(70, 17);
            this.rbtGanHet.TabIndex = 2;
            this.rbtGanHet.Text = "Gần hết";
            this.rbtGanHet.UseVisualStyleBackColor = true;
            // 
            // rbtdaHet
            // 
            this.rbtdaHet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtdaHet.AutoSize = true;
            this.rbtdaHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtdaHet.ForeColor = System.Drawing.Color.White;
            this.rbtdaHet.Location = new System.Drawing.Point(771, 102);
            this.rbtdaHet.Name = "rbtdaHet";
            this.rbtdaHet.Size = new System.Drawing.Size(63, 17);
            this.rbtdaHet.TabIndex = 2;
            this.rbtdaHet.Text = "Đã hết";
            this.rbtdaHet.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(924, 77);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(129, 42);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_Karaoke.Properties.Resources.kiemkho;
            this.pictureBox1.Location = new System.Drawing.Point(128, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 115);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // frmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1076, 615);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.rbtdaHet);
            this.Controls.Add(this.rbtGanHet);
            this.Controls.Add(this.rbtTatca);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTonKho);
            this.Name = "frmTonKho";
            this.Text = "frmTonKho";
            this.Load += new System.EventHandler(this.frmTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtTatca;
        private System.Windows.Forms.RadioButton rbtGanHet;
        private System.Windows.Forms.RadioButton rbtdaHet;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}