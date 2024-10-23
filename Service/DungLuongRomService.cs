using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DungLuongRomService : IDungLuongRomService
    {
        private List<DLRom> dLRomList;
        private static DungLuongRomService instance = null;
        private DLRomDAO dLRomDAO;
        private static readonly object lockObj = new object();

        public List<DLRom> getAll()
        {
            return dLRomList;
        }

        public DLRom getByIndex(int index)
        {
            return dLRomList[index];
        }

        public int getIndexByMaRom(int marom)
        {
            for (int i = 0; i < dLRomList.Count; i++)
            {
                if (dLRomList[i].Madlrom.Equals(marom))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool add(DLRom rom)
        {
            dLRomList.Add(rom);
            if (!isDuplicate(rom.Kichthuocrom) && dLRomDAO.insert(rom) > 0)
            {
                return true;
            }
            return false;
        }

        public bool remove(DLRom rom, int index)
        {
            if (!dLRomList.Contains(rom))
            {
                return false;
            }
            dLRomList.RemoveAt(index);
            dLRomDAO.delete(rom.Madlrom);
            return true;
        }

        public int getKichThuocById(int marom)
        {
            for (int i = 0; i < dLRomList.Count; i++)
            {
                if (dLRomList[i].Madlrom.Equals(marom))
                {
                    return dLRomList[i].Kichthuocrom;
                }
            }
            return -1;
        }

        public bool isDuplicate(int dungluongrom)
        {
            foreach (DLRom rom in dLRomList)
            {
                if (rom.Kichthuocrom.Equals(dungluongrom))
                {
                    return true;
                }
            }
            return false;
        }

        public string[] getArrKichThuoc()
        {
            string[] kq = new string[dLRomList.Count];
            for (int i = 0; i < dLRomList.Count; i++)
            {
                kq[i] = Convert.ToString(dLRomList[i].Kichthuocrom);
            }
            return kq;
        }
    }
}
