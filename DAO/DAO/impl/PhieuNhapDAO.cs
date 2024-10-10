using DAO.impl;
using DAO.Mapper;
using Entity;
using State.Utils;
using System;
using System.Collections.Generic;

namespace DAO.DAO.impl
{
    public class PhieuNhapDAO : AbstractDAO<PhieuNhap>, IPhieuNhapDAO
    {
        private readonly PhieuNhapRowMapper _rowMapper;

        public PhieuNhapDAO()
        {
            _rowMapper = new PhieuNhapRowMapper();
        }

        public void delete(long id)
        {
            string query = "UPDATE phieunhap SET trangthai = 0 WHERE maphieunhap = ?";
            Update(query, id);
        }

        public List<PhieuNhap> GetAll()
        {
            return SearchBy(null, _rowMapper, "phieunhap");
        }

        public long insert(PhieuNhap phieuNhap)
        {
            string query = @"
                INSERT INTO PhieuNhap 
                (
                    maphieunhap, thoigian, manhacungcap, nguoitao, tongtien, trangthai
                ) 
                VALUES 
                (
                    @maphieunhap, @thoigian, @manhacungcap, @nguoitao, @tongtien, @trangthai
                );";
            return Save(query,
                phieuNhap.Maphieunhap,
                phieuNhap.Thoigian,
                phieuNhap.Manhacungcap,
                phieuNhap.Nguoitao,
                phieuNhap.Tongtien,
                phieuNhap.Trangthai
            );
        }

        public void update(PhieuNhap phieuNhap)
        {
            string query = @"
            UPDATE PhieuNhap 
            SET 
                thoigian = @thoigian,
                manhacungcap = @manhacungcap,
                nguoitao = @nguoitao,
                tongtien = @tongtien,
                trangthai = @trangthai
            WHERE 
                maphieunhap = @maphieunhap;";

            Update(query,
                phieuNhap.Thoigian,
                phieuNhap.Manhacungcap,
                phieuNhap.Nguoitao,
                phieuNhap.Tongtien,
                phieuNhap.Trangthai,
                phieuNhap.Maphieunhap
            );
        }

        public List<PhieuNhap> FindLikeNguoiTao(string nguoitao)
        {
            var criterias = new List<Criteria>
            {
                new Criteria
                {
                    Key = "nguoitao",
                    Operation = "LIKE",
                    Value = nguoitao
                }
            };
            return SearchBy(criterias, _rowMapper, "phieunhap");
        }
    }
}
