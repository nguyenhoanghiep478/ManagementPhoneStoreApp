using Entity;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using ManagementPhoneStore.util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using Service.impl;
using ManagementPhoneStore.Properties;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaiKhoanForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.tk_prop = new System.Windows.Forms.ComboBox();
            this.refresh = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.search_tk = new System.Windows.Forms.TextBox();
            this.import = new System.Windows.Forms.Button();
            this.detail = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
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
            this.listView1.Location = new System.Drawing.Point(16, 170);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1446, 422);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã nhân viên";
            this.columnHeader1.Width = 361;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên đăng nhập";
            this.columnHeader2.Width = 361;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nhóm quyền";
            this.columnHeader3.Width = 361;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Trạng thái";
            this.columnHeader4.Width = 361;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tk_prop);
            this.panel2.Controls.Add(this.refresh);
            this.panel2.Controls.Add(this.export);
            this.panel2.Controls.Add(this.search_tk);
            this.panel2.Controls.Add(this.import);
            this.panel2.Controls.Add(this.detail);
            this.panel2.Controls.Add(this.delete);
            this.panel2.Controls.Add(this.update);
            this.panel2.Controls.Add(this.add);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1471, 135);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // tk_prop
            // 
            this.tk_prop.FormattingEnabled = true;
            this.tk_prop.Items.AddRange(new object[] {
            "Tất cả",
            "Mã nhân viên",
            "Tên đăng nhập"});
            this.tk_prop.Location = new System.Drawing.Point(844, 41);
            this.tk_prop.Margin = new System.Windows.Forms.Padding(4);
            this.tk_prop.Name = "tk_prop";
            this.tk_prop.Size = new System.Drawing.Size(180, 28);
            this.tk_prop.TabIndex = 7;
            this.tk_prop.Text = "Tất cả";
            this.tk_prop.SelectedIndexChanged += new System.EventHandler(this.tk_prop_SelectedIndexChanged);
            // 
            // refresh
            // 
            this.refresh.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.Image = ((System.Drawing.Image)(resources.GetObject("refresh.Image")));
            this.refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refresh.Location = new System.Drawing.Point(1303, 40);
            this.refresh.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(159, 50);
            this.refresh.TabIndex = 5;
            this.refresh.Text = "Làm mới";
            this.refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click_1);
            // 
            // export
            // 
            this.export.AutoSize = true;
            this.export.Cursor = System.Windows.Forms.Cursors.Hand;
            this.export.FlatAppearance.BorderSize = 0;
            this.export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.export.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.export.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.export.Image = ((System.Drawing.Image)(resources.GetObject("export.Image")));
            this.export.Location = new System.Drawing.Point(424, 14);
            this.export.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(94, 111);
            this.export.TabIndex = 2;
            this.export.Text = "XUẤT EXCEL";
            this.export.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.export.UseVisualStyleBackColor = true;
            // 
            // search_tk
            // 
            this.search_tk.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_tk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.search_tk.Location = new System.Drawing.Point(1032, 40);
            this.search_tk.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.search_tk.Multiline = true;
            this.search_tk.Name = "search_tk";
            this.search_tk.Size = new System.Drawing.Size(263, 50);
            this.search_tk.TabIndex = 6;
            // 
            // import
            // 
            this.import.AutoSize = true;
            this.import.Cursor = System.Windows.Forms.Cursors.Hand;
            this.import.FlatAppearance.BorderSize = 0;
            this.import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.import.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.import.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.import.Image = ((System.Drawing.Image)(resources.GetObject("import.Image")));
            this.import.Location = new System.Drawing.Point(526, 14);
            this.import.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(94, 111);
            this.import.TabIndex = 2;
            this.import.Text = "NHẬP EXCEL";
            this.import.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.import.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.import.UseVisualStyleBackColor = true;
            // 
            // detail
            // 
            this.detail.AutoSize = true;
            this.detail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.detail.FlatAppearance.BorderSize = 0;
            this.detail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.detail.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detail.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.detail.Image = ((System.Drawing.Image)(resources.GetObject("detail.Image")));
            this.detail.Location = new System.Drawing.Point(322, 14);
            this.detail.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(94, 111);
            this.detail.TabIndex = 2;
            this.detail.Text = "CHI TIẾT";
            this.detail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.detail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.detail.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            this.delete.AutoSize = true;
            this.delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.delete.FlatAppearance.BorderSize = 0;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.delete.Image = ((System.Drawing.Image)(resources.GetObject("delete.Image")));
            this.delete.Location = new System.Drawing.Point(220, 14);
            this.delete.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(94, 111);
            this.delete.TabIndex = 2;
            this.delete.Text = "XÓA";
            this.delete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.delete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.delete.UseVisualStyleBackColor = true;
            // 
            // update
            // 
            this.update.AutoSize = true;
            this.update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.update.FlatAppearance.BorderSize = 0;
            this.update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.update.Image = ((System.Drawing.Image)(resources.GetObject("update.Image")));
            this.update.Location = new System.Drawing.Point(118, 11);
            this.update.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(94, 111);
            this.update.TabIndex = 1;
            this.update.Text = "SỬA";
            this.update.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click_1);
            // 
            // add
            // 
            this.add.AutoSize = true;
            this.add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.add.FlatAppearance.BorderSize = 0;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.add.Image = ((System.Drawing.Image)(resources.GetObject("add.Image")));
            this.add.Location = new System.Drawing.Point(16, 11);
            this.add.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(94, 111);
            this.add.TabIndex = 0;
            this.add.Text = "THÊM";
            this.add.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click_1);
            // 
            // TaiKhoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 679);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TaiKhoanForm";
            this.Text = "TaiKhoan";
            this.Load += new System.EventHandler(this.TaiKhoanForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
            refresh.Click += refresh_Click;
        }
        private void refresh_Click(object sender, EventArgs e)
        {
            LoadDataToListView(tkService.GetTaiKhoanAll());
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button detail;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.TextBox search_tk;
        private ComboBox tk_prop;
    }
}