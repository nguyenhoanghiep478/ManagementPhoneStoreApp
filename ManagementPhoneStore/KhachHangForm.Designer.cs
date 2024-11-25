using Entity;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using Service.impl;
using System.Reflection;
using ManagementPhoneStore.util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using ManagementPhoneStore.Properties;
using GUI;

namespace ManagementPhoneStore
{
    partial class KhachHangForm
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
            this.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền form
            this.TopLevel = false;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KhachHangForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.kh_prop = new System.Windows.Forms.ComboBox();
            this.refresh = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.search_kh = new System.Windows.Forms.TextBox();
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
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 161);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1372, 321);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã khách hàng";
            this.columnHeader1.Width = 280;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên khách hàng";
            this.columnHeader2.Width = 280;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Địa chỉ";
            this.columnHeader3.Width = 280;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số điện thoại";
            this.columnHeader4.Width = 224;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ngày tham gia";
            this.columnHeader5.Width = 327;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.kh_prop);
            this.panel2.Controls.Add(this.refresh);
            this.panel2.Controls.Add(this.export);
            this.panel2.Controls.Add(this.search_kh);
            this.panel2.Controls.Add(this.import);
            this.panel2.Controls.Add(this.detail);
            this.panel2.Controls.Add(this.delete);
            this.panel2.Controls.Add(this.update);
            this.panel2.Controls.Add(this.add);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1471, 110);
            this.panel2.TabIndex = 1;
            // 
            // kh_prop
            // 
            this.kh_prop.FormattingEnabled = true;
            this.kh_prop.Items.AddRange(new object[] {
            "Tất cả",
            "Tên đăng nhập",
            "Mã nhân viên",
            ""});
            this.kh_prop.Location = new System.Drawing.Point(646, 31);
            this.kh_prop.Name = "kh_prop";
            this.kh_prop.Size = new System.Drawing.Size(141, 25);
            this.kh_prop.TabIndex = 7;
            this.kh_prop.Text = "Tất cả";
            this.kh_prop.SelectedIndexChanged += new System.EventHandler(this.kh_prop_SelectedIndexChanged);
            // 
            // refresh
            // 
            this.refresh.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.Image = ((System.Drawing.Image)(resources.GetObject("refresh.Image")));
            this.refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refresh.Location = new System.Drawing.Point(1149, 31);
            this.refresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(152, 50);
            this.refresh.TabIndex = 5;
            this.refresh.Text = "Làm mới";
            this.refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.button7_Click);
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
            this.export.Location = new System.Drawing.Point(336, 11);
            this.export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(93, 90);
            this.export.TabIndex = 2;
            this.export.Text = "XUẤT EXCEL";
            this.export.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.export.UseVisualStyleBackColor = true;
            // 
            // search_kh
            // 
            this.search_kh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_kh.Location = new System.Drawing.Point(818, 30);
            this.search_kh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search_kh.Multiline = true;
            this.search_kh.Name = "search_kh";
            this.search_kh.Size = new System.Drawing.Size(300, 50);
            this.search_kh.TabIndex = 6;
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
            this.import.Location = new System.Drawing.Point(435, 11);
            this.import.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(84, 90);
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
            this.detail.Location = new System.Drawing.Point(255, 11);
            this.detail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(75, 90);
            this.detail.TabIndex = 2;
            this.detail.Text = "CHI TIẾT";
            this.detail.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.detail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.detail.UseVisualStyleBackColor = true;
            this.detail.Click += new System.EventHandler(this.button4_Click);
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
            this.delete.Location = new System.Drawing.Point(175, 11);
            this.delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 90);
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
            this.update.Location = new System.Drawing.Point(95, 11);
            this.update.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 90);
            this.update.TabIndex = 1;
            this.update.Text = "SỬA";
            this.update.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.update.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.update.UseVisualStyleBackColor = true;
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
            this.add.Location = new System.Drawing.Point(15, 11);
            this.add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 90);
            this.add.TabIndex = 0;
            this.add.Text = "THÊM";
            this.add.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.add.UseVisualStyleBackColor = true;
            // 
            // KhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1396, 553);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listView1);
            this.Name = "KhachHangForm";
            this.Text = "Khách hàng";
            this.Load += new System.EventHandler(this.NhaCungCap_Load);
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

        public KhachHangForm()
        {
            InitializeComponent();
            LoadDataToListView(khService.getAll());
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
            search_kh.TextChanged += search_kh_TextChanged;
            refresh.Click += NhaCungCap_Load;

        }
        private void search_kh_TextChanged(object sender, EventArgs e)
        {
            if (Validation.IsEmpty(search_kh.Text))
            {
                LoadDataToListView(khService.getAll());
            }
            else
            {
                LoadDataToListView(khService.searchBy(search_kh.Text,kh_prop.SelectedItem.ToString()));
            }
        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            LoadDataToListView(khService.getAll());
        }
        private void detail_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() != -1)
            {
                KhachHangDialog khachHangDialog = new KhachHangDialog(this, khService.getByIndex(GetSelectedIndex()), "THÔNG TIN KHÁCH HÀNG", "view");
                khachHangDialog.ShowDialog();
            }
        }
        private void import_Click(object sender,EventArgs e)
        {
            ImportExcel();
        }
        private void add_Click(object sender, EventArgs e)
        {
            KhachHangDialog khachHangDialog = new KhachHangDialog(this,null, "THÊM KHÁCH HÀNG", "create");
            khachHangDialog.ShowDialog();
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() != -1)
            {
                KhachHangDialog khachHangDialog = new KhachHangDialog(this, khService.getByIndex(GetSelectedIndex()),"SỬA KHÁCH HÀNG", "update");
                khachHangDialog.ShowDialog();
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
                    khService.remove(khService.getByIndex(GetSelectedIndex()));
                    LoadDataToListView(khService.getAll());
                }
            }
        }
        public void ImportExcel()
        {

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open file",
                Filter = "Excel Files|*.xlsx"
            };

            int invalidCount = 0;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Kiểm tra xem tệp có tồn tại hay không
                    if (!File.Exists(openFileDialog.FileName))
                    {
                        MessageBox.Show("Tệp không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        IWorkbook workbook = new XSSFWorkbook(fileStream);
                        ISheet excelSheet = workbook.GetSheetAt(0);

                        for (int row = 1; row <= excelSheet.LastRowNum; row++)
                        {
                            IRow excelRow = excelSheet.GetRow(row);
                            if (excelRow == null) continue;

                            string tenkh = excelRow.GetCell(0)?.StringCellValue;
                            string sdt = excelRow.GetCell(1)?.NumericCellValue.ToString();
                            string diachi = excelRow.GetCell(2)?.StringCellValue;

                            if (string.IsNullOrWhiteSpace(tenkh) || string.IsNullOrWhiteSpace(sdt) ||
                                !IsPhoneNumber(sdt) || sdt.Length != 10 || string.IsNullOrWhiteSpace(diachi))
                            {
                                invalidCount++;
                            }
                            else
                            {
                                // Giả định khService là một dịch vụ để thêm khách hàng
                                khService.add(new KhachHang(null, tenkh, diachi, sdt, 1, DateTime.Now));
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

            LoadDataToListView(khService.getAll());
        }
        public static bool IsPhoneNumber(string str)
        {
            // Loại bỏ khoảng trắng và dấu ngoặc đơn nếu có
            str = str.Replace(" ", "")
                      .Replace("(", "")
                      .Replace(")", "")
                      .Replace("-", "");

            // Kiểm tra xem chuỗi có phải là một số điện thoại hợp lệ hay không
            if (Regex.IsMatch(str, @"^\d{10}$")) // Kiểm tra số điện thoại 10 chữ số
            {
                return true;
            }
            else if (Regex.IsMatch(str, @"^\d{3}-\d{3}-\d{4}$")) // Kiểm tra số điện thoại có dấu gạch ngang
            {
                return true;
            }
            else if (Regex.IsMatch(str, @"^\(\d{3}\)\d{3}-\d{4}$")) // Kiểm tra số điện thoại có dấu ngoặc đơn
            {
                return true;
            }
            else
            {
                return false; // Trả về false nếu chuỗi không phải là số điện thoại hợp lệ
            }
        }

        public void export_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewExport.ExportListViewToExcel(listView1);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadDataToListView(List<KhachHang> data)
        {
            // Xóa các mục hiện tại trong ListView
            listView1.Items.Clear();


            // Thêm dữ liệu vào ListView
            foreach (var item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.MakH.ToString()); // Tên nhà cung cấp
                listViewItem.SubItems.Add(item.TenKhachHang); // Địa chỉ
                listViewItem.SubItems.Add(item.DiaChi); // Địa chỉ
                listViewItem.SubItems.Add(item.Sdt); // Địa chỉ
                listViewItem.SubItems.Add(item.NgayThamGia.ToString()); // Địa chỉ

                // Thêm mục vào ListView
                listView1.Items.Add(listViewItem);
            }
        }
        #endregion
        public KhachHangService khService = new KhachHangService();

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button detail;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.TextBox search_kh;
        private ComboBox kh_prop;
    }
}