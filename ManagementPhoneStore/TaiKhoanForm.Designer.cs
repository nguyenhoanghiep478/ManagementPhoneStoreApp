using Entity;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using ManagementPhoneStore.util;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using Service.impl;

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
            this.search_tk = new System.Windows.Forms.TextBox();
            this.tk_prop = new System.Windows.Forms.ComboBox();
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
            // 
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
            // search_tk
            // 
            this.search_tk.Location = new System.Drawing.Point(176, 75);
            this.search_tk.Name = "search_tk";
            this.search_tk.Size = new System.Drawing.Size(198, 22);
            this.search_tk.TabIndex = 7;
            // 
            // tk_prop
            // 
            this.tk_prop.FormattingEnabled = true;
            this.tk_prop.Items.AddRange(new object[] {
            "Tất cả",
            "Mã nhân viên",
            "Tên đăng nhập"});
            this.tk_prop.Location = new System.Drawing.Point(37, 73);
            this.tk_prop.Name = "tk_prop";
            this.tk_prop.Size = new System.Drawing.Size(121, 24);
            this.tk_prop.TabIndex = 8;
            tk_prop.SelectedIndex = 0;
            // 
            // TaiKhoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.tk_prop);
            this.Controls.Add(this.search_tk);
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

        public TaiKhoanForm()
        {
            InitializeComponent();
            LoadDataToListView(tkService.GetTaiKhoanAll() );
            add_Event();
        }
        private void search_tk_TextChanged(object sender, EventArgs e)
        {
            if (Validation.IsEmpty(search_tk.Text))
            {
                LoadDataToListView(tkService.GetTaiKhoanAll());
            }
            else
            {
                LoadDataToListView(tkService.Search(search_tk.Text, tk_prop.SelectedItem.ToString()));
            }
        }
        private void add_Event()
        {
            add.Click += add_Click;
            update.Click += update_Click;
            detail.Click += detail_Click;
            delete.Click += delete_Click;
            import.Click += import_Click;
            export.Click += export_Click;
            search_tk.TextChanged += search_tk_TextChanged;

        }
      
        private void detail_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() != -1)
            {
                TaiKhoanDialog taiKhoanDialog = new TaiKhoanDialog(this, tkService.getByIndex(GetSelectedIndex()).Manv, "TÀI KHOẢN",
                  "view", tkService.getByIndex(GetSelectedIndex()));
                taiKhoanDialog.ShowDialog();
            }
        }
        private void import_Click(object sender, EventArgs e)
        {
            ImportExcel();
        }

        private void ImportExcel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open file",
                Filter = "Excel Files|*.xlsx;*.xls"
            };

            int invalidCount = 0;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = new XSSFWorkbook(fileStream);
                        ISheet excelSheet = workbook.GetSheetAt(0);

                        for (int row = 1; row <= excelSheet.LastRowNum; row++) // Bắt đầu từ dòng 2
                        {
                            IRow excelRow = excelSheet.GetRow(row);
                            if (excelRow == null) continue;

                            int manv = (int)excelRow.GetCell(0)?.NumericCellValue;
                            string tendangnhap = excelRow.GetCell(1)?.StringCellValue;
                            var cell = excelRow.GetCell(2);

                            // Kiểm tra nếu ô không phải là null
                            string matkhau;
                            if (cell != null)
                            {
                                // Kiểm tra kiểu dữ liệu của ô
                                if (cell.CellType == NPOI.SS.UserModel.CellType.String)
                                {
                                    matkhau = cell.StringCellValue; // Nếu là chuỗi, lấy giá trị chuỗi
                                }
                                else if (cell.CellType == NPOI.SS.UserModel.CellType.Numeric)
                                {
                                    matkhau = cell.NumericCellValue.ToString(); // Nếu là số, chuyển sang chuỗi
                                }
                                else
                                {
                                    matkhau = string.Empty; // Trường hợp khác, gán chuỗi rỗng
                                }
                            }
                            else
                            {
                                // Gán chuỗi rỗng nếu ô là null
                                matkhau = string.Empty;
                            }
                            string nhomquyen = excelRow.GetCell(3)?.StringCellValue;

                            int check1 = 0, check2 = 0, check3 = 0, check4 = 0;

                            // Kiểm tra các giá trị rỗng
                            if (string.IsNullOrWhiteSpace(manv.ToString()) || string.IsNullOrWhiteSpace(tendangnhap) ||
                                string.IsNullOrWhiteSpace(matkhau) || string.IsNullOrWhiteSpace(nhomquyen))
                            {
                                check1 = 1;
                            }

                            int manhomquyen = 0;
                            var nvbus = new NhanVienService();
                            var nvlist = nvbus.GetAll();

                            foreach (var nv in nvlist)
                            {
                                if (nv.Manv == manv)
                                {
                                    check2 = 0;
                                    break;
                                }
                                else
                                {
                                    check2 = 1;
                                }
                            }

                            var curlist =tkService.GetTaiKhoanAll();
                            foreach (var tk in curlist)
                            {
                                if (tk.Tendangnhap.Equals(tendangnhap))
                                {
                                    check3 = 1;
                                    break;
                                }
                                else
                                {
                                    check3 = 0;
                                }
                            }

                            var nhomquyenbus = new NhomQuyenService();
                            var quyenlist = nhomquyenbus.GetAll();
                            foreach (var quyen in quyenlist)
                            {
                                if (quyen.Tennhomquyen.Trim().Equals(nhomquyen.Trim()))
                                {
                                    check4 = 0;
                                    manhomquyen = (int)quyen.Manhomquyen;
                                    break;
                                }
                                else
                                {
                                    check4 = 1;
                                }
                            }

                            if (check1 != 0 || check2 != 0 || check3 != 0 || check4 != 0)
                            {
                                invalidCount++;
                            }
                            else
                            {
                                string hashedPassword = MyBcrypt.HashPassword(matkhau);
                                var newAccount = new TaiKhoan(manv,  hashedPassword ,manhomquyen,tendangnhap, 1,"123");
                                tkService.AddAcc(newAccount);
                              
                            }
                        }
                    }

                    MessageBox.Show("Nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Lỗi đọc file: Tệp không được tìm thấy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Lỗi đọc file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (invalidCount > 0)
            {
                MessageBox.Show($"Có {invalidCount} dữ liệu không hợp lệ không được thêm vào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            LoadDataToListView(tkService.GetTaiKhoanAll());
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
                taiKhoanDialog.ShowDialog();
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
                listViewItem.SubItems.Add(nqService.getNameByMA((int)item.Manhomquyen)); // Địa chỉ
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
        private TextBox search_tk;
        private ComboBox tk_prop;
    }
}