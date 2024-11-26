using Entity;
using MathNet.Numerics;
using Service.impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ManagementPhoneStore
{
    partial class KhuVucKhoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KhuVucKhoForm));
            this.tit = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tit
            // 
            this.tit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tit.Location = new System.Drawing.Point(4, 11);
            this.tit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tit.Name = "tit";
            this.tit.Size = new System.Drawing.Size(414, 33);
            this.tit.TabIndex = 0;
            this.tit.Text = "Danh sách sản phẩm đang có trong khu vực kho\r\n";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(16, 202);
            this.listView1.Margin = new System.Windows.Forms.Padding(5);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(731, 404);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã kho";
            this.columnHeader1.Width = 123;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên khu vực kho";
            this.columnHeader2.Width = 350;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ghi chú";
            this.columnHeader3.Width = 250;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(492, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh sách sản phẩm hiện có trong kho:\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(787, 202);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(515, 405);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(3, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1340, 138);
            this.panel2.TabIndex = 4;
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Calibri Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.Location = new System.Drawing.Point(1197, 40);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(126, 41);
            this.button7.TabIndex = 5;
            this.button7.Text = "Làm mới";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.comboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 35;
            this.comboBox1.Location = new System.Drawing.Point(673, 40);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(235, 41);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.Text = "Tất cả";
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.AutoSize = true;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(420, 14);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(116, 112);
            this.button6.TabIndex = 2;
            this.button6.Text = "XUẤT EXCEL";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(926, 40);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(263, 41);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(319, 14);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 112);
            this.button4.TabIndex = 2;
            this.button4.Text = "CHI TIẾT";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(219, 14);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 112);
            this.button3.TabIndex = 2;
            this.button3.Text = "XÓA";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(119, 14);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 112);
            this.button2.TabIndex = 1;
            this.button2.Text = "SỬA";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(19, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 112);
            this.button1.TabIndex = 0;
            this.button1.Text = "THÊM";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // KhuVucKhoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1340, 661);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "KhuVucKhoForm";
            this.Text = "KhuVucKhoForm";
            this.Load += new System.EventHandler(this.KhuVucKhoForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Lấy giá trị của mục đang vẽ
            string itemText = comboBox1.Items[e.Index].ToString();

            // Kiểm tra nếu chuột rê vào mục này
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                // Vẽ nền khi chuột rê
                e.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), e.Bounds);

                // Vẽ viền khi chuột rê
                ControlPaint.DrawBorder(e.Graphics, e.Bounds, Color.Blue, ButtonBorderStyle.Solid);
            }
            else
            {
                // Vẽ nền mặc định
                e.Graphics.FillRectangle(new SolidBrush(comboBox1.BackColor), e.Bounds);
            }

            // Vẽ chữ của mục
            TextRenderer.DrawText(
                e.Graphics,
                itemText,
                comboBox1.Font,
                e.Bounds,
                comboBox1.ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            // Xóa viền mặc định của ComboBox
            e.DrawFocusRectangle();
        }
        public void createItemWithHeader(FlowLayoutPanel fl, string title, List<SanPham> items)
        {
            // Xóa các mục cũ nếu cần làm mới danh sách
            fl.Controls.Clear();

            // Thêm tiêu đề danh sách
            Label titleLabel = new Label
            {
                Text = title,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(5, 5, 5, 10), // Khoảng cách
                ForeColor = System.Drawing.Color.Black
            };

            fl.Controls.Add(titleLabel);

            
            foreach (var item in items)
            {
                createItem(fl, item.Tensp,item.Soluongton.ToString(), item.Hinhanh);
            }
        }

        public void createItem(FlowLayoutPanel fl,string name,string sl,string imgPath)
        {
            //FlowLayoutPanel flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            // flowLayoutPanel2.Location = new System.Drawing.Point(3, 35);
            // flowLayoutPanel2.Name = "flowLayoutPanel2";
            // flowLayoutPanel2.Size = new System.Drawing.Size(394, 45);
            // flowLayoutPanel2.TabIndex = 8;
            // flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // flowLayoutPanel2.Padding = new Padding(0);
            // flowLayoutPanel2.Margin = new Padding(0, 0, 0, 5); // Không còn khoảng cách giữa các control
            // flowLayoutPanel2.SuspendLayout();
            // flowLayoutPanel2.ResumeLayout(false);
            FlowLayoutPanel flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel
            {
                Location = new System.Drawing.Point(3, 35),
                Name = "flowLayoutPanel2",
                Size = new System.Drawing.Size(394, 120),
                TabIndex = 8,
                Padding = new Padding(0),
                Margin = new Padding(0, 0, 0, 5),

            };

            PictureBox pictureBox = new PictureBox
            {
                Size = new System.Drawing.Size(60, 60),
                SizeMode = PictureBoxSizeMode.Zoom,
                Margin = new Padding(5, 5, 5, 5)
            };

            string imagePath = Path.Combine("./img_product", imgPath);

            // Kiểm tra và tải hình ảnh
            if (File.Exists(imagePath))
            {
                pictureBox.Image = System.Drawing.Image.FromFile(imagePath);
            }
            else
            {
                pictureBox.Image = System.Drawing.Image.FromFile("./img_product/default.png"); // Hình mặc định nếu không tìm thấy
            }

            flowLayoutPanel1.Padding = new Padding(0);

            //Label label2 = new System.Windows.Forms.Label();
            //label2.Location = new System.Drawing.Point(3, 0);
            //label2.Name = "label2";
            //label2.Size = new System.Drawing.Size(391, 20);
            //label2.TabIndex = 6;
            //label2.Text = name;
            //label2.Click += new System.EventHandler(this.label2_Click_2);
            //label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //label2.Click += new System.EventHandler(this.label2_Click_2);

            Label label2 = new System.Windows.Forms.Label
            {
                Location = new System.Drawing.Point(70, 0), // Cách hình ảnh 70px
                Name = "label2",
                Size = new System.Drawing.Size(320, 20),
                TabIndex = 6,
                Text = name,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold),
                Margin = new Padding(5, 5, 5, 0)
            };

            //Label label3= new System.Windows.Forms.Label();
            //label3.Location = new System.Drawing.Point(3, 25);
            //label3.Name = "label3";
            //label3.Size = new System.Drawing.Size(391, 23);
            //label3.TabIndex = 7;
            //label3.Text = sl;
            //label3.Click += new System.EventHandler(this.label3_Click_1);

            Label label3 = new System.Windows.Forms.Label
            {
                Location = new System.Drawing.Point(70, 25), // Cách hình ảnh 70px
                Name = "label3",
                Size = new System.Drawing.Size(320, 23),
                TabIndex = 7,
                Text = sl,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F),
                Margin = new Padding(5, 0, 5, 5) // Khoảng cách
            };

            flowLayoutPanel2.Controls.Add(pictureBox);
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(label3);


            flowLayoutPanel2.BorderStyle = BorderStyle.FixedSingle;

            // Gắn sự kiện Paint để vẽ viền màu
            flowLayoutPanel2.Paint += (sender, e) =>
            {
                // Màu viền mong muốn
                System.Drawing.Color borderColor = System.Drawing.Color.Black;
                int borderWidth = 2; // Độ dày viền

                // Tạo bút để vẽ
                using (Pen pen = new Pen(borderColor, borderWidth))
                {
                    // Vẽ hình chữ nhật bao quanh FlowLayoutPanel
                    e.Graphics.DrawRectangle(
                        pen,
                        new System.Drawing.Rectangle(0, 0, flowLayoutPanel2.Width - 1, flowLayoutPanel2.Height - 1)
                    );
                }
            };


            fl.Controls.Add(flowLayoutPanel2);
        }
        public KhuVucKhoForm()
        {
            InitializeComponent();
            foreach(var sp in spserv.GetAll())
            {
                createItem(this.flowLayoutPanel1, sp.Tensp.Trim(), sp.Soluongton.ToString(),sp.Hinhanh);
            }
      
        }



        #endregion
        private System.Windows.Forms.Label tit;
        private Color defaultBackColor;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private SanPhamService spserv=SanPhamService.Instance;
        private Panel panel2;
        private Button button7;
        private ComboBox comboBox1;
        private Button button6;
        private TextBox textBox1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
    }
}