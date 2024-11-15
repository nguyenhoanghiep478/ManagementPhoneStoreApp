using MathNet.Numerics;
using Service.impl;
using System;
using System.Drawing;
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.tit = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
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
            this.listView1.Location = new System.Drawing.Point(13, 162);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(623, 324);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh sách sản phẩm hiện có trong kho:\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(658, 162);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(412, 324);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // KhuVucKhoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KhuVucKhoForm";
            this.Text = "KhuVucKhoForm";
            this.Load += new System.EventHandler(this.KhuVucKhoForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        public void createItem(FlowLayoutPanel fl,string name,string sl)
        {
           FlowLayoutPanel flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel2.Location = new System.Drawing.Point(3, 35);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(394, 45);
            flowLayoutPanel2.TabIndex = 8;
            flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            flowLayoutPanel2.Padding = new Padding(0);
            flowLayoutPanel2.Margin = new Padding(0, 0, 0, 5); // Không còn khoảng cách giữa các control
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.ResumeLayout(false);

            flowLayoutPanel1.Padding = new Padding(0);

            Label label2 = new System.Windows.Forms.Label();
            label2.Location = new System.Drawing.Point(3, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(391, 20);
            label2.TabIndex = 6;
            label2.Text = name;
            label2.Click += new System.EventHandler(this.label2_Click_2);
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Click += new System.EventHandler(this.label2_Click_2);
            Label label3= new System.Windows.Forms.Label();
            label3.Location = new System.Drawing.Point(3, 25);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(391, 23);
            label3.TabIndex = 7;
            label3.Text = sl;
            label3.Click += new System.EventHandler(this.label3_Click_1);
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(label3);
            fl.Controls.Add(flowLayoutPanel2);
        }
        public KhuVucKhoForm()
        {
            InitializeComponent();
            foreach(var sp in spserv.GetAll())
            {
                createItem(this.flowLayoutPanel1, sp.Tensp.Trim(), sp.Soluongton.ToString());
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
       
    }
}