using DAO.DAO;
using DAO.DAO.impl;
using Entity;
using Service.impl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PhieuXuatService : IPhieuXuatService
    {
        // Singleton instance
        private static readonly Lazy<PhieuXuatService> _instance = new Lazy<PhieuXuatService>(() => new PhieuXuatService());


        private static readonly object _lock = new object();

        private readonly PhieuXuatDAO phieuXuatDAO;
        private readonly ChiTietPhieuXuatDAO _ctPhieuXuatDAO = new ChiTietPhieuXuatDAO();
        private readonly ChiTietSanPhamDAO _chiTietSanPhamDAO = new ChiTietSanPhamDAO();

        private readonly NhaChungCapService _nccService = NhaChungCapService.Instance;
        private readonly NhanVienService _nvService = NhanVienService.Instance;
        private readonly KhachHangService _khService = new KhachHangService();

        private static Lazy<PhieuXuatService> instance = new Lazy<PhieuXuatService>(() => new PhieuXuatService());

        private List<PhieuXuat> listPhieuXuat;

        private PhieuXuatService()
        {
            phieuXuatDAO = new PhieuXuatDAO();
            listPhieuXuat = phieuXuatDAO.GetAll();

        }

        public static PhieuXuatService Instance => instance.Value;
        public List<PhieuXuat> GetAll()
        {
            return phieuXuatDAO.GetAll();
        }

        public PhieuXuat GetSelect(int index)
        {
            var allPhieuXuat = phieuXuatDAO.GetAll();
            return index >= 0 && index < allPhieuXuat.Count ? allPhieuXuat[index] : null;
        }

        public void Cancel(int px)
        {
            // Placeholder code
            phieuXuatDAO.Delete(px);
        }

        public void Remove(int px)
        {
            phieuXuatDAO.Delete(px);
        }

        public void Insert(PhieuXuat px, List<ChiTietPhieuXuat> ct)
        {
            try
            {
                long phieuXuatId = phieuXuatDAO.Insert(px);

                foreach (var chiTiet in ct)
                {
                    var chiTietPhieuXuat = new ChiTietPhieuXuat
                    {
                        Maphieuxuat = (int)phieuXuatId,
                        Maphienbansp = chiTiet.Maphienbansp,
                        Soluong = chiTiet.Soluong,
                        Dongia = chiTiet.Dongia
                    };

                    //_ctPhieuXuatDAO.insert(chiTietPhieuXuat);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting PhieuXuat: {ex.Message}");
                throw;
            }
        }

        public List<ChiTietPhieu> SelectCTP(int maphieuxuat)
        {
            var chiTietPhieuXuatList = _ctPhieuXuatDAO.GetByPhieuXuatId(maphieuxuat);

            return chiTietPhieuXuatList.Select(ctpx => new ChiTietPhieu
            {
                MaPhieu = ctpx.Maphieuxuat,
                MaPhienBanSanPham = ctpx.Maphienbansp,
                SoLuong = ctpx.Soluong,
                Dongia = ctpx.Dongia
            }).ToList();
        }

        public long GetTongTien(List<ChiTietPhieuXuat> ctphieu)
        {
            return ctphieu.Sum(item => item.Dongia * item.Soluong);
        }

        public ChiTietPhieuXuat FindCT(List<ChiTietPhieuXuat> ctphieu, int mapb)
        {
            ChiTietPhieuXuat p = null;
            int i = 0;

            while (i < ctphieu.Count && p == null)
            {
                if (ctphieu[i].Maphienbansp == mapb)
                {
                    p = ctphieu[i];
                }
                else
                {
                    i++;
                }
            }

            return p;
        }

        public List<PhieuXuat> FilterPhieuXuat(
            int type,
            string input,
            int makh,
            int manv,
            DateTime time_s,
            DateTime time_e,
            string price_min,
            string price_max)
        {
            var allPhieuXuat = phieuXuatDAO.GetAll();
            List<PhieuXuat> result = new List<PhieuXuat>();

            foreach (var phieuXuat in allPhieuXuat)
            {
                bool match = false;

                switch (type)
                {
                    case 0:
                        if (phieuXuat.Maphieuxuat.ToString().Contains(input) ||
                            _nvService.GetNameById((int)phieuXuat.Nguoitaophieuxuat).ToLower().Contains(input) ||
                            _khService.getTenKhachHang((int)phieuXuat.Makh).ToLower().Contains(input))
                        {
                            match = true;
                        }
                        break;

                    case 1:
                        if (phieuXuat.Maphieuxuat.ToString().Contains(input))
                        {
                            match = true;
                        }
                        break;

                    case 2:
                        if (_khService.getTenKhachHang((int)phieuXuat.Makh).ToLower().Contains(input))
                        {
                            match = true;
                        }
                        break;

                    case 3:
                        if (_nvService.GetNameById((int)phieuXuat.Nguoitaophieuxuat).ToLower().Contains(input))
                        {
                            match = true;
                        }
                        break;
                }

                if (match && (makh == 0 || phieuXuat.Makh == makh)
                    && (manv == 0 || phieuXuat.Nguoitaophieuxuat == manv)
                    && (phieuXuat.Thoigian >= time_s && phieuXuat.Thoigian <= time_e))
                {
                    if (decimal.TryParse(price_min, out decimal minPrice) &&
                        decimal.TryParse(price_max, out decimal maxPrice) &&
                        phieuXuat.Tongtien >= minPrice && phieuXuat.Tongtien <= maxPrice)
                    {
                        result.Add(phieuXuat);
                    }
                    else if (string.IsNullOrEmpty(price_min) && string.IsNullOrEmpty(price_max))
                    {
                        result.Add(phieuXuat);
                    }
                }
            }

            return result;
        }
        public List<ChiTietPhieu> GetChiTietPhieu_Type(int maphieu)
        {
            var arr = _ctPhieuXuatDAO.GetAll();

            var result = arr
                .Where(ct => ct.Maphieuxuat == maphieu)
                .Select(ct => new ChiTietPhieu
                {
                    MaPhieu = ct.Maphieuxuat,
                    MaPhienBanSanPham = ct.Maphienbansp,
                    SoLuong = ct.Soluong,
                    Dongia = ct.Dongia
                })
                .ToList();

            return result;
        }

        public bool Add(PhieuXuat phieu, List<ChiTietPhieuXuat> ctPhieu, Dictionary<int, List<ChiTietSanPham>> chitietsanpham)
        {
            bool phieuInserted = phieuXuatDAO.insert(phieu) != 0;

            if (!phieuInserted)
            {
                Console.WriteLine("fail 1");
                return false;
            }

            bool chiTietPhieuInserted =_ctPhieuXuatDAO.insert(ctPhieu) > 0;
            if (!chiTietPhieuInserted)
            {
                Console.WriteLine("fail 2");
                return false;
            }
            bool chiTietSanPhamInserted = _chiTietSanPhamDAO.insert_mutiple(ConvertDictionaryToList(chitietsanpham)) == true;
            if (!chiTietSanPhamInserted) { Console.WriteLine("failed"); return false; }
            return true;
        }
        public List<ChiTietSanPham> ConvertDictionaryToList(Dictionary<int, List<ChiTietSanPham>> chitietsanpham)
        {
            List<ChiTietSanPham> result = new List<ChiTietSanPham>();
            foreach (var ctspList in chitietsanpham.Values)
            {
                result.AddRange(ctspList);
            }
            return result;
        }


        public int GetAutoIncrement()
        {
            return phieuXuatDAO.GetAutoIncrement();
        }
    }
}
