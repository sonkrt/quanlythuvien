using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmMain : Form
    {
        private THUTHU thuThu;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(THUTHU tt)
        {
            InitializeComponent();
            this.thuThu = tt;
        }
        private void btnMenuSach_Click(object sender, EventArgs e)
        {
            //--------------------------
            pageDocGia1.Hide();
            pageMuonTra1.Hide();
            pageTaiKhoan1.Hide();
            pageThongKe1.Hide();
            pageSach1.loadDataSubSach();
            pageSach1.Show();           
            pageSach1.BringToFront();
            //--------------------------

        }

        private void btnMenuDocGia_Click(object sender, EventArgs e)
        {
            //--------------------------
            pageMuonTra1.Hide();
            pageTaiKhoan1.Hide();
            pageThongKe1.Hide();
            pageSach1.Hide();
            pageDocGia1.Show();
            pageDocGia1.loadDataDocGia();
            pageDocGia1.resetForm();
            pageDocGia1.BringToFront();
            //--------------------------
        }

        private void btnMuonTra_Click(object sender, EventArgs e)
        {
            //--------------------------           
            pageTaiKhoan1.Hide();
            pageThongKe1.Hide();
            pageSach1.Hide();
            pageDocGia1.Hide();
            pageMuonTra1.maThuThu = this.thuThu.MATT;
            pageMuonTra1.Show();
            pageMuonTra1.loadDataMuonTra();
            pageMuonTra1.resetForm();
            pageMuonTra1.BringToFront();
            //--------------------------
        }

        private void btnMenuThongKe_Click(object sender, EventArgs e)
        {
            //--------------------------           
            pageTaiKhoan1.Hide();
            pageSach1.Hide();
            pageDocGia1.Hide();
            pageMuonTra1.Hide();
            pageThongKe1.Show();
            pageThongKe1.BringToFront();
            //--------------------------
        }

        private void btnMenuTaiKhoan_Click(object sender, EventArgs e)
        {
            //--------------------------           
            pageSach1.Hide();
            pageDocGia1.Hide();
            pageMuonTra1.Hide();
            pageThongKe1.Hide();
            pageTaiKhoan1.maTT = this.thuThu.MATT;
            pageTaiKhoan1.Show();
            if (thuThu.TAIKHOAN.QUYEN == 0)
            {
                pageTaiKhoan1.btnTaoTK.Visible = false;
                pageTaiKhoan1.button4.Visible = false;
            }
            pageTaiKhoan1.loadDataTaiKhoan();
            pageTaiKhoan1.BringToFront();
            //--------------------------
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //--------------------------
            pageDocGia1.Hide();
            pageMuonTra1.Hide();
            pageTaiKhoan1.Hide();
            pageThongKe1.Hide();
            pageSach1.Show();
            pageSach1.clearSelection();
            pageSach1.BringToFront();
            //--------------------------
        }
    }
}
