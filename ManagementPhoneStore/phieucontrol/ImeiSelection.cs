using Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private void CheckedListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Ensure we're only drawing valid items
            if (e.Index < 0)
                return;

            // Cast the current item
            CheckListItem item = (CheckListItem)list.Items[e.Index];

            // Set up the background color (selected vs non-selected)
            e.DrawBackground();
            bool isChecked = list.GetItemChecked(e.Index);

            // Set colors based on selection state
            Color backColor = isChecked ? Color.LightGray : e.BackColor;
            Color foreColor = e.ForeColor;

            // If item is selected, adjust the background and foreground colors
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backColor = Color.DodgerBlue;
                foreColor = Color.White;
            }

            // Fill the background
            e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);

            // Draw the checkbox (manually)
            e.Graphics.FillRectangle(isChecked ? Brushes.Gray : Brushes.White, e.Bounds.Left + 5, e.Bounds.Top + 5, 15, 15);
            e.Graphics.DrawRectangle(Pens.Black, e.Bounds.Left + 5, e.Bounds.Top + 5, 15, 15);

            // Draw the item text next to the checkbox
            e.Graphics.DrawString(item.ToString(), e.Font, new SolidBrush(foreColor), e.Bounds.Left + 25, e.Bounds.Top);

            // Draw the focus rectangle (if needed)
            e.DrawFocusRectangle();
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
