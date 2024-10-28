using DAO.impl;
using State.Utils;
using System.Collections.Generic;

using DAO.Mapper;
using Entity;

namespace DAO.DAO.impl
{
    public class ThuongHieuDAO : AbstractDAO<ThuongHieu>, IThuongHieuDAO
    {
        private readonly ThuongHieuRowMapper _rowMapper;

        public ThuongHieuDAO()
        {
            _rowMapper = new ThuongHieuRowMapper();
        }

        public void delete(long id)
        {
            string query = "UPDATE thuonghieu SET trangthai = 0 WHERE mathuonghieu = ?";
            Update(query, id);
        }

        public List<ThuongHieu> GetAll()
        {
            return SearchBy(null, _rowMapper, "thuonghieu");
        }

        public long insert(ThuongHieu thuongHieu)
        {
            string query = @"
                INSERT INTO thuonghieu 
                (
                    mathuonghieu, tenthuonghieu, trangthai
                ) 
                VALUES 
                (
                    @mathuonghieu, @tenthuonghieu, @trangthai
                );";
            return Save(query,
                 thuongHieu.Mathuonghieu,
                 thuongHieu.Tenthuonghieu,
                 thuongHieu.Trangthai
             );
        }

        public void update(ThuongHieu thuongHieu)
        {
            string query = @"
            UPDATE thuonghieu 
            SET 
                tenthuonghieu = @tenthuonghieu,
                trangthai = @trangthai
            WHERE 
                mathuonghieu = @mathuonghieu;";

            Update(query,
                thuongHieu.Tenthuonghieu,
                thuongHieu.Trangthai,
                thuongHieu.Mathuonghieu
            );
        }

        // Optionally, you can implement methods to find by name or other criteria
        public List<ThuongHieu> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "tenthuonghieu",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "thuonghieu");
        }
    }
}
