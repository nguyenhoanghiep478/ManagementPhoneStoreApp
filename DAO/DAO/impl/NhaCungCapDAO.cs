using DAO.impl;
using DAO.Mapper;
using Entity;
using System;
using System.Collections.Generic;

namespace DAO.DAO.impl
{
    public class NhaCungCapDAO : AbstractDAO<NhaCungCap>, INhaCungCapDAO
    {
        private readonly NhaCungCapRowMapper _rowMapper;

        public NhaCungCapDAO()
        {
            _rowMapper = new NhaCungCapRowMapper();
        }

        public void delete(long manhacungcap)
        {
            string query = "UPDATE nhacungcap SET trangthai = 0 WHERE manhacungcap = ?";
            Update(query, manhacungcap);
        }

        public List<NhaCungCap> GetAll()
        {
            return SearchBy(null, _rowMapper, "nhacungcap");
        }

        public long insert(NhaCungCap nhaCungCap)
        {
            string query = @"
                INSERT INTO NhaCungCap 
                (
                    manhacungcap, tennhacungcap, diachi, email, sdt, trangthai
                ) 
                VALUES 
                (
                    @manhacungcap, @tennhacungcap, @diachi, @email, @sdt, @trangthai
                );";
            return Save(query,
                nhaCungCap.Manhacungcap,
                nhaCungCap.Tennhacungcap,
                nhaCungCap.Diachi,
                nhaCungCap.Email,
                nhaCungCap.Sdt,
                nhaCungCap.Trangthai
            );
        }

        public void update(NhaCungCap nhaCungCap)
        {
            string query = @"
            UPDATE NhaCungCap 
            SET 
                tennhacungcap = @tennhacungcap,
                diachi = @diachi,
                email = @email,
                sdt = @sdt,
                trangthai = @trangthai
            WHERE 
                manhacungcap = @manhacungcap;";

            Update(query,
                nhaCungCap.Tennhacungcap,
                nhaCungCap.Diachi,
                nhaCungCap.Email,
                nhaCungCap.Sdt,
                nhaCungCap.Trangthai,
                nhaCungCap.Manhacungcap
            );
        }
    }
}
