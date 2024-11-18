using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Service;

namespace ManagementPhoneStore
{
    public partial class ThongKeTongQuanGUI : Form
    {
        private List<ThongKeTungNgayTrongThangDTO> data ;
        private ThongKeService service = ThongKeService.Instance;
        private int thang=0;
        private int nam= 0 ;
        public ThongKeTongQuanGUI()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            LoadData();
            AddGUIOverviewPanel();
            AddChartPanel();
            AddDataGridPanel();
            LoadComboBox();

            //AddDataGridContent();

        }
        private void LoadComboBox()
        {
            comboBoxMonth.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth.Items.Add($"Tháng {i}");
            }
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1;

            comboBoxYear.Items.Clear();
            for (int i = 2020; i <= DateTime.Now.Year; i++)
            {
                comboBoxYear.Items.Add($"Năm {i}");
            }
            comboBoxYear.SelectedIndex = comboBoxYear.Items.Count - 1;
        }
        private void LoadData()
        {
            if(thang == 0)
            {
               this.thang = DateTime.Now.Month;
               this.nam = DateTime.Now.Year;
            }
           
            data = service.GetThongKeTungNgayTrongThang(4, 2023);
         

        }
        private void AddGUIOverviewPanel()
        {
          
            this.overviewPanel.Controls.Add(CreateGUISummaryBox("Sản phẩm hiện có trong kho", service.countSanPham().ToString(), "icon_product.png", 0));
            this.overviewPanel.Controls.Add(CreateGUISummaryBox("Khách từ trước đến nay",service.countKhachHang().ToString() , "icon_customer.png", 280));
            this.overviewPanel.Controls.Add(CreateGUISummaryBox("Nhân viên đang hoạt động", "5", "icon_staff.png", 560));

            //this.Controls.Add(overviewPanel);
        }

        private void AddDataGridPanel()
        {
            //DataGridView dataGridView = new DataGridView
            //{
            //    Size = new System.Drawing.Size(880, 120),
            //    Location = new Point(10, 430),
            //    ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
            //    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            //};

           


            foreach(var item in data)
            {
                this.dataGridView.Rows.Add(item.Ngay, FormatVND(item.Chiphi), FormatVND(item.DoanhthuNgay),FormatVND(item.LoinhuanNgay));
            }
            //this.Controls.Add(dataGridView);
        }
        private void AddChartPanel()
        {
            Label chartTitle = new Label
            {
                Text = "Biểu đồ Thống kê Doanh thu tháng "+thang +" năm "+nam,
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(250, 0) // Vị trí tiêu đề
            };

            LiveCharts.WinForms.CartesianChart chart = new LiveCharts.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill
            };

            chart.Series = new LiveCharts.SeriesCollection
    {
        new LiveCharts.Wpf.LineSeries
        {
            Title = "Vốn",
             Values = new LiveCharts.ChartValues<double>(data.ConvertAll(d => (double)d.Chiphi)),
            StrokeThickness = 3,
            Fill = System.Windows.Media.Brushes.LightBlue,
            PointGeometry = null
        },
        new LiveCharts.Wpf.LineSeries
        {
            Title = "Doanh thu",
             Values = new LiveCharts.ChartValues<double>(data.ConvertAll(d => (double)d.DoanhthuNgay)),
            StrokeThickness = 3,
            Fill = System.Windows.Media.Brushes.LightGreen,
            PointGeometry = null
        },
        new LiveCharts.Wpf.LineSeries
        {
            Title = "Lợi nhuận",
            Values = new LiveCharts.ChartValues<double>(data.ConvertAll(d => (double)d.LoinhuanNgay)),
            StrokeThickness = 3,
            Fill = System.Windows.Media.Brushes.LightPink,
            PointGeometry = null
        }
    };

            chart.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Ngày",
                Labels = data.ConvertAll(d => d.Ngay.ToString())
            });

            chart.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Giá trị (VND)"
            });
            this.chartPanel.Controls.Add(chartTitle);
            this.chartPanel.Controls.Add(chart);
            //this.Controls.Add(chartPanel);
        }
        private string FormatVND(double value)
        {
            return $"{value:n0}đ"; // Ví dụ: 36,000,000đ
        }
        private void overviewPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void overviewPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void ThongKe_Load_1(object sender, EventArgs e)
        {

        }

        private void chartLabel_Click(object sender, EventArgs e)
        {

        }

        private void chartPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void overviewPanel_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.thang = comboBoxMonth.SelectedIndex + 1;
           

            
            data = service.GetThongKeTungNgayTrongThang(this.thang, this.nam);

         
            dataGridView.Rows.Clear();
            AddDataGridPanel();
            chartPanel.Controls.Clear();
            AddChartPanel();

           
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nam = int.Parse(comboBoxYear.SelectedItem.ToString().Replace("Năm ", ""));
            data = service.GetThongKeTungNgayTrongThang(this.thang, this.nam);

           
            dataGridView.Rows.Clear();
            AddDataGridPanel();
            chartPanel.Controls.Clear();
            AddChartPanel();
        }
    }
}
