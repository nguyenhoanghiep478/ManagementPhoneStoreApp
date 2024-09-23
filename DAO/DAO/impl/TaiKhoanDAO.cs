using DAO.impl;
using DAO.Mapper;
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
    public class TaiKhoanDAO : AbstractDAO<TaiKhoan>, ITaiKhoanDao
    {
        private readonly TaiKhoanRowMapper _rowMapper = new TaiKhoanRowMapper();
        public void delete(long id)
        {
            String query = "update from taikhoan set trangthai=@trangthai where manv=@manv";
            Update(query, 0, id);
        }

        public List<TaiKhoan> FindLikeMaNv(string tendangnhap)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "tendangnhap",
                Operation = "LIKE",
                Value = tendangnhap,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "taikhoan");
        }

        public List<TaiKhoan> GetAll()
        {
            return SearchBy(null, _rowMapper, "taikhoan");
        }

        public long insert(TaiKhoan taiKhoan)
        {
            string query = @"
                INSERT INTO taikhoan 
                (
                    manv,matkhau,manhomquyen,tendangnhap,trangthai,otp
                ) 
                VALUES 
                (
                   @manv,@matkhau,@manhomquyen,@tendangnhap,@trangthai,@otp
                );";
            return Save(query,
                 taiKhoan.Manv,
                 taiKhoan.Matkhau,
                 taiKhoan.Manhomquyen ?? (object)DBNull.Value,
                 taiKhoan.Tendangnhap ,
                 taiKhoan.Trangthai ?? (object)DBNull.Value,
                 taiKhoan.Otp
             );
        }
        public void update(TaiKhoan taiKhoan)
        {
            string query = @"
            UPDATE taikhoan 
            SET 
                manv=@manv,
                matkhau=@matkhau,
                manhomquyen=@manhomquyen,
                tendangnhap=@tendangnhap,
                trangthai=@trangthai,
                otp=@otp
                WHERE 
                manv = @manv;";

            Update(query,
                 taiKhoan.Manv,
                 taiKhoan.Matkhau,
                 taiKhoan.Manhomquyen ?? (object)DBNull.Value,
                 taiKhoan.Tendangnhap,
                 taiKhoan.Trangthai ?? (object)DBNull.Value,
                 taiKhoan.Otp
            );
        }
    }
}
