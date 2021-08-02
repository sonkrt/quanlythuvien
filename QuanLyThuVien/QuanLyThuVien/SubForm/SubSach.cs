using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace QuanLyThuVien.SubForm
{
    public partial class SubSach : UserControl
    {
        public SubSach()
        {
            InitializeComponent();
            dtgvSubSach.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvSubSach.ColumnHeadersDefaultCellStyle.Font = (new Font("Tahoma", 10, FontStyle.Bold));
            this.dtgvSubSach.DefaultCellStyle.Font = (new Font("Arial", 10, FontStyle.Regular));
            this.dtgvSubSach.DefaultCellStyle.BackColor = Color.LightCyan;
            this.dtgvSubSach.DefaultCellStyle.SelectionBackColor = Color.Crimson;
            dtgvSubSach.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvSubSach.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvSubSach.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvSubSach.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dtgvSubSach.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DataGridViewColumn dt1 = dtgvSubSach.Columns[0]; //Nó đổi màu đc 1 ô.
            //dt1.HeaderCell.Style.ForeColor = Color.Blue;

        }

        private void SubSach_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                var data = from sach in db.SACHes
                           select new
                           {
                               MASH = sach.MASH,
                               TENSH = sach.TENSH,
                               MALOAI = sach.MALOAI,
                               SOLUONG = sach.SOLUONG,
                               NXB = sach.NXB,
                               NAMXB = sach.NAMXB,
                               TACGIA = sach.TACGIA,
                               GIA = sach.GIA
                           };

                dtgvSubSach.DataSource = data;
                dtgvSubSach.ClearSelection();
                cbbMaLoai.DataSource = db.THELOAIs;
                //cbbMaLoai.ValueMember = "MALOAI";
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
                string tuKhoa = txtTimKiem.Text;
                var dtSearch = from sach in db.SACHes
                               where sach.MASH.Contains(tuKhoa) || sach.MALOAI.Contains(tuKhoa) || sach.TENSH.Contains(tuKhoa) || sach.TACGIA.Contains(tuKhoa)
                               select new
                               {
                                   MASH = sach.MASH,
                                   TENSH = sach.TENSH,
                                   MALOAI = sach.MALOAI,
                                   SOLUONG = sach.SOLUONG,
                                   NXB = sach.NXB,
                                   NAMXB = sach.NAMXB,
                                   TACGIA = sach.TACGIA,
                                   GIA = sach.GIA
                               };

                if (dtSearch.Count() == 0)
                {
                    MessageBox.Show("Không có kết quả cho tìm kiếm này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dtgvSubSach.DataSource = dtSearch;
                dtgvSubSach.ClearSelection();
            }
        }
        private static bool checkMa(int ma)
        {
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                bool ktMa = data.SACHes.Where(s => ma == Convert.ToInt32(s.MASH.Substring(2))).Count() > 0;
                if (ktMa)
                {
                    return false;
                }
            }
            return true;
        }
        public void resetForm()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            // cbbMaLoai.SelectedItem = 0;
            txtSoLuong.Clear();
            txtNhaXB.Clear();
            txtNamXB.Clear();
            txtTacGia.Clear();
            txtTimKiem.Clear();
            txtBrowse.Clear();
            txtGia.Clear();
            btnXoaSach.Enabled = false;
            btnSuaSach.Enabled = false;
            //
            txtTenSach.Focus();
        }
        private void btnThemSach_Click(object sender, EventArgs e)
        {

            if (cbbMaLoai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn Mã Loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtTenSach.Text == string.Empty || txtSoLuong.Text == string.Empty || txtNhaXB.Text == string.Empty || txtNamXB.Text == string.Empty || txtTacGia.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int countSach = 1;
            while (checkMa(countSach) == false)
            {
                countSach += 1;
            }
            String ma = "";
            if (countSach >= 1000)
            {
                ma = "SH" + countSach;
            }
            else if (countSach >= 100)
            {
                ma = "SH0" + countSach;

            }
            else if (countSach >= 10)
            {
                ma = "SH00" + countSach;
            }
            else
            {
                ma = "SH000" + countSach;
            }
            THELOAI selectedMaLoai = cbbMaLoai.SelectedItem as THELOAI;
            SACH newSach = new SACH();
            newSach.MASH = ma;
            newSach.TENSH = txtTenSach.Text;
            newSach.MALOAI = selectedMaLoai.MALOAI;
            newSach.NXB = txtNhaXB.Text;
            newSach.TACGIA = txtTacGia.Text;
            //Viết hàm ktra dữ liệu nhập vào phải là số hay k? Và kiểm tra năm xuất bản.
            try
            {
                int soLuong = int.Parse(txtSoLuong.Text);
                if (soLuong <= 0)
                {
                    MessageBox.Show("Số lương phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    newSach.SOLUONG = soLuong;
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu nhập vào không phải là số. Vui lòng nhập lại số lượng Sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                float gia = float.Parse(txtGia.Text);
                if (gia <= 0)
                {
                    MessageBox.Show("Giá sách phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    newSach.GIA = gia;
                }
            }
            catch
            {
                MessageBox.Show("Giá sách sai kiểu dữ liệu!. Vui lòng nhập lại Giá Sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                int namXB = int.Parse(txtNamXB.Text);
                if (namXB < 1700 || namXB > DateTime.Now.Year)
                {
                    MessageBox.Show("Năm xuất bản phải sau năm 1700 và nhỏ hơn hoặc bằng năm hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    newSach.NAMXB = namXB;
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu nhập vào không phải là số. Vui lòng nhập lại Năm xuất bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                try
                {
                    bool ktTrung = db.SACHes.Where(s => s.MASH == newSach.MASH).Count() > 0;
                    if (ktTrung)
                    {
                        MessageBox.Show("Trùng mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    db.SACHes.InsertOnSubmit(newSach);
                    db.SubmitChanges();
                    loadData();
                    MessageBox.Show("Thêm sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
                catch
                {
                    MessageBox.Show("Thêm sách không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
            resetForm();
        }

        private void dtgvSubSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvSubSach.SelectedRows.Count == 0)
            {
                return;
            }
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dtgvSubSach.Rows[e.RowIndex];
                txtMaSach.Text = dgvRow.Cells[0].Value.ToString();
                txtTenSach.Text = dgvRow.Cells[1].Value.ToString();
                txtSoLuong.Text = dgvRow.Cells[3].Value.ToString();
                txtNhaXB.Text = dgvRow.Cells[4].Value.ToString();
                txtNamXB.Text = dgvRow.Cells[5].Value.ToString();
                txtTacGia.Text = dgvRow.Cells[6].Value.ToString();
                string gias = dgvRow.Cells[7].Value.ToString();
                int gia = Convert.ToInt32(gias);
                txtGia.Text = String.Format("{0:0,0}", gia);

                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    THELOAI tl = data.THELOAIs.Where(t => t.MALOAI == dgvRow.Cells[2].Value.ToString()).FirstOrDefault();
                    if (tl != null)
                    {
                        cbbMaLoai.Text = tl.MALOAI + " - " + tl.TENLOAI; ;
                    }
                }
                btnXoaSach.Enabled = true;
                btnSuaSach.Enabled = true;
                //Đổi màu
            }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            dynamic sach = dtgvSubSach.CurrentRow.DataBoundItem;
            if (sach == null)
            {
                return;
            }
            string maSach = sach.MASH;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                bool ktSach = db.MUONSACHes.Where(ms => ms.MASH == maSach).Count() > 0;
                if (ktSach)
                {
                    MessageBox.Show("Hiện tại không thể xoá sách này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SACH ma = db.SACHes.Where(t => t.MASH == maSach).FirstOrDefault();
                if (ma == null)
                {
                    loadData();
                    return;
                }
                try
                {
                    db.SACHes.DeleteOnSubmit(ma);
                    db.SubmitChanges();
                    loadData();
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa không thành công!" + Environment.NewLine + "Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            dynamic sach = dtgvSubSach.CurrentRow.DataBoundItem;
            if (sach == null)
            {
                return;
            }
            string maSach = sach.MASH;
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                SACH ma = db.SACHes.Where(t => t.MASH == maSach).FirstOrDefault();
                if (ma == null)
                {
                    loadData();
                    return;
                }
                ma.TENSH = txtTenSach.Text;
                ma.MALOAI = (cbbMaLoai.SelectedItem as THELOAI).MALOAI;
                ma.NXB = txtNhaXB.Text;
                ma.TACGIA = txtTacGia.Text;
                try
                {
                    int soLuong = int.Parse(txtSoLuong.Text);
                    if (soLuong <= 0)
                    {
                        MessageBox.Show("Số lương phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        ma.SOLUONG = soLuong;
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu nhập vào không phải là số. Vui lòng nhập lại số lượng Sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    float gia = float.Parse(txtGia.Text);
                    if (gia <= 0)
                    {
                        MessageBox.Show("Giá sách phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        ma.GIA = gia;
                    }
                }
                catch
                {
                    MessageBox.Show("Giá sách sai kiểu dữ liệu!. Vui lòng nhập lại Giá Sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    int namXB = int.Parse(txtNamXB.Text);
                    if (namXB < 1700 || namXB > DateTime.Now.Year)
                    {
                        MessageBox.Show("Năm xuất bản phải sau năm 1700 và nhỏ hơn hoặc bằng năm hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        ma.NAMXB = namXB;
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu nhập vào không phải là số. Vui lòng nhập lại Năm xuất bản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    //
                    db.SubmitChanges();
                    loadData();
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sửa không thành công!" + Environment.NewLine + "Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Execl files |*.XLSX|*.XLS|*.XLSM|All files |*.*";
            DialogResult rs = openFileDialog1.ShowDialog();
            if (rs == DialogResult.Cancel)
            {
                return;
            }
            txtBrowse.Text = openFileDialog1.FileName;
            try
            {
                //ket noi du lieu excel
                string path = txtBrowse.Text;
                var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';");
                //do du lieu vao datatable
                var table = new DataTable();
                var dap = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn);
                dap.Fill(table);
                if (table.Rows.Count == 0)
                {
                    return;
                }
                dtgvSubSach.DataSource = table;
                dtgvSubSach.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                try
                {
                    //ket noi du lieu excel
                    string path = txtBrowse.Text;
                    var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';");
                    //do du lieu vao datatable
                    var table = new DataTable();
                    var dap = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn);
                    dap.Fill(table);
                    if (table.Rows.Count == 0)
                    {
                        MessageBox.Show("Dữ liệu trong file excel rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        loadData();
                        return;
                    }

                    foreach (DataRow i in table.Rows)
                    {
                        bool ktTrung = db.SACHes.Where(s => s.MASH == i[0].ToString()).Count() > 0;
                        bool ktMaTheLoai = db.THELOAIs.Where(tl => tl.MALOAI == i[2].ToString()).Count() == 0;
                        if (ktTrung || ktMaTheLoai)
                        {
                            continue;
                        }
                        SACH newS = new SACH();
                        newS.MASH = i[0].ToString();
                        newS.TENSH = i[1].ToString();
                        newS.MALOAI = i[2].ToString();
                        newS.SOLUONG = int.Parse(i[3].ToString());
                        newS.NXB = i[4].ToString();
                        newS.NAMXB = int.Parse(i[5].ToString());
                        newS.TACGIA = i[6].ToString();
                        newS.GIA = float.Parse(i[7].ToString());
                        db.SACHes.InsertOnSubmit(newS);
                    }
                    db.SubmitChanges();
                    loadData();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBrowse.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thất bại!" + Environment.NewLine + "Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtBrowse_TextChanged(object sender, EventArgs e)
        {
            if (txtBrowse.Text == string.Empty)
            {
                btnImportExcel.Enabled = false;
            }
            else
            {
                btnImportExcel.Enabled = true;
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workBook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet workSheet = null;
                workSheet = workBook.Sheets["Sheet1"];
                workSheet = workBook.ActiveSheet;
                workSheet.Name = "Sach";
                for (int i = 1; i < dtgvSubSach.Columns.Count + 1; i++)
                {
                    workSheet.Cells[1, i] = dtgvSubSach.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dtgvSubSach.Rows.Count; i++)
                {
                    for (int j = 0; j < dtgvSubSach.Columns.Count; j++)
                    {
                        if (dtgvSubSach.Rows[i].Cells[j].Value == null)
                        {
                            workSheet.Cells[i + 2, j + 1] = "";
                        }
                        else
                        {
                            workSheet.Cells[i + 2, j + 1] = dtgvSubSach.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                var save = new SaveFileDialog();
                save.FileName = "Sach";
                save.DefaultExt = ".xlsx";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    workBook.SaveAs(save.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }
                app.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSuaSach_EnabledChanged(object sender, EventArgs e)
        {
            if (btnSuaSach.Enabled == false)
            {
                btnSuaSach.BackColor = Color.LightGray;
                btnSuaSach.ForeColor = Color.Black;
            }
            else
            {
                btnSuaSach.BackColor = Color.Black;
                btnSuaSach.ForeColor = Color.White;
            }
        }

        private void btnXoaSach_EnabledChanged(object sender, EventArgs e)
        {
            if (btnXoaSach.Enabled == false)
            {
                btnXoaSach.BackColor = Color.LightGray;
                btnXoaSach.ForeColor = Color.Black;
            }
            else
            {
                btnXoaSach.BackColor = Color.Black;
                btnXoaSach.ForeColor = Color.White;
            }
        }

        private void btnImportExcel_EnabledChanged(object sender, EventArgs e)
        {
            if (btnImportExcel.Enabled == false)
            {
                btnImportExcel.BackColor = Color.LightGray;
                btnImportExcel.ForeColor = Color.Black;
            }
            else
            {
                btnImportExcel.BackColor = Color.Black;
                btnImportExcel.ForeColor = Color.White;
            }
        }
    }
}
