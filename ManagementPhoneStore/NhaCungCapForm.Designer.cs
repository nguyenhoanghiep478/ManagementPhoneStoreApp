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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhaCungCapForm));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.ncc_prop = new System.Windows.Forms.ComboBox();
            this.refresh1 = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.search_ncc = new System.Windows.Forms.TextBox();
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
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(9, 105);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1100, 584);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã NCC";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên nhà cung cấp";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Địa chỉ";
            this.columnHeader3.Width = 295;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Email";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 250;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số điện thoại";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 200;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.ncc_prop);
            this.panel2.Controls.Add(this.refresh1);
            this.panel2.Controls.Add(this.export);
            this.panel2.Controls.Add(this.search_ncc);
            this.panel2.Controls.Add(this.import);
            this.panel2.Controls.Add(this.detail);
            this.panel2.Controls.Add(this.delete);
            this.panel2.Controls.Add(this.update);
            this.panel2.Controls.Add(this.add);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(9, 6);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1100, 95);
            this.panel2.TabIndex = 1;
            // 
            // ncc_prop
            // 
            this.ncc_prop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ncc_prop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ncc_prop.FormattingEnabled = true;
            this.ncc_prop.ItemHeight = 36;
            this.ncc_prop.Items.AddRange(new object[] {
            "Tất cả",
            "Mã ncc",
            "Tên ncc",
            "Địa chỉ",
            "Emai",
            "Số điện thoại"});
            this.ncc_prop.Location = new System.Drawing.Point(583, 26);
            this.ncc_prop.Margin = new System.Windows.Forms.Padding(2);
            this.ncc_prop.Name = "ncc_prop";
            this.ncc_prop.Size = new System.Drawing.Size(152, 42);
            this.ncc_prop.TabIndex = 7;
            this.ncc_prop.SelectedIndexChanged += new System.EventHandler(this.ncc_prop_SelectedIndexChanged);
            // 
            // refresh1
            // 
            this.refresh1.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh1.Image = ((System.Drawing.Image)(resources.GetObject("refresh1.Image")));
            this.refresh1.Location = new System.Drawing.Point(964, 26);
            this.refresh1.Margin = new System.Windows.Forms.Padding(2);
            this.refresh1.Name = "refresh1";
            this.refresh1.Size = new System.Drawing.Size(128, 41);
            this.refresh1.TabIndex = 5;
            this.refresh1.Text = "Làm mới";
            this.refresh1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.refresh1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refresh1.UseVisualStyleBackColor = true;
            this.refresh1.Click += new System.EventHandler(this.refresh1_Click);
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
            this.export.Location = new System.Drawing.Point(252, 9);
            this.export.Margin = new System.Windows.Forms.Padding(2);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(80, 75);
            this.export.TabIndex = 2;
            this.export.Text = "XUẤT EXCEL";
            this.export.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.export.UseVisualStyleBackColor = true;
            // 
            // search_ncc
            // 
            this.search_ncc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_ncc.Location = new System.Drawing.Point(747, 26);
            this.search_ncc.Margin = new System.Windows.Forms.Padding(2);
            this.search_ncc.Multiline = true;
            this.search_ncc.Name = "search_ncc";
            this.search_ncc.Size = new System.Drawing.Size(213, 41);
            this.search_ncc.TabIndex = 6;
            this.search_ncc.TextChanged += new System.EventHandler(this.search_ncc_TextChanged_1);
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
            this.import.Location = new System.Drawing.Point(326, 9);
            this.import.Margin = new System.Windows.Forms.Padding(2);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(84, 75);
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
            this.detail.Location = new System.Drawing.Point(191, 9);
            this.detail.Margin = new System.Windows.Forms.Padding(2);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(59, 75);
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
            this.delete.Location = new System.Drawing.Point(131, 9);
            this.delete.Margin = new System.Windows.Forms.Padding(2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(56, 75);
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
            this.update.Location = new System.Drawing.Point(71, 9);
            this.update.Margin = new System.Windows.Forms.Padding(2);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(56, 75);
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
            this.add.Location = new System.Drawing.Point(11, 9);
            this.add.Margin = new System.Windows.Forms.Padding(2);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(56, 75);
            this.add.TabIndex = 0;
            this.add.Text = "THÊM";
            this.add.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.add.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click_1);
            // 
            // NhaCungCapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1120, 700);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NhaCungCapForm";
            this.Text = "NhaCungCap";
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

        public NhaCungCapForm()
        {
            InitializeComponent();
            LoadDataToListView(nccService.GetAll());
            add_Event();
            listView1.OwnerDraw = true;
            listView1.DrawColumnHeader += listView_DrawColumnHeader;
            listView1.DrawSubItem += listView_DrawSubItem;
            ncc_prop.SelectedIndex = 0;
            ncc_prop.MeasureItem += new MeasureItemEventHandler(ComboBox_MeasureItem);
            ncc_prop.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
        }
        private void ComboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 36;  // Điều chỉnh chiều cao mục của ComboBox
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
        private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (Brush headerBrush = new SolidBrush(Color.FromArgb(235, 235, 235)))
            {
                e.Graphics.FillRectangle(headerBrush, e.Bounds);
            }

            using (Font customFont = new Font("Arial", 9, FontStyle.Bold))
            {
                TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                TextRenderer.DrawText(e.Graphics, e.Header.Text, customFont, e.Bounds, Color.Black, flags);
            }

            if (e.ColumnIndex < listView1.Columns.Count - 1)
            {
                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    e.Graphics.DrawLine(pen, e.Bounds.Right - 1, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom);
                }
            }
        }

        private void listView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
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

            refresh1.Click += refresh_Click;
        }
        private void NhaCungCap_Load(object sender, EventArgs e)
        {

        }
        private void refresh_Click(object sender, EventArgs e)
        {
            LoadDataToListView(nccService.GetAll());
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
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp?", "Xóa nhà cung cấp",
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
                            int id = nccService.getIncreasementId();
                            string tenncc = excelRow.GetCell(0)?.StringCellValue;
                            string diachi = excelRow.GetCell(1)?.StringCellValue.ToString();
                            string email = excelRow.GetCell(2)?.StringCellValue;
                            string sdt = excelRow.GetCell(3)?.NumericCellValue.ToString();

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
                             
                                nccService.Add(new NhaCungCap(id, tenncc, diachi, email, sdt,1));  
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
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.Button detail;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button refresh1;
        private System.Windows.Forms.TextBox search_ncc;
        private ComboBox ncc_prop;
    }
}