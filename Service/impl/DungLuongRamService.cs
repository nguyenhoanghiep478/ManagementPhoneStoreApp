using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DungLuongRamService : IDungLuongRamService
    {
        private List<DLRam> dLRamList;
        private static DungLuongRamService instance = null;
        private DLRamDAO dlRamDAO;
        private static readonly object lockObj = new object();
        public bool add(DLRam ram)
        {
            dLRamList.Add(ram);
            if (!isDuplicate(ram.Kichthuocram)&& dlRamDAO.insert(ram) > 0)
            {
                return true;
            }
            return false;
            
        }

        public List<DLRam> getAll()
        {
            return dLRamList;
        }

        public string[] getArrKichThuoc()
        {
            string[] kq = new string[dLRamList.Count];
            for (int i = 0; i < dLRamList.Count; i++)
            {
                kq[i] =Convert.ToString( dLRamList[i].Kichthuocram);
            }
            return kq;
        }

        public DLRam getByIndex(int index)
        {
            return dLRamList[index];
        }

        public int getIndexByMaRam(int maRam)
        {
            for (int i = 0; i < dLRamList.Count; i++)
            {
                if (dLRamList[i].Madlram.Equals(maRam))
                {
                    return i;
                }
            }
            return -1;
        }

        public int getKichThuocById(int maRam)
        {
            for (int i = 0; i < dLRamList.Count; i++)
            {
                if (dLRamList[i].Madlram.Equals(maRam))
                {
                    return dLRamList[i].Kichthuocram;
                }
            }
            return -1;
        }

        public bool isDuplicate(int kichthuoc)
        {
            foreach (DLRam ram in dLRamList)
            {
                if (ram.Kichthuocram.Equals(kichthuoc))
                {
                    return true;
                }
            }
            return false;
        }

        public bool remove(DLRam ram, int index)
        {
            if (!dLRamList.Contains(ram))
            {
                return false;
            }
            dLRamList.RemoveAt(index);
            dlRamDAO.delete(ram.Madlram);
            return true;
        }
       
    }
}
