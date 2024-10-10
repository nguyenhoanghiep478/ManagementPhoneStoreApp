using DAO.DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IMauSacService
    {
        List<MauSac> GetAll();
        string[] GetArrTenMauSac();
        MauSac GetByIndex(int index);
        bool Add(MauSac msac);
        bool Delete(MauSac msac, int index);
        int GetIndexByMaMau(int mamau);
        string GetTenMau(int mamau);
        bool Update(MauSac msac);
        bool CheckDup(string name);
    }
}
