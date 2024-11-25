using DAO.DAO;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.impl
{
    public class KhachHangService : IKhachHangService
    {
        private List<KhachHang> _khachhangs;
        private KhachHangDAO dao=new KhachHangDAO();
        public KhachHangService()
        {
            // Initialize the list with active KhachHang records
            _khachhangs = dao.GetAll().Where(kh => kh.TrangThai.Equals(1)).ToList();
        }

        public List<KhachHang> getAll()
        {
            _khachhangs=dao.GetAll().Where(kh=>kh.TrangThai.Equals(1)).ToList();
            return _khachhangs;
        }

        public KhachHang getByIndex(int index)
        {
            if (index >= 0 && index < _khachhangs.Count)
            {
                return _khachhangs[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Error");
            }
        }
        public bool checkNameExist(String name)
        {
            return _khachhangs.Any(kh => kh.TenKhachHang.Equals(name));
        }
        public int getIndexByMaDV(int maKhachHang)
        {
            var khachhang = _khachhangs.FirstOrDefault(kh => kh.MakH == maKhachHang);
            if (khachhang != null)
            {
                return _khachhangs.IndexOf(khachhang);
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public Boolean add(KhachHang khachhang)
        {
            if (khachhang != null && !_khachhangs.Any(kh => kh.MakH == khachhang.MakH))
            {   
                dao.insert(khachhang);
                _khachhangs.Add(khachhang);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean remove(KhachHang khachhang)
        {
            if (_khachhangs.Remove(khachhang))
            {
                dao.delete((long)khachhang.MakH);
                return true;
            }
            return false;
        }

        public List<KhachHang> searchBy(String filter, string field)
        {
           filter = filter.ToLower();
            switch (field)
            {
                case "Tất cả":
                   return _khachhangs.Where(kh=>kh.MakH.ToString().Equals(filter)
                    ||kh.TenKhachHang.ToLower().Contains(filter)
                    || kh.DiaChi.ToLower().Contains(filter)
                    ||kh.Sdt.ToLower().Contains(filter)).ToList();
                    break;
                case "Mã khách hàng":
                    if (int.TryParse(filter, out int makhachhang))
                    {
                        return _khachhangs.Where(kh => kh.MakH == makhachhang).ToList();
                    }
                    break;

                case "Tên khách hàng":
                    return _khachhangs.Where(kh => kh.TenKhachHang.ToLower().Contains(filter)).ToList();

                case "Địa chỉ":
                    return _khachhangs.Where(kh => kh.DiaChi.ToLower().Contains(filter)).ToList();

                case "Số điện thoại":
                    return _khachhangs.Where(kh => kh.Sdt.ToLower().Contains(filter)).ToList();

                default:
                    throw new Exception("Error");

            }
            return new List<KhachHang>();
        }
        public String getTenKhachHang(int makh)
        {
            String name = "";
            foreach (KhachHang khachHang in _khachhangs)
            {
                if (khachHang.MakH == makh)
                {
                    name = khachHang.TenKhachHang;
                }
            }
            return name;
        }

        public string[] getArrTenKhachHang()
        {
            return _khachhangs.Select(kh => kh.TenKhachHang).ToArray();
        }

        public KhachHang selectKh(int makhachhang)
        {
            var khachhang = _khachhangs.FirstOrDefault(kh => kh.MakH == makhachhang);
            if(khachhang != null)
            {
                return khachhang;
            }
            throw new Exception("Error");
        }
        public bool update(KhachHang kvk)
        {
            for (int i = 0; i < _khachhangs.Count; i++)
            {
                if (_khachhangs[i].MakH.Equals(kvk.MakH))
                {
                    dao.update(kvk);
                    _khachhangs[i] = kvk;
                    return true;
                }
            }
            return false;
        }
    }
}
