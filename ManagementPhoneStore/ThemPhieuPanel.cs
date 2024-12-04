using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Service.impl;
using Service;
using Entity;
using static GUI.PhieuNhapPanel;
using System.Text.RegularExpressions;
using System.IO;
using NPOI.XSSF.UserModel;
using DocumentFormat.OpenXml.Drawing.Charts;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing;
using ManagementPhoneStore;
using DAO.DAO.impl;
using System.Linq;
namespace GUI
{

    public partial class ThemPhieuPanel : UserControl
    {

        private SanPhamService sanPhamService = SanPhamService.Instance;
        private NhanVienService nvService = NhanVienService.Instance;
        private NhaChungCapService nccService = NhaChungCapService.Instance;
        private DungLuongRamService dlramService = new DungLuongRamService();
        private DungLuongRomService dlromService = new DungLuongRomService();
        private PhieuNhapService pnService = PhieuNhapService.Instance;
        private PhienBanSanPhamService pbspService = PhienBanSanPhamService.Instance;
        private MauSacService mausacService = new MauSacService();

        private List<ChiTietPhieuNhap> chitietpn = new List<ChiTietPhieuNhap>();
        private Dictionary<int, List<ChiTietSanPham>> chitietsanpham = new Dictionary<int, List<ChiTietSanPham>>();

        private int maphieunhap;
        private int rowPhieuSelect = -1;
        private List<PhienBanSanPham> ch = new List<PhienBanSanPham>();
        private List<SanPham> sp = new List<SanPham>();
        private List<String> listmaimei = new List<String>();

        private List<NhanVien> listnv;
        private int manv;

        public ThemPhieuPanel(String tennv, int manvien, PhieuNhapPanel phieuNhapPanel)
        {
            InitializeComponent();
            
            manv = manvien;
            sp = sanPhamService.GetAll();
            maphieunhap = pnService.GetAutoIncrement();             
            List<string> listmamei = new List<string>();
            txtNhanvien.Text = tennv;
            txtMaphieu.Text = maphieunhap.ToString();
            LoadDataTableSanPham(sp);
            LoadDataTableChiTietPhieu();
            LoadNhaCungCapDropdown();
            listnv = nvService.GetAll();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtMasp.Enabled = false;
            txtTensp.Enabled = false;
            txtDongia.Enabled = false;

            add.Click += ActionPerformed;
            delete.Click += ActionPerformed;
            edit.Click += ActionPerformed;
            importImei.Click += ActionPerformed;
            cbxCauhinh.SelectedIndex = 0;

            dataGridView1.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    ResetForm();

                    var selectedProduct = sanPhamService.GetByMaSP((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    SetInfoSanPham(selectedProduct);
                    ActionBtn("importImei");
                    ChiTietPhieuNhap ctp = CheckTonTai();
                    if (ctp == null)
                    {
                        cbxPtNhap.Enabled =true;
                        ActionBtn("add");
                    }
                    else
                    {
                        cbxPtNhap.Enabled = false;
                        ActionBtn("update");
                        SetFormChiTietPhieu(ctp);
                    }
                }
            };

            txtNhanvien.Enabled = false;
            dataGridView2.CellClick += (sender, e) =>
            {
                int index = dataGridView2.SelectedRows.Count > 0 ? dataGridView2.SelectedRows[0].Index : -1;
                if (index != -1)
                {

                    var chitietPhieu = chitietpn[index];
                    cbxPtNhap.Enabled = false;
                    SetFormChiTietPhieu(chitietPhieu);
                    rowPhieuSelect = index;
                    ActionBtn("update");

                }
            };

            cbxCauhinh.SelectedIndexChanged += (s, e) =>
            {
                cbxPtNhap.Enabled = true;
                int index = cbxCauhinh.SelectedIndex;
                if (index >= 0 && index < ch.Count)
                {
                    txtDongia.Text = ch[index].GiaNhap.ToString();
                    txtSoLuongHienTai.Text = ch[index].SoLuongTon.ToString();
                    var ctp = CheckTonTai();
                    if (ctp == null)
                    {
                        ActionBtn("add");
                        txtSoLuongImei.Text = "";
                        txtMaImeiTheoLo.Text = "";

                    }
                    else
                    {
                        cbxPtNhap.Enabled = false;
                        ActionBtn("update");

                    }
                }
            };

            txtSearchbox.KeyUp += (sender, e) =>
            {
                List<SanPham> rs = sanPhamService.Search(txtSearchbox.Text);
                LoadDataTableSanPham(rs);
            };


            cbxPtNhap.SelectedIndexChanged += (sender, e) =>
            {
                int index = cbxPtNhap.SelectedIndex;
                if (index == 0)
                {
                    panel3.Visible = false;
                    label6.Visible = true;
                    label7.Visible = true;
                    txtSoLuongImei.Visible = true;
                    txtMaImeiTheoLo.Visible = true;
                }
                else
                {
                    label6.Visible = false;
                    label7.Visible = false;
                    panel3.Visible = true;
                    txtSoLuongImei.Visible = false;
                    txtMaImeiTheoLo.Visible = false;
                }
            };
            btnNhaphang.Click += (sender, e) =>
            {
                EventBtnNhapHang();
            };
            QuetImei.Click += button1_Click;

            SetPlaceholder(txtSearchbox, "Tìm kiếm...");
        }


        


