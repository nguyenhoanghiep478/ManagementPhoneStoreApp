using DAO.impl;
using DAO.Mapper;
using Entity;
using Google.Protobuf.Collections;
using State.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO.impl
{
    public class SanPhamDAO : AbstractDAO<SanPham>, ISanPhamDAO
    {   
        private readonly SanPhamRowMapper _rowMapper;
        public void delete(long id)
        {
            String query = "DELETE from san pham Where Id = ?";
            Update(query, id);
        }

        public List<SanPham> FindLikeName(string name)
        {   
            List<Criteria> criterias = new List<Criteria>();    
            Criteria criteria = new Criteria()
            {
                Key = "tensp",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "sanpham");
        }

        public List<SanPham> GetAll()
        {
            return SearchBy(null, _rowMapper , "sanpham");
        }

        public long insert(SanPham sanPham)
        {
            string query = @"
                INSERT INTO SanPham 
                (
                    masp, tensp, hinhanh, xuatxu, chipxuly, dungluongpin, 
                    kichthuocman, hedieuhanh, phienbanhdh, camerasau, cameratruoc, 
                    thoigianbaohanh, thuonghieu, khuvuckho, soluongton, trangthai
                ) 
                VALUES 
                (
                    @masp, @tensp, @hinhanh, @xuatxu, @chipxuly, @dungluongpin, 
                    @kichthuocman, @hedieuhanh, @phienbanhdh, @camerasau, @cameratruoc, 
                    @thoigianbaohanh, @thuonghieu, @khuvuckho, @soluongton, @trangthai
                );";
            return Save(query,
                 sanPham.Masp,
                 sanPham.Tensp,
                 sanPham.Hinhanh ?? (object)DBNull.Value,
                 sanPham.Xuatxu ?? (object)DBNull.Value,
                 sanPham.Chipxuly ?? (object)DBNull.Value,
                 sanPham.Dungluongpin ?? (object)DBNull.Value,
                 sanPham.Kichthuocman ?? (object)DBNull.Value,
                 sanPham.Hedieuhanh ?? (object)DBNull.Value,
                 sanPham.Phienbanhdh ?? (object)DBNull.Value,
                 sanPham.Camerasau ?? (object)DBNull.Value,
                 sanPham.Cameratruoc ?? (object)DBNull.Value,
                 sanPham.Thoigianbaohanh ?? (object)DBNull.Value,
                 sanPham.Thuonghieu ?? (object)DBNull.Value,
                 sanPham.Khuvuckho ?? (object)DBNull.Value,
                 sanPham.Soluongton,
                 sanPham.Trangthai
             );
        }

        public void update(SanPham sanPham)
        {
            string query = @"
            UPDATE SanPham 
            SET 
                tensp = @tensp,
                hinhanh = @hinhanh,
                xuatxu = @xuatxu,
                chipxuly = @chipxuly,
                dungluongpin = @dungluongpin,
                kichthuocman = @kichthuocman,
                hedieuhanh = @hedieuhanh,
                phienbanhdh = @phienbanhdh,
                camerasau = @camerasau,
                cameratruoc = @cameratruoc,
                thoigianbaohanh = @thoigianbaohanh,
                thuonghieu = @thuonghieu,
                khuvuckho = @khuvuckho,
                soluongton = @soluongton,
                trangthai = @trangthai
                WHERE 
            masp = @masp;"; 

            Update(query,
                sanPham.Tensp,
                sanPham.Hinhanh ?? (object)DBNull.Value,
                sanPham.Xuatxu ?? (object)DBNull.Value,
                sanPham.Chipxuly ?? (object)DBNull.Value,
                sanPham.Dungluongpin ?? (object)DBNull.Value,
                sanPham.Kichthuocman ?? (object)DBNull.Value,
                sanPham.Hedieuhanh ?? (object)DBNull.Value,
                sanPham.Phienbanhdh ?? (object)DBNull.Value,
                sanPham.Camerasau ?? (object)DBNull.Value,
                sanPham.Cameratruoc ?? (object)DBNull.Value,
                sanPham.Thoigianbaohanh ?? (object)DBNull.Value,
                sanPham.Thuonghieu ?? (object)DBNull.Value,
                sanPham.Khuvuckho ?? (object)DBNull.Value,
                sanPham.Soluongton,
                sanPham.Trangthai,
                sanPham.Masp  
            );
        }
    }
}
