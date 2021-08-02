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
    public partial class SubTheLoai : UserControl
    {
        public SubTheLoai()
        {
            InitializeComponent();
            dtgvTheLoaiSach.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvTheLoaiSach.ColumnHeadersDefaultCellStyle.Font = (new Font("Tahoma", 11, FontStyle.Bold));
            this.dtgvTheLoaiSach.DefaultCellStyle.Font = (new Font("Arial", 12, FontStyle.Regular));
            this.dtgvTheLoaiSach.DefaultCellStyle.BackColor = Color.LightCyan;
            this.dtgvTheLoaiSach.DefaultCellStyle.SelectionBackColor = Color.Crimson;

        }

        private void SubTheLoai_Load(object sender, EventArgs e)
        {
            LoadDL();
            dtgvTheLoaiSach.ClearSelection();
        }

        public void LoadDL()
        {
            using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext())
            {
                var data = from tl in db.THELOAIs
                           select new
                           {
                               MALOAI = tl.MALOAI,
                               TENLOAI = tl.TENLOAI
                           };
                dtgvTheLoaiSach.DataSource = data;
                dtgvTheLoaiSach.ClearSelection();
            }
        }
        private static bool checkMa(int ma)
        {
            using(QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                bool ktMa = data.THELOAIs.Where(tl => ma == Convert.ToInt32(tl.MALOAI.Substring(1))).Count() > 0;
                if (ktMa)
                {
                    return false;
                }
            }
            return true;
        }
        public void resetForm()
        {
            txtMaLoai.Clear();
            txtTenTheLoai.Clear();
            txtTimKiem.Clear();
            txtBrowse.Clear();
            btnSuaTheLoai.Enabled = false;
            btnXoaTheLoai.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string tuKhoa = txtTimKiem.Text;
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                var dtSearch = from tl in data.THELOAIs
                               where tl.MALOAI.Contains(tuKhoa) || tl.TENLOAI.Contains(tuKhoa)
                               select new
                               {
                                   MALOAI = tl.MALOAI,
                                   TENLOAI = tl.TENLOAI
                               };
                if (dtSearch.Count() == 0)
                {
                    MessageBox.Show("Không có kết quả cho tìm kiếm này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dtgvTheLoaiSach.DataSource = dtSearch;
                dtgvTheLoaiSach.ClearSelection();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDL();
            resetForm();
        }

        private void btnThemTheLoai_Click(object sender, EventArgs e)
        {
            if (txtTenTheLoai.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập tên thể loại sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int countMa = 1;
            while (checkMa(countMa) == false)
            {
                countMa += 1;
            }
            string ma = "";
            if (countMa >= 10000)
            {
                ma = "L" + countMa;
            }
            else if (countMa >= 1000)
            {
                ma = "L0" + countMa;
            }
            else if (countMa >= 100)
            {
                ma = "L00" + countMa;
            }
            else if (countMa >= 10)
            {
                ma = "L000" + countMa;
            }
            else
            {
                ma = "L0000" + countMa;
            }
            try
            {
                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    bool ktTrung = data.THELOAIs.Where(tl => tl.MALOAI == ma).Count() > 0;
                    if (ktTrung)
                    {
                        MessageBox.Show("Trùng mã thể loại sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    THELOAI tls = new THELOAI();
                    tls.MALOAI = ma;
                    tls.TENLOAI = txtTenTheLoai.Text;
                    data.THELOAIs.InsertOnSubmit(tls);
                    data.SubmitChanges();
                    LoadDL();
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm thất bại!" + Environment.NewLine + "Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgvTheLoaiSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvTheLoaiSach.SelectedRows.Count == 0)
            {
                return;
            }
            //dynamic tl = dtgvTheLoaiSach.CurrentRow.DataBoundItem;
            //if (tl == null)
            //{
            //    return;
            //}
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = dtgvTheLoaiSach.Rows[e.RowIndex];
                txtMaLoai.Text = dgvRow.Cells[0].Value.ToString();
                txtTenTheLoai.Text = dgvRow.Cells[1].Value.ToString();
                btnSuaTheLoai.Enabled = true;
                btnXoaTheLoai.Enabled = true;
            }
            //btnSuaTheLoai.Enabled = true;
            //btnXoaTheLoai.Enabled = true;
            //txtMaLoai.Text = tl.MALOAI;
            //txtTenTheLoai.Text = tl.TENLOAI;
            
        }

        private void btnSuaTheLoai_Click(object sender, EventArgs e)
        {
            dynamic tl = dtgvTheLoaiSach.CurrentRow.DataBoundItem;
            if (tl == null)
            {
                return;
            }
            string matl = tl.MALOAI;
            try
            {
                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    THELOAI tlMoi = data.THELOAIs.Where(t => t.MALOAI == matl).FirstOrDefault();
                    if (tlMoi == null)
                    {
                        LoadDL();
                        return;
                    }
                    if (txtTenTheLoai.Text == string.Empty)
                    {
                        MessageBox.Show("Vui lòng nhập tên thể loại sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    tlMoi.TENLOAI = txtTenTheLoai.Text;
                    data.SubmitChanges();
                    LoadDL();
                    MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Sửa thất bại!" + Environment.NewLine + "Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoaTheLoai_Click(object sender, EventArgs e)
        {
            dynamic tl = dtgvTheLoaiSach.CurrentRow.DataBoundItem;
            if (tl == null)
            {
                return;
            }
            string matl = tl.MALOAI;
            try
            {
                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    THELOAI tlMoi = data.THELOAIs.Where(t => t.MALOAI == matl).FirstOrDefault();
                    if (tlMoi == null)
                    {
                        LoadDL();
                        return;
                    }
                    bool ktXoa = data.SACHes.Where(s => s.MALOAI == matl).Count() > 0;
                    if (ktXoa)
                    {
                        MessageBox.Show("Hiện tại không thể xoá thể loại sách này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    data.THELOAIs.DeleteOnSubmit(tlMoi);
                    data.SubmitChanges();
                    LoadDL();
                    MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xoá thất bại!" + Environment.NewLine + "Lỗi : " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dtgvTheLoaiSach.DataSource = table;
                dtgvTheLoaiSach.ClearSelection();
            }
            catch(Exception ex)
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
                        LoadDL();
                        return;
                    }
                    foreach (DataRow i in table.Rows)
                    {
                        bool ktTrung = db.THELOAIs.Where(t => t.MALOAI == i[0].ToString()).Count() > 0;
                        if (ktTrung)
                        {
                            continue;
                        }
                        THELOAI theLoai = new THELOAI();
                        theLoai.MALOAI = i[0].ToString();
                        theLoai.TENLOAI = i[1].ToString();
                        db.THELOAIs.InsertOnSubmit(theLoai);

                    }
                    db.SubmitChanges();
                    LoadDL();
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
                workSheet.Name = "TheLoaiSach";
                for (int i = 1; i < dtgvTheLoaiSach.Columns.Count + 1; i++)
                {
                    workSheet.Cells[1, i] = dtgvTheLoaiSach.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dtgvTheLoaiSach.Rows.Count; i++)
                {
                    for (int j = 0; j < dtgvTheLoaiSach.Columns.Count; j++)
                    {
                        if (dtgvTheLoaiSach.Rows[i].Cells[j].Value == null)
                        {
                            workSheet.Cells[i + 2, j + 1] = "";
                        }
                        else
                        {
                            workSheet.Cells[i + 2, j + 1] = dtgvTheLoaiSach.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                var save = new SaveFileDialog();
                save.FileName = "TheLoaiSach";
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

        private void btnImportExcel_EnabledChanged(object sender, EventArgs e)
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
