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

namespace ManagementPhoneStore
{
    public partial class ThuocTinhDialog : Form
    {
        private string thuoctinh;
        private HeDieuHanhService heDieuHanhService = new HeDieuHanhService();
        private ThuongHieuService thuongHieuService = ThuongHieuService.Instance;
        private XuatXuService xuatXuService = new XuatXuService();
        private DungLuongRomService dungLuongRomService = new DungLuongRomService();
        private DungLuongRamService dungLuongRamService = new DungLuongRamService();
        private MauSacService mauSacService = new MauSacService();

        public ThuocTinhDialog(string thuoctinh)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.thuoctinh = thuoctinh;
            if (this.thuoctinh.Equals("thuonghieu"))
            {
                initThuonghieu();
            }
            else if (this.thuoctinh.Equals("xuatxu"))
            {
                initXuatxu();
            }
            else if (this.thuoctinh.Equals("hedieuhanh"))
            {
                initHedieuhanh();
            }
            else if (this.thuoctinh.Equals("ram"))
            {
                initRam();
            }
            else if (this.thuoctinh.Equals("rom"))
            {
                initRom();
            }
            else if (this.thuoctinh.Equals("mausac"))
            {
                initMausac();
            }
        }
        private void initThuonghieu()
        {
            label1.Text = "THƯƠNG HIỆU SẢN PHẨM";
            label2.Text = "Tên thương hiệu";

            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Mã thương hiệu";
            columnHeader1.Width = 203;
            columnHeader1.TextAlign = HorizontalAlignment.Center; 

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Tên thương hiệu";
            columnHeader2.Width = 203;
            columnHeader2.TextAlign = HorizontalAlignment.Center; 

            listView1.Columns.Add(columnHeader1);
            listView1.Columns.Add(columnHeader2);

            var thuongHieuList = thuongHieuService.GetAll();
            foreach (var thuongHieu in thuongHieuList)
            {
                if (thuongHieu.Trangthai == 1)
                {
                    ListViewItem item = new ListViewItem(thuongHieu.Mathuonghieu.ToString());
                    item.SubItems.Add(thuongHieu.Tenthuonghieu);
                    listView1.Items.Add(item);
                }
            }
        }
        private void initXuatxu()
        {
            label1.Text = "XUẤT XỨ SẢN PHẨM";
            label2.Text = "Xuất xứ";
            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Mã xuất xứ";
            columnHeader1.Width = 203;
            columnHeader1.TextAlign = HorizontalAlignment.Center;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Tên xuất xứ";
            columnHeader2.Width = 203;
            columnHeader2.TextAlign = HorizontalAlignment.Center;

            listView1.Columns.Add(columnHeader1);
            listView1.Columns.Add(columnHeader2);

            var xuatxuList= xuatXuService.GetAll();
            foreach (var xuatxu in xuatxuList)
            {
                if (xuatxu.Trangthai == true)
                {
                    ListViewItem item = new ListViewItem(xuatxu.Maxuatxu.ToString());
                    item.SubItems.Add(xuatxu.Tenxuatxu);
                    listView1.Items.Add(item);
                }
            }
        }
        private void initHedieuhanh()
        {
            label1.Text = "HỆ ĐIỀU HÀNH";
            label2.Text = "Tên hệ điều hành";
            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Mã hệ điều hành";
            columnHeader1.Width = 203;
            columnHeader1.TextAlign = HorizontalAlignment.Center;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Tên hệ điều hành";
            columnHeader2.Width = 203;
            columnHeader2.TextAlign = HorizontalAlignment.Center;

            listView1.Columns.Add(columnHeader1);
            listView1.Columns.Add(columnHeader2);

            var heDieuHanhList = heDieuHanhService.getAll();
            foreach (var heDieuHanh in heDieuHanhList)
            {
                if (heDieuHanh.Trangthai == 1)
                {
                    ListViewItem item = new ListViewItem(heDieuHanh.Mahedieuhanh.ToString());
                    item.SubItems.Add(heDieuHanh.Tenhedieuhanh);
                    listView1.Items.Add(item);
                }
            }
        }

