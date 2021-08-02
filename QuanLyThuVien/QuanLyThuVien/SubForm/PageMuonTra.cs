using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVien.Forms;

namespace QuanLyThuVien.SubForm
{
    public partial class PageMuonTra : UserControl
    {
        public string maThuThu;
        public PageMuonTra()
        {
            InitializeComponent();
            dtgvMuonTra.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvMuonTra.ColumnHeadersDefaultCellStyle.Font = (new Font("Tahoma", 10, FontStyle.Bold));
            this.dtgvMuonTra.DefaultCellStyle.Font = (new Font("Arial", 10, FontStyle.Regular));
            this.dtgvMuonTra.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvMuonTra.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvMuonTra.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvMuonTra.DefaultCellStyle.BackColor = Color.LightCyan;
            this.dtgvMuonTra.DefaultCellStyle.SelectionBackColor = Color.Crimson;
            this.dtgvMuonTra.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dtgvMuonTra.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
            this.dtgvMuonTra.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            //this.dtgvMuonTra.Columns[7].DefaultCellStyle.Format = "{0:0,00}";
            //this.dtgvMuonTra.DefaultCellStyle.SelectionBackColor = Color.Firebrick;

        }

        private void PageMuonTra_Load(object sender, EventArgs e)
        {
            loadDataMuonTra();
        }
        public void loadDataMuonTra()
        {
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                var dataMuonTra = from mt in data.MUONSACHes
                                  orderby mt.NGAYMUON descending
                                  select new
                                  {
                                      MATHE = mt.MATHE,
                                      MASH = mt.MASH,
                                      NGAYMUON = mt.NGAYMUON,
                                      MATT = mt.MATT,
                                      NGAYTRA = mt.NGAYTRA,
                                      HANTRA = mt.HANTRA,
                                      TINHTRANG = mt.TINHTRANG,
                                      TIENPHAT = mt.TIENPHAT,
                                      GHICHU = mt.GHICHU
                                  };
                dtgvMuonTra.DataSource = dataMuonTra;
                cbbMaThe.DataSource = data.THETVs;
                cbbMaSach.DataSource = data.SACHes;
                //dtgvMuonTra.Rows[0].Selected = false;
                dtgvMuonTra.ClearSelection();
                //txtMaTT.Text = maThuThu;
            }
        }
        public void resetForm()
        {
            txtTimKiem.Clear();
            txtGhiChu.Clear();
            txtTienPhat.Clear();
            dtNgayMuon.Clear();
            dtHanTra.Clear();
            txtTinhTrang.Clear();
            txtMaTT.Clear();
            dtNgayTra.Value = DateTime.Now;
            dtNgayTra.Enabled = false;

            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnKiemTra.Enabled = false;
            btnTraSach.Enabled = false;
            txtTienPhat.Enabled = false;
            txtTinhTrang.Enabled = false;

            txtTimKiem.Focus();
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
                var dtSearch = from ms in data.MUONSACHes
                               where ms.MASH.Contains(tuKhoa) || ms.MATHE.Contains(tuKhoa) || ms.MATT.Contains(tuKhoa) || ms.TINHTRANG.Contains(tuKhoa)
                               select new
                               {
                                   MATHE = ms.MATHE,
                                   MASH = ms.MASH,
                                   NGAYMUON = ms.NGAYMUON,
                                   MATT = ms.MATT,
                                   NGAYTRA = ms.NGAYTRA,
                                   HANTRA = ms.HANTRA,
                                   TINHTRANG = ms.TINHTRANG,
                                   TIENPHAT = ms.TIENPHAT,
                                   GHICHU = ms.GHICHU
                               };
                if (dtSearch.Count() == 0)
                {
                    MessageBox.Show("Không có kết quả cho tìm kiếm này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dtgvMuonTra.DataSource = dtSearch;
                dtgvMuonTra.ClearSelection();
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadDataMuonTra();
            resetForm();
        }

        private void dtgvMuonTra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgvMuonTra.SelectedRows.Count == 0)
                {
                    return;
                }
                dynamic ms = dtgvMuonTra.CurrentRow.DataBoundItem;
                if (ms == null)
                {
                    return;
                }
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnKiemTra.Enabled = true;
                btnTraSach.Enabled = true;
                txtTienPhat.Enabled = true;
                txtTinhTrang.Enabled = true;
                string maThe = ms.MATHE;
                string maSach = ms.MASH;
                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    SACH sach = data.SACHes.Where(s => s.MASH == maSach).FirstOrDefault();
                    THETV the = data.THETVs.Where(t => t.MATHE == maThe).FirstOrDefault();
                    if (sach == null || the == null)
                    {
                        return;
                    }
                    cbbMaThe.Text = the.MATHE + " - " + the.TENDG;
                    cbbMaSach.Text = sach.MASH + " - " + sach.TENSH;
                    dtNgayMuon.Text = ms.NGAYMUON.ToString("dd/MM/yyyy");
                    dtHanTra.Text = ms.HANTRA.ToString("dd/MM/yyyy");
                    txtTinhTrang.Text = ms.TINHTRANG;
                    txtMaTT.Text = ms.MATT;
                    //txtTienPhat.Text = ms.TIENPHAT.ToString();
                    if (ms.TIENPHAT == 0)
                    {
                        txtTienPhat.Text = "0";
                    }
                    else
                    {
                        txtTienPhat.Text = String.Format("{0:0,00}", ms.TIENPHAT);
                    }
                    txtGhiChu.Text = ms.GHICHU;
                    dtNgayTra.Enabled = true;
                    if (ms.NGAYTRA == null)
                    {
                        dtNgayTra.Value = DateTime.Now;
                    }
                    else
                    {
                        dtNgayTra.Value = ms.NGAYTRA;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbMaThe.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã thẻ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbbMaSach.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn mã sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                THETV selectedThe = cbbMaThe.SelectedItem as THETV;
                SACH selectedSach = cbbMaSach.SelectedItem as SACH;
                if (selectedSach.SOLUONG == 0)
                {
                    MessageBox.Show("Hiện tại thư viện đã hết sách này!" + Environment.NewLine + "Vui lòng chọn sách khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    THETV the = data.THETVs.Where(t => t.MATHE == selectedThe.MATHE).FirstOrDefault();
                    SACH sach = data.SACHes.Where(s => s.MASH == selectedSach.MASH).FirstOrDefault();
                    if (the == null || sach == null)
                    {
                        loadDataMuonTra();
                        return;
                    }
                    bool checkMuon = data.MUONSACHes.Where(m => m.MATHE == selectedThe.MATHE && m.MASH == selectedSach.MASH && m.NGAYMUON == DateTime.Now).Count() > 0;
                    if (checkMuon)
                    {
                        MessageBox.Show("Ngày hôm nay độc giả đã mượn sách này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    bool checkSlMuon = data.MUONSACHes.Where(m => m.MATHE == selectedThe.MATHE && m.NGAYMUON == DateTime.Now).Count() > 2;
                    if (checkSlMuon)
                    {
                        MessageBox.Show("Ngày hôm nay độc giả đã mượn tối đa 3 sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    bool checkSlMax = data.MUONSACHes.Where(m => m.MATHE == selectedThe.MATHE && m.NGAYTRA == null).Count() > 9;
                    if (checkSlMax)
                    {
                        MessageBox.Show("Độc giả đã mượn tối đa 10 cuốn sách và chưa trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (the.NGAYHETHAN < DateTime.Now)
                    {
                        MessageBox.Show("Thẻ thư viện của độc giả đã hết hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        MUONSACH muonSach = new MUONSACH();
                        muonSach.MATHE = the.MATHE;
                        muonSach.MASH = sach.MASH;
                        muonSach.TIENPHAT = 0;
                        muonSach.NGAYMUON = DateTime.Now;
                        muonSach.HANTRA = DateTime.Now.AddDays(15);
                        muonSach.MATT = this.maThuThu;
                        try
                        {
                            data.MUONSACHes.InsertOnSubmit(muonSach);
                            data.SubmitChanges();
                            loadDataMuonTra();
                            MessageBox.Show("Mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Mượn sách không thành công!" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mượn sách không thành công! - " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic ms = dtgvMuonTra.CurrentRow.DataBoundItem;
                if (ms == null)
                {
                    return;
                }
                string maThe = ms.MATHE;
                string maSach = ms.MASH;
                DateTime ngayMuon = ms.NGAYMUON;
                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    MUONSACH muonSach = data.MUONSACHes.Where(m => m.MASH == maSach && m.MATHE == maThe && m.NGAYMUON == ngayMuon).FirstOrDefault();
                    if (muonSach == null)
                    {
                        loadDataMuonTra();
                        return;
                    }
                    THETV selectedThe = cbbMaThe.SelectedItem as THETV;
                    SACH selectedSach = cbbMaSach.SelectedItem as SACH;
                    if (selectedThe.MATHE != muonSach.MATHE || selectedSach.MASH != muonSach.MASH)
                    {
                        MessageBox.Show("Không thể chỉnh sửa khoá chính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        if (dtNgayTra.Value < muonSach.NGAYMUON)
                        {
                            MessageBox.Show("Ngày trả sách phải lớn hơn ngày mượn sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        try
                        {
                            decimal tienPhat = decimal.Parse(txtTienPhat.Text);
                        }
                        catch
                        {
                            MessageBox.Show("Kiểu dữ liệu tiền tệ không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (decimal.Parse(txtTienPhat.Text) < 0)
                        {
                            MessageBox.Show("Tiền phạt phải lớn hơn hoặc bằng 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        muonSach.NGAYTRA = dtNgayTra.Value;
                        muonSach.GHICHU = txtGhiChu.Text;
                        muonSach.TIENPHAT = decimal.Parse(txtTienPhat.Text);
                        muonSach.TINHTRANG = txtTinhTrang.Text;
                        data.SubmitChanges();
                        loadDataMuonTra();
                        MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetForm();
                    }

                }
            }
            catch
            {
                MessageBox.Show("Sửa không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic ms = dtgvMuonTra.CurrentRow.DataBoundItem;
                if (ms == null)
                {
                    return;
                }
                string maThe = ms.MATHE;
                string maSach = ms.MASH;
                DateTime ngayMuon = ms.NGAYMUON;
                using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    MUONSACH muonSach = data.MUONSACHes.Where(m => m.MASH == maSach && m.MATHE == maThe && m.NGAYMUON == ngayMuon).FirstOrDefault();
                    if (muonSach == null)
                    {
                        loadDataMuonTra();
                        return;
                    }
                    DialogResult rs = MessageBox.Show("Bạn có muốn xoá dữ liệu mượn sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (rs == DialogResult.Yes)
                    {
                        data.MUONSACHes.DeleteOnSubmit(muonSach);
                        data.SubmitChanges();
                        loadDataMuonTra();
                        MessageBox.Show("Xoá thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetForm();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Xoá không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic ms = dtgvMuonTra.CurrentRow.DataBoundItem;
                if (ms == null)
                {
                    return;
                }
                if (ms.NGAYTRA == null)
                {
                    TimeSpan days = DateTime.Now.Date - ms.HANTRA;
                    int han = Convert.ToInt32(days.TotalDays);
                    if (han > 0)
                    {
                        string ghiChu = "Độc giả chưa trả sách !" + Environment.NewLine + "Và quá hạn trả " + han.ToString() + " ngày !";
                        txtGhiChu.Text = "Trả sách quá hạn " + han + " ngày.";
                        MessageBox.Show(ghiChu, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtGhiChu.Clear();
                        MessageBox.Show("Độc giả chưa trả sách !" + Environment.NewLine + "Hạn mượn sách còn : " + Math.Abs(han) + " ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    TimeSpan ngay = ms.NGAYTRA - ms.HANTRA;
                    int kq = Convert.ToInt32(ngay.TotalDays);
                    if (kq <= 0)
                    {
                        MessageBox.Show("Độc giả đã trả sách!" + Environment.NewLine + "Và trả sách đúng hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Độc giả đã trả sách!" + Environment.NewLine + "Và quá hạn trả " + kq + " ngày.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                dynamic ms = dtgvMuonTra.CurrentRow.DataBoundItem;
                if (ms == null)
                {
                    return;
                }
                if (ms.NGAYTRA != null)
                {
                    MessageBox.Show("Độc giả đã trả sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string maThe = ms.MATHE;
                string maSach = ms.MASH;
                DateTime ngayMuon = ms.NGAYMUON;
                using(QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                {
                    MUONSACH muonSach = data.MUONSACHes.Where(m => m.MATHE == maThe && m.MASH == maSach && m.NGAYMUON == ngayMuon).FirstOrDefault();
                    if (muonSach == null)
                    {
                        loadDataMuonTra();
                        return;
                    }
                    muonSach.NGAYTRA = DateTime.Now;
                    if (txtGhiChu.Text != string.Empty)
                    {
                        muonSach.GHICHU = txtGhiChu.Text;
                    }
                    muonSach.TIENPHAT = decimal.Parse(txtTienPhat.Text);
                    data.SubmitChanges();
                    loadDataMuonTra();
                    MessageBox.Show("Trả sách thành công! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Trả sách không thành công! " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                   
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workBook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet workSheet = null;
                workSheet = workBook.Sheets["Sheet1"];
                workSheet = workBook.ActiveSheet;
                workSheet.Name = "MuonTraSach";
                for (int i = 1; i < dtgvMuonTra.Columns.Count + 1; i++)
                {
                    workSheet.Cells[1, i] = dtgvMuonTra.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dtgvMuonTra.Rows.Count; i++)
                {
                    for (int j = 0; j < dtgvMuonTra.Columns.Count; j++)
                    {
                        if (dtgvMuonTra.Rows[i].Cells[j].Value == null)
                        {
                            workSheet.Cells[i + 2, j + 1] = "";
                        }
                        else
                        {
                            workSheet.Cells[i + 2, j + 1] = dtgvMuonTra.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }
                var save = new SaveFileDialog();
                save.FileName = "ChiTietMuonTraSach";
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
        int rowIndex = 0;
        private void dtgvMuonTra_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dtgvMuonTra.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.contextMenuStrip1.Show(this.dtgvMuonTra, e.Location);
                this.contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dtgvMuonTra.Rows.Count > 0)
            {
                if (!dtgvMuonTra.Rows[rowIndex].IsNewRow)
                {
                    string maThe = dtgvMuonTra.Rows[rowIndex].Cells[0].Value.ToString();
                    string maSach = dtgvMuonTra.Rows[rowIndex].Cells[1].Value.ToString();
                    DateTime date = DateTime.Parse(dtgvMuonTra.Rows[rowIndex].Cells[2].Value.ToString());


                    using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
                    {
                        MUONSACH ms = data.MUONSACHes.Where(m => m.NGAYMUON.Date == date.Date && m.MATHE == maThe && m.MASH == maSach).FirstOrDefault();
                        if (ms == null)
                        {
                            loadDataMuonTra();
                            resetForm();
                        }
                        FrmDetail frmDetail = new FrmDetail(ms);
                        frmDetail.ShowDialog();
                    }
                }


            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            loadDataMuonTra();
            resetForm();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dtgvMuonTra.SelectedRows.Count > 0)
            {
                btnKiemTra_Click(sender, e);
            }
        }

        private void btnSua_EnabledChanged(object sender, EventArgs e)
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
