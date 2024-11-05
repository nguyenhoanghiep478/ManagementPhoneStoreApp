using Entity;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ManagementPhoneStore
{
    partial class NhanVienGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void initdata()
        {
            List<NhanVien> nvlist = new List<NhanVien>();
            foreach (var nv in nvlist)
            {
                ListViewItem listViewItemNhanVien = new ListViewItem(nv.Manv.ToString());
                listViewItemNhanVien.SubItems.Add(nv.Hoten);
                listViewItemNhanVien.SubItems.Add(nv.Giotinh.ToString());
                listViewItemNhanVien.SubItems.Add(nv.Ngaysinh.ToString());
                listViewItemNhanVien.SubItems.Add(nv.Sdt);
                listViewItemNhanVien.SubItems.Add(nv.Email);
                listViewNhanVien.Items.Add(listViewItemNhanVien);
            }
        }
        private void InitializeComponent()
        {
            this.listViewNhanVien = new System.Windows.Forms.ListView();
            this.maNhanVien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hoTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gioTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngaySinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sđt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewNhanVien
            // 
            this.listViewNhanVien.BackColor = System.Drawing.Color.White;
            this.listViewNhanVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.maNhanVien,
            this.hoTen,
            this.gioTinh,
            this.ngaySinh,
            this.sđt,
            this.email});
            this.listViewNhanVien.FullRowSelect = true;
            this.listViewNhanVien.GridLines = true;
            this.listViewNhanVien.HideSelection = false;
            this.listViewNhanVien.Location = new System.Drawing.Point(155, 125);
            this.listViewNhanVien.Name = "listViewNhanVien";
            this.listViewNhanVien.Size = new System.Drawing.Size(904, 426);
            this.listViewNhanVien.TabIndex = 0;
            this.listViewNhanVien.UseCompatibleStateImageBehavior = false;
            this.listViewNhanVien.View = System.Windows.Forms.View.Details;
            // 
            // maNhanVien
            // 
            this.maNhanVien.Text = "Mã Nhân Viên";
            this.maNhanVien.Width = 150;
            // 
            // hoTen
            // 
            this.hoTen.Text = "Ho Tên";
            this.hoTen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hoTen.Width = 150;
            // 
            // gioTinh
            // 
            this.gioTinh.Text = "Giới Tính";
            this.gioTinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gioTinh.Width = 150;
            // 
            // ngaySinh
            // 
            this.ngaySinh.Text = "Ngày Sinh";
            this.ngaySinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ngaySinh.Width = 150;
            // 
            // sđt
            // 
            this.sđt.Text = "Số Điện Thoại";
            this.sđt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sđt.Width = 150;
            // 
            // email
            // 
            this.email.Text = "Email";
            this.email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.email.Width = 150;
            // 
            // NhanVienGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 624);
            this.Controls.Add(this.listViewNhanVien);
            this.Name = "NhanVienGUI";
            this.Text = "NhanVienGUI";
            this.ResumeLayout(false);

        }
        public NhanVienGUI()
        {
            InitializeComponent();
            initdata();
        }



        #endregion

        private System.Windows.Forms.ListView listViewNhanVien;
        private System.Windows.Forms.ColumnHeader maNhanVien;
        private System.Windows.Forms.ColumnHeader hoTen;
        private System.Windows.Forms.ColumnHeader gioTinh;
        private System.Windows.Forms.ColumnHeader ngaySinh;
        private System.Windows.Forms.ColumnHeader sđt;
        private System.Windows.Forms.ColumnHeader email;



    }
}