using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
namespace QuanLyThuVien.Classes
{
    class Mail
    {
        public void sendMail(string tenDN)
        {
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                TAIKHOAN taiKhoan = data.TAIKHOANs.Where(tk => tk.TENDN.Equals(tenDN)).FirstOrDefault();
                if (taiKhoan == null)
                {
                    MessageBox.Show("Tên đăng nhập/tài khoản không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                THUTHU thuThu = data.THUTHUs.Where(tt => tt.TENDN.Equals(taiKhoan.TENDN)).FirstOrDefault();
                if (thuThu == null)
                {
                    return;
                }
                string to = taiKhoan.EMAIL;
                string from = "librarysystems.031099@gmail.com";
                string password = "sonkarate19";
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Subject = "Quản Lý Thư Viện";
                message.Body = "Xin chào! " + thuThu.HOTEN + "\n" + "Mật khẩu quản lý thư viện của bạn là : " + taiKhoan.MATKHAU;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from, password);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("Mật khẩu đã được gửi đến địa chỉ email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gửi mail thất bại! Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
