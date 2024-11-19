using DAO.DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Service.impl
{
    public class MauSacService : IMauSacService
    {
        private readonly List<MauSac> mauSacList;
        private readonly MauSacDAO mauSacDao;

        public MauSacService()
        {
            mauSacDao = new MauSacDAO();
            mauSacList = mauSacDao.GetAll();
        }

        public List<MauSac> GetAll()
        {
            mauSacList.Clear();
            mauSacList.AddRange(mauSacDao.GetAll());
            return mauSacList;
        }

        public string[] GetArrTenMauSac()
        {
            return mauSacList.Select(m => m.Tenmau).ToArray();
        }

        public MauSac GetByIndex(int index)
        {
            if (index < 0 || index >= mauSacList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
            return mauSacList[index];
        }

        public bool Add(MauSac msac)
        {
            if (CheckDup(msac.Tenmau))
            {
                return false;
            }
            long isAdded = mauSacDao.insert(msac);
            if (isAdded != 0)
            {
                mauSacList.Add(msac);
                return true;
            }
            return false;
        }

        public bool Delete(MauSac msac, int index)
        {
            if (index < 0 || index >= mauSacList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            try
            {
                mauSacDao.delete(msac.Mamau);
                mauSacList.RemoveAt(index);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public int GetIndexByMaMau(int mamau)
        {
            return mauSacList.FindIndex(m => m.Mamau == mamau);
        }

        public string GetTenMau(int mamau)
        {
            var mauSac = mauSacList.FirstOrDefault(m => m.Mamau == mamau);
            return mauSac?.Tenmau;
        }

        public bool Update(MauSac msac)
        {
            try
            {
                mauSacDao.update(msac);
                return true;
            }
            catch (Exception) {
                return false;  
            }
        }

        public bool CheckDup(string name)
        {
            return mauSacList.Any(m => m.Tenmau.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
