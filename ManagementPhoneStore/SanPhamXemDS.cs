using Entity;
using Service;
using Service.impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementPhoneStore
{
    public partial class SanPhamXemDS : Form
    {
        private int masp;
        private DungLuongRomService dungLuongRomService = new DungLuongRomService();
        private DungLuongRamService dungLuongRamService = new DungLuongRamService();
        private MauSacService mauSacService = new MauSacService();
        private PhienBanSanPhamService phienBanSanPhamService=new PhienBanSanPhamService();
        private ChiTietSanPhamService chiTietSanPhamService=ChiTietSanPhamService.Instance;
        public SanPhamXemDS(int masp)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.masp = masp;
            LoadDuLieuComboBox();
            initSanpham();
        }
        private void initSanpham()
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            var comboboxSplit = comboBox1.Text.Split('-');
            List<PhienBanSanPham> phienBanSanPhams = new List<PhienBanSanPham>();
            foreach (PhienBanSanPham pb in phienBanSanPhamService.GetAll(this.masp))
            {
                if (pb.Rom == FindRom(comboboxSplit[0].Substring(0, comboboxSplit[0].Length - 2)).Madlrom
                    && pb.Ram == FindRam(comboboxSplit[1].Substring(0, comboboxSplit[1].Length - 2)).Madlram
                    && pb.MauSac==FindMausac(comboboxSplit[2]).Mamau)
                {
                    phienBanSanPhams.Add(pb);
                }
            }
            List<ChiTietSanPham> chiTietSanPhams = new List<ChiTietSanPham>();
            foreach (PhienBanSanPham pb in phienBanSanPhams)
            {
                chiTietSanPhams.AddRange(chiTietSanPhamService.getAllByMaPBSP(pb.MaPhienBanSanPham));
            }
            foreach (ChiTietSanPham chiTietSanPham in chiTietSanPhams)
            {
                ListViewItem item = new ListViewItem(chiTietSanPham.MaImei);
                item.SubItems.Add(chiTietSanPham.MaPhieuNhap.ToString());
                if (chiTietSanPham.MaPhieuXuat.ToString().Equals(""))
                {
                    item.SubItems.Add("Chưa xuất kho");
                }
                else
                {
                    item.SubItems.Add(chiTietSanPham.MaPhieuXuat.ToString());
                }
                if (chiTietSanPham.TinhTrang.ToString().Equals("True")){
                    item.SubItems.Add("Tồn kho");
                }
                else
                {
                    item.SubItems.Add("Đã bán");
                }
                listView1.Items.Add(item);
            }
            textBox1.Text=chiTietSanPhams.Count.ToString(); 
        }
        private void LoadDuLieuComboBox()
        {
            List<PhienBanSanPham> phienBanSanPhams= phienBanSanPhamService.GetAll(this.masp);
            foreach (PhienBanSanPham phienBanSanPham in phienBanSanPhams) 
            {
                string rom = dungLuongRomService.getKichThuocById(phienBanSanPham.Rom).ToString() + "GB";
                string ram = dungLuongRamService.getKichThuocById((int)phienBanSanPham.Ram).ToString() + "GB";
                string mausac = mauSacService.GetTenMau(phienBanSanPham.MauSac);
                comboBox1.Items.Add(rom + "-" + ram + "-" + mausac);
            }
            if (comboBox1.Items.Count == 0)
            {
                MessageBox.Show("Sản phẩm chưa có danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            comboBox1.SelectedIndex = 0;
            comboBox1.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox1.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
            comboBox2.Items.Add("Tất cả");
            comboBox2.Items.Add("Đã bán");
            comboBox2.Items.Add("Tồn kho");
            comboBox2.SelectedIndex = 0;
            comboBox2.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            comboBox2.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
        }
        private void ComboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;  // Điều chỉnh chiều cao mục của ComboBox
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Lấy ComboBox đang được vẽ
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && e.Index >= 0)
            {
                string itemText = comboBox.Items[e.Index].ToString();

                StringFormat stringFormat = new StringFormat()
                {
                    LineAlignment = StringAlignment.Center
                };

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
                    e.Graphics.DrawString(itemText, e.Font, Brushes.White, e.Bounds, stringFormat);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                    e.Graphics.DrawString(itemText, e.Font, Brushes.Black, e.Bounds, stringFormat);
                }
            }
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
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            initSanpham();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                initSanpham();
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                initSanpham();
                List<ListViewItem> filteredItems = new List<ListViewItem>();

                foreach (ListViewItem item in listView1.Items)
                {
                    string columnValue = item.SubItems[3].Text;

                    if (columnValue.Equals("Đã bán"))
                    {
                        filteredItems.Add(item);
                    }
                }

                listView1.Items.Clear();

                listView1.Items.AddRange(filteredItems.ToArray());
                textBox1.Text = filteredItems.Count.ToString();
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                initSanpham();
                List<ListViewItem> filteredItems = new List<ListViewItem>();

                foreach (ListViewItem item in listView1.Items)
                {
                    string columnValue = item.SubItems[3].Text;

                    if (columnValue.Equals("Tồn kho"))
                    {
                        filteredItems.Add(item);
                    }
                }

                listView1.Items.Clear();

                listView1.Items.AddRange(filteredItems.ToArray());
                textBox1.Text = filteredItems.Count.ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
