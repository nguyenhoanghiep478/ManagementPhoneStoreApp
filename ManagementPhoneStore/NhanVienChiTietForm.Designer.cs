using Entity;
using ManagementPhoneStore.util;
using NPOI.SS.Formula.Functions;
using System.Windows.Forms;
using System;
using Service.impl;
using System.Collections.Generic;

namespace ManagementPhoneStore
{
    partial class NhanVienChiTietForm
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
            this.components = new System.ComponentModel.Container();
            this.hoVaTenLabel = new System.Windows.Forms.Label();
            this.hoVaTenText = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.emailLabel = new System.Windows.Forms.Label();
            this.emailText = new System.Windows.Forms.TextBox();
            this.sđtText = new System.Windows.Forms.TextBox();
            this.soDienThoaiLabel = new System.Windows.Forms.Label();
            this.gioiTinhLabel = new System.Windows.Forms.Label();
            this.namRadio = new System.Windows.Forms.RadioButton();
            this.nuRadio = new System.Windows.Forms.RadioButton();
            this.ngayLabel = new System.Windows.Forms.Label();
            this.nhanVienDate = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hoVaTenLabel
            // 
            this.hoVaTenLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.hoVaTenLabel.Location = new System.Drawing.Point(12, 98);
            this.hoVaTenLabel.Name = "hoVaTenLabel";
            this.hoVaTenLabel.Size = new System.Drawing.Size(100, 23);
            this.hoVaTenLabel.TabIndex = 0;
            this.hoVaTenLabel.Text = "Họ Và Tên";
            // 
            // hoVaTenText
            // 
            this.hoVaTenText.Location = new System.Drawing.Point(15, 135);
            this.hoVaTenText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hoVaTenText.Multiline = true;
            this.hoVaTenText.Name = "hoVaTenText";
            this.hoVaTenText.Size = new System.Drawing.Size(524, 41);
            this.hoVaTenText.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // emailLabel
            // 
            this.emailLabel.Location = new System.Drawing.Point(12, 202);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(44, 16);
            this.emailLabel.TabIndex = 4;
            this.emailLabel.Text = "Email";
            // 
            // emailText
            // 
            this.emailText.Location = new System.Drawing.Point(15, 239);
            this.emailText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.emailText.Multiline = true;
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(524, 41);
            this.emailText.TabIndex = 5;
            // 
            // sđtText
            // 
            this.sđtText.Location = new System.Drawing.Point(12, 353);
            this.sđtText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sđtText.Multiline = true;
            this.sđtText.Name = "sđtText";
            this.sđtText.Size = new System.Drawing.Size(524, 41);
            this.sđtText.TabIndex = 6;
            // 
            // soDienThoaiLabel
            // 
            this.soDienThoaiLabel.Location = new System.Drawing.Point(12, 299);
            this.soDienThoaiLabel.Name = "soDienThoaiLabel";
            this.soDienThoaiLabel.Size = new System.Drawing.Size(116, 34);
            this.soDienThoaiLabel.TabIndex = 7;
            this.soDienThoaiLabel.Text = "Số Điện Thoại";
            // 
            // gioiTinhLabel
            // 
            this.gioiTinhLabel.Location = new System.Drawing.Point(12, 423);
            this.gioiTinhLabel.Name = "gioiTinhLabel";
            this.gioiTinhLabel.Size = new System.Drawing.Size(64, 18);
            this.gioiTinhLabel.TabIndex = 8;
            this.gioiTinhLabel.Text = "Giới Tính";
            // 
            // namRadio
            // 
            this.namRadio.AutoSize = true;
            this.namRadio.Location = new System.Drawing.Point(15, 468);
            this.namRadio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.namRadio.Name = "namRadio";
            this.namRadio.Size = new System.Drawing.Size(57, 20);
            this.namRadio.TabIndex = 9;
            this.namRadio.TabStop = true;
            this.namRadio.Text = "Nam";
            this.namRadio.UseVisualStyleBackColor = true;
            // 
            // nuRadio
            // 
            this.nuRadio.AutoSize = true;
            this.nuRadio.Location = new System.Drawing.Point(205, 468);
            this.nuRadio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nuRadio.Name = "nuRadio";
            this.nuRadio.Size = new System.Drawing.Size(45, 20);
            this.nuRadio.TabIndex = 10;
            this.nuRadio.TabStop = true;
            this.nuRadio.Text = "Nữ";
            this.nuRadio.UseVisualStyleBackColor = true;
            // 
            // ngayLabel
            // 
            this.ngayLabel.Location = new System.Drawing.Point(12, 514);
            this.ngayLabel.Name = "ngayLabel";
            this.ngayLabel.Size = new System.Drawing.Size(116, 27);
            this.ngayLabel.TabIndex = 11;
            this.ngayLabel.Text = "Ngày Sinh";
            // 
            // nhanVienDate
            // 
            this.nhanVienDate.AllowDrop = true;
            this.nhanVienDate.Location = new System.Drawing.Point(15, 561);
            this.nhanVienDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nhanVienDate.Name = "nhanVienDate";
            this.nhanVienDate.RightToLeftLayout = true;
            this.nhanVienDate.Size = new System.Drawing.Size(295, 22);
            this.nhanVienDate.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 76);
            this.panel1.TabIndex = 14;
            this.panel1.Tag = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(187, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Xem Nhân Viên";
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.Tomato;
            this.cancel.Location = new System.Drawing.Point(316, 604);
            this.cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(163, 43);
            this.cancel.TabIndex = 15;
            this.cancel.Text = "Hủy Bỏ";
            this.cancel.UseVisualStyleBackColor = false;
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.Color.Tomato;
            this.add.Location = new System.Drawing.Point(87, 604);
            this.add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(163, 43);
            this.add.TabIndex = 16;
            this.add.Text = "Thêm";
            this.add.UseVisualStyleBackColor = false;
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.Color.Tomato;
            this.update.Location = new System.Drawing.Point(87, 604);
            this.update.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(163, 43);
            this.update.TabIndex = 17;
            this.update.Text = "Sửa";
            this.update.UseVisualStyleBackColor = false;
            this.update.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // NhanVienChiTietGUI
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 658);
            this.Controls.Add(this.update);
            this.Controls.Add(this.add);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.nhanVienDate);
            this.Controls.Add(this.ngayLabel);
            this.Controls.Add(this.nuRadio);
            this.Controls.Add(this.namRadio);
            this.Controls.Add(this.gioiTinhLabel);
            this.Controls.Add(this.soDienThoaiLabel);
            this.Controls.Add(this.sđtText);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.hoVaTenText);
            this.Controls.Add(this.hoVaTenLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "NhanVienChiTietGUI";
            this.Text = "NhanVienChiTietGUIcs";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hoVaTenLabel;
        private System.Windows.Forms.TextBox hoVaTenText;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox emailText;
        private System.Windows.Forms.TextBox sđtText;
        private System.Windows.Forms.Label soDienThoaiLabel;
        private System.Windows.Forms.Label gioiTinhLabel;
        private System.Windows.Forms.RadioButton namRadio;
        private System.Windows.Forms.RadioButton nuRadio;
        private System.Windows.Forms.Label ngayLabel;
        private System.Windows.Forms.DateTimePicker nhanVienDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button update;
        private NhanVien nv;
        private NhanVienForm nvGui;
        private String type;
        private String title;
        
       
        private void Cancel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void initInfo()
        {
            
            hoVaTenText.Text = nv.Hoten;
            emailText.Text=nv.Email;
            sđtText.Text=nv.Sdt;
            if (nv.Giotinh == 1)
            {
                namRadio.Checked = true;
                nuRadio.Checked = false;
            }
            else if (nv.Giotinh == 0)
            {
                nuRadio.Checked = true;
                namRadio.Checked = false;
            }
            nhanVienDate.Value = nv.Ngaysinh;
        }

        public void initView()
        {
            hoVaTenText.ReadOnly = true;
            sđtText.ReadOnly = true;
            emailText.ReadOnly = true;
            // Vô hiệu hóa các RadioButton để làm cho chúng "chỉ đọc"
            namRadio.Enabled = false;
            nuRadio.Enabled = false;
            nhanVienDate.Enabled = false;
           

        }
        public NhanVienChiTietForm(NhanVienForm nvGui, NhanVien nv, string title, string type)
        {
            this.nvGui = nvGui;
            this.nv = nv;
            this.title = title;
            this.type = type;
            InitializeComponent();
            Inittype();
            add_Event();
        }

        private void Inittype()
        {
            this.label1.Text = title;
            switch (type)
            {
                case "create":
                    this.Controls.Add(add);
                    this.update.Visible=false;
                    break;

                case "update":

                    this.Controls.Add(update);
                    this.add.Visible=false;
                    initInfo();
                    break;
                case "view":
                    this.update.Visible = false;
                    this.add.Visible = false;
                    initInfo();
                    initView();
                    cancel.Location = new System.Drawing.Point(242, 461);
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }
        public void add_Event()
        {
            update.Click += update_Click;
            add.Click += add_Click;
            cancel.Click += cancel_Click;
        }

        public bool Validate()
        {
            // Kiểm tra Họ
            if (Validation.IsEmpty(hoVaTenText.Text))
            {
                MessageBox.Show("Họ và tên nhân viên không được rỗng", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

          

            // Kiểm tra Email
            else if (Validation.IsEmpty(emailText.Text) || !Validation.IsEmail(emailText.Text))
            {
                MessageBox.Show("Email không hợp lệ hoặc bị trống", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra Số điện thoại
            else if (Validation.IsEmpty(sđtText.Text) || !Validation.IsNumber(sđtText.Text) || sđtText.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không được rỗng và phải là 10 ký tự số", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra Giới tính
            else if (!namRadio.Checked && !nuRadio.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra Ngày sinh
            else if (nhanVienDate.Value == null || nhanVienDate.Value >= DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                NhanVien temp = new NhanVien();
                List<NhanVien> nhanVienList = nvGui.nvService.GetAll();
                temp.Hoten = hoVaTenText.Text;
                temp.Email = emailText.Text;
                temp.Sdt = sđtText.Text;
                temp.Trangthai = 1;
                if (namRadio.Checked)
                {
                    temp.Giotinh = 1;
                }
                else if (nuRadio.Checked)
                {
                    temp.Giotinh = 0;
                }

                DateTime ngaySinh = nhanVienDate.Value;
                temp.Ngaysinh = ngaySinh;

                nvGui.nvService.InsertNv(temp);
                nvGui.LoadDataToListView(nvGui.nvService.GetAll());
                Dispose();
            }
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                NhanVien temp = new NhanVien();
                temp.Hoten = hoVaTenText.Text;
                temp.Email = emailText.Text;
                temp.Sdt = sđtText.Text;
                temp.Trangthai = 1;
                temp.Manv = nv.Manv;
                if (namRadio.Checked)
                {
                    temp.Giotinh = 1;
                }
                else if (nuRadio.Checked)
                {
                    temp.Giotinh = 0;
                }

                DateTime ngaySinh = nhanVienDate.Value;
                temp.Ngaysinh = ngaySinh;
                int index=nvGui.nvService.GetIndexById((int)nv.Manv);
                nvGui.nvService.UpdateNv(index,temp);
                nvGui.LoadDataToListView(nvGui.nvService.GetAll());
                Dispose();
            }
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ten_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}