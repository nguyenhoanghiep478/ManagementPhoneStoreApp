using DAO.impl;
using DAO.Mapper;
using DAO.Mapper.impl;
using Entity;
using State.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.DAO.impl
{
    public class KhuVucKhoDAO : AbstractDAO<KhuVucKho>, IKhuVucKhoDAO
    {
        private readonly KhuVucKhoRowMapper _rowMapper;
        public void delete(long id)
        {
            String query = "update from khuvuckho set trangthai=@trangthai where makhuvuc=@makhuvuc";
            Update(query,0, id);
        }

        public List<KhuVucKho> FindLikeName(string name)
        {
            List<Criteria> criterias = new List<Criteria>();
            Criteria criteria = new Criteria()
            {
                Key = "tenkhuvuc",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "khuvuckho");
        }

        public List<KhuVucKho> GetAll()
        {
            return SearchBy(null, _rowMapper, "khuvuckho");
        }

        public long insert(KhuVucKho khuvuckho)
        {
            string query = @"
                INSERT INTO khuvuckho
                (
                 makhuvuc,tenkhuvuc,ghichu,trangthai
                ) 
                VALUES 
                (
                    @makhuvuc,@tenkhuvuc,@ghichu,@trangthai
                );";
            return Save(query,
                 khuvuckho.Makhuvuc,
                 khuvuckho.Tenkhuvuc ?? (object)DBNull.Value,
                 khuvuckho.Ghichu ?? (object)DBNull.Value,
                 khuvuckho.Trangthai ?? (object)DBNull.Value
                
             );
        }

        public void update(KhuVucKho khuvuckho)
        {
            string query = @"
            UPDATE khuvuckho
            SET 
                tenkhuvuc = @tenkhuvuc,
                ghichu = @ghichu,
                trangthai = @trangthai
                WHERE 
            makhuvuc = @makhuvuc;";

            Update(query,
                khuvuckho.Tenkhuvuc,
                khuvuckho.Ghichu?? (object)DBNull.Value,
                khuvuckho.Trangthai ?? (object)DBNull.Value,
                khuvuckho.Makhuvuc
               
            );
        }
    }
}