        private void initRam()
        {
            label1.Text = "DUNG LƯỢNG RAM";
            label2.Text = "Dung lượng RAM";
            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Mã RAM";
            columnHeader1.Width = 203;
            columnHeader1.TextAlign = HorizontalAlignment.Center;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Dung lượng RAM";
            columnHeader2.Width = 203;
            columnHeader2.TextAlign = HorizontalAlignment.Center;

            listView1.Columns.Add(columnHeader1);
            listView1.Columns.Add(columnHeader2);

            var ramList = dungLuongRamService.getAll();
            foreach (var ram in ramList)
            {
                if (ram.Trangthai == true)
                {
                    ListViewItem item = new ListViewItem(ram.Madlram.ToString());
                    item.SubItems.Add(ram.Kichthuocram.ToString() + "GB");
                    listView1.Items.Add(item);
                }
            }
        }

        private void initRom()
        {
            label1.Text = "DUNG LƯỢNG ROM";
            label2.Text = "Dung lượng ROM";
            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Mã ROM";
            columnHeader1.Width = 203;
            columnHeader1.TextAlign = HorizontalAlignment.Center;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Dung lượng ROM";
            columnHeader2.Width = 203;
            columnHeader2.TextAlign = HorizontalAlignment.Center;

            listView1.Columns.Add(columnHeader1);
            listView1.Columns.Add(columnHeader2);

            var romList = dungLuongRomService.getAll();
            foreach (var rom in romList)
            {
                if (rom.Trangthai == true)
                {
                    ListViewItem item = new ListViewItem(rom.Madlrom.ToString());
                    item.SubItems.Add(rom.Kichthuocrom.ToString() + "GB");
                    listView1.Items.Add(item);
                }
            }
        }

