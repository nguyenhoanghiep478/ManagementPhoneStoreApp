using Entity;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using Service.impl;
using ManagementPhoneStore.util;

namespace ManagementPhoneStore
{
    partial class TaiKhoanForm
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
            this.add = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.detail = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 138);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1058, 305);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
           
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã nhân viên";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên đăng nhập";
            this.columnHeader2.Width = 400;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nhóm quyền";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Trạng thái";
            this.columnHeader4.Width = 258;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(201, 34);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 1;
            this.add.Text = "thêm";
            this.add.UseVisualStyleBackColor = true;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(283, 33);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 2;
            this.update.Text = "sửa";
            this.update.UseVisualStyleBackColor = true;
            // 
            // detail
            // 
            this.detail.Location = new System.Drawing.Point(364, 34);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(75, 23);
            this.detail.TabIndex = 3;
            this.detail.Text = "chitiet";
            this.detail.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(445, 34);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 4;
            this.delete.Text = "xóa";
            this.delete.UseVisualStyleBackColor = true;
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(526, 34);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(75, 23);
            this.import.TabIndex = 5;
            this.import.Text = "nhập";
            this.import.UseVisualStyleBackColor = true;
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(607, 34);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 6;
            this.export.Text = "xuất";
            this.export.UseVisualStyleBackColor = true;
            // 
            // TaiKhoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.export);
            this.Controls.Add(this.import);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.detail);
            this.Controls.Add(this.update);
            this.Controls.Add(this.add);
            this.Controls.Add(this.listView1);
            this.Name = "TaiKhoanForm";
            this.Text = "TaiKhoan";
            this.ResumeLayout(false);

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

        public TaiKhoanForm()
        {
            InitializeComponent();
            LoadDataToListView(tkService.GetTaiKhoanAll());
            add_Event();
        }

        private void add_Event()
        {
            add.Click += add_Click;
            update.Click += update_Click;
            detail.Click += detail_Click;
            delete.Click += delete_Click;
            import.Click += import_Click;
            export.Click += export_Click;


        }
       
        private void detail_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() != -1)
            {
                TaiKhoanDialog taiKhoanDialog = new TaiKhoanDialog(this, tkService.getByIndex(GetSelectedIndex()).Manv, "SỬA TÀI KHOẢN",
                  "view", tkService.getByIndex(GetSelectedIndex()));
            }
        }
        private void import_Click(object sender, EventArgs e)
        {
            //ImportExcel();
        }
        public void export_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewExport.ExportListViewToExcel(listView1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
          ListNhanVien listNhanVien = new ListNhanVien();
            listNhanVien.ShowDialog();
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() != -1)
            {
                TaiKhoanDialog taiKhoanDialog=new TaiKhoanDialog(this,tkService.getByIndex(GetSelectedIndex()).Manv,"SỬA TÀI KHOẢN",
                    "update",tkService.getByIndex(GetSelectedIndex()));
            }
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() != -1)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng?", "Xóa khách hàng",
                                      MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    tkService.DeleteAcc(tkService.getByIndex(GetSelectedIndex()).Manv);
                    LoadDataToListView(tkService.GetTaiKhoanAll());
                }
            }
        }
        public void LoadDataToListView(List<TaiKhoan> data)
        {
            // Xóa các mục hiện tại trong ListView
            listView1.Items.Clear();


            // Thêm dữ liệu vào ListView
            foreach (var item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Manv.ToString()); // Tên nhà cung cấp
                listViewItem.SubItems.Add(item.Tendangnhap); // Địa chỉ
                listViewItem.SubItems.Add(item.Manhomquyen.ToString()); // Địa chỉ
                listViewItem.SubItems.Add(item.Trangthai==1?"Hoạt  động":"Ngưng hoạt đông"); // Địa chỉ

                // Thêm mục vào ListView
                listView1.Items.Add(listViewItem);
            }
        }
        public TaiKhoanService tkService = TaiKhoanService.Instance;
        #endregion
   
        public NhomQuyenService nqService=new NhomQuyenService();
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private Button add;
        private Button update;
        private Button detail;
        private Button delete;
        private Button import;
        private Button export;
    }
}