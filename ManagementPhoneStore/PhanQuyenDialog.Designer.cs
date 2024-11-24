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
            this.phanQuyenLabel.Location = new System.Drawing.Point(96, 52);
            this.phanQuyenLabel.Name = "phanQuyenLabel";
            this.phanQuyenLabel.Size = new System.Drawing.Size(107, 16);
            this.phanQuyenLabel.TabIndex = 0;
            this.phanQuyenLabel.Text = "Tên nhóm quyền";
            this.phanQuyenLabel.Click += new System.EventHandler(this.phanQuyenLabel_Click);
            // 
            // phanQuyenTextBox
            // 
            this.phanQuyenTextBox.Location = new System.Drawing.Point(235, 33);
            this.phanQuyenTextBox.Multiline = true;
            this.phanQuyenTextBox.Name = "phanQuyenTextBox";
            this.phanQuyenTextBox.Size = new System.Drawing.Size(1014, 46);
            this.phanQuyenTextBox.TabIndex = 0;
            // 
            // dgvPermissions
            // 
            this.dgvPermissions.AllowUserToAddRows = false;
            this.dgvPermissions.AllowUserToOrderColumns = true;
            this.dgvPermissions.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermissions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPermissions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPermissions.ColumnHeadersHeight = 29;
            this.dgvPermissions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFunction,
            this.colView,
            this.colCreate,
            this.colUpdate,
            this.colDelete});
            this.dgvPermissions.GridColor = System.Drawing.Color.White;
            this.dgvPermissions.Location = new System.Drawing.Point(12, 146);
            this.dgvPermissions.Name = "dgvPermissions";
            this.dgvPermissions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPermissions.RowHeadersWidth = 51;
            this.dgvPermissions.Size = new System.Drawing.Size(1266, 332);
            this.dgvPermissions.TabIndex = 1;
            this.dgvPermissions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermissions_CellContentClick);
            // 
            // colFunction
            // 
            this.colFunction.HeaderText = "Danh mục chức năng";
            this.colFunction.MinimumWidth = 6;
            this.colFunction.Name = "colFunction";
            this.colFunction.ReadOnly = true;
            this.colFunction.Width = 200;
            // 
            // colView
            // 
            this.colView.HeaderText = "Xem";
            this.colView.MinimumWidth = 6;
            this.colView.Name = "colView";
            this.colView.Width = 80;
            // 
            // colCreate
            // 
            this.colCreate.HeaderText = "Tạo mới";
            this.colCreate.MinimumWidth = 6;
            this.colCreate.Name = "colCreate";
            this.colCreate.Width = 80;
            // 
            // colUpdate
            // 
            this.colUpdate.HeaderText = "Cập nhật";
            this.colUpdate.MinimumWidth = 6;
            this.colUpdate.Name = "colUpdate";
            this.colUpdate.Width = 80;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "Xóa";
            this.colDelete.MinimumWidth = 6;
            this.colDelete.Name = "colDelete";
            this.colDelete.Width = 80;
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add.ForeColor = System.Drawing.SystemColors.Window;
            this.add.Location = new System.Drawing.Point(496, 497);
            this.add.Margin = new System.Windows.Forms.Padding(0);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(157, 50);
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
            this.cancel.Location = new System.Drawing.Point(720, 496);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(156, 50);
            this.cancel.TabIndex = 11;
            this.cancel.Text = "HỦY BỎ";
            this.cancel.UseVisualStyleBackColor = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // PhanQuyenDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 582);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.add);
            this.Controls.Add(this.phanQuyenTextBox);
            this.Controls.Add(this.phanQuyenLabel);
            this.Controls.Add(this.dgvPermissions);
            this.Name = "PhanQuyenDialog";
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