        private void initMausac()
        {
            label1.Text = "MÀU SẮC SẢN PHẨM";
            label2.Text = "Tên màu sắc";
            listView1.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = "Mã màu sắc";
            columnHeader1.Width = 203;
            columnHeader1.TextAlign = HorizontalAlignment.Center;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Tên màu sắc";
            columnHeader2.Width = 203;
            columnHeader2.TextAlign = HorizontalAlignment.Center;

            listView1.Columns.Add(columnHeader1);
            listView1.Columns.Add(columnHeader2);

            var mauSacList = mauSacService.GetAll();
            foreach (var mauSac in mauSacList)
            {
                if (mauSac.Trangthai == true)
                {
                    ListViewItem item = new ListViewItem(mauSac.Mamau.ToString());
                    item.SubItems.Add(mauSac.Tenmau);
                    listView1.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (this.thuoctinh)
            {
                case "thuonghieu":
                    ThuongHieu thuongHieu = new ThuongHieu();
                    thuongHieu.Tenthuonghieu = textBox1.Text;
                    thuongHieu.Trangthai = 1;
                    if (!thuongHieuService.CheckDup(thuongHieu.Tenthuonghieu))
                    {
                        thuongHieuService.Add(thuongHieu);
                        initThuonghieu();
                    }
                    else
                    {
                        MessageBox.Show("Tên thương hiệu đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "xuatxu":
                    XuatXu xuatXu = new XuatXu();
                    xuatXu.Tenxuatxu = textBox1.Text;
                    xuatXu.Trangthai = true;
                    if (!xuatXuService.CheckDup(xuatXu.Tenxuatxu))
                    {
                        xuatXuService.Add(xuatXu);
                        initXuatxu();
                    }
                    else
                    {
                        MessageBox.Show("Xuất xứ đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "hedieuhanh":
                    HeDieuHanh heDieuHanh = new HeDieuHanh();
                    heDieuHanh.Tenhedieuhanh = textBox1.Text;
                    heDieuHanh.Trangthai = 1;
                    if (!heDieuHanhService.isDuplicate(heDieuHanh.Tenhedieuhanh))
                    {
                        heDieuHanhService.add(heDieuHanh);
                        initHedieuhanh();
                    }
                    else
                    {
                        MessageBox.Show("Hệ điều hành đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "rom":
                    DLRom rom = new DLRom();
                    int kichThuocRom;
                    if (int.TryParse(textBox1.Text, out kichThuocRom))
                    {
                        rom.Kichthuocrom = kichThuocRom;
                    }
                    else
                    {
                        MessageBox.Show("Giá trị nhập không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    rom.Trangthai = true;
                    if (!dungLuongRomService.isDuplicate(kichThuocRom))
                    {
                        dungLuongRomService.add(rom);
                        initRom();
                    }
                    else
                    {
                        MessageBox.Show("Dung lượng ROM đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "ram":
                    DLRam ram = new DLRam();
                    int kichThuocRam;
                    if (int.TryParse(textBox1.Text, out kichThuocRam))
                    {
                        ram.Kichthuocram = kichThuocRam;
                    }
                    else
                    {
                        MessageBox.Show("Giá trị nhập không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    ram.Trangthai = true;
                    if (!dungLuongRamService.isDuplicate(kichThuocRam))
                    {
                        dungLuongRamService.add(ram);
                        initRam();
                    }
                    else
                    {
                        MessageBox.Show("Dung lượng RAM đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "mausac":
                    MauSac mauSac = new MauSac();
                    mauSac.Tenmau = textBox1.Text;
                    mauSac.Trangthai = true;
                    if (!mauSacService.CheckDup(mauSac.Tenmau))
                    {
                        mauSacService.Add(mauSac);
                        initMausac();
                    }
                    else
                    {
                        MessageBox.Show("Màu sắc đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (this.thuoctinh)
            {
                case "thuonghieu":
                    if (listView1.SelectedItems.Count > 0)
                    {
                        var selectedItem = listView1.SelectedItems[0];
                        int math;

                        if (int.TryParse(selectedItem.SubItems[0].Text, out math))
                        {
                            thuongHieuService.Delete(thuongHieuService.GetByIndex(thuongHieuService.GetIndexByMaLH(math)));
                            initThuonghieu();
                            MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Mã thương hiệu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa chọn dòng nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                case "xuatxu":
                    if (listView1.SelectedItems.Count > 0)
                    {
                        var selectedItem = listView1.SelectedItems[0];
                        int maxx;

                        if (int.TryParse(selectedItem.SubItems[0].Text, out maxx))
                        {
                            XuatXu xuatXu = xuatXuService.GetByIndex(xuatXuService.GetIndexByMaXX(maxx));
                            bool isDeleted = xuatXuService.Delete(xuatXu, xuatXuService.GetIndexByMaXX(maxx));
                            initXuatxu();
                            if (isDeleted)
                            {
                                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã xuất xứ không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn chưa chọn dòng nào trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                case "hedieuhanh":
                    if (listView1.SelectedItems.Count > 0)
                    {
                        var selectedItem = listView1.SelectedItems[0];
                        int mahdh;
                        if (int.TryParse(selectedItem.SubItems[0].Text, out mahdh))
                        {
                            HeDieuHanh heDieuHanh = heDieuHanhService.getByIndex(heDieuHanhService.getIndexByMaHdh(mahdh));
                            bool isDeleted =heDieuHanhService.remove(heDieuHanh,heDieuHanhService.getIndexByMaHdh(mahdh));
                            initHedieuhanh();
                            if (isDeleted)
                            {
                                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã hệ điều hành không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;

                case "ram":
                    if (listView1.SelectedItems.Count > 0)
                    {
                        var selectedItem = listView1.SelectedItems[0];
                        int madl;
                        if (int.TryParse(selectedItem.SubItems[0].Text, out madl))
                        {
                            DLRam dLRam=dungLuongRamService.getByIndex(dungLuongRamService.getIndexByMaRam(madl));
                            bool isDeleted = dungLuongRamService.remove(dLRam, dungLuongRamService.getIndexByMaRam(madl));
                            initRam();
                            if (isDeleted)
                            {
                                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã ram không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;

                case "rom":
                    if (listView1.SelectedItems.Count > 0)
                    {
                        var selectedItem = listView1.SelectedItems[0];
                        int madl;
                        if (int.TryParse(selectedItem.SubItems[0].Text, out madl))
                        {
                            DLRom dLRom = dungLuongRomService.getByIndex(dungLuongRomService.getIndexByMaRom(madl));
                            bool isDeleted = dungLuongRomService.remove(dLRom, dungLuongRomService.getIndexByMaRom(madl));
                            initRom();
                            if (isDeleted)
                            {
                                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã rom không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;

                case "mausac":
                    if (listView1.SelectedItems.Count > 0)
                    {
                        var selectedItem = listView1.SelectedItems[0];
                        int mams;
                        if (int.TryParse(selectedItem.SubItems[0].Text, out mams))
                        {
                            MauSac mauSac=mauSacService.GetByIndex(mauSacService.GetIndexByMaMau(mams));
                            bool isDeleted=mauSacService.Delete(mauSac, mauSacService.GetIndexByMaMau(mams));
                            initMausac();
                            if (isDeleted)
                            {
                                MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã màu không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }
    }
}
