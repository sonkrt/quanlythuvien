using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyThuVien.SubForm
{
    public partial class PageThongKe : UserControl
    {
        public PageThongKe()
        {
            InitializeComponent();
        }
        private void loadChart(int year)
        {
            using (QuanLyThuVienDataContext data = new QuanLyThuVienDataContext())
            {
                var dt2 = data.MUONSACHes.Where(x => x.NGAYMUON.Year == year).GroupBy(x => x.NGAYMUON.Month).Select(x => new
                {
                    Thang = x.Key,
                    SoLuong = x.Count()
                }
                        );
                if (dt2.Count() == 0)
                {
                    MessageBox.Show("Không có bất kỳ sách nào được mượn trong năm " + year, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbNam.Text = "2020";
                    return;
                }
                chart1.Series[0].ChartType = SeriesChartType.Line;
                chart1.Series[0].IsValueShownAsLabel = true;
                chart1.DataSource = dt2;
                chart1.ChartAreas[0].AxisX.Minimum = 1;
                chart1.ChartAreas[0].AxisX.Maximum = 12;
                chart1.Series[0].Color = Color.Crimson;
                chart1.ChartAreas[0].AxisX.Title = "Tháng";
                chart1.ChartAreas[0].AxisY.Title = "Số lượng";
                chart1.Series[0].XValueMember = "Thang";
                chart1.Series[0].YValueMembers = "SoLuong";

                chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                dtgvThongKe.DataSource = dt2;
                dtgvThongKe.ClearSelection();
                chart1.DataBind();
            }
        }
        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNam.SelectedIndex < 0)
            {
                return;
            }

            string nam = cbbNam.SelectedItem.ToString();
            loadChart(int.Parse(nam));
        }

        private void PageThongKe_Load(object sender, EventArgs e)
        {
            dtgvThongKe.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtgvThongKe.ColumnHeadersDefaultCellStyle.Font = (new Font("Tahoma", 9, FontStyle.Bold));
            dtgvThongKe.DefaultCellStyle.Font = (new Font("Arial", 10, FontStyle.Regular));
           // this.dtgvThongKe.DefaultCellStyle.BackColor = Color.LightCyan;
            this.dtgvThongKe.DefaultCellStyle.SelectionBackColor = Color.Crimson;
            cbbNam.Items.Add("2018");
            cbbNam.Items.Add("2019");
            cbbNam.Items.Add("2020");
            cbbNam.Items.Add("2021");
            cbbNam.Items.Add("2022");
            cbbNam.Text = "2020";
            loadChart(DateTime.Now.Year);
        }
    }
}