        public static class Validation
        {
            public static bool IsEmail(string value)
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(value, pattern);
            }

            public static bool IsNumber(string value)
            {
                return int.TryParse(value, out _);
            }

            public static bool IsEmpty(string value)
            {
                return string.IsNullOrEmpty(value);
            }
            public static bool IsValidImei(string value)
            {
                return Regex.IsMatch(value.Trim(), @"^\d{15}$");
            }

        }
        public void LoadDataTableSanPham(List<SanPham> result)
        {
            dataGridView1.Rows.Clear();

            foreach (SanPham sp in result)
            {
                dataGridView1.Rows.Add(sp.Masp, sp.Tensp, sp.Soluongton);
            }

        }
        private void LoadNhaCungCapDropdown()
        {

            var nhaCungCapList = nccService.GetAll();
            cbxNcc.DataSource = nhaCungCapList;
            cbxNcc.DisplayMember = "tennhacungcap";

        }

        public void LoadDataTableChiTietPhieu()
        {
            dataGridView2.Rows.Clear();

            int size = chitietpn.Count;
            for (int i = 0; i < size; i++)
            {
                PhienBanSanPham pb = pbspService.GetByMaPhienBan(chitietpn[i].Maphienbansp);

                dataGridView2.Rows.Add(
                    i + 1,
                    pb.MaSanPham,
                    sanPhamService.GetByMaSP((int)pb.MaSanPham).Tensp,
                    dlramService.getKichThuocById((int)pb.Ram) + "GB",
                    dlromService.getKichThuocById(pb.Rom) + "GB",
                   mausacService.GetTenMau(pb.MauSac),
                    Formater.FormatVND(chitietpn[i].Dongia),
                    chitietpn[i].Soluong
                );
            }

            tongtien.Text = Formater.FormatVND(pnService.GetTongTien(chitietpn));

        }
        public void SetInfoSanPham(SanPham sp)
        {
            txtMasp.Text = sp.Masp.ToString();
            txtTensp.Text = sp.Tensp;

            ch = pbspService.GetAll(sp.Masp);

            var cauHinhList = GetCauHinhPhienBan(sp.Masp);
            cbxCauhinh.Items.Clear();
            cbxCauhinh.Items.AddRange(cauHinhList);


            if (cauHinhList.Length > 0)
            {
                cbxCauhinh.SelectedIndex = 0;
            }
            cbxPtNhap.SelectedIndex = 0;

            if (ch.Count > 0)
            {
                txtDongia.Text = ch[0].GiaNhap.ToString();
            }
        }
        public void SetFormChiTietPhieu(ChiTietPhieuNhap phieu)
        {
            // Retrieve PhienBanSanPham details by Maphienbansp
            PhienBanSanPham pb = pbspService.GetByMaPhienBan(phieu.Maphienbansp);

            // Set the product ID in txtMasp TextBox
            this.txtMasp.Text = pb.MaSanPham.ToString();

            // Set the product name in txtTensp TextBox
            this.txtTensp.Text = sanPhamService.GetByMaSP((int)pb.MaSanPham).Tensp;

            // Populate the ComboBox with items
            var cauHinhItems = GetCauHinhPhienBan((int)pb.MaSanPham);
            this.cbxCauhinh.Items.Clear();  // Clear existing items
            this.cbxCauhinh.Items.AddRange(cauHinhItems.ToArray());  // Add new items to ComboBox

            // Set the selected index for ComboBox
            this.cbxCauhinh.SelectedIndex = pbspService.GetIndexByMaPhienBan(ch, phieu.Maphienbansp);

            // Set the unit price in txtDongia TextBox
            this.txtDongia.Text = phieu.Dongia.ToString();

            // Set the IMEI or perform additional setup
            SetImei(phieu);
        }




