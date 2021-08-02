using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien.SubForm
{
    public partial class PageMenuTop : UserControl
    {
        public PageMenuTop()
        {
            InitializeComponent();
        }

        private void PageSach_Load(object sender, EventArgs e)
        {
            //----------------------------
            subTheLoai1.Hide();
            subSach1.Show();
            subSach1.BringToFront();
            //-----------------------------
        }
        public void clearSelection()
        {
            subSach1.dtgvSubSach.ClearSelection();
        }
        public void loadDataSubSach()
        {
            subSach1.loadData();
            subSach1.resetForm();
        }
        private void btnMenuSubSach_Click(object sender, EventArgs e)
        {
            //----------------------------
            subTheLoai1.Hide();
            subSach1.Show();
            subSach1.loadData();
            subSach1.resetForm();
            subSach1.dtgvSubSach.ClearSelection();
            subSach1.BringToFront();
            //-----------------------------
        }

        private void btnMenuSubTheLoai_Click(object sender, EventArgs e)
        {
            //----------------------------
            subSach1.Hide();
            subTheLoai1.Show();
            subTheLoai1.LoadDL();
            subTheLoai1.resetForm();
            subTheLoai1.dtgvTheLoaiSach.ClearSelection();
            subTheLoai1.BringToFront();
            //-----------------------------
        }
    }
}
