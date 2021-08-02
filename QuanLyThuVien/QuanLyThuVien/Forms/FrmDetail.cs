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
    public partial class FrmDetail : Form
    {
        private MUONSACH ms;
        public FrmDetail()
        {
            InitializeComponent();
        }
        public FrmDetail(MUONSACH ms)
        {
            InitializeComponent();
            this.ms = ms;
        }
        private void loadForm()
        {
            if (this.ms != null)
            {
                lbHoTen.Text = ms.THETV.TENDG;
                lbMaThe.Text = ms.THETV.MATHE;
                lbTenSach.Text = ms.SACH.TENSH;
                lbMaSach.Text = ms.SACH.MASH;
                lbTinhTrang.Text = ms.TINHTRANG;
                lbNgayMuon.Text = ms.NGAYMUON.ToString("dd/MM/yyyy");//ms.NGAYMUON.ToShortDateString();
                if (ms.NGAYTRA != null)
                {
                    lbNgayTra.Text = String.Format("{0:dd/MM/yyyy}", ms.NGAYTRA);  
                }
                lbHanTra.Text = ms.HANTRA.ToString("dd/MM/yyyy");//ms.HANTRA.ToShortDateString();
                if (ms.TIENPHAT != 0)
                {
                    lbTienPhat.Text = String.Format("{0:0,0}", ms.TIENPHAT) + " đ";
                }
                if (ms.GHICHU != null)
                {
                    lbGhiChu.Text = ms.GHICHU;
                }
                lbThuThu.Text = ms.THUTHU.HOTEN;

            }
        }

        private void FrmDetail_Load(object sender, EventArgs e)
        {
            loadForm();
        }
    }
}
