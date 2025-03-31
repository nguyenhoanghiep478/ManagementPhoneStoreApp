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
        private readonly DLRomRowMapper _rowMapper = new DLRomRowMapper();
        public void delete(long id)
        {
            String query = "UPDATE dungluongrom SET trangthai = 0 WHERE madlrom = @param0";
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
                INSERT INTO dungluongrom 
                (
                    madlrom, kichthuocrom, trangthai
                ) 
                VALUES 
                (
                   @param0, @param1, @param2
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
            UPDATE dungluongrom 
            SET 
                kichthuocrom = @param0,
                trangthai = @param1
                WHERE 
            masp = @param2;"; 

            Update(query,
                dLRom.Kichthuocrom,
                dLRom.Trangthai,
                dLRom.Madlrom  
            );
        }
    }
}
