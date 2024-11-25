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
        private static PhieuNhapService _instance;
        private static readonly object _lock = new object();

        private readonly PhieuNhapDAO phieuNhapDAO;
        private readonly ChiTietPhieuNhapDAO _ctPhieuNhapDAO = new ChiTietPhieuNhapDAO();
        private readonly ChiTietSanPhamDAO _chiTietSanPhamDAO = new ChiTietSanPhamDAO();

        private readonly NhaChungCapService _nccService = NhaChungCapService.Instance;
        private readonly NhanVienService _nvService = NhanVienService.Instance;

        private List<PhieuNhap> listPhieuNhap;

        // Private constructor to prevent external instantiation
        private PhieuNhapService()
        {
            phieuNhapDAO = new PhieuNhapDAO();
            listPhieuNhap = new List<PhieuNhap>();
        }

        // Public static property to access the single instance
        public static PhieuNhapService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new PhieuNhapService();
                    }
                    return _instance;
                }
            }
        }

        public List<PhieuNhap> GetAll()
        {
            listPhieuNhap = phieuNhapDAO.GetAll();
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
            };
        }

        public bool Add(PhieuNhap phieu, List<ChiTietPhieuNhap> ctPhieu, Dictionary<int, List<ChiTietSanPham>> chitietsanpham)
        {
            bool phieuInserted = phieuNhapDAO.insert(phieu) != 0;

            if (!phieuInserted) { 
                Console.WriteLine("fail 1");
                return false;  }        

            bool chiTietPhieuInserted = _ctPhieuNhapDAO.insert(ctPhieu) > 0;
            if (!chiTietPhieuInserted)
            {
                Console.WriteLine("fail 2");
                return false;
            }             
            bool chiTietSanPhamInserted = _chiTietSanPhamDAO.insert_mutiple(ConvertDictionaryToList(chitietsanpham)) ==true;
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



        public ChiTietPhieuNhap FindCT(List<ChiTietPhieuNhap> ctphieu, int mapb)
        {
            ChiTietPhieuNhap p = null;
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


        public long GetTongTien(List<ChiTietPhieuNhap> ctphieu)
        {
            return ctphieu.Sum(item => item.Dongia * item.Soluong);
        }

        public List<PhieuNhap> FilterPhieuNhap(
       int type,
       string input,
       int mancc,
       int manv,
       DateTime time_start,
       DateTime time_end,
       string price_minnn,
       string price_maxxx)
        {
            // Parse price range, setting defaults if fields are empty
            long price_min = !string.IsNullOrEmpty(price_minnn) ? long.Parse(price_minnn) : 0L;
            long price_max = !string.IsNullOrEmpty(price_maxxx) ? long.Parse(price_maxxx) : long.MaxValue;

            // Set time range
            DateTime time_s = time_start.Date;
            DateTime time_e = time_end.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            // Initialize result list
            List<PhieuNhap> result = new List<PhieuNhap>();

            // Iterate over all PhieuNhap entries
            foreach (var phieuNhap in GetAllList())
            {
                bool match = false;

                // Filter by type
                switch (type)
                {
                    case 0: // Match any field
                        match = phieuNhap.Maphieunhap.ToString().Contains(input) ||
                                _nccService.GetTenNhaCungCap(phieuNhap.Manhacungcap).ToLower().Contains(input) ||
                                _nvService.GetNameById(int.Parse(phieuNhap.Nguoitao)).ToLower().Contains(input);
                        break;

                    case 1: // Match Maphieunhap
                        match = phieuNhap.Maphieunhap.ToString().Contains(input);
                        break;

                    case 2: // Match Manhacungcap
                        match = _nccService.GetTenNhaCungCap(phieuNhap.Manhacungcap).ToLower().Contains(input);
                        break;

                    case 3: // Match Nguoitao
                        match = _nvService.GetNameById(int.Parse(phieuNhap.Nguoitao)).ToLower().Contains(input);
                        break;
                }

                // Apply additional filters
                if (match &&
                    (manv == 0 || int.Parse(phieuNhap.Nguoitao) == manv) &&
                    (mancc == 0 || phieuNhap.Manhacungcap == mancc) &&
                    phieuNhap.Thoigian >= time_s &&
                    phieuNhap.Thoigian <= time_e &&
                    phieuNhap.Tongtien >= price_min &&
                    phieuNhap.Tongtien <= price_max)
                {
                    result.Add(phieuNhap);
                }
            }

            return result;
        }


        public int GetAutoIncrement()
        {
            return phieuNhapDAO.GetAutoIncrement();
        }
        public bool checkCancelPn(int maphieu)
        {
            return phieuNhapDAO.CheckCancelPn(maphieu);
        }

        public int cancelPhieuNhap(int maphieu)
        {
            return phieuNhapDAO.CancelPhieuNhap(maphieu);
        }
    }
}
