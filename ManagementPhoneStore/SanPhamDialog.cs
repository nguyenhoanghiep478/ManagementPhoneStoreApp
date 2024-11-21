using Service.impl;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using System.IO;
using ManagementPhoneStore.Properties;
using GUI;
using NPOI.SS.Formula.Functions;

namespace ManagementPhoneStore
{
    public partial class SanPhamDialog : Form
    {
        private string chucnang;
        private string selectedImagePath;

        private SanPhamService sanPhamService = SanPhamService.Instance;
        private PhienBanSanPhamService PhienBanSanPhamService = new PhienBanSanPhamService();
        private HeDieuHanhService heDieuHanhService = new HeDieuHanhService();
        private ThuongHieuService thuongHieuService = ThuongHieuService.Instance;
        private XuatXuService xuatXuService = new XuatXuService();
        private KhuVucKhoService khuVucKhoService = KhuVucKhoService.Instance;
        private DungLuongRomService dungLuongRomService = new DungLuongRomService();
        private DungLuongRamService dungLuongRamService = new DungLuongRamService();
        private MauSacService mauSacService = new MauSacService();
        private int masp = 0;

        public SanPhamDialog(string chucnang, int masp)
        {
            InitializeComponent();
            LoadDulieuCombobox();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.chucnang = chucnang;
            this.masp = masp;
            if (this.chucnang.Equals("them"))
            {
                initThemsanpham();
            }
            else if (this.chucnang.Equals("sua"))
            {
                initSuasanpham();
            }
            else if (this.chucnang.Equals("chitiet"))
            {
                initChitietsanpham();
            }
        }
        private void initThemsanpham()
        {
            label13.Text = "Thêm sản phẩm mới";
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = true;
            panel3.Visible = false;
            string imagePath = Path.Combine(Application.StartupPath, "img_product", "default.jpg");
            pictureBox1.Image = Image.FromFile(imagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void initSuasanpham()
        {
            label13.Text = "Chỉnh sửa sản phẩm";
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = true;
            panel3.Visible = false;
            SanPham sanPham = sanPhamService.GetByMaSP(masp);
            string imagePath = Path.Combine(Application.StartupPath, "img_product", sanPham.Hinhanh);
            pictureBox1.Image = Image.FromFile(imagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            textBox_Tensp.Text = sanPham.Tensp;
            textBox_chip.Text = sanPham.Chipxuly;
            textBox_Pin.Text = sanPham.Dungluongpin.ToString();
            textBox_Kichthuocman.Text = sanPham.Kichthuocman.ToString();
            textBox_Camerasau.Text = sanPham.Camerasau.ToString();
            textBox_Cameratruoc.Text = sanPham.Cameratruoc.ToString();
            textBox_Phienbanhdh.Text = sanPham.Phienbanhdh.ToString();
            textBox_Thoigianbh.Text = sanPham.Thoigianbaohanh.ToString();
            comboBox_Xuatxu.Text = xuatXuService.GetTenXuatXu((int)sanPham.Xuatxu);
            comboBox_Hedieuhanh.Text = heDieuHanhService.selectById((int)sanPham.Hedieuhanh).Tenhedieuhanh.ToString();
            comboBox_Thuonghieu.Text = thuongHieuService.GetTenThuongHieu((int)sanPham.Thuonghieu).ToString();
            int kvkIndex = khuVucKhoService.GetIndexByMaKVK((int)sanPham.Khuvuckho);
            comboBox_Khuvuckho.Text = khuVucKhoService.GetByIndex(kvkIndex).Tenkhuvuc.ToString();
        }
        private void initChitietsanpham()
        {
            label13.Text = "Xem chi tiết sản phẩm";
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = false;
            panel3.Visible = false;
            SanPham sanPham = sanPhamService.GetByMaSP(masp);
            string imagePath = Path.Combine(Application.StartupPath, "img_product", sanPham.Hinhanh);
            pictureBox1.Image = Image.FromFile(imagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            textBox_Tensp.Text = sanPham.Tensp;
            textBox_chip.Text = sanPham.Chipxuly;
            textBox_Pin.Text = sanPham.Dungluongpin.ToString();
            textBox_Kichthuocman.Text = sanPham.Kichthuocman.ToString();
            textBox_Camerasau.Text = sanPham.Camerasau.ToString();
            textBox_Cameratruoc.Text = sanPham.Cameratruoc.ToString();
            textBox_Phienbanhdh.Text = sanPham.Phienbanhdh.ToString();
            textBox_Thoigianbh.Text = sanPham.Thoigianbaohanh.ToString();
            comboBox_Xuatxu.Text = xuatXuService.GetTenXuatXu((int)sanPham.Xuatxu);
            comboBox_Hedieuhanh.Text = heDieuHanhService.selectById((int)sanPham.Hedieuhanh).Tenhedieuhanh.ToString();
            comboBox_Thuonghieu.Text = thuongHieuService.GetTenThuongHieu((int)sanPham.Thuonghieu).ToString();
            int kvkIndex = khuVucKhoService.GetIndexByMaKVK((int)sanPham.Khuvuckho);
            comboBox_Khuvuckho.Text = khuVucKhoService.GetByIndex(kvkIndex).Tenkhuvuc.ToString();
        }
        private void LoadDulieuCombobox()
        {
            // Thêm dữ liệu vào ComboBox
            comboBox_Xuatxu.Items.AddRange(xuatXuService.GetAll().Where(xx => xx.Trangthai == true).Select(xx => xx.Tenxuatxu).ToArray());
            comboBox_Hedieuhanh.Items.AddRange(heDieuHanhService.getAll().Where(hdh => hdh.Trangthai == 1).Select(hdh => hdh.Tenhedieuhanh).ToArray());
            comboBox_Thuonghieu.Items.AddRange(thuongHieuService.GetAll().Where(th => th.Trangthai == 1).Select(th => th.Tenthuonghieu).ToArray());
            comboBox_Khuvuckho.Items.AddRange(khuVucKhoService.GetAll().Where(khuvuc => khuvuc.Trangthai == 1).Select(khuvuc => khuvuc.Tenkhuvuc).ToArray());
            comboBox_Rom.Items.AddRange(dungLuongRomService.getAll().Where(dlrom => dlrom.Trangthai == true).Select(dlrom => dlrom.Kichthuocrom + "GB").ToArray());
            comboBox_Ram.Items.AddRange(dungLuongRamService.getAll().Where(dlram => dlram.Trangthai == true).Select(dlram => dlram.Kichthuocram + "GB").ToArray());
            comboBox_Mausac.Items.AddRange(mauSacService.GetAll().Where(mausac => mausac.Trangthai == true).Select(mausac => mausac.Tenmau).ToArray());

            // Chọn mục đầu tiên cho tất cả các ComboBox
            comboBox_Xuatxu.SelectedIndex = 0;
            comboBox_Hedieuhanh.SelectedIndex = 0;
            comboBox_Thuonghieu.SelectedIndex = 0;
            comboBox_Khuvuckho.SelectedIndex = 0;
            comboBox_Rom.SelectedIndex = 0;
            comboBox_Ram.SelectedIndex = 0;
            comboBox_Mausac.SelectedIndex = 0;

            // Đăng ký các sự kiện với phương thức chung
            comboBox_Xuatxu.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox_Xuatxu.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);

            comboBox_Hedieuhanh.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox_Hedieuhanh.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);

            comboBox_Thuonghieu.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox_Thuonghieu.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);

            comboBox_Khuvuckho.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox_Khuvuckho.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);

            comboBox_Rom.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox_Rom.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);

