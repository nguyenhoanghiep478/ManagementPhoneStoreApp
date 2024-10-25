using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDungLuongRamService
    {
        List<DLRam> getAll();
        DLRam getByIndex(int index); // get by index of DLRAM list
        int getIndexByMaRam(int maRam); //get index by mã ram
        Boolean add(DLRam ram);
        Boolean remove(DLRam ram,int index); // soft delete
        Boolean isDuplicate(int kichthuoc); // check dung luong exist
        int getKichThuocById(int maRam); //get kích thước của ram by mã ram
        String[] getArrKichThuoc(); // vd ["4gb","8gb" , ....]
    }
}
