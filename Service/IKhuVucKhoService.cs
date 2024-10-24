using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IKhuVucKhoService
    {
     
        List<KhuVucKho> GetAll();
        KhuVucKho GetByIndex(int index); //get Khu Vuc Kho by index of KhuVucKho List
        int GetIndexByMaKVK(int makhuvuc); // Get index in KhuVucKho list 
        bool Add(KhuVucKho kvk);
        bool Delete(KhuVucKho kvk, int index);
        bool Update(KhuVucKho kvk);
        List<KhuVucKho> Search(string txt, string type); // search by type with value txt (vd : Mã Khu Vực Kho, Tên khu vực kho)
        string[] GetArrTenKhuVuc();
    }
}
