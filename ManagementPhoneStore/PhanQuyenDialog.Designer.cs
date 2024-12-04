using System.Windows.Forms;

namespace ManagementPhoneStore
{
    partial class PhanQuyenDialog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.phanQuyenLabel = new System.Windows.Forms.Label();
            this.phanQuyenTextBox = new System.Windows.Forms.TextBox();
            this.dgvPermissions = new System.Windows.Forms.DataGridView();
            this.colFunction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colView = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCreate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.add = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).BeginInit();
            this.SuspendLayout();
            // 
            // phanQuyenLabel
            // 
            this.phanQuyenLabel.AutoSize = true;
            this.phanQuyenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phanQuyenLabel.Location = new System.Drawing.Point(11, 36);
            this.phanQuyenLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phanQuyenLabel.Name = "phanQuyenLabel";
            this.phanQuyenLabel.Size = new System.Drawing.Size(127, 20);
            this.phanQuyenLabel.TabIndex = 0;
            this.phanQuyenLabel.Text = "Tên nhóm quyền";
            this.phanQuyenLabel.Click += new System.EventHandler(this.phanQuyenLabel_Click);
            // 
            // phanQuyenTextBox
            // 
            this.phanQuyenTextBox.Location = new System.Drawing.Point(142, 27);
            this.phanQuyenTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.phanQuyenTextBox.Multiline = true;
            this.phanQuyenTextBox.Name = "phanQuyenTextBox";
            this.phanQuyenTextBox.Size = new System.Drawing.Size(416, 38);
            this.phanQuyenTextBox.TabIndex = 0;
            // 
            // dgvPermissions
            // 
            this.dgvPermissions.AllowUserToAddRows = false;
            this.dgvPermissions.AllowUserToOrderColumns = true;
            this.dgvPermissions.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermissions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPermissions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPermissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPermissions.ColumnHeadersHeight = 29;
            this.dgvPermissions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFunction,
            this.colView,
            this.colCreate,
            this.colUpdate,
            this.colDelete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPermissions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPermissions.GridColor = System.Drawing.Color.White;
            this.dgvPermissions.Location = new System.Drawing.Point(11, 94);
            this.dgvPermissions.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPermissions.Name = "dgvPermissions";
            this.dgvPermissions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPermissions.RowHeadersWidth = 51;
            this.dgvPermissions.Size = new System.Drawing.Size(950, 284);
            this.dgvPermissions.TabIndex = 1;
            this.dgvPermissions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermissions_CellContentClick);
            // 
            // colFunction
            // 
            this.colFunction.HeaderText = "Danh mục chức năng";
            this.colFunction.MinimumWidth = 6;
            this.colFunction.Name = "colFunction";
            this.colFunction.ReadOnly = true;
            this.colFunction.Width = 495;
            // 
            // colView
            // 
            this.colView.HeaderText = "Xem";
            this.colView.MinimumWidth = 6;
            this.colView.Name = "colView";
            // 
            // colCreate
            // 
            this.colCreate.HeaderText = "Tạo mới";
            this.colCreate.MinimumWidth = 6;
            this.colCreate.Name = "colCreate";
            // 
            // colUpdate
            // 
            this.colUpdate.HeaderText = "Cập nhật";
            this.colUpdate.MinimumWidth = 6;
            this.colUpdate.Name = "colUpdate";
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "Xóa";
            this.colDelete.MinimumWidth = 6;
            this.colDelete.Name = "colDelete";
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.ForeColor = System.Drawing.SystemColors.Window;
            this.add.Location = new System.Drawing.Point(269, 404);
            this.add.Margin = new System.Windows.Forms.Padding(0);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(189, 41);
            this.add.TabIndex = 10;
            this.add.Text = "THÊM NHÓM QUYỀN";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // cancel
            // 
            this.cancel.BackColor = System.Drawing.Color.IndianRed;
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.ForeColor = System.Drawing.SystemColors.Window;
            this.cancel.Location = new System.Drawing.Point(505, 403);
            this.cancel.Margin = new System.Windows.Forms.Padding(2);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(189, 41);
            this.cancel.TabIndex = 11;
            this.cancel.Text = "HỦY BỎ";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // PhanQuyenDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(973, 472);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.add);
            this.Controls.Add(this.phanQuyenTextBox);
            this.Controls.Add(this.phanQuyenLabel);
            this.Controls.Add(this.dgvPermissions);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PhanQuyenDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhanQuyenDialog";
            this.Load += new System.EventHandler(this.PhanQuyenDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox phanQuyenTextBox;
        private System.Windows.Forms.Label phanQuyenLabel;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.DataGridView dgvPermissions;

        #endregion

        private DataGridViewTextBoxColumn colFunction;
        private DataGridViewCheckBoxColumn colView;
        private DataGridViewCheckBoxColumn colCreate;
        private DataGridViewCheckBoxColumn colUpdate;
        private DataGridViewCheckBoxColumn colDelete;
        private Button add;
        private Button cancel;
    }
}