        public string[] GetCauHinhPhienBan(int masp)
        {
            int size = ch.Count;
            string[] arr = new string[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = dlromService.getKichThuocById(ch[i].Rom) + " GB - " +
                        dlramService.getKichThuocById((int)ch[i].Ram) + " GB - " +
                        mausacService.GetTenMau(ch[i].MauSac);
            }

            return arr;
        }



        public void SetImei(ChiTietPhieuNhap phieu)
        {
            List<ChiTietSanPham> ctsp = FindMaPhienBan(phieu.Maphienbansp, chitietsanpham);
            this.cbxPtNhap.SelectedIndex = phieu.Hinhthucnhap;

            if (phieu.Hinhthucnhap == 0)
            {
                this.txtMaImeiTheoLo.Text = ctsp[0].MaImei;
                this.txtSoLuongImei.Text = ctsp.Count.ToString();
            }
            //else
            //{
            //    CardLayout c = (CardLayout)content_right_bottom.Layout;
            //    c.Last(content_right_bottom);
            //    this.textAreaImei.Text = GetStringListImei(ctsp);
            //}
        }


        public List<ChiTietSanPham> FindMaPhienBan(int mapb, Dictionary<int, List<ChiTietSanPham>> chitietsanpham)
        {
            
            if (chitietsanpham.ContainsKey(mapb))
            {
                return chitietsanpham[mapb];
            }
            else
            {
                return new List<ChiTietSanPham>();
            }
        }

        public void ResetForm()
        {

            txtMasp.Text = "";
            txtTensp.Text = "";
            txtDongia.Text = "";
            txtSoLuongImei.Text = "";
            txtMaImeiTheoLo.Text = "";
            //textAreaImei.Text = "";

            cbxCauhinh.Items.Clear();
            cbxCauhinh.Items.Add("Chọn sản phẩm");
            cbxCauhinh.SelectedIndex = 0;
        }

        public ChiTietPhieuNhap CheckTonTai()
        {
            int mapb = ch[cbxCauhinh.SelectedIndex].MaPhienBanSanPham;
            ChiTietPhieuNhap p = pnService.FindCT(chitietpn, mapb);

            return p;
        }

        public void ActionBtn(string type)
        {
            bool val1 = type.Equals("add");
            bool val2 = type.Equals("update");


            add.Enabled = val1;
            import.Enabled = val1;
            edit.Enabled = val2;
            delete.Enabled = val2;
            importImei.Enabled = val1;

        }

