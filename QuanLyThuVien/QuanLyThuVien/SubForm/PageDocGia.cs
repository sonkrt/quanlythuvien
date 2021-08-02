using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using QuanLyThuVien.Forms;

namespace QuanLyThuVien.SubForm
{
    public partial class PageDocGia : UserControl
    {
        public PageDocGia()
        {
            InitializeComponent();
            dtgvDocGia.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvDocGia.ColumnHeadersDefaultCellStyle.Font = (new Font("Tahoma", 10, FontStyle.Bold));
            this.dtgvDocGia.DefaultCellStyle.Font = (new Font("Arial", 10, FontStyle.Regular));
            dtgvDocGia.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvDocGia.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgvDocGia.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           // dtgvDocGia.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvDocGia.DefaultCellStyle.BackColor = Color.LightCyan;
            this.dtgvDocGia.DefaultCellStyle.SelectionBackColor = Color.Crimson;
            this.dtgvDocGia.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dtgvDocGia.Columns[6].DefaultCellStyle.Format = "dd/MM/yyyy";

        }

        public void loadDataDocGia()
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                var docGias = from docgia in db.THETVs
                              select new
                              {
                                  MATHE = docgia.MATHE,
                                  TENDG = docgia.TENDG,
                                  PHAI = docgia.PHAI,
                                  SODT = docgia.SODT,
                                  DIACHI = docgia.DIACHI,
                                  NGAYCAP = docgia.NGAYCAP,
                                  NGAYHETHAN = docgia.NGAYHETHAN
                              };
                dtgvDocGia.DataSource = docGias;
                dtgvDocGia.ClearSelection();
            }
        }
        public void resetForm()
        {
            txtMaThe.Clear();
            txtHoTen.Clear();
            txtSDT.Clear();
            txtTimKiem.Clear();
            txtDiaChi.Clear();
            txtPath.Clear();
            //reset về ngày hiện tại.
            dtNgayCap.Value = DateTime.Now;
            dtNgayHetHan.Value = DateTime.Now;
            //reset radiobutton
            radNam.Checked = false;
            radNu.Checked = false;
            btnXoaThe.Enabled = false;
            btnSuaThe.Enabled = false;
            btnGHThe.Enabled = false;
            btnInThe.Enabled = false;
            ptAnhThe.Image = null;
            txtHoTen.Focus();
        }
        private void ptAnhThe_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            PictureBox p = sender as PictureBox;
            if (p != null)
            {
                open.Filter = "(*.jpg; *.jpeg; *.gif; *.png) | *.jpg; *.jpeg; *.gif; *.png";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    p.Image = Image.FromFile(open.FileName);
                    txtPath.Text = open.FileName;
                }
            }
        }

        private byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                var dtSearch = from tk in db.THETVs
                               where tk.MATHE.Contains(txtTimKiem.Text) || tk.TENDG.Contains(txtTimKiem.Text) || tk.SODT.Contains(txtTimKiem.Text)
                               select new
                               {
                                   MATHE = tk.MATHE,
                                   TENDG = tk.TENDG,
                                   PHAI = tk.PHAI,
                                   SODT = tk.SODT,
                                   DIACHI = tk.DIACHI,
                                   NGAYCAP = tk.NGAYCAP,
                                   NGAYHETHAN = tk.NGAYHETHAN
                               };
                if (dtSearch.Count() == 0)
                {
                    MessageBox.Show("Không có kết quả cho tìm kiếm này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dtgvDocGia.DataSource = dtSearch;
                dtgvDocGia.ClearSelection();
            }
        }

        private void PageDocGia_Load(object sender, EventArgs e)
        {
            loadDataDocGia();
        }
        private static bool checkMa(int ma)
        {
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                bool ktMaThe = data.THETVs.Where(t => ma == Convert.ToInt32(t.MATHE.Substring(2))).Count() > 0;
                if (ktMaThe)
                {
                    return false;
                }
            }
            return true;
        }
        private void btnDKThe_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == string.Empty || txtSDT.Text == string.Empty || txtDiaChi.Text == string.Empty || radNam.Checked == false && radNu.Checked == false)
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
                ma = "TH" + countThe;
            }
            else if (countThe >= 100)
            {
                ma = "TH0" + countThe;

            }
            else if (countThe >= 10)
            {
                ma = "TH00" + countThe;
            }
            else
            {
                ma = "TH000" + countThe;
            }
            //Ảnh thẻ           
            THETV themTV = new THETV();
            themTV.MATHE = ma; //Mã thẻ
            themTV.TENDG = txtHoTen.Text; //Họ tên
            if (ptAnhThe.Image == null)
            {
                themTV.ANHTHE = null;
            }
            else
            {
                byte[] file_byte = ImageToByteArray(ptAnhThe.Image);
                System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);
                themTV.ANHTHE = file_binary; //Ảnh thẻ
            }
            if (radNam.Checked) //Giới tính
            {
                themTV.PHAI = "Nam";
            }
            else
            {
                themTV.PHAI = "Nữ";
            }
            themTV.SODT = txtSDT.Text;
            themTV.DIACHI = txtDiaChi.Text;
            themTV.NGAYCAP = DateTime.Now; //ngày cấp thẻ = ngày hiện tại.
            themTV.NGAYHETHAN = DateTime.Now.AddMonths(6); // Ngày hết hạn = ngày hiện tại thêm 6 tháng.
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                try
                {
                    db.THETVs.InsertOnSubmit(themTV);
                    db.SubmitChanges();
                    loadDataDocGia();
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
                catch
                {
                    MessageBox.Show("Đăng ký không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDataDocGia();
            resetForm();
        }

        private void dtgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDocGia.SelectedRows.Count == 0)
            {
                return;
            }
            dynamic dg = dtgvDocGia.CurrentRow.DataBoundItem;
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                THETV the = data.THETVs.Where(th => th.MATHE == dtgvDocGia.CurrentRow.Cells[0].Value.ToString()).FirstOrDefault();
                if (the == null)
                {
                    return;
                }
                txtMaThe.Text = dg.MATHE;
                txtHoTen.Text = dg.TENDG;
                //RadioButton
                if (dtgvDocGia.CurrentRow.Cells[2].Value.ToString() == "Nam")
                {
                    radNam.Checked = true;
                }
                if (dtgvDocGia.CurrentRow.Cells[2].Value.ToString() == "Nữ")
                {
                    radNu.Checked = true;
                }
                txtDiaChi.Text = dg.DIACHI;
                txtSDT.Text = dg.SODT;
                //Kiểm tra nếu giá trị ngày cấp/ngày hết hạn trong database là null.
                if (dg.NGAYCAP == null)
                {
                    dtNgayCap.Value = DateTime.Now;
                }
                else
                {
                    dtNgayCap.Value = dg.NGAYCAP;
                }
                //Kiem tra ngay het han
                if (dg.NGAYHETHAN == null)
                {
                    dtNgayHetHan.Value = DateTime.Now;
                }
                else
                {
                    dtNgayHetHan.Value = dg.NGAYHETHAN;
                }
                if (the.ANHTHE == null)
                {
                    ptAnhThe.Image = null;
                }
                else
                {
                    ptAnhThe.Image = ByteArrayToImage(the.ANHTHE.ToArray());
                }
                btnXoaThe.Enabled = true;
                btnSuaThe.Enabled = true;
                btnGHThe.Enabled = true;
                btnInThe.Enabled = true;
            }
        }
        private void btnXoaThe_Click(object sender, EventArgs e)
        {
            dynamic dg = dtgvDocGia.CurrentRow.DataBoundItem;
            if (dg == null)
            {
                return;
            }
            string maThe = dg.MATHE;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                THETV tv = db.THETVs.Where(t => t.MATHE == maThe).FirstOrDefault();
                if (tv == null)
                {
                    loadDataDocGia();
                    return;
                }
                bool ktXoa = db.MUONSACHes.Where(the => the.MATHE == tv.MATHE).Count() > 0;
                if (ktXoa)
                {
                    MessageBox.Show("Hiện tại không thể xoá độc giả này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    db.THETVs.DeleteOnSubmit(tv);
                    db.SubmitChanges();
                    loadDataDocGia();
                    MessageBox.Show("Xóa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa độc giả không thành công!" + Environment.NewLine + "Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSuaThe_Click(object sender, EventArgs e)
        {
            dynamic dg = dtgvDocGia.CurrentRow.DataBoundItem;
            if (dg == null)
            {
                return;
            }
            string maThe = dg.MATHE;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                THETV tv = db.THETVs.Where(t => t.MATHE == maThe).FirstOrDefault();
                if (tv == null)
                {
                    loadDataDocGia();
                    return;
                }
                if (txtPath.Text.Length > 0)
                {
                    byte[] file_byte = ImageToByteArray(ptAnhThe.Image);
                    System.Data.Linq.Binary file_binary = new System.Data.Linq.Binary(file_byte);
                    tv.ANHTHE = file_binary;
                }
                tv.TENDG = txtHoTen.Text;
                if (radNam.Checked)
                {
                    tv.PHAI = "Nam";
                }
                if (radNu.Checked)
                {
                    tv.PHAI = "Nữ";
                }
                tv.SODT = txtSDT.Text;
                tv.DIACHI = txtDiaChi.Text;
                try
                {
                    db.SubmitChanges();
                    loadDataDocGia();
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Sửa không thành công!" + Environment.NewLine + "Lỗi : "+ ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDSTheHetHan_Click(object sender, EventArgs e)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                var dgs = from theHH in db.THETVs
                          where theHH.NGAYHETHAN < DateTime.Now //Nếu bé hơn ngày hiện tại, thì thẻ đó hết hạn.
                          select new
                          {
                              MATHE = theHH.MATHE,
                              TENDG = theHH.TENDG,
                              PHAI = theHH.PHAI,
                              SODT = theHH.SODT,
                              DIACHI = theHH.DIACHI,
                              NGAYCAP = theHH.NGAYCAP,
                              NGAYHETHAN = theHH.NGAYHETHAN

                          };
                if (dgs.Count() == 0)
                {
                    MessageBox.Show("Không có thẻ hết hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dtgvDocGia.DataSource = dgs;
                dtgvDocGia.ClearSelection();
                resetForm();
            }
        }

        private void btnGHThe_Click(object sender, EventArgs e)
        {
            dynamic dg = dtgvDocGia.CurrentRow.DataBoundItem;
            if (dg == null)
            {
                return;
            }
            string maThe = dg.MATHE;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                THETV theTV = db.THETVs.Where(t => t.MATHE == maThe).FirstOrDefault();
                if (theTV == null)
                {
                    loadDataDocGia();
                    return;
                }
                try
                {
                    DateTime ngayHetHan = DateTime.Now;
                    //Ngày hết hạn của thẻ = ngày hiện tại + 6 tháng.
                    theTV.NGAYHETHAN = ngayHetHan.AddMonths(6);
                    db.SubmitChanges();
                    loadDataDocGia();
                    MessageBox.Show("Gia hạn thẻ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
                catch
                {
                    MessageBox.Show("Gia hạn thẻ không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

        }

        
        private void btnInThe_Click(object sender, EventArgs e)
        {
           // Print(this.pnTheTV);
            string ma = dtgvDocGia.CurrentRow.Cells[0].Value.ToString();
            if (ma == string.Empty)
            {
                loadDataDocGia();
                return;
            }
            FrmPrintImage form = new FrmPrintImage(ma);
            form.ShowDialog();
        }

        private void btnXoaThe_EnabledChanged(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Enabled == false)
            {
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.Black;
            }
            else
            {
                btn.BackColor = Color.Black;
                btn.ForeColor = Color.White;
            }
        }
    }
}
