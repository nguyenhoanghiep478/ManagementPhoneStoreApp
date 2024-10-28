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
    public class XuatXuDAO : AbstractDAO<XuatXu>, IXuatXuDAO
    {   
        private readonly XuatXuRowMapper _rowMapper = new XuatXuRowMapper();
        public void delete(long id)
        {
            String query = "DELETE from xuat xu Where Id = ?";
            Update(query, id);
        }

        public List<XuatXu> FindLikeName(string name)
        {   
            List<Criteria> criterias = new List<Criteria>();    
            Criteria criteria = new Criteria()
            {
                Key = "tenxuatxu",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "xuatxu");
        }

        public List<XuatXu> GetAll()
        {
            return SearchBy(null, _rowMapper , "xuatxu");
        }

        public long insert(XuatXu xuatXu)
        {
            string query = @"
                INSERT INTO XuatXu 
                (
                    maxuatxu, tenxuatxu, trangthai
                ) 
                VALUES 
                (
                    @maxuatxu, @tenxuatxu, @trangthai
                );";
            return Save(query,
                 xuatXu.Maxuatxu,
                 xuatXu.Tenxuatxu,
                 xuatXu.Trangthai
             );
        }


        public void update(XuatXu xuatXu)
        {
            string query = @"
            UPDATE XuatXu 
            SET 
                tenxuatxu = @tenxuatxu,
                trangthai = @trangthai
                WHERE 
            maxuatxu = @maxuatxu;"; 

            Update(query,
                xuatXu.Tenxuatxu,
                xuatXu.Trangthai,
                xuatXu.Maxuatxu
            );
        }

    }
}
