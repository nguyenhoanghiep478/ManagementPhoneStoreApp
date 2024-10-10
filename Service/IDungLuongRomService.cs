using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IDungLuongRomService
    {
        List<DLRom> getAll();
        DLRom getByIndex(int index); // get by index of DLRom list
        int getIndexByMaRom(int marom);// get index of Rom by ma Rom in DLRom List
        Boolean add(DLRom rom);
        Boolean remove(DLRom rom,int index);
        int getKichThuocById(int marom);//get kich thuoc of rom
        Boolean isDuplicate(int dungluongrom); // check if kich thuoc dung luong rom exist
        String[] getArrKichThuoc(); // vd ["128gb","256gb" , ....]

    }
}
