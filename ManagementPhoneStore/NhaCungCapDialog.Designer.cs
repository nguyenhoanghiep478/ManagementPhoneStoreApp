using Entity;
using ManagementPhoneStore.util;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ManagementPhoneStore
{
    partial class NhaCungCapDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.diachi = new System.Windows.Forms.TextBox();
            this.sodienthoai = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1083, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm nhà cung cấp";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên  nhà cung cấp";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(542, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Địa chỉ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(542, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số điện thoại";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // ten
            // 
            this.ten.Location = new System.Drawing.Point(18, 94);
            this.ten.Multiline = true;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(490, 52);
            this.ten.TabIndex = 5;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(17, 201);
            this.email.Multiline = true;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(490, 56);
            this.email.TabIndex = 6;
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            // 
            // diachi
            // 
            this.diachi.Location = new System.Drawing.Point(545, 94);
            this.diachi.Multiline = true;
            this.diachi.Name = "diachi";
            this.diachi.Size = new System.Drawing.Size(526, 52);
            this.diachi.TabIndex = 7;
            this.diachi.TextChanged += new System.EventHandler(this.diachi_TextChanged);
            // 
            // sodienthoai
            // 
            this.sodienthoai.Location = new System.Drawing.Point(545, 201);
            this.sodienthoai.Multiline = true;
            this.sodienthoai.Name = "sodienthoai";
            this.sodienthoai.Size = new System.Drawing.Size(526, 56);
            this.sodienthoai.TabIndex = 8;
            this.sodienthoai.TextChanged += new System.EventHandler(this.sodienthoai_TextChanged);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.ForeColor = System.Drawing.SystemColors.Window;
            this.add.Location = new System.Drawing.Point(359, 269);
            this.add.Margin = new System.Windows.Forms.Padding(0);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(149, 54);
            this.add.TabIndex = 9;
            this.add.Text = "THÊM ĐƠN VỊ";
            this.add.UseVisualStyleBackColor = false;
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.ForeColor = System.Drawing.SystemColors.Window;
            this.cancel.Location = new System.Drawing.Point(545, 269);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(158, 54);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "HỦY BỎ";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click_1);
            // 
            // NhaCungCapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1083, 335);
            this.Controls.Add(this.cancel);
          
            this.Controls.Add(this.sodienthoai);
            this.Controls.Add(this.diachi);
            this.Controls.Add(this.email);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NhaCungCapDialog";
            this.Load += new System.EventHandler(this.NhaCungCapDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void initInfo()
        {
            ten.Text=ncc.Tennhacungcap;
            diachi.Text=ncc.Diachi;
            email.Text=ncc.Email;
            sodienthoai.Text = ncc.Sdt;
        }

        public void initView()
        {
            ten.ReadOnly = true;
            diachi.ReadOnly = true;
            email.ReadOnly = true;
            sodienthoai.ReadOnly = true;

        }
        public NhaCungCapDialog(NhaCungCapForm nccform,NhaCungCap ncc, string title, string type)
        {
            this.nccForm = nccform;
            this.ncc = ncc; 
                this.title = title;
            this.type = type;
           InitializeComponent();
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
            else if (Validation.IsEmpty(email.Text) || !Validation.IsEmail(email.Text))
            {
                MessageBox.Show("Email không được rỗng và phải đúng cú pháp", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                NhaCungCap temp=new NhaCungCap();
                temp.Tennhacungcap=ten.Text;
                temp.Diachi=diachi.Text;
                temp.Email=email.Text;
                temp.Sdt=sodienthoai.Text;
                temp.Manhacungcap = 11;
                nccForm.nccService.Add(temp);
                nccForm.LoadDataToListView(nccForm.l);
                Dispose();
            }
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                NhaCungCap temp = new NhaCungCap();
                temp.Tennhacungcap = ten.Text;
                temp.Diachi = diachi.Text;
                temp.Email = email.Text;
                temp.Sdt = sodienthoai.Text;
                temp.Manhacungcap = 11;
                nccForm.nccService.Update(temp);
                nccForm.LoadDataToListView(nccForm.l);
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
        #endregion
        private string title;
        private string type;
        private NhaCungCap ncc;
        private NhaCungCapForm nccForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ten;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox diachi;
        private System.Windows.Forms.TextBox sodienthoai;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button update;



    }
}