using Entity;
using ManagementPhoneStore.util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Service;
using Service.impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
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
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.add = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.detail = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.search_ncc = new System.Windows.Forms.TextBox();
            this.ncc_prop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(181, 126);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(900, 426);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã NCC";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên nhà cung cấp";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Địa chỉ";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Email";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 180;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số điện thoại";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 180;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(135, 65);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 1;
            this.add.Text = "Thêm";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.button1_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(247, 65);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 2;
            this.update.Text = "Sửa";
            this.update.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(361, 65);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 3;
            this.delete.Text = "Xóa";
            this.delete.UseVisualStyleBackColor = true;
            // 
            // import
            // 
            this.import.Location = new System.Drawing.Point(594, 65);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(75, 23);
            this.import.TabIndex = 4;
            this.import.Text = "Nhập";
            this.import.UseVisualStyleBackColor = true;
            // 
            // detail
            // 
            this.detail.Location = new System.Drawing.Point(479, 65);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(75, 23);
            this.detail.TabIndex = 4;
            this.detail.Text = "Chi tiết";
            this.detail.UseVisualStyleBackColor = true;
            this.detail.Click += new System.EventHandler(this.button5_Click);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(709, 65);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 5;
            this.export.Text = "Xuất";
            this.export.UseVisualStyleBackColor = true;
            // 
            // search_ncc
            // 
            this.search_ncc.Location = new System.Drawing.Point(806, 66);
            this.search_ncc.Name = "search_ncc";
            this.search_ncc.Size = new System.Drawing.Size(264, 22);
            this.search_ncc.TabIndex = 9;
            // 
            // ncc_prop
            // 
            this.ncc_prop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ncc_prop.FormattingEnabled = true;
            this.ncc_prop.Items.AddRange(new object[] {
            "Tất cả",
            "Mã ncc",
            "Tên ncc",
            "Địa chỉ",
            "Email",
            "Số điện thoại"});
            this.ncc_prop.Location = new System.Drawing.Point(806, 32);
            this.ncc_prop.Name = "ncc_prop";
            this.ncc_prop.Size = new System.Drawing.Size(121, 28);
            this.ncc_prop.TabIndex = 7;
            ncc_prop.SelectedIndex = 0;
            // 
            // NhaCungCapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.export);
            this.Controls.Add(this.detail);
            this.Controls.Add(this.import);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.update);
            this.Controls.Add(this.add);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.search_ncc);
            this.Controls.Add(this.ncc_prop);
            this.Name = "NhaCungCapForm";
            this.Text = "NhaCungCap";
            this.Load += new System.EventHandler(this.NhaCungCap_Load);
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

        public NhaCungCapForm()
        {
            InitializeComponent();
            LoadDataToListView(nccService.GetAll());
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
            search_ncc.TextChanged += search_ncc_TextChanged;

        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {

        }
        private void detail_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() != -1)
            {
                NhaCungCapDialog nhaCungCapDialog = new NhaCungCapDialog(this, nccService.GetByIndex(GetSelectedIndex()), "THÔNG TIN NHÀ CUNG CẤP", "view");
                nhaCungCapDialog.ShowDialog();
            }
        }
        private void import_Click(object sender, EventArgs e)
        {
            ImportExcel();
        }
        private void add_Click(object sender, EventArgs e)
        {
            NhaCungCapDialog nhaCungCapDialog = new NhaCungCapDialog(this, null, "THÊM NHÀ CUNG CẤP", "create");
            nhaCungCapDialog.ShowDialog();
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() != -1)
            {
                NhaCungCapDialog nhaCungCapDialog = new NhaCungCapDialog(this, nccService.GetByIndex(GetSelectedIndex()), "SỬA NHÀ CUNG CẤP", "update");
                nhaCungCapDialog .ShowDialog();
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
                   
                    nccService.Delete(nccService.GetByIndex(GetSelectedIndex()),GetSelectedIndex());
                    LoadDataToListView(nccService.GetAll());
                }
            }
        }
        private void search_ncc_TextChanged(object sender, EventArgs e)
        {
            if (Validation.IsEmpty(search_ncc.Text))
            {
                LoadDataToListView(nccService.GetAll());
            }
            else
            {
                LoadDataToListView(nccService.Search(search_ncc.Text, ncc_prop.SelectedItem.ToString()));
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

                            string tenncc = excelRow.GetCell(0)?.StringCellValue;
                            string diachi = excelRow.GetCell(1)?.StringCellValue.ToString();
                            string email = excelRow.GetCell(2)?.StringCellValue;
                            string sdt = excelRow.GetCell(3)?.StringCellValue;

                            if (string.IsNullOrWhiteSpace(tenncc) ||  // Kiểm tra tên nhà cung cấp không rỗng
                                string.IsNullOrWhiteSpace(diachi) || // Kiểm tra địa chỉ không rỗng
                                !IsPhoneNumber(sdt) ||               // Kiểm tra số điện thoại hợp lệ
                                sdt.Length != 10 ||                  // Kiểm tra số điện thoại có 10 chữ số
                                !IsValidEmail(email))                // Kiểm tra email hợp lệ
                            {
                                invalidCount++;
                            }
                            else
                            {
                                // Giả định khService là một dịch vụ để thêm nhà cung cấp
                                nccService.Add(new NhaCungCap(null, tenncc, diachi, email, sdt,1));  
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

            LoadDataToListView(nccService.GetAll());


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
        public void LoadDataToListView(List<NhaCungCap>data)
        {
            // Xóa các mục hiện tại trong ListView
            listView1.Items.Clear();

   
            // Thêm dữ liệu vào ListView
            foreach (var item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Manhacungcap.ToString()); // Tên nhà cung cấp
                listViewItem.SubItems.Add(item.Tennhacungcap); 
                listViewItem.SubItems.Add(item.Diachi); 
                listViewItem.SubItems.Add(item.Email); 
                listViewItem.SubItems.Add(item.Sdt);

                // Thêm mục vào ListView
                listView1.Items.Add(listViewItem);
            }
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
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // Biểu thức chính quy kiểm tra định dạng email
            string emailPattern = @"^[^@]+@[^@]+\.[^@]+$";

            // Kiểm tra email có khớp với biểu thức chính quy không
            return Regex.IsMatch(email, emailPattern);
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
        private Button add;
        private Button update;
        private Button delete;
        private Button import;
        private Button detail;
        private Button export;
        private System.Windows.Forms.TextBox search_ncc;
        private System.Windows.Forms.ComboBox ncc_prop;
    }
}