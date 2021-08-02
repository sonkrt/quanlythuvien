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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void cbShowMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowMK.Checked)
            {
                txtMK.UseSystemPasswordChar = false;
            }
            else
            {
                txtMK.UseSystemPasswordChar = true;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            btnDangNhap.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text == string.Empty || txtMK.Text == string.Empty || txtTenDN.Text == "Tên đăng nhập" || txtMK.Text == "Mật khẩu")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                TAIKHOAN tk = data.TAIKHOANs.Where(t => t.TENDN == txtTenDN.Text && t.MATKHAU == txtMK.Text).FirstOrDefault();
                if (tk == null)
                {
                    MessageBox.Show("Thông tin tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    THUTHU tt = data.THUTHUs.Where(t => t.TENDN == tk.TENDN).FirstOrDefault();
                    //if (tt == null)
                    //{
                    //    MessageBox.Show("Không tìm thấy thông tin của tài khoản này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    if (tk.QUYEN == -1)
                    {
                        MessageBox.Show("Tài khoản này hiện đang bị khoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    frmMain formMain = new frmMain(tt);
                    formMain.Show();
                    this.Hide();
                }
            }
        }

        private void txtTenDN_Enter(object sender, EventArgs e)
        {
            if (txtTenDN.Text == "Tên đăng nhập")
            {
                txtTenDN.Text = "";
                txtTenDN.ForeColor = Color.Black;
            }
        }

        private void txtTenDN_Leave(object sender, EventArgs e)
        {
            if (txtTenDN.Text == "")
            {
                txtTenDN.Text = "Tên đăng nhập";
                txtTenDN.ForeColor = Color.Gray;
            }
        }

        private void txtMK_Enter(object sender, EventArgs e)
        {
            if (txtMK.Text == "Mật khẩu")
            {
                txtMK.Text = "";
                txtMK.ForeColor = Color.Black;
                txtMK.UseSystemPasswordChar = true;
            }
        }

        private void txtMK_Leave(object sender, EventArgs e)
        {
            if (txtMK.Text == "")
            {
                txtMK.Text = "Mật khẩu";
                txtMK.ForeColor = Color.Gray;
                txtMK.UseSystemPasswordChar = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FrmForgetPassword formForgetPassword = new FrmForgetPassword();
            formForgetPassword.Show();
            this.Hide();
        }
    }
}
