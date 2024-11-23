using Entity;
using ManagementPhoneStore.util;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Service.impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
namespace ManagementPhoneStore
{
    partial class NhanVienForm
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhanVienForm));
            this.listViewNhanVien = new System.Windows.Forms.ListView();
            this.maNhanVien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hoTen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gioTinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ngaySinh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sđt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.nv_prop = new System.Windows.Forms.ComboBox();
            this.refresh = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.search_nv = new System.Windows.Forms.TextBox();
            this.import = new System.Windows.Forms.Button();
            this.detail = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewNhanVien
            // 
            this.listViewNhanVien.BackColor = System.Drawing.Color.White;
            this.listViewNhanVien.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.maNhanVien,
            this.hoTen,
            this.gioTinh,
            this.ngaySinh,
            this.sđt,
            this.email});
            this.listViewNhanVien.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listViewNhanVien.ForeColor = System.Drawing.Color.Black;
            this.listViewNhanVien.FullRowSelect = true;
            this.listViewNhanVien.GridLines = true;
            this.listViewNhanVien.HideSelection = false;
            this.listViewNhanVien.Location = new System.Drawing.Point(15, 169);
            this.listViewNhanVien.Name = "listViewNhanVien";
            this.listViewNhanVien.Size = new System.Drawing.Size(1443, 382);
            this.listViewNhanVien.TabIndex = 0;
            this.listViewNhanVien.UseCompatibleStateImageBehavior = false;
            this.listViewNhanVien.View = System.Windows.Forms.View.Details;
            // 
            // maNhanVien
            // 
            this.maNhanVien.Text = "Mã Nhân Viên";
            this.maNhanVien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maNhanVien.Width = 240;
            // 
            // hoTen
            // 
            this.hoTen.Text = "Ho Tên";
            this.hoTen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hoTen.Width = 240;
            // 
            // gioTinh
            // 
            this.gioTinh.Text = "Giới Tính";
            this.gioTinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gioTinh.Width = 240;
            // 
            // ngaySinh
            // 
            this.ngaySinh.Text = "Ngày Sinh";
            this.ngaySinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ngaySinh.Width = 240;
            // 
            // sđt
            // 
            this.sđt.Text = "Số Điện Thoại";
            this.sđt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sđt.Width = 240;
            // 
            // email
            // 
            this.email.Text = "Email";
            this.email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.email.Width = 240;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.nv_prop);
            this.panel2.Controls.Add(this.refresh);
            this.panel2.Controls.Add(this.export);
            this.panel2.Controls.Add(this.search_nv);
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
            // nv_prop
            // 
            this.nv_prop.FormattingEnabled = true;
            this.nv_prop.Items.AddRange(new object[] {
            "Tất cả",
            "Mã nhân viên",
            "Họ tên",
            "Giới tính",
            "Ngày sinh",
            "Số điện thoại",
            "Email"});
            this.nv_prop.Location = new System.Drawing.Point(837, 32);
            this.nv_prop.Name = "nv_prop";
            this.nv_prop.Size = new System.Drawing.Size(141, 28);
            this.nv_prop.TabIndex = 7;
            this.nv_prop.Text = "Tất cả";
            // 
            // refresh
            // 
            this.refresh.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.Image = ((System.Drawing.Image)(resources.GetObject("refresh.Image")));
            this.refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refresh.Location = new System.Drawing.Point(1303, 32);
            this.refresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(139, 50);
            this.refresh.TabIndex = 5;
            this.refresh.Text = "Làm mới";
            this.refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refresh.UseVisualStyleBackColor = true;
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
            // search_nv
            // 
            this.search_nv.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_nv.Location = new System.Drawing.Point(996, 32);
            this.search_nv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search_nv.Multiline = true;
            this.search_nv.Name = "search_nv";
            this.search_nv.Size = new System.Drawing.Size(300, 50);
            this.search_nv.TabIndex = 6;
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
            // NhanVienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1470, 553);
            this.Controls.Add(this.listViewNhanVien);
            this.Controls.Add(this.panel2);
            this.Name = "NhanVienForm";
            this.Text = "NhanVienGUI";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        public int GetSelectedIndex()
        {
            int index = listViewNhanVien.SelectedIndices.Count > 0 ? listViewNhanVien.SelectedIndices[0] : -1;

            if (index == -1)
            {
                MessageBox.Show("Vui lòng chọn một mục trong danh sách");
            }
            return index;
        }
        public NhanVienForm()
        {
            InitializeComponent();
            LoadDataToListView(nvService.GetAll());
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
            search_nv.TextChanged += search_nv_TextChanged;
            refresh.Click += refresh_click;
        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {

        }
        private void refresh_click(object sender, EventArgs e)
        {
            LoadDataToListView(nvService.GetAll());
        }
        private void detail_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() != -1)
            {
                NhanVienChiTietForm nhanVienChiTietGui = new NhanVienChiTietForm(this, nvService.GetByIndex(GetSelectedIndex()), "THÔNG TIN NHÂN VIÊN", "view");
                nhanVienChiTietGui.ShowDialog();
            }
        }
        private void import_Click(object sender, EventArgs e)
        {
            ImportExcel();
        }
        private void add_Click(object sender, EventArgs e)
        {
            NhanVienChiTietForm nhanVienChiTietGUI = new NhanVienChiTietForm(this, null, "THÊM NHÂN VIÊN", "create");
            nhanVienChiTietGUI.ShowDialog();
        }
        private void update_Click(object sender, EventArgs e)
        {
            if (GetSelectedIndex() != -1)
            {
                NhanVienChiTietForm nhanVienChiTietGui = new NhanVienChiTietForm(this, nvService.GetByIndex(GetSelectedIndex()), "SỬA NHÂN VIÊN", "update");
                nhanVienChiTietGui.ShowDialog();
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
                    nvService.DeleteNv(nvService.GetByIndex(GetSelectedIndex()));
                    LoadDataToListView(nvService.GetAll());
                }
            }
        }
        private void search_nv_TextChanged(object sender, EventArgs e)
        {
            if (Validation.IsEmpty(search_nv.Text))
            {
                LoadDataToListView(nvService.GetAll());
            }
            else
            {
                LoadDataToListView(nvService.Search(search_nv.Text, nv_prop.SelectedItem.ToString()));
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

                            string hovaten = excelRow.GetCell(0) != null && excelRow.GetCell(0).CellType == CellType.String
                                ? excelRow.GetCell(0).StringCellValue
                                : string.Empty;

                            string gioitinh = excelRow.GetCell(1) != null && excelRow.GetCell(1).CellType == CellType.String
                                ? excelRow.GetCell(1).StringCellValue
                                : string.Empty;

                            DateTime ngaysinh = DateTime.MinValue;
                           
                            var cell = excelRow.GetCell(2);

                            if (cell != null)
                            {
                                // Kiểm tra nếu ô là kiểu số và được định dạng là ngày tháng
                                if (cell.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(cell))
                                {
                                    ngaysinh = (DateTime)cell.DateCellValue; // Lấy giá trị ngày trực tiếp
                                }
                                // Kiểm tra nếu ô là kiểu chuỗi
                                else if (cell.CellType == CellType.String)
                                {
                                    DateTime tempDate;
                                    // Thử chuyển đổi chuỗi sang DateTime
                                    if (DateTime.TryParse(cell.StringCellValue, out tempDate))
                                    {
                                        ngaysinh = tempDate;
                                    }
                                }
                            }


                            string sodienthoai = string.Empty;
                            if (excelRow.GetCell(3) != null)
                            {
                                if (excelRow.GetCell(3).CellType == CellType.Numeric)
                                {
                                    sodienthoai = excelRow.GetCell(3).NumericCellValue.ToString();
                                }
                                else if (excelRow.GetCell(3).CellType == CellType.String)
                                {
                                    sodienthoai = excelRow.GetCell(3).StringCellValue;
                                }
                            }

                            string email = excelRow.GetCell(4) != null && excelRow.GetCell(4).CellType == CellType.String
                                ? excelRow.GetCell(4).StringCellValue
                                : string.Empty;
                            if (
                                string.IsNullOrWhiteSpace(hovaten) ||
                                string.IsNullOrWhiteSpace(email) ||
                                !IsValidEmail(email) ||
                                string.IsNullOrWhiteSpace(sodienthoai) ||
                                !IsPhoneNumber(sodienthoai) ||
                                sodienthoai.Length != 10 ||
                                (gioitinh != "Nam" && gioitinh != "Nữ"))
                            {
                                invalidCount++;
                            }
                            else
                            {
                                int gt = 0;
                                if (gioitinh == "Nam")
                                {
                                    gt = 1;
                                }
                                // Giả định nvService là một dịch vụ để thêm nhân viên
                                nvService.InsertNv(new NhanVien(null, hovaten, gt, ngaysinh, sodienthoai, email, 1));
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
         
              

            LoadDataToListView(nvService.GetAll());
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
                ListViewExport.ExportListViewToExcel(listViewNhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadDataToListView(List<NhanVien> data)
        {
            // Xóa các mục hiện tại trong ListView
            listViewNhanVien.Items.Clear();


            // Thêm dữ liệu vào ListView
            foreach (var item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Manv.ToString()); 
                listViewItem.SubItems.Add(item.Hoten);
                string gioiTinh = item.Giotinh == 1 ? "Nam" : "Nữ";
                listViewItem.SubItems.Add(gioiTinh);
                listViewItem.SubItems.Add(item.Ngaysinh.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(item.Sdt.ToString()); 
                listViewItem.SubItems.Add(item.Email.ToString()); 
                // Thêm mục vào ListView
                listViewNhanVien.Items.Add(listViewItem);
            }
        }

        #endregion
        
        private System.Windows.Forms.ListView listViewNhanVien;
        private System.Windows.Forms.ColumnHeader maNhanVien;
        private System.Windows.Forms.ColumnHeader hoTen;
        private System.Windows.Forms.ColumnHeader gioTinh;
        private System.Windows.Forms.ColumnHeader ngaySinh;
        private System.Windows.Forms.ColumnHeader sđt;
        private System.Windows.Forms.ColumnHeader email;
        public NhanVienService nvService = new NhanVienService();
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button detail;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.TextBox search_nv;
        private System.Windows.Forms.ComboBox nv_prop;

    }
}