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
using DAO.DAO.impl;

using DAO.DAO;
namespace GUI
{

    public partial class ThemPhieuXuat : UserControl
    {

        private SanPhamService sanPhamService = SanPhamService.Instance;
        private NhanVienService nvService = NhanVienService.Instance;
        private KhachHangService khService = new KhachHangService();
        private DungLuongRamService dlramService = new DungLuongRamService();
        private DungLuongRomService dlromService = new DungLuongRomService();
        private PhieuXuatService pnService = PhieuXuatService.Instance;
        private PhienBanSanPhamService pbspService = PhienBanSanPhamService.Instance;
        private MauSacService mausacService = new MauSacService();
        private NhanVien nvnhap = new NhanVien();
        private ChiTietSanPhamService ctspBus = ChiTietSanPhamService.Instance;
        private ChiTietSanPhamDAO ctspdao = new ChiTietSanPhamDAO();
        private Dictionary<int, List<ChiTietSanPham>> chitietsanpham = new Dictionary<int, List<ChiTietSanPham>>();

        private List<ChiTietPhieuXuat> chitietpx = new List<ChiTietPhieuXuat>();
  
        private int rowPhieuSelect = -1;
        private List<PhienBanSanPham> ch = new List<PhienBanSanPham>();
        private List<String> imeiSelected = new List<String>();
        private List<String> listmaimei = new List<String>();
        private List<ChiTietSanPham> ctsp = new List<ChiTietSanPham>();
        private ChiTietSanPhamDAO ct = new ChiTietSanPhamDAO();
        private List<NhanVien> listnv;
        public RichTextBox TextAreaImei => textAreaImei;

