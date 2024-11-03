using Entity;
using Service.impl;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Linq;

namespace ManagementPhoneStore
{
    partial class ListNhanVien
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
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.TextBox();
            this.select = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 118);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1036, 305);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã nhân viên";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Họ tên";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giới tính";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ngày sinh";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SDT";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Email";
            this.columnHeader6.Width = 234;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 43);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(119, 18);
            this.search.Multiline = true;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(758, 43);
            this.search.TabIndex = 2;
            this.search.TextChanged += new System.EventHandler(this.search_TextChanged);
            // 
            // select
            // 
            this.select.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select.ForeColor = System.Drawing.SystemColors.Window;
            this.select.Location = new System.Drawing.Point(897, 18);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(151, 43);
            this.select.TabIndex = 3;
            this.select.Text = "Chọn nhân viên";
            this.select.UseVisualStyleBackColor = false;
            // 
            // TaiKhoanDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1059, 512);
            this.Controls.Add(this.select);
            this.Controls.Add(this.search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Name = "TaiKhoanDialog";
            this.Text = "NhaCungCap";
            this.Load += new System.EventHandler(this.NhaCungCap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public int GetSelectedIndex()
        {
            int index = listView1.SelectedIndices.Count > 0 ? listView1.SelectedIndices[0] : -1;

            if (index == -1)
            {
                MessageBox.Show("Vui lòng chọn một mục trong danh sách");
            }
            return index;
        }

        public ListNhanVien()
        {
            InitializeComponent();
            LoadDataToListView(getNV());
            add_Even();
        }
        public List<NhanVien> getNV()
        {
            List<int>id_TK=tkService.GetTaiKhoanAll().Select(tk=>tk.Manv).ToList();
            List<NhanVien>l=nvService.GetAll().Where(nv=>!id_TK.Contains(nv.Manv)).ToList();
            return l;
        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {

        }
        private void add_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!:)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.Close();

                var tkd = new TaiKhoanDialog(new TaiKhoanForm(),nvService.GetByIndex(GetSelectedIndex()).Manv, "Thêm tài khoản", "create",null);
                tkd.ShowDialog();
            }
        }
        
        private void text_Change(object sender, EventArgs e)
        {
            String text = search.Text.ToLower();
            
           List<NhanVien>l= search_NV(text);
            LoadDataToListView(l);
        }

        private List<NhanVien>search_NV(string text)
        {
            List<NhanVien> l = nvService.GetAll();
            return l.Where(nv => nv.Hoten.Contains(text) || nv.Sdt.Contains(text) || nv.Email.Contains(text)).ToList();
            
        }

        public void add_Even()
        {
            search.TextChanged += text_Change;
            select.Click += add_Click;
        }
        public void LoadDataToListView(List<NhanVien> data)
        {
            // Xóa các mục hiện tại trong ListView
            listView1.Items.Clear();


            // Thêm dữ liệu vào ListView
            foreach (var item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Manv.ToString()); // Tên nhà cung cấp
                listViewItem.SubItems.Add(item.Hoten); // Địa chỉ
                listViewItem.SubItems.Add(item.Giotinh == 0 ? "nữ" : "nam");
                listViewItem.SubItems.Add(item.Ngaysinh.ToString()); // Địa chỉ
                listViewItem.SubItems.Add(item.Sdt); // Địa chỉ
                listViewItem.SubItems.Add(item.Email); // Địa chỉ

                // Thêm mục vào ListView
                listView1.Items.Add(listViewItem);
            }
        }
        public NhanVienService nvService = new NhanVienService();
        #endregion
        public TaiKhoanService tkService = TaiKhoanService.Instance;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Label label1;
        private TextBox search;
        private Button select;
    }
}