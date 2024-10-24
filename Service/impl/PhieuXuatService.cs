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
        private readonly PhieuXuatDAO _phieuXuatDAO = new PhieuXuatDAO();
        private readonly ChiTietPhieuXuatDAO _chiTietPhieuXuatDAO = new ChiTietPhieuXuatDAO();
        private readonly NhanVienService _nvService = new NhanVienService();
        private readonly KhachHangService _khService = new KhachHangService();

        public List<PhieuXuat> GetAll()
        {
            return _phieuXuatDAO.GetAll();
        }

        public PhieuXuat GetSelect(int index)
        {
            var allPhieuXuat = _phieuXuatDAO.GetAll();
            return index >= 0 && index < allPhieuXuat.Count ? allPhieuXuat[index] : null;
        }

        public void Cancel(int px)
        {
            //k bt lam
            //placeholder code
            _phieuXuatDAO.Delete(px);
        }

        public void Remove(int px)
        {

            _phieuXuatDAO.Delete(px);
        }



        public void Insert(PhieuXuat px, List<ChiTietPhieu> ct)
        {
            try
            {
                long phieuXuatId = _phieuXuatDAO.Insert(px);

                foreach (var chiTiet in ct)
                {
                    var chiTietPhieuXuat = new ChiTietPhieuXuat
                    {
                        Maphieuxuat = (int)phieuXuatId,
                        Maphienbansp = chiTiet.MaPhienBanSanPham,
                        Soluong = chiTiet.SoLuong,
                        Dongia = chiTiet.Dongia
                    };

                    _chiTietPhieuXuatDAO.insert(chiTietPhieuXuat);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the insert process
                Console.WriteLine($"Error inserting PhieuXuat: {ex.Message}");
                throw; // Re-throw to propagate the exception
            }
        }

        public List<ChiTietPhieu> SelectCTP(int maphieuxuat)
        {

            var chiTietPhieuXuatList = _chiTietPhieuXuatDAO.GetByPhieuXuatId(maphieuxuat);


            return chiTietPhieuXuatList.Select(ctpx => new ChiTietPhieu
            {
                MaPhieu = ctpx.Maphieuxuat,
                MaPhienBanSanPham = ctpx.Maphienbansp,
                SoLuong = ctpx.Soluong,
                Dongia = ctpx.Dongia
            }).ToList();
        }

        public List<PhieuXuat> FilterPhieuXuat(
     int type, string input, int makh, int manv,
     DateTime time_s, DateTime time_e,
     string price_min, string price_max)
        {
            // Retrieve all PhieuXuat entries
            var allPhieuXuat = _phieuXuatDAO.GetAll();
            List<PhieuXuat> result = new List<PhieuXuat>();

            foreach (var phieuXuat in allPhieuXuat)
            {
                bool match = false;

                switch (type)
                {
                    case 0:
                        // Check if maphieuxuat matches input first
                        if (phieuXuat.Maphieuxuat.ToString().Contains(input) ||
                            _nvService.GetNameById((int)phieuXuat.Nguoitaophieuxuat).ToLower().Contains(input) ||
                            _khService.getTenKhachHang((int)phieuXuat.Makh).ToLower().Contains(input))
                        {
                            match = true;
                        }
                        break;

                    case 1:
                        // Check if maphieuxuat matches input
                        if (phieuXuat.Maphieuxuat.ToString().Contains(input))
                        {
                            match = true;
                        }
                        break;

                    case 2:
                        // Check if customer name matches input
                        if (_khService.getTenKhachHang((int)phieuXuat.Makh).ToLower().Contains(input))
                        {
                            match = true;
                        }
                        break;

                    case 3:
                        // Check if employee name matches input
                        if (_nvService.GetNameById((int)phieuXuat.Nguoitaophieuxuat).ToLower().Contains(input))
                        {
                            match = true;
                        }
                        break;
                }

                // Check additional conditions after the switch statement
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

    }
}