        public bool ValidateNhap()
        {
            int phuongthuc = cbxPtNhap.SelectedIndex;

            if (string.IsNullOrEmpty(txtMasp.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.", "Chọn sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(txtDongia.Text) || !Validation.IsNumber(txtDongia.Text))
            {
                MessageBox.Show("Giá nhập không được để rỗng và phải là số!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (phuongthuc == 0) // Nhập theo lô
            {
                if (string.IsNullOrEmpty(txtMaImeiTheoLo.Text) || !Validation.IsValidImei(txtMaImeiTheoLo.Text))
                {
                    MessageBox.Show("Mã imei bắt đầu không được để rỗng và phải là 15 ký tự số!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (string.IsNullOrEmpty(txtSoLuongImei.Text) || !Validation.IsNumber(txtSoLuongImei.Text))
                {
                    MessageBox.Show("Số lượng không được để rỗng và phải là số!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (phuongthuc == 1) // Nhập theo imei
            {
                if (string.IsNullOrEmpty(textAreaImei.Text) || !Validation.IsValidImei(textAreaImei.Text))
                {
                    MessageBox.Show("Mã imei không được để rỗng và phải là số!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        public bool CheckImeiExists()
        {
            List<ChiTietSanPham> ctSP = GetChiTietSanPham();
            List<ChiTietSanPham> dsCheck = new List<ChiTietSanPham>();


            foreach (var ctspList in chitietsanpham.Values)
            {
                dsCheck.AddRange(ctspList);
            }

            foreach (var chiTietSanPham in ctSP)
            {
                foreach (var chiTietSanPhamInCheck in dsCheck)
                {
                    if (chiTietSanPham.MaImei.Equals(chiTietSanPhamInCheck.MaImei))
                    {
                        MessageBox.Show("Có sự nhầm lẫn nào đó IMEI đã tồn tại trong phiếu");
                        return false;
                    }
                }
            }
            //if (!pbspService.CheckImeiExists(ctSP))
            //{
            //    MessageBox.Show("Có IMEI trùng với imei trong kho có sự sai sót nào đó!");
            //    return false;
            //}
            return true;
        }

        public List<ChiTietSanPham> GetChiTietSanPham()
        {
            int hinhthuc = cbxPtNhap.SelectedIndex;
            int maphienbansp = (int)ch[cbxCauhinh.SelectedIndex].MaPhienBanSanPham;
            List<ChiTietSanPham> result = new List<ChiTietSanPham>();

            if (hinhthuc == 1)
            {
                string[] arrImei = textAreaImei.Text.Split('\n');
                foreach (var imei in arrImei)
                {
                    result.Add(new ChiTietSanPham(imei, maphienbansp, maphieunhap, 0, true));
                }
            }
            else
            {
                long imeiBatDau = long.Parse(txtMaImeiTheoLo.Text);
                int soLuong = int.Parse(txtSoLuongImei.Text);

                for (long i = imeiBatDau; i < imeiBatDau + soLuong; i++)
                {
                    result.Add(new ChiTietSanPham(i.ToString(), maphienbansp, maphieunhap, 0, true));
                }
            }

            return result;
        }


        public void ActionPerformed(object sender, EventArgs e)
        {
            Button source = sender as Button;

            if (source == add && ValidateNhap())
            {
                if (CheckImeiExists())
                {
                    AddCtPhieu();
                }
            }
            else if (source == delete)//van ko xoa duoc imei 
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int index = dataGridView2.SelectedRows[0].Index;
                    chitietpn.RemoveAt(index);
                    ActionBtn("add");
                    LoadDataTableChiTietPhieu();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (source == edit)
            {
                if (cbxCauhinh.SelectedIndex >= 0)
                {
                    int mapb = (int)ch[cbxCauhinh.SelectedIndex].MaPhienBanSanPham;
                    chitietsanpham.Remove(mapb);
                    List<ChiTietSanPham> ctsp = GetChiTietSanPham();
                    chitietsanpham[mapb] = ctsp;

                    int ptnhap = cbxPtNhap.SelectedIndex;
                    chitietpn[rowPhieuSelect].Hinhthucnhap = ptnhap;
                    chitietpn[rowPhieuSelect].Soluong = ctsp.Count;
                    LoadDataTableChiTietPhieu();
                }
                else
                {
                    MessageBox.Show("Please select a configuration.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (source == importImei)
            {
                GetImeifromFile();
                foreach (string imei in listmaimei)
                {
                    textAreaImei.AppendText(imei + "\n");
                }
            }
        }

        public void AddCtPhieu()
        {

            ChiTietPhieuNhap ctphieu = GetInfoChiTietPhieu();

            ChiTietPhieuNhap existingProduct = pnService.FindCT(chitietpn, ctphieu.Maphienbansp);

            if (existingProduct == null)
            {
                chitietpn.Add(ctphieu);
                LoadDataTableChiTietPhieu();
                ResetForm();
            }

        }
        public ChiTietPhieuNhap GetInfoChiTietPhieu()
        {

            int masp = int.Parse(txtMasp.Text);
            int maphienbansp = (int)ch[cbxCauhinh.SelectedIndex].MaPhienBanSanPham;

            int gianhap = int.Parse(txtDongia.Text);
            int phuongthucnhap = cbxPtNhap.SelectedIndex;
            MessageBox.Show(maphienbansp.ToString());

            List<ChiTietSanPham> ctSP = GetChiTietSanPham();
            int soluong = ctSP.Count;

            chitietsanpham[maphienbansp] = GetChiTietSanPham();


            ChiTietPhieuNhap ctphieu = new ChiTietPhieuNhap(phuongthucnhap, maphieunhap, maphienbansp, soluong, gianhap);
            return ctphieu;
        }

        public void GetImeifromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open file",
                Filter = "Excel Files|*.xlsx;*.xls"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string excelFile = openFileDialog.FileName;
                MessageBox.Show($"Selected file: {excelFile}");

                try
                {
                    using (FileStream fileStream = new FileStream(excelFile, FileMode.Open, FileAccess.Read))
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(fileStream);
                        var sheet = workbook.GetSheetAt(0);

                        for (int row = 1; row <= sheet.LastRowNum; row++)
                        {
                            var excelRow = sheet.GetRow(row);
                            if (excelRow != null)
                            {
                                var cell = excelRow.GetCell(0);
                                if (cell != null)
                                {
                                    string maimei = cell.ToString();
                                    if (maimei.Length == 15)
                                    {
                                        listmaimei.Add(maimei);
                                        Console.WriteLine(maimei);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Error: File not found.");
                }
                catch (IOException)
                {
                    Console.WriteLine("Error: Cannot read the file.");
                }
            }
        }
        public void EventBtnNhapHang()
        {
            if (chitietpn.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong phiếu!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult input = MessageBox.Show("Bạn có chắc chắn muốn tạo phiếu nhập!",
                                                     "Xác nhận tạo phiếu",
                                                     MessageBoxButtons.OKCancel,
                                                     MessageBoxIcon.Information);

                if (input == DialogResult.OK)
                {
                    int mancc = (int)nccService.GetByIndex(cbxNcc.SelectedIndex).Manhacungcap;
                    DateTime now = DateTime.Now;
                    PhieuNhap pn = new PhieuNhap(
                        maphieunhap,
                         now,
                        mancc,
                        listnv[0].Manv.ToString(),
                        pnService.GetTongTien(chitietpn),
                        1
                    );

                    bool result = pnService.Add(pn, chitietpn, chitietsanpham);
                    if (result)
                    {
                        MessageBox.Show("Nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        maphieunhap = pnService.GetAutoIncrement()+1;
                        LoadDataTableSanPham(sp);
                        PhieuNhapPanel newpan = new PhieuNhapPanel(manv);
                        SetPanel(newpan);
                    }
                    else
                    {
                        MessageBox.Show("Nhập hàng không thành công!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public void SetPanel(UserControl newPanel)
        {
            Console.WriteLine("Switching to a new panel...");

            this.Controls.Clear();

            newPanel.Dock = DockStyle.Fill;
            this.Controls.Add(newPanel);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PhieuNhapPanel phieuNhapPanel = new PhieuNhapPanel(manv);
            SetPanel(phieuNhapPanel);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaphieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ImeiScannerDialog scannerDialog = new ImeiScannerDialog())
            {

                if (scannerDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Quét IMEI thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string imei = scannerDialog.IMEI;
                    textAreaImei.Text = imei;
                }
                else
                {
                    MessageBox.Show("Quét IMEI đã bị hủy.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        private void SetPlaceholder(RichTextBox richTextBox, string placeholder)
        {
            richTextBox.Text = placeholder;
            richTextBox.ForeColor = Color.Gray;

            richTextBox.Enter += (sender, e) =>
            {
                if (richTextBox.Text == placeholder)
                {
                    richTextBox.Text = "";
                    richTextBox.ForeColor = Color.Black;
                }
            };

            richTextBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrEmpty(richTextBox.Text))
                {
                    richTextBox.Text = placeholder;
                    richTextBox.ForeColor = Color.Gray;
                }
            };
        }

        private void textAreaImei_TextChanged(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            PhieuNhapPanel phieuNhapPanel = new PhieuNhapPanel(manv);
            SetPanel(phieuNhapPanel);
        }

        private void add_Click_1(object sender, EventArgs e)
        {

        }

        private void QuetImei_Click(object sender, EventArgs e)
        {

        }

        private void cbxCauhinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNhaphang_Click(object sender, EventArgs e)
        {

        }
    }
}
