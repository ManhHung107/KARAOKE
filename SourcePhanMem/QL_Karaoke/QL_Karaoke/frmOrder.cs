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
    public partial class frmOrder : Form
    {
        public frmOrder(long idHoaDon,string tenphong, DataGridViewRow r)
        {
            this.idHoaDon = idHoaDon;
            this.r = r;
            this.tenphong = tenphong;
            InitializeComponent();
        }
        private long idHoaDon;
        private string tenphong;
        private DataGridViewRow r;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }
        private DataClasses1DataContext db;
        private void frmOrder_Load(object sender, EventArgs e)
        {

            this.lblTenMatHang.Text ="Mặt hàng yêu cầu: " +r.Cells["tenhang"].Value.ToString()+ " [" + r.Cells["dvt"].Value.ToString() + "]";
            this.lblPhong.Text = string.Format("Phòng phục vụ: {0}",tenphong);
            txtSoLuong.Select();
            db = new DataClasses1DataContext();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if(e.KeyChar==(char)13)
            {
                btnXacNhan.PerformClick();
            }    
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                int sl = 0;
                try
                {
                    sl = int.Parse(txtSoLuong.Text);
                    if (sl == 0)
                    {
                        MessageBox.Show("Số lượng không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSoLuong.Select();
                        return;
                    }

                }
                catch
                {
                    MessageBox.Show("Số lượng không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoLuong.Select();
                    return;
                }




                var item = db.ChiTietHoaDonBanHangs.SingleOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(r.Cells["mahang"].Value.ToString()));
                if (item != null)
                {
                    item.SL += sl;
                    db.SubmitChanges();
                }
                else
                {
                    var ct = new ChiTietHoaDonBanHang();
                    ct.IDHoaDon = idHoaDon;
                    ct.IDMatHang = int.Parse(r.Cells["mahang"].Value.ToString());
                    ct.SL = sl;

                    var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["mahang"].Value.ToString()));
                    ct.DonGia = mh.DonGiaBan;
                    db.ChiTietHoaDonBanHangs.InsertOnSubmit(ct);
                    db.SubmitChanges();

                }
                MessageBox.Show("Thêm mặt hàng vào phòng: " + tenphong + " thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi:" +ex.Message, "Yêu cầu phục vụ thất bại ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
