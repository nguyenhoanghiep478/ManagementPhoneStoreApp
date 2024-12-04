using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using Service;
using Service.impl;

namespace ManagementPhoneStore
{
    public partial class PhanQuyenDialog : Form
    {
        private INhomQuyenService nhomQuyenService = NhomQuyenService.Instace;
        private List<DanhMucChucNang> chucnangs;
        private NhomQuyen nhomquyen;


        public PhanQuyenDialog()
        {
            InitializeComponent();
            LoadData();
        }

        public PhanQuyenDialog(NhomQuyen nhomQuyen)
        {
            InitializeComponent();
            LoadData(nhomQuyen);
        }
        private void LoadData(NhomQuyen nhomQuyen)
        {
            this.nhomquyen = nhomQuyen;
            this.add.Text = "Cập nhật nhóm quyền";

            chucnangs = nhomQuyenService.getAllDanhMucChucNang();
            this.dgvPermissions.Rows.Clear();
            foreach (var chucnangs in chucnangs)
            {
               
                List<ChiTietQuyen> ctquyen = this.nhomQuyenService.GetChiTietQuyen((int)nhomQuyen.Manhomquyen);
                List<ChiTietQuyen> filterHanhDong = ctquyen.Where(ct => ct.MaChucNang.Equals(chucnangs.MaChucNang)).ToList();

                Boolean isHaveView = false,isHaveCreate = false,isHaveUpdate = false,isHaveDelete = false;
                
                if(filterHanhDong.Count >0)
                {
                    isHaveView = filterHanhDong.Any(ct => ct.HanhDong.Equals("view"));
                    isHaveCreate = filterHanhDong.Any(ct => ct.HanhDong.Equals("create"));
                    isHaveUpdate = filterHanhDong.Any(ct => ct.HanhDong.Equals("update"));
                    isHaveDelete = filterHanhDong.Any(ct => ct.HanhDong.Equals("delete"));
                }

                this.dgvPermissions.Rows.Add(chucnangs.MaChucNang, isHaveView, isHaveCreate, isHaveUpdate, isHaveDelete);
            }
        }


        private void LoadData()
        {
            chucnangs = nhomQuyenService.getAllDanhMucChucNang();
            this.dgvPermissions.Rows.Clear();
            foreach (var chuc in chucnangs)
            {
                this.dgvPermissions.Rows.Add(chuc.MaChucNang, false, false, false, false);
            }
        }

        private void PhanQuyenDialog_Load(object sender, EventArgs e)
        {

        }

        private void phanQuyenTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void phanQuyenLabel_Click(object sender, EventArgs e)
        {

        }

        private void tableLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvPermissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            string groupName = this.phanQuyenTextBox.Text.Trim();

            string action = "";
            if(this.nhomquyen == null)
            {
                action = "Thêm";
            }
            else
            {
                if (string.IsNullOrEmpty(groupName))
                {
                    groupName = nhomquyen.Tennhomquyen;
                }
                action = "Cập Nhật";
            }

            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn " +action + " không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Kiểm tra tên nhóm quyền có được nhập chưa
                if (string.IsNullOrEmpty(groupName))
                {
                    MessageBox.Show(
                        "Yêu cầu nhập tên nhóm quyền!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
               if(nhomquyen == null)
                {
                    if (nhomQuyenService.checkDup(groupName))
                    {
                        MessageBox.Show(
                           "Nhóm quyền đã tồn tại!",
                           "Thông báo",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning
                       );
                        return;
                    }
                }
                // Lấy toàn bộ thông tin quyền từ DataGridView
                var permissions = new List<ChiTietQuyen>();

                foreach (DataGridViewRow row in dgvPermissions.Rows)
                {
                    if (row.Cells["colFunction"].Value != null)
                    {
                     
                        int maNhomQuyen = nhomQuyenService.getIncreasementId();
                        if(nhomquyen != null)
                        {
                            maNhomQuyen -= 1;
                        }

                        string tenChucNang = row.Cells["colFunction"].Value.ToString();
                        Boolean CanView = Convert.ToBoolean(row.Cells["colView"].Value);
                        Boolean CanCreate = Convert.ToBoolean(row.Cells["colCreate"].Value);
                        Boolean CanUpdate = Convert.ToBoolean(row.Cells["colUpdate"].Value);
                        Boolean CanDelete = Convert.ToBoolean(row.Cells["colDelete"].Value);
                        if (CanView)
                        {
                            ChiTietQuyen chiTietQuyen = new ChiTietQuyen();
                            chiTietQuyen.MaNhomQuyen = maNhomQuyen;
                            chiTietQuyen.MaChucNang = tenChucNang;
                            chiTietQuyen.HanhDong = "view";
                            permissions.Add(chiTietQuyen);
                        }
                        if (CanCreate)
                        {
                            ChiTietQuyen chiTietQuyen = new ChiTietQuyen();
                            chiTietQuyen.MaNhomQuyen = maNhomQuyen;
                            chiTietQuyen.MaChucNang = tenChucNang;
                            chiTietQuyen.HanhDong = "create";
                            permissions.Add(chiTietQuyen);
                        }
                        if (CanUpdate)
                        {
                            ChiTietQuyen chiTietQuyen = new ChiTietQuyen();
                            chiTietQuyen.MaNhomQuyen = maNhomQuyen;
                            chiTietQuyen.MaChucNang = tenChucNang;
                            chiTietQuyen.HanhDong = "update";
                            permissions.Add(chiTietQuyen);
                        }
                        if (CanDelete)
                        {
                            ChiTietQuyen chiTietQuyen = new ChiTietQuyen();
                            chiTietQuyen.MaNhomQuyen = maNhomQuyen;
                            chiTietQuyen.MaChucNang = tenChucNang;
                            chiTietQuyen.HanhDong = "delete";
                            permissions.Add(chiTietQuyen);
                        }
                    }
                }
                if(this.nhomquyen == null)
                {
                    this.nhomQuyenService.Add(groupName, permissions);
                }
                else
                {
              
                    this.nhomQuyenService.Update(this.nhomquyen, permissions,nhomQuyenService.getIndexByMaNhomQuyen((int)nhomquyen.Manhomquyen),groupName);
                }


            }
            else
            {
                return;
            }
            MessageBox.Show(action + " Nhóm quyền thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();


        }

       


        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn hủy không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
               this.DialogResult= DialogResult.Cancel;
                this.Close();
            }

        }
    }
}
