using System.Windows.Forms;
using System;
using System.Drawing;
using DocumentFormat.OpenXml.Office.CustomUI;

namespace ManagementPhoneStore
{
    partial class Log_InGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Log_InGUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelResetPasswordButtons = new System.Windows.Forms.Panel();
            this.panelForgotUsername = new System.Windows.Forms.Panel();
            this.textBoxForgotUsername = new System.Windows.Forms.TextBox();
            this.panelForgotButtons = new System.Windows.Forms.Panel();
            this.buttonRecover = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panelOTPCountDown = new System.Windows.Forms.Panel();
            this.labelCountdown = new System.Windows.Forms.Label();
            this.panelOTPInput = new System.Windows.Forms.Panel();
            this.textBoxOTP = new System.Windows.Forms.TextBox();
            this.panelOTPButtons = new System.Windows.Forms.Panel();
            this.buttonOTPConfirm = new System.Windows.Forms.Button();
            this.buttonOTPBack = new System.Windows.Forms.Button();
            this.buttonResetPasswordConfirm = new System.Windows.Forms.Button();
            this.buttonResetBack = new System.Windows.Forms.Button();
            this.labelForgotPassword = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelForgotUsername.SuspendLayout();
            this.panelForgotButtons.SuspendLayout();
            this.panelOTPInput.SuspendLayout();
            this.panelOTPButtons.SuspendLayout();
            this.panelResetPasswordButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.labelCountdown);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panelForgotUsername);
            this.panel1.Controls.Add(this.panelForgotButtons);
            this.panel1.Controls.Add(this.panelOTPCountDown);
            this.panel1.Controls.Add(this.panelOTPInput);
            this.panel1.Controls.Add(this.panelOTPButtons);
            this.panel1.Controls.Add(this.panelResetPasswordButtons);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1309, 564);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Location = new System.Drawing.Point(747, 268);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(486, 52);
            this.panel3.TabIndex = 9;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(20, 16);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '•';
            this.textBox2.Size = new System.Drawing.Size(460, 19);
            this.textBox2.TabIndex = 2;
            this.textBox2.UseSystemPasswordChar = true;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(747, 151);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(486, 52);
            this.panel2.TabIndex = 8;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(20, 16);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(460, 19);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1057, 353);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "Quên mật khẩu";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            this.label5.MouseEnter += new System.EventHandler(this.label5_MouseEnter);
            this.label5.MouseLeave += new System.EventHandler(this.label5_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(741, 406);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(491, 46);
            this.button1.TabIndex = 6;
            this.button1.Text = "ĐĂNG NHẬP";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(743, 245);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mật khẩu";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(741, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tên đăng nhập";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(685, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(611, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "ĐĂNG NHẬP VÀO HỆ THỐNG";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(673, 534);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelForgotUsername
            // 
            this.panelForgotUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForgotUsername.Controls.Add(this.textBoxForgotUsername);
            this.panelForgotUsername.Location = new System.Drawing.Point(747, 150);
            this.panelForgotUsername.Name = "panelForgotUsername";
            this.panelForgotUsername.Size = new System.Drawing.Size(486, 52);
            this.panelForgotUsername.TabIndex = 10;
            this.panelForgotUsername.Visible = false;
            // 
            // textBoxForgotUsername
            // 
            this.textBoxForgotUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxForgotUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBoxForgotUsername.Location = new System.Drawing.Point(20, 16);
            this.textBoxForgotUsername.Name = "textBoxForgotUsername";
            this.textBoxForgotUsername.Size = new System.Drawing.Size(460, 19);
            this.textBoxForgotUsername.TabIndex = 0;
            // 
            // panelForgotButtons
            // 
            this.panelForgotButtons.Controls.Add(this.buttonRecover);
            this.panelForgotButtons.Controls.Add(this.buttonBack);
            this.panelForgotButtons.Location = new System.Drawing.Point(747, 220);
            this.panelForgotButtons.Name = "panelForgotButtons";
            this.panelForgotButtons.Size = new System.Drawing.Size(486, 100);
            this.panelForgotButtons.TabIndex = 11;
            this.panelForgotButtons.Visible = false;
            // 
            // buttonRecover
            // 
            this.buttonRecover.BackColor = System.Drawing.Color.Black;
            this.buttonRecover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecover.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.buttonRecover.ForeColor = System.Drawing.Color.White;
            this.buttonRecover.Location = new System.Drawing.Point(4, 0);
            this.buttonRecover.Name = "buttonRecover";
            this.buttonRecover.Size = new System.Drawing.Size(486, 40);
            this.buttonRecover.TabIndex = 0;
            this.buttonRecover.Text = "Lấy lại mật khẩu";
            this.buttonRecover.UseVisualStyleBackColor = false;
            this.buttonRecover.Click += new System.EventHandler(this.buttonRecover_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Brown;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Location = new System.Drawing.Point(0, 50);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(486, 40);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Trở về đăng nhập";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // panelOTPCountDown
            // 
            this.panelOTPCountDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOTPCountDown.Location = new System.Drawing.Point(768, 92);
            this.panelOTPCountDown.Name = "panelOTPCountDown";
            this.panelOTPCountDown.Size = new System.Drawing.Size(440, 20);
            this.panelOTPCountDown.TabIndex = 12;
            this.panelOTPCountDown.Visible = false;
            // 
            // labelCountdown
            // 
            this.labelCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelCountdown.Location = new System.Drawing.Point(768, 92);
            this.labelCountdown.Name = "labelCountdown";
            this.labelCountdown.Size = new System.Drawing.Size(440, 20);
            this.labelCountdown.TabIndex = 1;
            this.labelCountdown.Text = "Thời gian còn lại: 05:00";
            this.labelCountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCountdown.Visible = false;    
            // 
            // panelOTPInput
            // 
            this.panelOTPInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOTPInput.Controls.Add(this.textBoxOTP);
            this.panelOTPInput.Location = new System.Drawing.Point(747, 150);
            this.panelOTPInput.Name = "panelOTPInput";
            this.panelOTPInput.Size = new System.Drawing.Size(486, 52);
            this.panelOTPInput.TabIndex = 12;
            this.panelOTPInput.Visible = false;
            this.textBoxOTP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOTP_KeyPress);
            // 
            // textBoxOTP
            // 
            this.textBoxOTP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.textBoxOTP.Location = new System.Drawing.Point(20, 20);
            this.textBoxOTP.Name = "textBoxOTP";
            this.textBoxOTP.Size = new System.Drawing.Size(440, 19);
            this.textBoxOTP.TabIndex = 0;
            // 
            // panelOTPButtons
            // 
            this.panelOTPButtons.Controls.Add(this.buttonOTPConfirm);
            this.panelOTPButtons.Controls.Add(this.buttonOTPBack);
            this.panelOTPButtons.Location = new System.Drawing.Point(747, 270);
            this.panelOTPButtons.Name = "panelOTPButtons";
            this.panelOTPButtons.Size = new System.Drawing.Size(486, 100);
            this.panelOTPButtons.TabIndex = 13;
            this.panelOTPButtons.Visible = false;
            // 
            // buttonOTPConfirm
            // 
            this.buttonOTPConfirm.BackColor = System.Drawing.Color.Green;
            this.buttonOTPConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOTPConfirm.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.buttonOTPConfirm.ForeColor = System.Drawing.Color.White;
            this.buttonOTPConfirm.Location = new System.Drawing.Point(0, 0);
            this.buttonOTPConfirm.Name = "buttonOTPConfirm";
            this.buttonOTPConfirm.Size = new System.Drawing.Size(486, 40);
            this.buttonOTPConfirm.TabIndex = 0;
            this.buttonOTPConfirm.Text = "Xác nhận";
            this.buttonOTPConfirm.UseVisualStyleBackColor = false;
            this.buttonOTPConfirm.Click += new System.EventHandler(this.ButtonOTPConfirm_Click);
            // 
            // buttonOTPBack
            // 
            this.buttonOTPBack.BackColor = System.Drawing.Color.Gray;
            this.buttonOTPBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOTPBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.buttonOTPBack.ForeColor = System.Drawing.Color.White;
            this.buttonOTPBack.Location = new System.Drawing.Point(250, 0);
            this.buttonOTPBack.Name = "buttonOTPBack";
            this.buttonOTPBack.Size = new System.Drawing.Size(486, 40);
            this.buttonOTPBack.TabIndex = 1;
            this.buttonOTPBack.Text = "Trở lại";
            this.buttonOTPBack.UseVisualStyleBackColor = false;
            this.buttonOTPBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelForgotPassword
            // 
            this.labelForgotPassword.Location = new System.Drawing.Point(0, 0);
            this.labelForgotPassword.Name = "labelForgotPassword";
            this.labelForgotPassword.Size = new System.Drawing.Size(100, 23);
            this.labelForgotPassword.TabIndex = 0;
            // 
            // panelForgotButtons
            // 
            this.panelResetPasswordButtons.Controls.Add(this.buttonResetPasswordConfirm);
            this.panelResetPasswordButtons.Controls.Add(this.buttonResetBack);
            this.panelResetPasswordButtons.Location = new System.Drawing.Point(741, 406);
            this.panelResetPasswordButtons.Name = "panelResetPassword";
            this.panelResetPasswordButtons.Size = new System.Drawing.Size(486, 100);
            this.panelResetPasswordButtons.TabIndex = 11;
            this.panelResetPasswordButtons.Visible = false;
            // 
            // buttonResetPasswordConfirm
            // 
            this.buttonResetPasswordConfirm.BackColor = System.Drawing.Color.Black;
            this.buttonResetPasswordConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetPasswordConfirm.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.buttonResetPasswordConfirm.ForeColor = System.Drawing.Color.White;
            this.buttonResetPasswordConfirm.Location = new System.Drawing.Point(4, 0);
            this.buttonResetPasswordConfirm.Name = "buttonReset";
            this.buttonResetPasswordConfirm.Size = new System.Drawing.Size(486, 40);
            this.buttonResetPasswordConfirm.TabIndex = 0;
            this.buttonResetPasswordConfirm.Text = "Cập nhật mật khẩu";
            this.buttonResetPasswordConfirm.UseVisualStyleBackColor = false;
            this.buttonResetPasswordConfirm.Click += new System.EventHandler(this.handleResetPassword);
            // 
            // buttonResetPasswordBack
            // 
            this.buttonResetBack.BackColor = System.Drawing.Color.Brown;
            this.buttonResetBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonResetBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.buttonResetBack.ForeColor = System.Drawing.Color.White;
            this.buttonResetBack.Location = new System.Drawing.Point(0, 50);
            this.buttonResetBack.Name = "buttonBack";
            this.buttonResetBack.Size = new System.Drawing.Size(486, 40);
            this.buttonResetBack.TabIndex = 1;
            this.buttonResetBack.Text = "Trở về đăng nhập";
            this.buttonResetBack.UseVisualStyleBackColor = false;
            this.buttonResetBack.Click += new System.EventHandler(this.buttonBack_Click);

            // 
            // Log_InGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 567);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Log_InGUI";
            this.Text = "Log_InGUI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelForgotUsername.ResumeLayout(false);
            this.panelForgotUsername.PerformLayout();
            this.panelForgotButtons.ResumeLayout(false);
            this.panelOTPInput.ResumeLayout(false);
            this.panelOTPInput.PerformLayout();
            this.panelOTPButtons.ResumeLayout(false);
            this.panelResetPasswordButtons.ResumeLayout(false);
            this.panelResetPasswordButtons.PerformLayout();
            this.ResumeLayout(false);

        }




        #endregion
        
        private System.Windows.Forms.Panel panelForgotUsername;
        private System.Windows.Forms.Panel panelForgotButtons;
        private System.Windows.Forms.Panel panelOTPInput;
        private System.Windows.Forms.Panel panelOTPCountDown;
        private System.Windows.Forms.Panel panelOTPButtons;
        private System.Windows.Forms.Panel panelResetPasswordButtons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelForgotPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxForgotUsername;
        private System.Windows.Forms.TextBox textBoxOTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCountdown;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonRecover;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonOTPConfirm;
        private System.Windows.Forms.Button buttonOTPBack;
        private System.Windows.Forms.Button buttonResetPasswordConfirm;
        private System.Windows.Forms.Button buttonResetBack;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox2;

    }
}