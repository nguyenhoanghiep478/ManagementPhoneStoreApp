using Entity;
using ManagementPhoneStore.util;
using System.Windows.Forms;
using System;
using Service.impl;

namespace ManagementPhoneStore
{
    partial class TaiKhoanDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.TextBox();
            this.matkhau = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nhomquyen = new System.Windows.Forms.ComboBox();
            this.trangthai = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nhóm quyền";
            // 
            // ten
            // 
            this.ten.Location = new System.Drawing.Point(12, 83);
            this.ten.Multiline = true;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(580, 56);
            this.ten.TabIndex = 5;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            // 
            // matkhau
            // 
            this.matkhau.Location = new System.Drawing.Point(12, 216);
            this.matkhau.Multiline = true;
            this.matkhau.Name = "matkhau";
            this.matkhau.Size = new System.Drawing.Size(580, 60);
            this.matkhau.TabIndex = 8;
            this.matkhau.TextChanged += new System.EventHandler(this.sodienthoai_TextChanged);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.ForeColor = System.Drawing.SystemColors.Window;
            this.add.Location = new System.Drawing.Point(120, 537);
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
            this.cancel.Location = new System.Drawing.Point(322, 537);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(156, 50);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "HỦY BỎ";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click_1);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(-6, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(610, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "THÊM KHÁCH HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 409);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Trạng thái";
            // 
            // nhomquyen
            // 
            this.nhomquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomquyen.FormattingEnabled = true;
            this.nhomquyen.Items.AddRange(new object[] {
            "Admin",
            "Nhân viên nhập hàng",
            "Nhân viên xuất hàng"});
            this.nhomquyen.Location = new System.Drawing.Point(12, 347);
            nhomquyen.SelectedIndex = 0;
            this.nhomquyen.Name = "nhomquyen";
            this.nhomquyen.Size = new System.Drawing.Size(580, 28);
            this.nhomquyen.TabIndex = 12;
            this.nhomquyen.SelectedIndexChanged += new System.EventHandler(this.nhomquyen_SelectedIndexChanged);
            // 
            // trangthai
            // 
            this.trangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trangthai.FormattingEnabled = true;
            this.trangthai.Items.AddRange(new object[] {
            "Ngưng Hoạt động",
            "Hoạt động"});
            trangthai.SelectedIndex = 1;
            this.trangthai.Location = new System.Drawing.Point(12, 457);
            this.trangthai.Name = "trangthai";
            this.trangthai.Size = new System.Drawing.Size(580, 28);
            this.trangthai.TabIndex = 13;
            this.trangthai.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TaiKhoanDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 694);
            this.Controls.Add(this.trangthai);
            this.Controls.Add(this.nhomquyen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.matkhau);
            this.Controls.Add(this.ten);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TaiKhoanDialog";
            this.Text = "TaiKhoanDialog";
            this.Load += new System.EventHandler(this.TaiKhoanDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void initInfo()
        {
            ten.Text = tk.Tendangnhap;
            matkhau.Text = tk.Matkhau;
            trangthai.SelectedIndex = tk.Trangthai==1?0:1;
            nhomquyen.SelectedItem = tkForm.tkService.GetNhomQuyen((int)tk.Manhomquyen);
        }

        public void initView()
        {
            ten.ReadOnly = true;
            matkhau.ReadOnly = true;
            trangthai.Enabled = false;
            nhomquyen.Enabled = false;

        }
        public TaiKhoanDialog(TaiKhoanForm tkform, TaiKhoan TK, string title, string type)
        {
            this.tkForm = tkform;
            this.tk = tk;
            this.title = title;
            this.type = type;
            InitializeComponent();
            load_Combobox();
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

                    break;

                case "update":

                    this.Controls.Add(update);
                    initInfo();
                    break;

                case "view":

                    initInfo();
                    initView();
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
            else if (Validation.IsEmpty(matkhau.Text))
            {
                MessageBox.Show("Mật khẩu" +" không được rỗng", "Cảnh báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

       
            return true;
        }
        public void load_Combobox()
        {
            foreach(var nq in tkForm.nqService.GetAll())
            {
                nhomquyen.Items.Add(nq.Tennhomquyen);
            }
            nhomquyen.SelectedIndex = 0;
        }
        private void add_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                TaiKhoan temp = new TaiKhoan();
                temp.Tendangnhap = ten.Text;
                temp.Matkhau = matkhau.Text;
                temp.Trangthai = trangthai.SelectedIndex ;
                temp.Manhomquyen =tkForm.nqService.GetByIndex(nhomquyen.SelectedIndex).Manhomquyen ;
                tkForm.tkService.AddAcc(temp);
                tkForm.LoadDataToListView(tkForm.tkService.GetTaiKhoanAll());
                Dispose();
            }
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (Validate())
            {

                TaiKhoan temp = new TaiKhoan();
                temp.Tendangnhap = ten.Text;
                temp.Matkhau = matkhau.Text;
                temp.Trangthai = trangthai.SelectedIndex;
                temp.Manhomquyen = tkForm.nqService.GetByIndex(nhomquyen.SelectedIndex).Manhomquyen;
                tkForm.tkService.UpdateAcc(nhomquyen.SelectedIndex,temp);
                tkForm.LoadDataToListView(tkForm.tkService.GetTaiKhoanAll());
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
       
        private string title;
        private string type;
        private TaiKhoan tk;
        private TaiKhoanForm tkForm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ten;
        private System.Windows.Forms.TextBox matkhau;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button update;
        private Label label1;

        #endregion

        private Label label4;
        private ComboBox nhomquyen;
        private ComboBox trangthai;
    }
}