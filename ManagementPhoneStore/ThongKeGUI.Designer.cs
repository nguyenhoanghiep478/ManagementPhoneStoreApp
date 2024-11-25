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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.thongQuanGUI = new ManagementPhoneStore.ThongKeTongQuanGUI();
            this.tonKhoGUI = new ManagementPhoneStore.ThongKeTonKho();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tonKhoGUI);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1371, 699);
            this.tabPage2.Text = "Thống kê tồn kho";
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.thongQuanGUI);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1371, 699);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thống kê tổng quan";
            // 
            // thongQuanGUI
            // 
            this.thongQuanGUI.TopLevel = false;
            this.thongQuanGUI.ClientSize = new System.Drawing.Size(1371, 699);
            this.thongQuanGUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thongQuanGUI.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.thongQuanGUI.Location = new System.Drawing.Point(0, 0);
            this.thongQuanGUI.Margin = new System.Windows.Forms.Padding(4);
            this.thongQuanGUI.Name = "thongQuanGUI";
            this.thongQuanGUI.Text = "Thống Kê Tổng Quan";
            this.thongQuanGUI.Visible = false;
            // 
            // tonKhoGUI
            // 
            this.tonKhoGUI.TopLevel = false;
            this.tonKhoGUI.ClientSize = new System.Drawing.Size(1371, 699);
            this.tonKhoGUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tonKhoGUI.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.tonKhoGUI.Location = new System.Drawing.Point(0, 0);
            this.tonKhoGUI.Margin = new System.Windows.Forms.Padding(4);
            this.tonKhoGUI.Name = "thongQuanGUI";
            this.tonKhoGUI.Text = "Thống Kê Tồn Kho";
            this.tonKhoGUI.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1379, 728);
            this.tabControl1.TabIndex = 0;
            // 
            // ThongKeGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 746);
            this.Controls.Add(this.tabControl1);
            this.Name = "ThongKeGUI";
            this.Text = "ThongKeGUI";
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private ThongKeTongQuanGUI thongQuanGUI;
        private ThongKeTonKho tonKhoGUI;
       
    }
}