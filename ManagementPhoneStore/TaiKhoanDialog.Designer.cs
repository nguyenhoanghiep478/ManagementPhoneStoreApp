using Entity;
using ManagementPhoneStore.util;
using System.Windows.Forms;
using System;
using Service.impl;
using System.Linq;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Service;
using System.Drawing;

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
            this.update = new System.Windows.Forms.Button();
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
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 173);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 261);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nhóm quyền";
            // 
            // ten
            // 
            this.ten.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ten.Location = new System.Drawing.Point(9, 106);
            this.ten.Margin = new System.Windows.Forms.Padding(2);
            this.ten.Multiline = true;
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(436, 46);
            this.ten.TabIndex = 5;
            this.ten.TextChanged += new System.EventHandler(this.ten_TextChanged);
            // 
            // matkhau
            // 
            this.matkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matkhau.Location = new System.Drawing.Point(9, 195);
            this.matkhau.Margin = new System.Windows.Forms.Padding(2);
            this.matkhau.Multiline = true;
            this.matkhau.Name = "matkhau";
            this.matkhau.Size = new System.Drawing.Size(436, 50);
            this.matkhau.TabIndex = 8;
            this.matkhau.TextChanged += new System.EventHandler(this.sodienthoai_TextChanged);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.SystemColors.Highlight;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.ForeColor = System.Drawing.SystemColors.Window;
            this.add.Location = new System.Drawing.Point(90, 464);
            this.add.Margin = new System.Windows.Forms.Padding(0);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(118, 41);
            this.add.TabIndex = 9;
            this.add.Text = "Thêm tài khoản";
            this.add.UseVisualStyleBackColor = false;
            // 
            // update
            // 
            this.update.BackColor = System.Drawing.SystemColors.Highlight;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.ForeColor = System.Drawing.SystemColors.Window;
            this.update.Location = new System.Drawing.Point(90, 464);
            this.update.Margin = new System.Windows.Forms.Padding(0);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(118, 41);
            this.update.TabIndex = 9;
            this.update.Text = "Sửa tài khoản";
            this.update.UseVisualStyleBackColor = false;
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.IndianRed;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.SystemColors.Window;
            this.cancel.Location = new System.Drawing.Point(242, 463);
            this.cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(117, 41);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "Hủy bỏ";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click_1);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(-4, -2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(471, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm tài khoản";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 350);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Trạng thái";
            // 
            // nhomquyen
            // 
            this.nhomquyen.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.nhomquyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nhomquyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nhomquyen.FormattingEnabled = true;
            this.nhomquyen.ItemHeight = 50;
            this.nhomquyen.Location = new System.Drawing.Point(9, 282);
            this.nhomquyen.Margin = new System.Windows.Forms.Padding(2);
            this.nhomquyen.Name = "nhomquyen";
            this.nhomquyen.Size = new System.Drawing.Size(436, 56);
            this.nhomquyen.TabIndex = 12;
            this.nhomquyen.SelectedIndexChanged += new System.EventHandler(this.nhomquyen_SelectedIndexChanged);
            // 
            // trangthai
            // 
            this.trangthai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.trangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trangthai.FormattingEnabled = true;
            this.trangthai.ItemHeight = 50;
            this.trangthai.Items.AddRange(new object[] {
            "Ngưng Hoạt động",
            "Hoạt động"});
            this.trangthai.Location = new System.Drawing.Point(9, 371);
            this.trangthai.Margin = new System.Windows.Forms.Padding(2);
            this.trangthai.Name = "trangthai";
            this.trangthai.Size = new System.Drawing.Size(436, 56);
            this.trangthai.TabIndex = 13;
            this.trangthai.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // TaiKhoanDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 529);
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
            this.Controls.Add(this.add);
            this.Controls.Add(this.update);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TaiKhoanDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaiKhoanDialog";
            this.Load += new System.EventHandler(this.TaiKhoanDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ComboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 50;  // Điều chỉnh chiều cao mục của ComboBox
        }

        private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Lấy ComboBox đang được vẽ
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null && e.Index >= 0)
            {
                string itemText = comboBox.Items[e.Index].ToString();

                StringFormat stringFormat = new StringFormat()
                {
                    LineAlignment = StringAlignment.Center
                };

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
                    e.Graphics.DrawString(itemText, e.Font, Brushes.White, e.Bounds, stringFormat);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                    e.Graphics.DrawString(itemText, e.Font, Brushes.Black, e.Bounds, stringFormat);
                }
            }
        }

        public void initInfo()
        {
            if (tk != null)
            {
                this.Controls.Remove(label3);
                this.Controls.Remove(matkhau);
                this.label4.Location = label5.Location;
                this.label5.Location = label3.Location;
                trangthai.Location = nhomquyen.Location;
                nhomquyen.Location = matkhau.Location;

                ten.Text = tk.Tendangnhap;
                trangthai.SelectedIndex = (int)tk.Trangthai;
                nhomquyen.SelectedItem = tkForm.nqService
                    .GetAll()
                    .Where(nhomquyen => nhomquyen.Manhomquyen.Equals(tk.Manhomquyen))
                    .First().Tennhomquyen;
            }
      
        }
        public void initView()
        {
            ten.ReadOnly = true;  
         
            trangthai.Enabled = false;
            nhomquyen.Enabled = false;

        }
        public TaiKhoanDialog(TaiKhoanForm tkform,int id_nv, string title, string type,TaiKhoan tk)
        {
            this.tkForm = tkform;
            this.id_nv = id_nv;
            this.title = title;
            this.tk = tk;
            this.type = type;
            InitializeComponent();
            load_Combobox();
            Inittype();
            add_Event();
            nhomquyen.SelectedIndex = 0;
            nhomquyen.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            nhomquyen.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
            trangthai.SelectedIndex = 0;
            trangthai.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            trangthai.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
        }

        private void Inittype()
        {
            this.label1.Text = title;
            switch (type)
            {
                case "create":
                    this.Controls.Remove(update);

                    break;

                case "update":

                    this.Controls.Remove(add);
                     initInfo();
                    break;

                case "view":
                    initInfo();
                    initView();
                    this.Controls.Remove(cancel);
                    this.Controls.Remove(update);
                    this.Controls.Remove(add);
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }
        public void add_Event()
        {
          
            add.Click += add_Click;
            update.Click += update_Click;
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
            foreach(var nq in tkForm.nqService.GetAll().Where(nq=>nq.Trangthai==1))
            {
                nhomquyen.Items.Add(nq.Tennhomquyen);
            }
            nhomquyen.SelectedIndex = 0;
            trangthai.SelectedIndex = 1;
        }
        private void add_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string tendangnhap = ten.Text; // Lấy tên đăng nhập từ TextBox
                int check = 0;

                // Kiểm tra xem tên đăng nhập đã tồn tại trong danh sách tài khoản hay chưa
                foreach (var i in ltk)
                {
                    if (i.Tendangnhap.Equals(ten.Text))
                    {
                        check++;
                        break;
                    }
                }
                
                // Nếu tên đăng nhập chưa tồn tại
                if (check == 0)
                {
                    string pass =MyBcrypt.HashPassword(matkhau.Text);
                    int manhom =(int)lnq.Where(nq=>nhomquyen.SelectedItem.Equals(nq.Tennhomquyen)).Select(nq=>nq.Manhomquyen).FirstOrDefault(); // Lấy mã nhóm quyền từ danh sách
                    int tt = trangthai.SelectedIndex; // Lấy trạng thái đã chọn

                    // Tạo đối tượng TaiKhoanDTO mới
                    TaiKhoan tk = new TaiKhoan(id_nv,pass, manhom, tendangnhap,tt, "123");

                    // Chèn tài khoản vào cơ sở dữ liệu
                   TaiKhoanService.Instance.AddAcc(tk);

                    // Thêm tài khoản vào bus
             

                    // Cập nhật bảng hiển thị
                    tkForm.LoadDataToListView(TaiKhoanService.Instance.GetTaiKhoanAll());

                    // Đóng form hiện tại
                    this.Dispose();
                }
                else
                {
                    // Hiển thị thông báo nếu tên tài khoản đã tồn tại
                    MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng đổi tên khác!", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ten.Focus(); // Đặt tiêu điểm trở lại TextBox username
                }
            }
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ten.Text)) // Kiểm tra xem tên đăng nhập có rỗng không
            {
                string tendangnhap = ten.Text; // Lấy tên đăng nhập từ TextBox
                string pass =tk.Matkhau; // Mã hóa mật khẩu
                int manhom = (int)lnq.Where(nq => nhomquyen.SelectedItem.Equals(nq.Tennhomquyen)).Select(nq => nq.Manhomquyen).FirstOrDefault(); // Lấy mã nhóm quyền từ danh sách
                int tt = trangthai.SelectedIndex; // Lấy trạng thái đã chọn
                
                // Tạo đối tượng TaiKhoanDTO mới
                TaiKhoan tk1 = new TaiKhoan(id_nv, pass, manhom, tendangnhap, tt, "123");

                // Cập nhật tài khoản trong cơ sở dữ liệu
                TaiKhoanService.Instance.UpdateAcc(tkForm.GetSelectedIndex(),tk1);

                // Cập nhật tài khoản trong bus
               

                // Cập nhật bảng hiển thị
                tkForm.LoadDataToListView(TaiKhoanService.Instance.GetTaiKhoanAll());

                // Đóng form hiện tại
                this.Dispose();
            }
            else
            {
                // Hiển thị thông báo nếu tên đăng nhập trống
                MessageBox.Show("Vui lòng không để trống tên", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        private void ten_TextChanged(object sender, EventArgs e)
        {

        }
        public bool ValidateInput()
        {
            if (string.IsNullOrEmpty(ten.Text))
            {
                MessageBox.Show("Vui lòng không để trống tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (ten.Text.Length < 6)
            {
                MessageBox.Show("Tên đăng nhập ít nhất 6 kí tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (string.IsNullOrEmpty(matkhau.Text))
            {
                MessageBox.Show("Vui lòng không để trống mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (matkhau.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu ít nhất 6 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private List<NhomQuyen> lnq = new NhomQuyenService().GetAll();
        List<TaiKhoan>ltk=TaiKhoanService.Instance.GetTaiKhoanAll();
        private TaiKhoan tk;
        private string title;
        private string type;
        private int id_nv;
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