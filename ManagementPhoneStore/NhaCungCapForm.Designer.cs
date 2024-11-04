using Entity;
using Service;
using Service.impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ManagementPhoneStore
{
    partial class NhaCungCapForm
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
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 129);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1058, 339);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã NCC";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên nhà cung cấp";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Địa chỉ";
            this.columnHeader3.Width = 400;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Email";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số điện thoại";
            this.columnHeader5.Width = 158;
            // 
            // NhaCungCapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.listView1);
            this.Name = "NhaCungCapForm";
            this.Text = "NhaCungCap";
            this.Load += new System.EventHandler(this.NhaCungCap_Load);
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

        public NhaCungCapForm()
        {
            InitializeComponent();
            LoadDataToListView(nccService.GetAll());
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {

        }
        public void LoadDataToListView(List<NhaCungCap>data)
        {
            // Xóa các mục hiện tại trong ListView
            listView1.Items.Clear();

   
            // Thêm dữ liệu vào ListView
            foreach (var item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Manhacungcap.ToString()); // Tên nhà cung cấp
                listViewItem.SubItems.Add(item.Tennhacungcap); // Địa chỉ
                listViewItem.SubItems.Add(item.Diachi); // Địa chỉ
                listViewItem.SubItems.Add(item.Email); // Địa chỉ
                listViewItem.SubItems.Add(item.Sdt); // Địa chỉ

                // Thêm mục vào ListView
                listView1.Items.Add(listViewItem);
            }
        }
        public INhaCungCapService nccService=NhaChungCapService.Instance;
        #endregion
        public List<NhaCungCap> l=NhaChungCapService.Instance.GetAll();
       
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}