using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Service.impl
{
    public class XuatXuService : IXuatXuService
    {
        private readonly List<XuatXu> xuatXuList = new List<XuatXu>();
        private readonly XuatXuDAO xuatXuDao = new XuatXuDAO(); // Giả sử XuatXuDAO là lớp truy cập dữ liệu của bạn

        public XuatXuService()
        {
            xuatXuDao=new XuatXuDAO();
            xuatXuList=xuatXuDao.GetAll();
        }
        public List<XuatXu> GetAll()
        {
            xuatXuList.Clear();
            xuatXuList.AddRange(xuatXuDao.GetAll());
            return xuatXuList;
        }

        public string[] GetArrTenXuatXu()
        {
            return xuatXuList.Select(x => x.Tenxuatxu).ToArray();
        }

        public XuatXu GetByIndex(int index)
        {
            if (index < 0 || index >= xuatXuList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
            return xuatXuList[index];
        }

        public bool Add(XuatXu xuatxu)
        {
            if (CheckDup(xuatxu.Tenxuatxu))
            {
                return false;
            }
            long isAdded = xuatXuDao.insert(xuatxu);
            if (isAdded!=0)
            {
                xuatXuList.Add(xuatxu);
                return true;
            }
            return false;
        }

        public bool Delete(XuatXu xuatxu, int index)
        {
            if (index < 0 || index >= xuatXuList.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }

            try
            {
                xuatXuDao.delete(xuatxu.Maxuatxu);
                xuatXuList.RemoveAt(index);
                return true;
            }
            catch (Exception)
            {
                return false; 
            }
        }


        public int GetIndexByMaXX(int maxx)
        {
            return xuatXuList.FindIndex(x => x.Maxuatxu == maxx);
        }

        public string GetTenXuatXu(int maxx)
        {
            var xuatXu = xuatXuList.FirstOrDefault(x => x.Maxuatxu == maxx);
            return xuatXu != null ? xuatXu.Tenxuatxu : null;
        }

        public bool Update(XuatXu xuatxu)
        {
            try
            {
                xuatXuDao.update(xuatxu);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CheckDup(string name)
        {
            return xuatXuList.Any(x => x.Tenxuatxu.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
