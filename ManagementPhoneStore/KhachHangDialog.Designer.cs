using Entity;
using ManagementPhoneStore.util;
using System.Windows.Forms;
using System;

namespace ManagementPhoneStore
{
    partial class KhachHangDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /// private string title;
        private string type;
        private KhachHang kh;
        private string title;
        private KhachHangForm khForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ten;
        private System.Windows.Forms.TextBox sodienthoai;
        private System.Windows.Forms.TextBox diachi;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button update;
        private Label label1;
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.sodienthoai = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên khách hàng";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số điện thoại";
            // 
            // ten
            // 
            this.ten.Location = new System.Drawing.Point(12, 83);
            this.ten.Multiline = true;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(654, 56);
            this.ten.TabIndex = 5;
            // 
            // sodienthoai
            // 
            this.sodienthoai.Location = new System.Drawing.Point(12, 358);
            this.sodienthoai.Multiline = true;
            this.sodienthoai.Name = "sodienthoai";
            this.sodienthoai.Size = new System.Drawing.Size(654, 63);
            this.sodienthoai.TabIndex = 7;
            // 
            // diachi
            // 
            this.diachi.Location = new System.Drawing.Point(12, 215);
            this.diachi.Multiline = true;
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(654, 60);
            this.diachi.TabIndex = 8;
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.ForeColor = System.Drawing.SystemColors.Window;
            this.add.Location = new System.Drawing.Point(146, 451);
            this.add.Margin = new System.Windows.Forms.Padding(0);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(157, 50);
            this.add.TabIndex = 9;
            this.add.Text = "THÊM ĐƠN VỊ";
            this.add.UseVisualStyleBackColor = false;
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.IndianRed;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.SystemColors.Window;
            this.cancel.Location = new System.Drawing.Point(354, 450);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(156, 50);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "HỦY BỎ";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(679, 45);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.ForeColor = System.Drawing.SystemColors.Window;
            this.update.Location = new System.Drawing.Point(146, 451);
            this.update.Margin = new System.Windows.Forms.Padding(0);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(157, 50);
            this.update.TabIndex = 9;
            this.update.Text = "SỬA ĐƠN VỊ";
            this.update.UseVisualStyleBackColor = false;
            // 
            // KhachHangDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(678, 569);
            this.Controls.Add(this.cancel);
      
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.sodienthoai);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KhachHangDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void initInfo()
        {
            ten.Text = kh.TenKhachHang;
            sodienthoai.Text =kh.Sdt;
            diachi.Text = kh.DiaChi;
        }

        public void initView()
        {
            ten.ReadOnly = true;
            sodienthoai.ReadOnly = true;
            diachi.ReadOnly = true;

        }
        public KhachHangDialog(KhachHangForm khform, KhachHang kh, string title, string type)
        {
            this.khForm = khform;
            this.kh = kh;
            this.title = title;
            this.type = type;
            InitializeComponent();
            Inittype();
            add_Event();        }

        private void Inittype()
        {
            this.label1.Text = title;
            switch (type)
            {
                case "create":
                    this.Controls.Add(add);
                   
                    break;

                case "update":
             
                    this.Controls.Add(update);
                    initInfo();
                    break;

                case "view":
                 
                    initInfo();
                    initView();
                    cancel.Location = new System.Drawing.Point(242,461);
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
            if (Validation.IsEmpty(ten.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được rỗng", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Validation.IsEmpty(diachi.Text))
            {
                MessageBox.Show("Địa chỉ không được rỗng", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
           
            else if (Validation.IsEmpty(sodienthoai.Text) || !Validation.IsNumber(sodienthoai.Text) || sodienthoai.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại không được rỗng và phải là 10 ký tự số", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void add_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                KhachHang temp = new KhachHang();
                temp.TenKhachHang = ten.Text;
                temp.DiaChi = diachi.Text;
                temp.Sdt = sodienthoai.Text;
                temp.TrangThai = 1;
                temp.NgayThamGia = DateTime.Now;
                
                khForm.khService.add(temp);
                khForm.LoadDataToListView(khForm.khService.getAll());
                Dispose();
            }
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                KhachHang temp = new KhachHang();
                temp.TenKhachHang = ten.Text;
                temp.DiaChi = sodienthoai.Text;
                temp.Sdt= diachi.Text;
                temp.TrangThai = 1;
                temp.MakH = kh.MakH;
                temp.NgayThamGia = DateTime.Now;
                khForm.khService.update(temp);
                khForm.LoadDataToListView(khForm.khService.getAll());
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