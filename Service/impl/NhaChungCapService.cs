using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class NhaChungCapService : INhaCungCapService
    {
        private List<NhaCungCap> nhaCungCapList;
        private static NhaChungCapService instance = null;
        private NhaCungCapDAO dao;
        private static readonly object lockObj = new object();

        public NhaChungCapService()
        {

            dao = new NhaCungCapDAO();
            nhaCungCapList = dao.GetAll().Where(ncc=>ncc.Trangthai.Equals(1)).ToList();
        }

        public int getIncreasementId()
        {
            return nhaCungCapList.Count+1;
        }
        public static NhaChungCapService Instance
        {
            get
            {
                // Đảm bảo việc khởi tạo instance là thread-safe.
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new NhaChungCapService();
                        }
                    }
                }
                return instance;
            }
        }
       
       
        public bool CheckDup(string name)
        {
            foreach (NhaCungCap th in nhaCungCapList)
            {
                if (th.Tennhacungcap == name) return true;
            }
            return false;
        }

        public bool Add(NhaCungCap nhaCungCap)
        {
            long i = 0;
            i = dao.insert(nhaCungCap);
            if (!CheckDup(nhaCungCap.Tennhacungcap)&&i>0)
            {
                nhaCungCap.Manhacungcap = (int)i;
                nhaCungCapList.Add(nhaCungCap);
                return true;
            }
            return false;
        }
        public bool Delete(NhaCungCap ncc, int index)
        {
            if (!nhaCungCapList.Contains(ncc))
            {
                return false;
            }
            dao.delete((long)ncc.Manhacungcap);
            nhaCungCapList.RemoveAt(index);
            return true;
        }

        public NhaCungCap FindCT(List<NhaCungCap> ncc, string tenncc)
        {
            for(int i = 0; i < ncc.Count; i++)
            {
                if (ncc[i].Tennhacungcap.Equals(tenncc))
                {
                    return ncc[i];
                }
            }
            return new NhaCungCap();
        }

        public List<NhaCungCap> GetAll()
        {
            return nhaCungCapList;
        }

        public string[] GetArrTenNhaCungCap()
        {
            string[] kq = new string[nhaCungCapList.Count];
            for (int i = 0; i < nhaCungCapList.Count; i++)
            {
                kq[i] = nhaCungCapList[i].Tennhacungcap;
            }
            return kq;
        }

        public NhaCungCap GetByIndex(int index)
        {
            return nhaCungCapList[(int)index];
        }

        public int GetIndexByMaNCC(int mancc)
        {
            for (int i = 0; i < nhaCungCapList.Count; i++)
            {
                if (nhaCungCapList[i].Manhacungcap.Equals(mancc))
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetTenNhaCungCap(int mancc)
        {
            for (int i = 0; i <nhaCungCapList.Count; i++)
            {
                if (nhaCungCapList[i].Manhacungcap.Equals(mancc))
                {
                    return nhaCungCapList[i].Tennhacungcap;
                }
            }
            return "";
        }

        public List<NhaCungCap> Search(string txt, string type)
        {
            List<NhaCungCap> ketQua = new List<NhaCungCap>();
            txt = txt.Trim().ToLower();
            // Dựa trên 'type', thực hiện tìm kiếm theo các thuộc tính khác nhau
            switch (type)
            {
                case "Tất cả":
                    // Tìm kiếm theo Mã nhà cung cấp, Tên nhà cung cấp, Địa chỉ, Email, Số điện thoại
                    ketQua = nhaCungCapList.Where(ncc =>
                    ncc.Manhacungcap.ToString().Equals(Convert.ToInt32(txt)) ||  // Tìm theo Mã nhà cung cấp
                    ncc.Tennhacungcap.ToLower().Contains(txt) ||  // Tìm theo Tên nhà cung cấp
                    ncc.Diachi.ToLower().Contains(txt) ||  // Tìm theo Địa chỉ
                    ncc.Email.ToLower().Contains(txt) ||  // Tìm theo Email
                        ncc.Sdt.Contains(txt)  // Tìm theo Số điện thoại
                    ).ToList();
                    break;
                case "Mã ncc":
                    // Kiểm tra nếu giá trị nhập là số
                    if (int.TryParse(txt, out int maNCC))
                    {
                        // Tìm kiếm theo Mã nhà cung cấp
                        ketQua = nhaCungCapList.Where(ncc => ncc.Manhacungcap.Equals(maNCC)).ToList();
                    }
                   
                    break;
                case "Tên ncc":
                    // Tìm kiếm theo tên nhà cung cấp
                    ketQua = nhaCungCapList.Where(ncc => ncc.Tennhacungcap.ToLower().Contains(txt)).ToList();
                    break;

                case "Địa chỉ":
                    // Tìm kiếm theo địa chỉ
                    ketQua = nhaCungCapList.Where(ncc => ncc.Diachi.ToLower().Contains(txt)).ToList();
                    break;

                case "Email":
                    // Tìm kiếm theo email
                    ketQua = nhaCungCapList.Where(ncc => ncc.Email.ToLower().Contains(txt)).ToList();
                    break;
                case "Số điện thoại":
                    // Tìm kiếm theo số điện thoại
                    ketQua = nhaCungCapList.Where(ncc => ncc.Sdt.Contains(txt)).ToList();
                    break;
                default:
                    ketQua = nhaCungCapList;
                    break;
            }

            return ketQua;
        } 

        public bool Update(NhaCungCap ncc)
        {
            for (int i = 0; i <nhaCungCapList.Count; i++)
            {
                if (nhaCungCapList[i].Manhacungcap.Equals(ncc.Manhacungcap))
                {
                    dao.update(ncc);
                    nhaCungCapList[i] = ncc;
                    return true;
                }
            }
            return false;
        }
    }
}
