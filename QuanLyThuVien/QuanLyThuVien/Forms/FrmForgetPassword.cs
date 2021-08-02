using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.Classes;

namespace QuanLyThuVien.Forms
{
    public partial class FrmForgetPassword : Form
    {
        public FrmForgetPassword()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FrmLogin formLogin = new FrmLogin();
            formLogin.Show();
            this.Hide();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDN.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập tài khoản/tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Mail mail = new Mail();
            mail.sendMail(txtTenDN.Text);

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
    }
}
