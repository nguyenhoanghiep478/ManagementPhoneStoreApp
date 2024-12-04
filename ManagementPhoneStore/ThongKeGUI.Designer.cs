using System.Drawing;
using System.Windows.Forms;

namespace ManagementPhoneStore
{
    partial class ThongKeGUI
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.thongQuanGUI = new ManagementPhoneStore.ThongKeTongQuanGUI();
            this.tonKhoGUI = new ManagementPhoneStore.ThongKeTonKho();
            this.thongKeDoanhThu = new ManagementPhoneStore.ThongKeDoanhThu();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tonKhoGUI);
            this.tabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1094, 603);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Thống kê tồn kho";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.thongKeDoanhThu);
            this.tabPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1094, 603);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Thống kê doanh thu";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.thongQuanGUI);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1094, 603);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thống kê tổng quan";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = this.ClientSize;
            this.tabControl1.TabIndex = 0;
            // 
            // thongQuanGUI
            // 
            this.thongQuanGUI.BackColor = System.Drawing.Color.AliceBlue;
            this.thongQuanGUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thongQuanGUI.Location = new System.Drawing.Point(0, 0);
            this.thongQuanGUI.Name = "thongQuanGUI";
            this.thongQuanGUI.Size = new System.Drawing.Size(1094, 603);
            this.thongQuanGUI.TabIndex = 0;
            this.thongQuanGUI.Load += new System.EventHandler(this.ThongKe_Load);
            // 
            // tonKhoGUI
            // 
            this.tonKhoGUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tonKhoGUI.Location = new System.Drawing.Point(0, 0);
            this.tonKhoGUI.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tonKhoGUI.Name = "tonKhoGUI";
            this.tonKhoGUI.Size = new System.Drawing.Size(1094, 603);
            this.tonKhoGUI.TabIndex = 0;
            this.tonKhoGUI.Load += new System.EventHandler(this.tonKhoGUI_Load);
            // 
            // thongKeDoanhThu
            // 
            this.thongKeDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thongKeDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.thongKeDoanhThu.Name = "thongKeDoanhThu";
            this.thongKeDoanhThu.Size = new System.Drawing.Size(1094, 603);
            this.thongKeDoanhThu.TabIndex = 0;
            this.thongKeDoanhThu.Load += new System.EventHandler(this.thongKeDoanhThu_Load);
            // 
            // ThongKeGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 629);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ThongKeGUI";
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
      
        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl1;
        private ThongKeTongQuanGUI thongQuanGUI;
        private ThongKeTonKho tonKhoGUI;
        private ThongKeDoanhThu thongKeDoanhThu;

    }
}