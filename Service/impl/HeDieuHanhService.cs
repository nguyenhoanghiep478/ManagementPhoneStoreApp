using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class HeDieuHanhService : IHeDieuHanhService
    {
        private List<HeDieuHanh> heDieuHanhList;
        private static HeDieuHanhService instance = null;
        private HeDieuHanhDAO heDieuHanhDao;
        private static readonly object lockObj = new object();
        public bool add(HeDieuHanh hdh)
        {
            
            if (!isDuplicate(hdh.Tenhedieuhanh) && heDieuHanhDao.insert(hdh) > 0)
            {
                heDieuHanhList.Add(hdh);
                return true;
            }
            return false;
        }

        public List<HeDieuHanh> getAll()
        {
            return heDieuHanhList;
        }

        public string[] getAllTenHeDieuHanh()
        {
            string[] kq = new string[heDieuHanhList.Count];
            for (int i = 0; i < heDieuHanhList.Count; i++)
            {
                kq[i] = Convert.ToString(heDieuHanhList[i].Tenhedieuhanh);
            }
            return kq;
        }

        public HeDieuHanh getByIndex(int index)
        {
            return heDieuHanhList[index];
        }

        public int getIndexByMaHdh(int mahdhd)
        {
            for (int i = 0; i < heDieuHanhList.Count; i++)
            {
                if (heDieuHanhList[i].Mahedieuhanh.Equals(mahdhd))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool isDuplicate(string name)
        {
            foreach (HeDieuHanh hdh in heDieuHanhList)
            {
                if (hdh.Tenhedieuhanh.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        public bool remove(HeDieuHanh hdh, int index)
        {
            if (heDieuHanhList.Contains(hdh))
            {
                return false;
            }
            heDieuHanhDao.delete((long)hdh.Mahedieuhanh);
            heDieuHanhList.RemoveAt(index);
            return true;
        }
    }
}
