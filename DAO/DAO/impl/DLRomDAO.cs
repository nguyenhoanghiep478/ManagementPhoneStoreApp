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
    public class DLRomDAO : AbstractDAO<DLRom>, IDLRomDAO
    {   
        private readonly DLRomRowMapper _rowMapper;
        public void delete(long id)
        {
            String query = "DELETE from dung luong rom Where Id = ?";
            Update(query, id);
        }

        public List<DLRom> FindLikeName(string name)
        {   
            List<Criteria> criterias = new List<Criteria>();    
            Criteria criteria = new Criteria()
            {
                Key = "kichthuocrom",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "dungluongrom");
        }

        public List<DLRom> GetAll()
        {
            return SearchBy(null, _rowMapper , "dungluongrom");
        }

        public long insert(DLRom dLRom)
        {
            string query = @"
                INSERT INTO DLRom 
                (
                    madlrom, kichthuocrom, trangthai
                ) 
                VALUES 
                (
                    @madlrom, @kichthuocrom, @trangthai
                );";
            return Save(query,
                 dLRom.Madlrom,
                 dLRom.Kichthuocrom,
                 dLRom.Trangthai
             );
        }

        public void update(DLRom dLRom)
        {
            string query = @"
            UPDATE DLRom 
            SET 
                kichthuocrom = @kichthuocrom,
                trangthai = @trangthai
                WHERE 
            masp = @madlrom;"; 

            Update(query,
                dLRom.Kichthuocrom,
                dLRom.Trangthai,
                dLRom.Madlrom  
            );
        }
    }
}
