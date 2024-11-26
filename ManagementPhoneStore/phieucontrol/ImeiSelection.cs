using Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GUI
{
    public partial class ImeiSelection : Form
    {
        private ThemPhieuXuat parentControl;
        public List<ChiTietSanPham> ct;

        private List<string> selectedImeiList;

        public ImeiSelection(List<ChiTietSanPham> ct, ThemPhieuXuat parentControl)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            this.ct = ct;
            this.parentControl = parentControl;
            selectedImeiList = new List<string>();
            InitializeComponent();
            LoadImei();


            findImei.TextChanged += (sender, e) =>
            {
                LoadImei();
            };


            list.SelectedIndexChanged += (s, e) =>
            {
                // Loop through selected items in the list
                foreach (int index in list.SelectedIndices)
                {
                    var item = (CheckListItem)list.Items[index];

                    item.IsSelected = !item.IsSelected;

                    if (item.IsSelected)
                    {

                        if (!selectedImeiList.Contains(item.Label))
                        {
                            selectedImeiList.Add(item.Label);
                        }
                    }
                    else
                    {

                        selectedImeiList.Remove(item.Label);
                    }
                }
            };
        }

        public void LoadImei()
        {
            string search = findImei.Text.ToLower();
            var result = new List<ChiTietSanPham>();

            foreach (var item in ct)
            {
                if (item.MaImei.ToLower().Contains(search))
                {
                    result.Add(item);
                }
            }

            list.Items.Clear();
            foreach (var chiTietSanPham in result)
            {
                var check = new CheckListItem(chiTietSanPham.MaImei);


                if (CheckImeiArea(chiTietSanPham.MaImei))
                {
                    check.IsSelected = true;
                    if (!selectedImeiList.Contains(chiTietSanPham.MaImei)) //
                    {
                        selectedImeiList.Add(chiTietSanPham.MaImei);
                    }
                }

                list.Items.Add(check);
            }

            list.DrawMode = DrawMode.OwnerDrawFixed;

        }


        private void button1_Click(object sender, EventArgs e)
        {

            foreach (var imei in selectedImeiList)
            {
                parentControl.TextAreaImei.AppendText(imei + Environment.NewLine);
            }

            this.Close();
        }
        public bool CheckImeiArea(string maImei)
        {
            var arrImei = parentControl.TextAreaImei.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var imei in arrImei)
            {
                if (imei.Equals(maImei))
                {
                    return true;
                }
            }
            return false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            foreach (var imei in selectedImeiList)
            {
                parentControl.TextAreaImei.AppendText(imei + Environment.NewLine);
            }

            this.Close();
       
    }
    }
}
