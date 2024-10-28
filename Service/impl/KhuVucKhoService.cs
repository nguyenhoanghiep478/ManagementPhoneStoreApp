using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class KhuVucKhoService :IKhuVucKhoService
    {
        private List<KhuVucKho> listKhuVucKho;
        private static KhuVucKhoService instance = null;
        private KhuVucKhoDAO dao;
        private static readonly object lockObj = new object();

        private KhuVucKhoService()
        {

            dao = new KhuVucKhoDAO();
            listKhuVucKho= dao.GetAll();
        }
        public static KhuVucKhoService Instance
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
                            instance = new KhuVucKhoService();
                        }
                    }
                }
                return instance;
            }
        }

        public List<KhuVucKho> GetAll()
        {
           return listKhuVucKho;
        }

        public KhuVucKho GetByIndex(int index)
        {
            return listKhuVucKho[index];
        }

        public int GetIndexByMaKVK(int makhuvuc)
        {
            for (int i = 0; i < listKhuVucKho.Count; i++)
            {
                if (listKhuVucKho[i].Makhuvuc.Equals(makhuvuc))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Add(KhuVucKho kvk)
        {
            if (!CheckDup(kvk.Tenkhuvuc)&&dao.insert(kvk)>0)
            {
                listKhuVucKho.Add(kvk);
                return true;
            }
            return false;
        }
        public bool CheckDup(string name)
        {
            foreach (KhuVucKho kv in listKhuVucKho)
            {
                if (kv.Tenkhuvuc == name) return true;
            }
            return false;
        }

        public bool Delete(KhuVucKho kvk, int index)
        {
            if (!listKhuVucKho.Contains(kvk))
            {
                return false;
            }
            dao.delete((long)kvk.Makhuvuc);
            listKhuVucKho.RemoveAt(index);
            return true;
        }

        public bool Update(KhuVucKho kvk)
        {
            for (int i = 0; i <listKhuVucKho.Count; i++)
            {
                if (listKhuVucKho[i].Makhuvuc.Equals(kvk.Makhuvuc))
                {
                    dao.update(kvk);
                    listKhuVucKho[i] = kvk;
                    return true;
                }
            }
            return false;
        }

        public List<KhuVucKho> Search(string txt, string type)
        {
            List<KhuVucKho> ketQua = new List<KhuVucKho>();

            // Dựa trên 'type', thực hiện tìm kiếm theo các thuộc tính khác nhau
            switch (type.ToLower())
            {


                case "makhuvuc":
                    // Tìm kiếm theo ma khuvuckho
                    ketQua = listKhuVucKho.Where(ncc => ncc.Makhuvuc.Equals(Convert.ToInt32(txt))).ToList();
                    break;
                case "tenkhuvuc":
                    // Tìm kiếm theo tên khuvuckho
                    ketQua = listKhuVucKho.Where(ncc => ncc.Tenkhuvuc.Contains(txt)).ToList();
                    break;

                case "ghichu":
                    // Tìm kiếm theo ghichu khuvuckho
                    ketQua = listKhuVucKho.Where(ncc => ncc.Ghichu.Contains(txt)).ToList();
                    break;

                case "trangthai":
                    // Tìm kiếm theo trangthai khuvuckho
                    ketQua = listKhuVucKho.Where(ncc => ncc.Trangthai.Equals(Convert.ToInt32(txt))).ToList();
                    break;

                default:
                    ketQua =listKhuVucKho;
                    break;
            }

            return ketQua;
        }

        public string[] GetArrTenKhuVuc()
        {
            string[] kq = new string[listKhuVucKho.Count];
            for (int i = 0; i < listKhuVucKho.Count; i++)
            {
                kq[i] = listKhuVucKho[i].Tenkhuvuc;
            }
            return kq;
        }
    }
}
