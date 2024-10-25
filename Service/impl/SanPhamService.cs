using DAO.DAO;
using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.impl
{
    public class SanPhamService : ISanPhamService
    {
        private static readonly Lazy<SanPhamService> instance = new Lazy<SanPhamService>(() => new SanPhamService());
        private SanPhamService()
        {
            listSP = spDAO.GetAll();
        }
        public static SanPhamService Instance => instance.Value;

        private readonly ISanPhamDAO spDAO = new SanPhamDAO();
        private readonly IPhienBanSanPhamService cauhinhBus ;
        private List<SanPham> listSP = new List<SanPham>();

        public bool Add(SanPham sp, List<PhienBanSanPham> listch)
        {
            bool check = spDAO.insert(sp) != 0;
            if (check)
            {
                cauhinhBus.Add(listch);
                listSP.Add(sp);
            }
            return check;
        }

        public bool Delete(SanPham sp)
        {
            spDAO.delete(sp.Masp);
            listSP.Remove(sp);
            return true;
        }

        public List<SanPham> GetAll()
        {
            return listSP;
        }

        public SanPham GetByIndex(int index)
        {
            return listSP[index];
        }

        public List<SanPham> GetByMakhuvuc(int makv)
        {
            return listSP.Where(sp => sp.Khuvuckho == makv).ToList();
        }

        public SanPham GetByMaSP(int masp)
        {
            int index = GetIndexByMaSP(masp);
            return index != -1 ? listSP[index] : null;
        }

        public int GetIndexByMaSP(int masanpham)
        {
            return listSP.FindIndex(sp => sp.Masp == masanpham);
        }

        public int GetQuantity()
        {
            return listSP.Where(sp => sp.Soluongton != 0).Sum(sp => sp.Soluongton);
        }

        public SanPham GetSp(int mapb)
        {
            return spDAO.FindByMaPb(mapb.ToString());

        }

        public List<SanPham> Search(string text)
        {
            text = text.ToLower();
            return listSP.Where(sp => sp.Masp.ToString().ToLower().Contains(text) || sp.Tensp.ToLower().Contains(text)).ToList();
        }

        public bool Update(SanPham sp)
        {
            spDAO.update(sp);
            
                int index = GetIndexByMaSP(sp.Masp);
                if (index != -1)
                {
                    listSP[index] = sp;
                }
            
            return true;
        }
    }
}
