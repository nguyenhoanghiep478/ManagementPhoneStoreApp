using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IHeDieuHanhService
    {
        List<HeDieuHanh> getAll();
        String[] getAllTenHeDieuHanh(); //get ten he dieu hanh
        HeDieuHanh getByIndex(int index); // get by index of hedieuhanh list
        Boolean add(HeDieuHanh hdh); //add he dieu hanh
        Boolean remove(HeDieuHanh hdh,int index);// soft delete
        int getIndexByMaHdh(int mahdhd); // get index of hedieuhanh list
        Boolean isDuplicate(String name); // check is this name exist;

    }
}
