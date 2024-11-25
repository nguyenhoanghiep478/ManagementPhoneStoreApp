namespace GUI
{
    partial class ImeiSelection
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
            this.list = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.findImei = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(0, 106);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(333, 395);
            this.list.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.findImei);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.list);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 569);
            this.panel1.TabIndex = 3;
            // 
            // findImei
            // 
            this.findImei.Dock = System.Windows.Forms.DockStyle.Top;
            this.findImei.Location = new System.Drawing.Point(0, 0);
            this.findImei.Name = "findImei";
            this.findImei.Size = new System.Drawing.Size(333, 107);
            this.findImei.TabIndex = 3;
            this.findImei.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(107, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ImeiSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 569);
            this.Controls.Add(this.panel1);
            this.Name = "ImeiSelection";
            this.Text = "ImeiSelection";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox list;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox findImei;
        private System.Windows.Forms.Button button1;
    }
}