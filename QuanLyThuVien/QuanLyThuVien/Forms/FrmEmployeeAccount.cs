using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace QuanLyThuVien.Forms
{
    public partial class FrmEmployeeAccount : Form
    {
        public FrmEmployeeAccount()
        {
            InitializeComponent();
            this.dtgvNV.ColumnHeadersDefaultCellStyle.Font = (new Font("Tahoma", 9, FontStyle.Bold));
            this.dtgvNV.DefaultCellStyle.Font = (new Font("Tahoma", 10, FontStyle.Regular));
           // this.dtgvNV.DefaultCellStyle.BackColor = Color.LightCyan;
            this.dtgvNV.DefaultCellStyle.SelectionBackColor = Color.Crimson;
        }

        private void FrmEmployeeAccount_Load(object sender, EventArgs e)
        {
            loadDataNV();
        }
        public void loadDataNV()
        {
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                var dt = from tt in data.THUTHUs
                         where tt.TAIKHOAN.QUYEN == 0 || tt.TAIKHOAN.QUYEN == -1 && tt.TAIKHOAN.QUYEN != 1
                         select new
                         {
                             MATT = tt.MATT,
                             HOTEN = tt.HOTEN,
                             PHAI = tt.PHAI,
                             DIACHI = tt.DIACHI,
                             SODT = tt.SODT,
                             TINHTRANG = tt.TAIKHOAN.QUYEN == -1 ? "Lock" : "Active"
                         };
                dtgvNV.DataSource = dt;
                dtgvNV.ClearSelection();
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (dtgvNV.SelectedRows.Count == 0)
            {
                return;
            }
            dynamic tt = dtgvNV.CurrentRow.DataBoundItem;
            string maTT = tt.MATT;
            try
            {
                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    THUTHU thuThu = data.THUTHUs.Where(t => t.MATT == maTT).FirstOrDefault();
                    if (thuThu == null)
                    {
                        loadDataNV();
                        return;
                    }
                    TAIKHOAN tk = data.TAIKHOANs.Where(t => t.TENDN == thuThu.TENDN).FirstOrDefault();
                    if (tk.QUYEN != -1)
                    {
                        tk.QUYEN = -1;
                        data.SubmitChanges();
                        MessageBox.Show("Khoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataNV();
                    }
                    else
                    {
                        MessageBox.Show("Tài này đã bị khoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thất bại!" + Environment.NewLine + "Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            if (dtgvNV.SelectedRows.Count == 0)
            {
                return;
            }
            dynamic tt = dtgvNV.CurrentRow.DataBoundItem;
            string maTT = tt.MATT;
            try
            {
                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    THUTHU thuThu = data.THUTHUs.Where(t => t.MATT == maTT).FirstOrDefault();
                    if (thuThu == null)
                    {
                        loadDataNV();
                        return;
                    }
                    TAIKHOAN tk = data.TAIKHOANs.Where(t => t.TENDN == thuThu.TENDN).FirstOrDefault();
                    if (tk.QUYEN != 0)
                    {
                        tk.QUYEN = 0;
                        data.SubmitChanges();
                        MessageBox.Show("Mở khoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataNV();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản này đang hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại!" + Environment.NewLine + "Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
