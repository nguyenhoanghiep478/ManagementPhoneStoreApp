using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IKhachHangService
    {
        List<KhachHang> getAll();
        KhachHang getByIndex(int index); // get by index of khach hang list
        int getIndexByMaDV(int maKhachHang); // get index by ma khach hang

        Boolean add (KhachHang khachhang);
        Boolean remove (KhachHang khachhang); //soft delete
        List<KhachHang> searchBy(String filter, String field); // search by field with value filter (vd Mã Khách Hàng , Tên Khách Hàng,Địa chỉ , Số điện thoại, )
        String getTenKhachHang(int maKhachHang);
        String[] getArrTenKhachHang();
        KhachHang selectKh(int maKhachHang);
    }
}
