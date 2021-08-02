using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }
        private static bool checkMa(int ma)
        {
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                bool ktMa = data.THUTHUs.Where(t => ma == Convert.ToInt32(t.MATT.Substring(2))).Count() > 0;
                if (ktMa)
                {
                    return false;
                }
            }
            return true;
        }
        private void resetFromTaiKhoan()
        {
            txtTenDN.Clear();
            txtMK.Clear();
            txtEmail.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            rdbNV.Checked = false;
            rdbQL.Checked = false;
            rdNam.Checked = false;
            rdNu.Checked = false;
            txtTenDN.Focus();
        }
        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text == string.Empty || txtMK.Text == string.Empty || txtEmail.Text == string.Empty || txtHoTen.Text == string.Empty ||
                txtSDT.Text == string.Empty || txtDiaChi.Text == string.Empty || rdbNV.Checked == false && rdbQL.Checked == false || rdNam.Checked == false && rdNu.Checked == false)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int countThe = 1;
            while (checkMa(countThe) == false)
            {
                countThe += 1;
            }
            String ma = "";
            if (countThe >= 1000)
            {
                ma = "TT" + countThe;
            }
            else if (countThe >= 100)
            {
                ma = "TT0" + countThe;
            }
            else if (countThe >= 10)
            {
                ma = "TT00" + countThe;
            }
            else
            {
                ma = "TT000" + countThe;
            }
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                //Kiểm tra tên ĐN có tồn tại ko?
                bool ktraTenDN = db.TAIKHOANs.Where(t => t.TENDN == txtTenDN.Text).Count() > 0;
                if (ktraTenDN)
                {
                    MessageBox.Show("Đã tồn tại tên Đăng nhập này. Vui lòng chọn tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Kiểm tra Email có tồn tại ko?
                bool ktraEmail = db.TAIKHOANs.Where(t => t.EMAIL == txtEmail.Text).Count() > 0;
                if (ktraEmail)
                {
                    MessageBox.Show("Đã tồn tại Email này. Vui lòng chọn tài khoản Email khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //Thêm 1 tài khoản mới.
                TAIKHOAN newTK = new TAIKHOAN();
                newTK.TENDN = txtTenDN.Text;
                newTK.MATKHAU = txtMK.Text;
                newTK.EMAIL = txtEmail.Text;
                //Thêm 1 thủ thư mới.
                THUTHU newTT = new THUTHU();
                newTT.MATT = ma;
                newTT.HOTEN = txtHoTen.Text;
                newTT.DIACHI = txtDiaChi.Text;
                newTT.SODT = txtSDT.Text;
                newTT.TENDN = txtTenDN.Text;
                if (rdbNV.Checked)
                {
                    newTK.QUYEN = 0;
                }
                else
                {
                    newTK.QUYEN = 1;
                }
                if (rdNam.Checked)
                {
                    newTT.PHAI = "Nam";
                }
                else
                {
                    newTT.PHAI = "Nữ";
                }
                try
                {
                    db.TAIKHOANs.InsertOnSubmit(newTK);
                    db.THUTHUs.InsertOnSubmit(newTT);
                    db.SubmitChanges();
                    MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetFromTaiKhoan();
                }
                catch
                {
                    MessageBox.Show("Tạo tài khoản không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                this.Hide();
            }
        }
    }
}
