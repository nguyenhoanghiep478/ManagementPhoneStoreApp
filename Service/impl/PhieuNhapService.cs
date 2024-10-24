using System;
using System.Collections.Generic;
using System.Linq;
using DAO.DAO;
using DAO.DAO.impl;
using Entity;
using Service.impl;

namespace Service
{
    public class PhieuNhapService : IPhieuNhapService
    {
        private readonly PhieuNhapDAO _phieuNhapDAO = new PhieuNhapDAO();
        private readonly ChiTietPhieuNhapDAO _ctPhieuNhapDAO = new ChiTietPhieuNhapDAO();
        private readonly ChiTietSanPhamDAO _chiTietSanPhamDAO = new ChiTietSanPhamDAO();

        private readonly NhaChungCapService _nccService = NhaChungCapService.Instance;
        private readonly NhanVienService _nvService = new NhanVienService();

        private List<PhieuNhap> listPhieuNhap;

        public PhieuNhapService()
        {
            listPhieuNhap = new List<PhieuNhap>();
        }

        public List<PhieuNhap> GetAll()
        {
            listPhieuNhap = _phieuNhapDAO.GetAll();
            return listPhieuNhap;
        }

        public List<PhieuNhap> GetAllList()
        {
            return listPhieuNhap;
        }

        public List<ChiTietSanPham> ConvertHashMapToArray(Dictionary<int, List<ChiTietSanPham>> chitietsanpham)
        {
            return chitietsanpham.SelectMany(kvp => kvp.Value).ToList();
        }

        public List<ChiTietPhieuNhap> GetChiTietPhieu(int maphieunhap)
        {
            return _ctPhieuNhapDAO.GetAll().Where(ct => ct.Maphieunhap == maphieunhap).ToList();
        }


        public List<ChiTietPhieu> GetChiTietPhieu_Type(int maphieunhap)
        {
           
            var arr = _ctPhieuNhapDAO.GetAll();
                    
            var result = arr
                .Where(ct => ct.Maphieunhap == maphieunhap) 
                .Select(ct => new ChiTietPhieu  
                {
                    MaPhieu = ct.Maphieunhap,
                    MaPhienBanSanPham = ct.Maphienbansp,
                    SoLuong = ct.Soluong,
                    Dongia = ct.Dongia
                })
                .ToList();

            return result;
        }


        private ChiTietPhieu ConvertToChiTietPhieu(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            return new ChiTietPhieu
            {
                MaPhienBanSanPham = chiTietPhieuNhap.Maphienbansp,
                SoLuong = chiTietPhieuNhap.Soluong,
                Dongia = chiTietPhieuNhap.Dongia,
                // Map other properties if needed
            };
        }

        public bool Add(PhieuNhap phieu, List<ChiTietPhieuNhap> ctPhieu, Dictionary<int, List<ChiTietSanPham>> chitietsanpham)
        {
            // Step 1: Insert the PhieuNhap (main receipt)
            long insertedPhieuId = _phieuNhapDAO.insert(phieu);
            if (insertedPhieuId == 0)
            {
                return false; // Insertion failed
            }

            // Step 2: Insert each ChiTietPhieuNhap individually
            foreach (var item in ctPhieu)
            {
                item.Maphieunhap = (int)insertedPhieuId; // Set foreign key to the inserted receipt ID
                long insertedCtId = _ctPhieuNhapDAO.insert(item);
                if (insertedCtId == 0)
                {
                    return false; // If any insertion fails, return false
                }
            }

            // Step 3: Convert Dictionary to List<ChiTietSanPham>
            List<ChiTietSanPham> chiTietSanPhamList = ConvertHashMapToArray(chitietsanpham);

            // Step 4: Insert each ChiTietSanPham individually
            foreach (var sanPham in chiTietSanPhamList)
            {
                sanPham.MaPhieuNhap = (int)insertedPhieuId; // Set foreign key
                long insertedSanPhamId = _chiTietSanPhamDAO.insert(sanPham);
                if (insertedSanPhamId == 0)
                {
                    return false; // Return false if any insertion fails
                }
            }

            // All insertions succeeded
            return true;
        }




        public ChiTietPhieuNhap FindCT(List<ChiTietPhieuNhap> ctphieu, int mapb)
        {
            return ctphieu.FirstOrDefault(ct => ct.Maphienbansp == mapb);
        }

        public long GetTongTien(List<ChiTietPhieuNhap> ctphieu)
        {
            return ctphieu.Sum(item => item.Dongia * item.Soluong);
        }


        public List<PhieuNhap> FilterPhieuNhap(int type, string input, int mancc, int manv, DateTime time_s, DateTime time_e, string price_min, string price_max)
        {
            var allPhieuNhap = GetAllList();
            List<PhieuNhap> result = new List<PhieuNhap>();

            foreach (var phieuNhap in allPhieuNhap)
            {
                bool match = false;

            
                switch (type)
                {
                    case 0:
                        // Match if either Maphieunhap contains input or other criteria can be added here
                        if (phieuNhap.Maphieunhap.ToString().Contains(input) ||
                            (manv > 0 && phieuNhap.Nguoitao.ToString() == manv.ToString()))
                        {
                            match = true;
                        }
                        break;

                    case 1:
                        // Match if only Maphieunhap contains input
                        if (phieuNhap.Maphieunhap.ToString().Contains(input))
                        {
                            match = true;
                        }
                        break;

                    case 2:
                        // Match if creator's ID matches exactly
                        if (manv > 0 && phieuNhap.Nguoitao.ToString() == manv.ToString())

                        {
                            match = true;
                        }
                        break;
                }

              
                if (match && (mancc == 0 || phieuNhap.Manhacungcap == mancc)
                    && (time_s != DateTime.MinValue && time_e != DateTime.MinValue
                        && phieuNhap.Thoigian >= time_s && phieuNhap.Thoigian <= time_e))
                {
                    if (decimal.TryParse(price_min, out decimal minPrice) &&
                        decimal.TryParse(price_max, out decimal maxPrice))
                    {
                        if (phieuNhap.Tongtien >= minPrice && phieuNhap.Tongtien <= maxPrice)
                        {
                            result.Add(phieuNhap);
                        }
                    }
                    else if (string.IsNullOrEmpty(price_min) && string.IsNullOrEmpty(price_max))
                    {
                        result.Add(phieuNhap);
                    }
                }
            }

            return result;
        }


        public bool CheckCancelPn(int maphieu)
        {
            // Retrieve the PhieuNhap object by ID using GetAll()
            var phieu = listPhieuNhap.FirstOrDefault(pn => pn.Maphieunhap == maphieu);

            // Check if the object exists and is active (status != 0)
            return phieu != null && phieu.Trangthai != 0;
        }

        public int CancelPhieuNhap(int maphieu)
        {            
            var phieu = listPhieuNhap.FirstOrDefault(pn => pn.Maphieunhap == maphieu);
            
            if (phieu == null || phieu.Trangthai == 0)
            {
                return 0;
            }
             phieu.Trangthai = 0;
                       
            _phieuNhapDAO.update(phieu);

            return 1;
        }


    }
}
