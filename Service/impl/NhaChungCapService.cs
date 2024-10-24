using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class NhaChungCapService : INhaCungCapService
    {
        private List<NhaCungCap> nhaCungCapList;
        private static NhaChungCapService instance = null;
        private NhaCungCapDAO dao;
        private static readonly object lockObj = new object();

        private NhaChungCapService()
        {

            dao = new NhaCungCapDAO();
            nhaCungCapList = dao.GetAll();
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
            if (!CheckDup(nhaCungCap.Tennhacungcap)&&dao.insert(nhaCungCap)>0)
            {
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
            dao.delete(ncc.Manhacungcap);
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

            // Dựa trên 'type', thực hiện tìm kiếm theo các thuộc tính khác nhau
            switch (type.ToLower())
            {
                case "manhacungcap":
                    // Tìm kiếm theo tên nhà cung cấp
                    ketQua = nhaCungCapList.Where(ncc => ncc.Manhacungcap.Equals(Convert.ToInt32(txt))).ToList();
                    break;
                case "tennhacungcap":
                    // Tìm kiếm theo tên nhà cung cấp
                    ketQua = nhaCungCapList.Where(ncc => ncc.Tennhacungcap.Contains(txt)).ToList();
                    break;

                case "diachi":
                    // Tìm kiếm theo địa chỉ
                    ketQua = nhaCungCapList.Where(ncc => ncc.Diachi.Contains(txt)).ToList();
                    break;

                case "email":
                    // Tìm kiếm theo email
                    ketQua = nhaCungCapList.Where(ncc => ncc.Email.Contains(txt)).ToList();
                    break;
                case "sdt":
                    // Tìm kiếm theo số điện thoại
                    ketQua = nhaCungCapList.Where(ncc => ncc.Sdt.Contains(txt)).ToList();
                    break;
                case "trangthai":
                    // Tìm kiếm theo số điện thoại
                    ketQua = nhaCungCapList.Where(ncc => ncc.Trangthai.Equals(Convert.ToInt32(txt))).ToList();
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
