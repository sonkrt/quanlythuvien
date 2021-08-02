using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FrmPrintImage : Form
    {
        public FrmPrintImage()
        {
            InitializeComponent();
        }
        private string ma;
        public FrmPrintImage(string maThe)
        {
            InitializeComponent();
            this.ma = maThe;
        }
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
        private void fillCard()
        {
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                THETV the = data.THETVs.Where(m => m.MATHE == this.ma).FirstOrDefault();
                if (the == null)
                {
                    MessageBox.Show("Không tồn tại thẻ thư viện này");
                    return;
                }
                lbHoTen.Text = the.TENDG;
                lbMaThe.Text = the.MATHE;
                lbNgayCap.Text = the.NGAYCAP.ToString();
                lbNgayHetHan.Text = the.NGAYHETHAN.ToString();
                if (the.ANHTHE != null)
                {
                    ptAnhThe.Image = ByteArrayToImage(the.ANHTHE.ToArray());
                }
            }
        }
        PrintPreviewDialog prtPreview = new PrintPreviewDialog();
        //using System.Drawing;
        //using System.Drawing.Printing;
        PrintDocument prtDocument = new PrintDocument();
        public void Print(Panel pn)
        {
            PrinterSettings ps = new PrinterSettings();
            pnTheTV = pn;
            getprintarea(pn);
            prtPreview.Document = prtDocument;
            prtDocument.PrintPage += new PrintPageEventHandler(prtDocument_printPage);
            prtPreview.ShowDialog();
        }
        public void prtDocument_printPage(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(memory, (pagearea.Width / 2) - (this.pnTheTV.Width / 2), this.pnTheTV.Location.Y);
        }
        Bitmap memory;

        public void getprintarea(Panel pn)
        {
            memory = new Bitmap(pn.Width, pn.Height);
            pn.DrawToBitmap(memory, new Rectangle(0, 0, pn.Width, pn.Height));
        }
        private void FrmPrintImage_Load(object sender, EventArgs e)
        {
            fillCard();
            //
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print(pnTheTV);
        }
    }
}
