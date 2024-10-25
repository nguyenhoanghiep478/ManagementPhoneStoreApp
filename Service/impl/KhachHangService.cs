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
        private List<KhachHang> _khachhangs = new List<KhachHang>();
        
        public List<KhachHang> getAll()
        {
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
                return true;
            }
            return false;
        }

        public List<KhachHang> searchBy(String filter, string field)
        {
            switch (field.ToLower())
            {
                case "MakH":
                    if (int.TryParse(filter, out int makhachhang))
                    {
                        return _khachhangs.Where(kh => kh.MakH == makhachhang).ToList();
                    }
                    break;

                case "TenKhachHang":
                    return _khachhangs.Where(kh => kh.TenKhachHang.Contains(filter)).ToList();

                case "DiaChi":
                    return _khachhangs.Where(kh => kh.DiaChi.Contains(filter)).ToList();

                case "Sdt":
                    return _khachhangs.Where(kh => kh.Sdt.Contains(filter)).ToList();

                default:
                    throw new Exception("Error");

            }
            return new List<KhachHang>();
        }
        public string getTenKhachHang(int makhachhang)
        {
            var khachhang = _khachhangs.FirstOrDefault(kh => kh.MakH == makhachhang);
            if (khachhang != null)
            {
                return khachhang.TenKhachHang;
            }
            throw new Exception("Error");
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
    }
}
