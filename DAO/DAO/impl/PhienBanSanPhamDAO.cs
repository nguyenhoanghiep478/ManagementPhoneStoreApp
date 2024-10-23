using DAO.impl;
using DAO.Mapper.impl;
using DAO.utils;
using Entity;
using State.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO.impl
{
    public class PhienBanSanPhamDAO : AbstractDAO<PhienBanSanPham>, IPhienBanSanPham
    {
        private readonly PhienBanSanPhamRowMapper _rowMapper = new PhienBanSanPhamRowMapper();

       

        public void delete(long id)
        {
            String query = "update phienbansanpham set trangthai = 0 where maphienbansp = ?";
            Update(query, id);
        }

        public PhienBanSanPham FindByMaPhienBanSanPham(int maphienban)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "maphienban",
                Operation = ":",
                Value = maphienban,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "phienbansanpham").FirstOrDefault(null);
        }

        public List<PhienBanSanPham> FindByMaSp(string masp)
        {
            String sql = "SELECT * FROM phienbansanpham WHERE masp = ? and trangthai = 1";
            return this.Query(sql,_rowMapper, masp);
        }

        public long insert(PhienBanSanPham phienBanSanPham)
        {
            string query = @"
            INSERT INTO phienbansanpham 
            (
                maphienbansp, masp, rom, ram, mausac, gianhap, giaxuat, soluongton, trangthai
            ) 
            VALUES 
            (
                @maphienbansp, @masp, @rom, @ram, @mausac, @gianhap, @giaxuat, @soluongton, @trangthai
            );";

            return Save(query,
                phienBanSanPham.MaPhienBanSanPham,
                phienBanSanPham.MaSanPham ?? (object)DBNull.Value,
                phienBanSanPham.Rom,
                phienBanSanPham.Ram ?? (object)DBNull.Value,
                phienBanSanPham.MauSac,
                phienBanSanPham.GiaNhap ?? (object)DBNull.Value,
                phienBanSanPham.GiaXuat ?? (object)DBNull.Value,
                phienBanSanPham.SoLuongTon,
                phienBanSanPham.TrangThai ? 1 : 0
            );
        }

        public void update(PhienBanSanPham phienBanSanPham)
        {
            string query = @"
                UPDATE phienbansanpham
                SET 
                    masp = @masp,
                    rom = @rom,
                    ram = @ram,
                    mausac = @mausac,
                    gianhap = @gianhap,
                    giaxuat = @giaxuat,
                    soluongton = @soluongton,
                    trangthai = @trangthai
                WHERE 
                    maphienbansp = @maphienbansp;";

             Update(query,
                phienBanSanPham.MaSanPham ?? (object)DBNull.Value,
                phienBanSanPham.Rom,
                phienBanSanPham.Ram ?? (object)DBNull.Value,
                phienBanSanPham.MauSac,
                phienBanSanPham.GiaNhap ?? (object)DBNull.Value,
                phienBanSanPham.GiaXuat ?? (object)DBNull.Value,
                phienBanSanPham.SoLuongTon,
                phienBanSanPham.TrangThai ? 1 : 0, 
                phienBanSanPham.MaPhienBanSanPham 
            );
        }
    }
}
