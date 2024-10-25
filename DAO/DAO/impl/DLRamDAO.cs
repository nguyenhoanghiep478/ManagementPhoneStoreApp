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
    public class DLRamDAO : AbstractDAO<DLRam>, IDLRamDAO
    {   
        private readonly DLRamRowMapper _rowMapper = new DLRamRowMapper();
        public void delete(long id)
        {
            String query = "DELETE from dung luong ram Where Id = ?";
            Update(query, id);
        }

        public List<DLRam> FindLikeName(string name)
        {   
            List<Criteria> criterias = new List<Criteria>();    
            Criteria criteria = new Criteria()
            {
                Key = "kichthuocram",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "dungluongram");
        }

        public List<DLRam> GetAll()
        {
            return SearchBy(null, _rowMapper , "dungluongram");
        }

        public long insert(DLRam dLRam)
        {
            string query = @"
                INSERT INTO DLRam 
                (
                    madlram, kichthuocram, trangthai
                ) 
                VALUES 
                (
                    @madlram, @kichthuocram, @trangthai
                );";
            return Save(query,
                 dLRam.Madlram,
                 dLRam.Kichthuocram,
                 dLRam.Trangthai
             );
        }

        public void update(DLRam dLRam)
        {
            string query = @"
            UPDATE DLRam 
            SET 
                kichthuocram = @kichthuocram,
                trangthai = @trangthai
                WHERE 
            masp = @madlram;"; 

            Update(query,
                dLRam.Kichthuocram,
                dLRam.Trangthai,
                dLRam.Madlram  
            );
        }
    }
}
