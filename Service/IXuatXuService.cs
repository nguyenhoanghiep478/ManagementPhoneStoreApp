using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IXuatXuService
    {
        List<XuatXu> GetAll();
        string[] GetArrTenXuatXu();
        XuatXu GetByIndex(int index);
        bool Add(XuatXu xuatxu);
        bool Delete(XuatXu xuatxu, int index);
        int GetIndexByMaXX(int maxx);
        string GetTenXuatXu(int maxx);
        bool Update(XuatXu xuatxu);
        bool CheckDup(string name);
    }
}