            comboBox_Ram.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox_Ram.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);

            comboBox_Mausac.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox_Mausac.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
        }

        private void ComboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;  // Điều chỉnh chiều cao mục của ComboBox
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Lấy ComboBox đang được vẽ
            ComboBox comboBox = sender as ComboBox;

            // Kiểm tra nếu ComboBox có item
            if (comboBox != null && e.Index >= 0)
            {
                // Lấy mục cần vẽ
                string itemText = comboBox.Items[e.Index].ToString();

                // Nếu mục được chọn, tô màu nền khác
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    // Tô màu nền khi mục được chọn
                    e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
                    e.Graphics.DrawString(itemText, e.Font, Brushes.White, e.Bounds);  // Màu chữ trắng khi chọn
                }
                else
                {
                    // Tô màu nền mặc định khi không chọn
                    e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                    e.Graphics.DrawString(itemText, e.Font, Brushes.Black, e.Bounds);  // Màu chữ đen khi không chọn
                }
            }
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Tạo một OpenFileDialog để người dùng chọn ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Thiết lập bộ lọc để chỉ cho phép chọn các file ảnh
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

            // Mở hộp thoại để người dùng chọn ảnh
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của file ảnh đã chọn
                selectedImagePath = openFileDialog.FileName;

                // Hiển thị ảnh trong PictureBox
                pictureBox1.Image = Image.FromFile(selectedImagePath);

                // Thiết lập chế độ hiển thị ảnh cho PictureBox (Zoom, StretchImage...)
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SanPham sanPham = new SanPham();
            sanPham.Masp = sanPhamService.GetAll().Max(sp => sp.Masp) + 1;
            sanPham.Tensp = textBox_Tensp.Text;
            sanPham.Xuatxu = FindXuatxu(comboBox_Xuatxu.Text).Maxuatxu;
            sanPham.Chipxuly = textBox_chip.Text;
            if (int.TryParse(textBox_Pin.Text, out int pin))
            {
                sanPham.Dungluongpin = pin;
            }
            else
            {
                MessageBox.Show("Dung lượng pin không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(double.TryParse(textBox_Kichthuocman.Text, out double kichthuocman))
            {
                sanPham.Kichthuocman = kichthuocman;
            }
            else
            {
                MessageBox.Show("Kích thước màn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sanPham.Camerasau = textBox_Camerasau.Text;
            sanPham.Cameratruoc = textBox_Cameratruoc.Text;
            sanPham.Hedieuhanh = FindHedieuhanh(comboBox_Hedieuhanh.Text).Mahedieuhanh;
            if (int.TryParse(textBox_Phienbanhdh.Text, out int pb))
            {
                sanPham.Phienbanhdh = pb;
            }
            else
            {
                MessageBox.Show("Phiên bản hệ điều hành không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(textBox_Thoigianbh.Text, out int thoigianbh))
            {
                sanPham.Thoigianbaohanh = thoigianbh;
            }
            else
            {
                MessageBox.Show("Thời gian bảo hành không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sanPham.Thuonghieu = FindThuonghieu(comboBox_Thuonghieu.Text).Mathuonghieu;
            sanPham.Khuvuckho = FindKhuvuckho(comboBox_Khuvuckho.Text).Makhuvuc;
            sanPham.Trangthai = true;
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                string projectFolder = Application.StartupPath;
                string imageFolder = Path.Combine(projectFolder, "img_product");
                string fileName = $"{sanPham.Masp}_{Path.GetFileName(selectedImagePath)}";
                string destinationPath = Path.Combine(imageFolder, fileName);

                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }

                File.Copy(selectedImagePath, destinationPath, true);

                sanPham.Hinhanh = Path.Combine(fileName);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<PhienBanSanPham> phienBanSanPhams = new List<PhienBanSanPham>();
            panel3.Visible = true;
            listView1.Visible = true;
            listView2.Visible = false;
            listView1.Items.Clear();
            listView1.View = View.Details;
            sanPhamService.Add(sanPham, phienBanSanPhams);
            this.masp=sanPham.Masp;
        }
        private XuatXu FindXuatxu(string tenxuatxu)
        {
            List<XuatXu> xuatxuList = xuatXuService.GetAll();
            foreach (XuatXu xuatXu in xuatxuList)
            {
                if (xuatXu.Tenxuatxu.Equals(tenxuatxu))
                {
                    return xuatXu;
                }
            }
            return null;
        }
        private ThuongHieu FindThuonghieu(string tenthuonghieu)
        {
            List<ThuongHieu> thuonghieuList = thuongHieuService.GetAll();
            foreach (ThuongHieu thuongHieu in thuonghieuList)
            {
                if (thuongHieu.Tenthuonghieu.Equals(tenthuonghieu))
                {
                    return thuongHieu;
                }
            }
            return null;
        }
        private HeDieuHanh FindHedieuhanh(string tenhedieuhanh)
        {
            List<HeDieuHanh> heDieuhanhList = heDieuHanhService.getAll();
            foreach (HeDieuHanh heDieuHanh in heDieuhanhList)
            {
                if (heDieuHanh.Tenhedieuhanh.Equals(tenhedieuhanh))
                {
                    return heDieuHanh;
                }
            }
            return null;
        }
        private KhuVucKho FindKhuvuckho(string tenkhuvuc)
        {
            List<KhuVucKho> khuVucKhoList = khuVucKhoService.GetAll();
            foreach (KhuVucKho khuVucKho in khuVucKhoList)
            {
                if (khuVucKho.Tenkhuvuc.Equals(tenkhuvuc))
                {
                    return khuVucKho;
                }
            }
            return null;
        }

        private DLRom FindRom(string rom)
        {
            List<DLRom> dLRoms = dungLuongRomService.getAll();
            foreach (DLRom dRom in dLRoms)
            {
                if (dRom.Kichthuocrom.ToString().Equals(rom))
                {
                    return dRom;
                }
            }
            return null;
        }

        private DLRam FindRam(string ram)
        {
            List<DLRam> dLRams = dungLuongRamService.getAll();
            foreach (DLRam dRam in dLRams)
            {
                if (dRam.Kichthuocram.ToString().Equals(ram))
                {
                    return dRam;
                }
            }
            return null;
        }

        private MauSac FindMausac(string mausac)
        {
            List<MauSac> mauSacs = mauSacService.GetAll();
            foreach (MauSac mauSac in mauSacs)
            {
                if (mauSac.Tenmau.Equals(mausac))
                {
                    return mauSac;
                }
            }
            return null;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            listView1.Visible = true;
            listView2.Visible = false;
            listView1.Items.Clear();
            listView1.View = View.Details;
            List<PhienBanSanPham> phienBanSanPhams = PhienBanSanPhamService.GetAll(this.masp);
            int stt = 1;
            foreach (PhienBanSanPham pb in phienBanSanPhams)
            {
                if (pb.TrangThai == true)
                {
                    ListViewItem item = new ListViewItem(stt.ToString());
                    item.SubItems.Add(dungLuongRomService.getKichThuocById(pb.Rom).ToString() + "GB");
                    item.SubItems.Add(dungLuongRamService.getKichThuocById((int)pb.Ram).ToString() + "GB");
                    item.SubItems.Add(mauSacService.GetTenMau(pb.MauSac));
                    item.SubItems.Add(pb.GiaNhap.ToString());
                    item.SubItems.Add(pb.GiaXuat.ToString());
                    listView1.Items.Add(item);
                    stt++;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            listView1.Visible = false;
            listView2.Visible = true;
            listView2.Items.Clear();
            listView2.View = View.Details;
            List<PhienBanSanPham> phienBanSanPhams = PhienBanSanPhamService.GetAll(this.masp);
            int stt = 1;
            foreach (PhienBanSanPham pb in phienBanSanPhams)
            {
                if (pb.TrangThai == true)
                {
                    ListViewItem item = new ListViewItem(stt.ToString());
                    item.SubItems.Add(dungLuongRomService.getKichThuocById(pb.Rom).ToString() + "GB");
                    item.SubItems.Add(dungLuongRamService.getKichThuocById((int)pb.Ram).ToString() + "GB");
                    item.SubItems.Add(mauSacService.GetTenMau(pb.MauSac));
                    item.SubItems.Add(pb.GiaNhap.ToString());
                    item.SubItems.Add(pb.GiaXuat.ToString());
                    listView2.Items.Add(item);
                    stt++;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<PhienBanSanPham> phienBanSanPhams = new List<PhienBanSanPham>();
            PhienBanSanPham phienBanSanPham = new PhienBanSanPham();
            phienBanSanPham.TrangThai = true;
            phienBanSanPham.MaSanPham = this.masp;
            phienBanSanPham.Rom = FindRom(comboBox_Rom.Text.Substring(0, comboBox_Rom.Text.Length - 2)).Madlrom;
            phienBanSanPham.Ram = FindRam(comboBox_Ram.Text.Substring(0, comboBox_Ram.Text.Length - 2)).Madlram;
            phienBanSanPham.MauSac = FindMausac(comboBox_Mausac.Text).Mamau;
            phienBanSanPham.SoLuongTon = 0;
            if (int.TryParse(textBox1.Text, out int gianhap))
            {
                phienBanSanPham.GiaNhap = gianhap;
            }
            else
            {
                MessageBox.Show("Giá nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (int.TryParse(textBox2.Text, out int giaxuat))
            {
                phienBanSanPham.GiaXuat = giaxuat;
            }
            else
            {
                MessageBox.Show("Giá xuất không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            phienBanSanPhams.Add(phienBanSanPham);
            PhienBanSanPhamService.Add(phienBanSanPhams);
            listView1.Items.Clear();
            listView1.View = View.Details;
            int stt = 1;
            foreach (PhienBanSanPham pb in PhienBanSanPhamService.GetAll(this.masp))
            {
                if (pb.TrangThai == true)
                {
                    ListViewItem item = new ListViewItem(stt.ToString());
                    item.SubItems.Add(dungLuongRomService.getKichThuocById(pb.Rom).ToString() + "GB");
                    item.SubItems.Add(dungLuongRamService.getKichThuocById((int)pb.Ram).ToString() + "GB");
                    item.SubItems.Add(mauSacService.GetTenMau(pb.MauSac));
                    item.SubItems.Add(pb.GiaNhap.ToString());
                    item.SubItems.Add(pb.GiaXuat.ToString());
                    listView1.Items.Add(item);
                    stt++;
                }
            }
            MessageBox.Show("Thêm cấu hình thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                comboBox_Rom.Text = listView1.SelectedItems[0].SubItems[1].Text;
                comboBox_Ram.Text=listView1.SelectedItems[0].SubItems[2].Text;
                comboBox_Mausac.Text=listView1.SelectedItems[0].SubItems[3].Text;
                textBox1.Text= listView1.SelectedItems[0].SubItems[4].Text;
                textBox2.Text =listView1.SelectedItems[0].SubItems[5].Text;
            }
            else
            {
                textBox1.Clear();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var selectedItem = listView1.SelectedItems[0];
                int sttpb;

                if (int.TryParse(selectedItem.SubItems[0].Text, out sttpb))
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiên bản này?", "Xác nhận xóa",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        PhienBanSanPhamService.delete(PhienBanSanPhamService.GetAll(this.masp)[sttpb-1]);
                        listView1.Items.Clear();
                        listView1.View = View.Details;
                        List<PhienBanSanPham> phienBanSanPhams = PhienBanSanPhamService.GetAll(this.masp);
                        int stt = 1;
                        foreach (PhienBanSanPham pb in phienBanSanPhams)
                        {
                            if (pb.TrangThai == true)
                            {
                                ListViewItem item = new ListViewItem(stt.ToString());
                                item.SubItems.Add(dungLuongRomService.getKichThuocById(pb.Rom).ToString() + "GB");
                                item.SubItems.Add(dungLuongRamService.getKichThuocById((int)pb.Ram).ToString() + "GB");
                                item.SubItems.Add(mauSacService.GetTenMau(pb.MauSac));
                                item.SubItems.Add(pb.GiaNhap.ToString());
                                item.SubItems.Add(pb.GiaXuat.ToString());
                                listView1.Items.Add(item);
                                stt++;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mã phiên bản không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn dòng nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SanPham sanPham = new SanPham();
            sanPham.Masp = this.masp;
            sanPham.Tensp = textBox_Tensp.Text;
            sanPham.Xuatxu = FindXuatxu(comboBox_Xuatxu.Text).Maxuatxu;
            sanPham.Chipxuly = textBox_chip.Text;
            if (int.TryParse(textBox_Pin.Text, out int pin))
            {
                sanPham.Dungluongpin = pin;
            }
            else
            {
                MessageBox.Show("Dung lượng pin không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (double.TryParse(textBox_Kichthuocman.Text, out double kichthuocman))
            {
                sanPham.Kichthuocman = kichthuocman;
            }
            else
            {
                MessageBox.Show("Kích thước màn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sanPham.Camerasau = textBox_Camerasau.Text;
            sanPham.Cameratruoc = textBox_Cameratruoc.Text;
            sanPham.Hedieuhanh = FindHedieuhanh(comboBox_Hedieuhanh.Text).Mahedieuhanh;
            if (int.TryParse(textBox_Phienbanhdh.Text, out int pb))
            {
                sanPham.Phienbanhdh = pb;
            }
            else
            {
                MessageBox.Show("Phiên bản hệ điều hành không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.TryParse(textBox_Thoigianbh.Text, out int thoigianbh))
            {
                sanPham.Thoigianbaohanh = thoigianbh;
            }
            else
            {
                MessageBox.Show("Thời gian bảo hành không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sanPham.Thuonghieu = FindThuonghieu(comboBox_Thuonghieu.Text).Mathuonghieu;
            sanPham.Khuvuckho = FindKhuvuckho(comboBox_Khuvuckho.Text).Makhuvuc;
            sanPham.Trangthai = true;
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                sanPham.Hinhanh = sanPhamService.GetByMaSP(masp).Hinhanh;
            }
            else
            {
                string projectFolder = Application.StartupPath;
                string imageFolder = Path.Combine(projectFolder, "img_product");
                string fileName = $"{sanPham.Masp}_{Path.GetFileName(selectedImagePath)}";
                string destinationPath = Path.Combine(imageFolder, fileName);

                if (!Directory.Exists(imageFolder))
                {
                    Directory.CreateDirectory(imageFolder);
                }

                File.Copy(selectedImagePath, destinationPath, true);

                sanPham.Hinhanh = Path.Combine(fileName);
            }

            this.Close();
            MessageBox.Show("Sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            sanPhamService.Update(sanPham);
        }
    }
}
