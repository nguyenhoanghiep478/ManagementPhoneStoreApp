using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class ThuongHieuService : IThuongHieuService
    {
        private List<ThuongHieu> thuongHieuList;
        private static ThuongHieuService instance=null;
        private ThuongHieuDAO dao;
        private static readonly object lockObj = new object();

        private ThuongHieuService()
        {
          
            dao = new ThuongHieuDAO();
            thuongHieuList = dao.GetAll();
        }
        public static ThuongHieuService Instance
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
                            instance = new ThuongHieuService();
                        }
                    }
                }
                return instance;
            }
        }
       

       

        public bool Delete(ThuongHieu lh)
        {
            if (!thuongHieuList.Contains(lh))
            {
                return false;
            }
            dao.delete(lh.Mathuonghieu);
            thuongHieuList.Remove(lh);
            return true;
        }

        public List<ThuongHieu> GetAll()
        {
            return thuongHieuList;
        }

        public string[] GetArrTenThuongHieu()
        {
            string[]kq=new string[thuongHieuList.Count];
            for(int i = 0;i<thuongHieuList.Count;i++)
            {
                kq[i] = thuongHieuList[i].Tenthuonghieu;
            }
            return kq;
        }

        public ThuongHieu GetByIndex(int index)
        {
            return thuongHieuList[index];
        }

        public int GetIndexByMaLH(int maloaihang)
        {
            for(int i = 0; i < thuongHieuList.Count; i++)
            {
                if (thuongHieuList[i].Mathuonghieu.Equals(maloaihang))
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetTenThuongHieu(int mathuonghieu)
        {
            for (int i = 0; i < thuongHieuList.Count; i++)
            {
                if (thuongHieuList[i].Mathuonghieu.Equals(mathuonghieu))
                {
                    return thuongHieuList[i].Tenthuonghieu;
                }
            }
            return "";
        }

        public List<ThuongHieu> Search(string text)
        {
           return dao.FindLikeName(text);
        }

        public bool Update(ThuongHieu lh)
        {
           

            for(int i = 0; i < thuongHieuList.Count; i++)
            {
                if (thuongHieuList[i].Mathuonghieu.Equals(lh.Mathuonghieu))
                {
                    dao.update(lh);
                    thuongHieuList[i] = lh;
                    return true;
                }
            }
            return false;
        }

        public bool CheckDup(string name)
        {
           foreach(ThuongHieu th in thuongHieuList)
            {
                if(th.Tenthuonghieu == name) return true;
            }
            return false;
        }

        public bool Add(ThuongHieu th)
        {
            if (!CheckDup(th.Tenthuonghieu)&&dao.insert(th)>0)
            {
                thuongHieuList.Add(th);

            }
            return false;
        }
    }
}
