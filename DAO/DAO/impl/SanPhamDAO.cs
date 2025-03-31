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
            private readonly SanPhamRowMapper _rowMapper = new SanPhamRowMapper();

            public void delete(long id)
            {
                String query = "Update sanpham set trangthai = 0 Where masp = ?";
                Update(query, id);
            }

            public SanPham FindByMaPb(string pb)
            {
                String sql = "SELECT * FROM sanpham sp join phienbansanpham pb on sp.masp=pb.masp WHERE maphienbansp=?";
                return this.Query(sql, _rowMapper, pb).FirstOrDefault();
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
                return SearchBy(null, _rowMapper, "sanpham");
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
                   @param0, @param1, @param2, @param3, @param4, @param5,@param6,
                    @param7,@param8,@param9,@param10,@param11,@param12,@param13,@param14,@param15
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
                tensp = @param0,
                hinhanh = @param1,
                xuatxu = @param2,
                chipxuly = @param3,
                dungluongpin = @param4,
                kichthuocman = @param5,
                hedieuhanh = @param6,
                phienbanhdh = @param7,
                camerasau = @param8,
                cameratruoc = @param9,
                thoigianbaohanh = @param10,
                thuonghieu = @param11,
                khuvuckho = @param12,
                soluongton = @param13,
                trangthai = @param14
                WHERE 
            masp = @param15;";

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
            public SanPham FindById(long masp)
            {
                string sql = "SELECT * FROM sanpham WHERE masp = ?";
                return this.Query(sql, _rowMapper, masp).FirstOrDefault();
            }
       
            public void updateSoLuongTon(long masp, int soluong)
            {                
                SanPham sanPham = this.FindById(masp); 
                if (sanPham != null)
                {
                    int currentStock = sanPham.Soluongton;
                    int newStock = currentStock + soluong;

                    if (newStock >= 0)
                    {
                        string query = "UPDATE sanpham SET soluongton = @param0 WHERE masp = @param1";
                        Update(query, newStock, masp);
                    }
                    else
                    {
                        throw new InvalidOperationException("Insufficient stock to complete the operation.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Product not found.");
                }
            }
      


    }
}


