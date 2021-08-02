using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.Forms;

namespace QuanLyThuVien.SubForm
{
    public partial class PageTaiKhoan : UserControl
    {
        public string maTT;
        public PageTaiKhoan()
        {
            InitializeComponent();
        }

        private void PageTaiKhoan_Load(object sender, EventArgs e)
        {

        }
        public void loadDataTaiKhoan()
        {
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                THUTHU thuThuTK = data.THUTHUs.Where(tt => tt.MATT == this.maTT).FirstOrDefault();
                if (thuThuTK == null)
                {
                    return;
                }
                txtHoTen.Text = thuThuTK.HOTEN;
                txtEmail.Text = thuThuTK.TAIKHOAN.EMAIL;
                txtSDT.Text = thuThuTK.SODT;
                txtDiaChi.Text = thuThuTK.DIACHI;
                lbTenDN.Text = thuThuTK.TAIKHOAN.TENDN;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {


        }

        private void btnSuaTT_Click(object sender, EventArgs e)
        {
            if (btnSuaTT.Tag.ToString().Equals("1"))
            {
                txtDiaChi.Enabled = true;
                txtHoTen.Enabled = true;
                txtEmail.Enabled = true;
                txtSDT.Enabled = true;
                btnSuaTT.Tag = "2";
                btnSuaTT.Text = "Lưu thông tin";
            }
            else
            {
                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    THUTHU thuThuTK = data.THUTHUs.Where(tt => tt.MATT == this.maTT).FirstOrDefault();
                    if (thuThuTK != null)
                    {
                        thuThuTK.HOTEN = txtHoTen.Text;
                        thuThuTK.DIACHI = txtDiaChi.Text;
                        thuThuTK.SODT = txtSDT.Text;
                        if (txtEmail.Text != thuThuTK.TAIKHOAN.EMAIL)
                        {
                            bool ktEmail = data.TAIKHOANs.Where(t => t.EMAIL == txtEmail.Text).Count() > 0;
                            if (ktEmail)
                            {
                                MessageBox.Show("Email này đã được sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            TAIKHOAN tk = data.TAIKHOANs.Where(t => t.TENDN == thuThuTK.TENDN).FirstOrDefault();
                            if (tk != null)
                            {
                                tk.EMAIL = txtEmail.Text;
                            }
                        }
                        data.SubmitChanges();
                        MessageBox.Show("Chỉnh sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                loadDataTaiKhoan();
                btnSuaTT.Tag = "1";
                btnSuaTT.Text = "Chỉnh sửa thông tin";
                txtDiaChi.Enabled = false;
                txtHoTen.Enabled = false;
                txtEmail.Enabled = false;
                txtSDT.Enabled = false;
            }
        }

        private void btnThayMK_Click(object sender, EventArgs e)
        {
            if (txtDoiMK.Text == string.Empty || txtNhapMK.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtDoiMK.Text != txtNhapMK.Text)
            {
                MessageBox.Show("Mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                THUTHU thuThuTK = data.THUTHUs.Where(tt => tt.MATT == this.maTT).FirstOrDefault();
                if (thuThuTK != null)
                {
                    TAIKHOAN tk = data.TAIKHOANs.Where(t => t.TENDN == thuThuTK.TENDN).FirstOrDefault();
                    if (tk != null)
                    {
                        tk.MATKHAU = txtDoiMK.Text;
                        data.SubmitChanges();
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDoiMK.Clear();
                        txtNhapMK.Clear();
                    }
                }
            }
        }

        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            FrmRegister formRegister = new FrmRegister();
            formRegister.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmEmployeeAccount formEmpAccount = new FrmEmployeeAccount();
            formEmpAccount.ShowDialog();
        }
    }
}