        //info phieu
        int manv;
        int maPhieuXuat;
        int makh = -1;
        public ThemPhieuXuat(String tennv, int manvien)
        {
            List<SanPham> sp = new List<SanPham>();
            maPhieuXuat = pnService.GetAutoIncrement();
            InitializeComponent();
            txtNhanvien.Text = tennv;
            txtMaphieu.Text = maPhieuXuat.ToString();
            manv = manvien;
            sp = sanPhamService.GetAll();

            LoadDataTableSanPham(sp);
            LoadDataTableChiTietPhieu(chitietpx);
            LoadKhachHangDropdown();
            listnv = nvService.GetAll();
           (cbxkh.SelectedIndex)=0;


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            add.Click += (sender, e) =>
            {
                if (CheckInfo())
                {
                    GetInfoChiTietPhieu();


                    LoadDataTableChiTietPhieu(chitietpx);
                    ActionBtn("update");
                }
            };
            delete.Click += (sender, e) =>
            {
                int index = dataGridView2.SelectedRows.Count > 0 ? dataGridView2.SelectedRows[0].Index : -1;
                if (index < 0)
                {
                    MessageBox.Show("Vui lòng chọn cấu hình cần xóa");
                }
                else
                {
                    var ctPhieuDel = chitietpx[index];
                    int maphienban = ctPhieuDel.Maphienbansp;
                    List<ChiTietSanPham> ctSpDel = new List<ChiTietSanPham>();
                    foreach (var chiTietSanPham in ctsp)
                    {
                        if (chiTietSanPham.MaPhienBanSanPham != maphienban)
                        {
                            ctSpDel.Add(chiTietSanPham);
                        }
                    }
                    chitietpx.RemoveAt(index);
                    ctsp = ctSpDel;
                    LoadDataTableChiTietPhieu(chitietpx);
                }
            };

            import.Click += (sender, e) =>
            {
                MessageBox.Show("Chức năng không khả dụng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };

           
            cbxCauhinh.SelectedIndex = 0;


            dataGridView1.CellClick += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    ResetForm();
                    var selectedProduct = sanPhamService.GetByMaSP((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    SetInfoSanPham(selectedProduct);
                    ActionBtn("importImei");
                    ChiTietPhieuXuat ctp = CheckTonTai();
                    if (ctp == null)
                    {
                       
                        ActionBtn("add");
                    }
                    else
                    {
                    
                        ActionBtn("update");
                        SetFormChiTietPhieu(ctp);
                    }
                }
            };


            dataGridView2.CellClick += (sender, e) =>
            {
                int index = dataGridView2.SelectedRows.Count > 0 ? dataGridView2.SelectedRows[0].Index : -1;
                if (index != -1)
                {
                    var chitietPhieu = chitietpx[index];
                    SetFormChiTietPhieu(chitietPhieu);
                    rowPhieuSelect = index;
                    ActionBtn("update");
                }
            };

            cbxCauhinh.SelectedIndexChanged += (s, e) =>
            {
                int index = cbxCauhinh.SelectedIndex;

                if (index >= 0 && index < ch.Count)                {

                    txtDongia.Text = ch[index].GiaNhap.ToString();
                    soluong.Text = ch[index].SoLuongTon.ToString();
                    var ctp = CheckTonTai();
                    if (ctp == null)
                    {
                        ActionBtn("add");
                        textAreaImei.Text = "";

                    }
                    else
                    {
                        ActionBtn("update");

                    }
                }
            };

            txtSearchbox.KeyUp += (sender, e) =>
            {
                List<SanPham> rs = sanPhamService.Search(txtSearchbox.Text);
                LoadDataTableSanPham(rs);
            };


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
            for (int i = 0; i  < result.Count;i++)
            {
                SanPham sp=sanPhamService.GetByIndex(i);
                dataGridView1.Rows.Add(sp.Masp, sp.Tensp, sp.Soluongton);
            }

        }

        private void LoadKhachHangDropdown()
        {

            var khList = khService.getAll();
            cbxkh.DataSource = khList;
            cbxkh.DisplayMember = "tenkhachhang";

        }

        public void LoadDataTableChiTietPhieu(List<ChiTietPhieuXuat> ctpx)
        {
            dataGridView2.Rows.Clear();

            int size = chitietpx.Count;
            for (int i = 0; i < size; i++)
            {
                PhienBanSanPham pb = pbspService.GetByMaPhienBan(chitietpx[i].Maphienbansp);

                dataGridView2.Rows.Add(
                    i + 1,
                    pb.MaSanPham,
                    sanPhamService.GetByMaSP((int)pb.MaSanPham).Tensp,
                    dlramService.getKichThuocById((int)pb.Ram) + "GB",
                    dlromService.getKichThuocById(pb.Rom) + "GB",
                   mausacService.GetTenMau(pb.MauSac),
                    Formater.FormatVND(chitietpx[i].Dongia),
                    chitietpx[i].Soluong
                );
            }

            tongtien.Text = Formater.FormatVND(pnService.GetTongTien(chitietpx));

        }
        public void SetInfoSanPham(SanPham sp)
        {
            txtMasp.Text = sp.Masp.ToString();
            txtTensp.Text = sp.Tensp;
            soluong.Text = sp.Soluongton.ToString();

            ch = pbspService.GetAll(sp.Masp);

            var cauHinhList = GetCauHinhPhienBan(sp.Masp);
            cbxCauhinh.Items.Clear();
            cbxCauhinh.Items.AddRange(cauHinhList);
            if (cauHinhList.Length > 0)
            {
                cbxCauhinh.SelectedIndex = 0;
            }
            if (ch.Count > 0)
            {
                txtDongia.Text = ch[0].GiaNhap.ToString();
            }
        }
        public void SetFormChiTietPhieu(ChiTietPhieuXuat phieu)
        {
            PhienBanSanPham pb = pbspService.GetByMaPhienBan(phieu.Maphienbansp);
            if (pb == null)
            {
                MessageBox.Show("Product version not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            this.txtMasp.Text = pb.MaSanPham.ToString();
            this.txtTensp.Text = sanPhamService.GetByMaSP((int)pb.MaSanPham).Tensp;

            var cauHinhList = GetCauHinhPhienBan((int)pb.MaSanPham);


            this.cbxCauhinh.Items.Clear();
            this.cbxCauhinh.Items.AddRange(cauHinhList);


            if (cauHinhList.Length > 0)
            {
                int selectedIndex = pbspService.GetIndexByMaPhienBan(ch, phieu.Maphienbansp);

            }
            else
            {
                MessageBox.Show("No configurations available for this product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.txtDongia.Text = phieu.Dongia.ToString();


            //SetImei(phieu);
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
            textAreaImei.Text = "";

            cbxCauhinh.Items.Clear();
            cbxCauhinh.Items.Add("Chọn sản phẩm");
            cbxCauhinh.SelectedIndex = 0;
        }

        public ChiTietPhieuXuat CheckTonTai()
        {
            int mapb = ch[cbxCauhinh.SelectedIndex].MaPhienBanSanPham;

            ChiTietPhieuXuat p = pnService.FindCT(chitietpx, mapb);

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


            return true;
        }



        public int GetChiTietSanPham()
        {
            int maphienbansp = (int)ch[cbxCauhinh.SelectedIndex].MaPhienBanSanPham;

            // Remove empty entries caused by extra newlines
            String[] imei = textAreaImei.Text.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string itemimei in imei)
            {
                ChiTietSanPham ch = new ChiTietSanPham(itemimei, maphienbansp, 0, maPhieuXuat, false);
                ctsp.Add(ch);
            }

            return imei.Length;
        }


        public bool checkTonTai()
        {
            bool check = false;
            int maphienbansp = (int)ch[cbxCauhinh.SelectedIndex].MaPhienBanSanPham;
            foreach (ChiTietPhieuXuat chiTietPhieu in chitietpx)
            {
                if (chiTietPhieu.Maphienbansp == maphienbansp)
                {
                    return true;
                }
            }
            return check;
        }

        public void ActionPerformed(object sender, EventArgs e)
        {
            Button source = sender as Button;

            if (source == add && ValidateNhap())
            {

                AddCtPhieu();

            }
            else if (source == delete)//van ko xoa duoc imei 
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int index = dataGridView2.SelectedRows[0].Index;
                    chitietpx.RemoveAt(index);
                    ActionBtn("add");
                    LoadDataTableChiTietPhieu(chitietpx);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            ChiTietPhieuXuat ctphieu = GetInfoChiTietPhieu();

            ChiTietPhieuXuat existingProduct = pnService.FindCT(chitietpx, ctphieu.Maphienbansp);

            if (existingProduct == null)
            {
                chitietpx.Add(ctphieu);
                LoadDataTableChiTietPhieu(chitietpx);
                ResetForm();
            }

        }
        public ChiTietPhieuXuat GetInfoChiTietPhieu()
        {

            int masp = int.Parse(txtMasp.Text);
            int maphienbansp = (int)ch[cbxCauhinh.SelectedIndex].MaPhienBanSanPham;

            int gianhap = int.Parse(txtDongia.Text);
            int soluong = GetChiTietSanPham();
            String[] imei = textAreaImei.Text.Split(new char[] { '\n' });
            ChiTietPhieuXuat ctphieu = new ChiTietPhieuXuat(maPhieuXuat, maphienbansp, soluong, gianhap);
            chitietpx.Add(ctphieu);
            return null;
        }
        public void setImeiByPb(int mapb)
        {
            ctsp = ctspdao.SelectAllByPb(mapb);
            PhienBanSanPham pbsp = pbspService.GetByMaPhienBan(mapb);
            txtDongia.Text = pbsp.GiaXuat.ToString();
            soluong.Text = (pbsp.SoLuongTon.ToString());
            textAreaImei.Text = "";
            for (int i = 0; i < ctsp.Count; i++)
            {
                foreach (ChiTietSanPham chiTietSanPham in ctsp)
                {
                    if (chiTietSanPham.MaImei.Equals(ctsp[i].MaImei))
                    {
                        textAreaImei.AppendText(chiTietSanPham.MaImei + "\n");
                    }
                }
            }
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

        public void SetPanel(UserControl newPanel)
        {
            Console.WriteLine("Switching to a new panel...");

            if (this.Controls.Contains(tableLayoutPanel1))
            {
                this.Controls.Remove(tableLayoutPanel1);
            }

            newPanel.Dock = DockStyle.Fill;
            this.Controls.Add(newPanel);

        }


   
     
    
        public bool CheckInfo()
        {
            bool check = true;

            if (string.IsNullOrEmpty(txtMasp.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                check = false;
            }
            else if (string.IsNullOrEmpty(TextAreaImei.Text))
            {
                MessageBox.Show("Vui lòng chọn mã imei", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                check = false;
            }

            return check;
        }
        public void SetPhieuSelected()
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView2.SelectedRows[0].Index;
                ChiTietPhieuXuat chitiet = chitietpx[selectedIndex];
                SanPham spSel = sanPhamService.GetSp(chitiet.Maphienbansp);
                SetInfoSanPham(spSel);
                cbxCauhinh.SelectedItem = chitiet.Maphienbansp.ToString();
            }
        }

        private void btnNhaphang_Click(object sender, EventArgs e)
        {
            if (chitietpx.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong phiếu!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult input = MessageBox.Show("Bạn có chắc chắn muốn tạo phiếu xuất!",
                                                      "Xác nhận tạo phiếu",
                                                      MessageBoxButtons.OKCancel,
                                                      MessageBoxIcon.Information);

                if (input == DialogResult.OK)
                {
                    int kh = (int)khService.getByIndex(cbxkh.SelectedIndex).MakH;
                    DateTime now = DateTime.Now;
                    PhieuXuat px = new PhieuXuat(
                        maPhieuXuat,
                        now,
                        pnService.GetTongTien(chitietpx),
                        listnv[0].Manv,
                        kh,
                        1
                    );

                    bool result = pnService.Add(px, chitietpx, chitietsanpham);
                    if (result)
                    {
                        MessageBox.Show("Xuất hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                        PhieuXuatPanel newpan = new PhieuXuatPanel(manv);
                        SetPanel(newpan);
                    }
                    else
                    {
                        MessageBox.Show("Xuất hàng không thành công!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
             string selectedText = cbxCauhinh.SelectedItem.ToString();

            if (selectedText == "Chọn sản phẩm")
            {
                MessageBox.Show("Hãy chọn cấu hình điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int mapb = ch[cbxCauhinh.SelectedIndex].MaPhienBanSanPham;
            ctsp = ct.SelectAllByPb(mapb);
           


            ImeiSelection imeiSelection = new ImeiSelection(ctsp, this,imeiSelected);
            imeiSelection.Visible = true;
            imeiSelected = imeiSelection.beforeSelectedImei;

        }

        private void back_Click(object sender, EventArgs e)
        {
         
            PhieuXuatPanel phieuNhapPanel = new PhieuXuatPanel(manv);
            SetPanel(phieuNhapPanel);
       

    }

        private void cbxCauhinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtDongia_TextChanged(object sender, EventArgs e)
        {

        }

        private void soluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void textAreaImei_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
