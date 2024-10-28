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

namespace DAO.DAO
{
    public class MauSacDAO : AbstractDAO<MauSac>, IMauSacDAO
    {   
        private readonly MauSacRowMapper _rowMapper = new MauSacRowMapper();
        public void delete(long id)
        {
            String query = "update  mausac set trangthai=@trangthai where mamau=@mamau ";
            Update(query, id);
        }

        public List<MauSac> FindLikeName(string name)
        {   
            List<Criteria> criterias = new List<Criteria>();    
            Criteria criteria = new Criteria()
            {
                Key = "tenmau",
                Operation = "LIKE",
                Value = name,
            };
            criterias.Add(criteria);
            return SearchBy(criterias, _rowMapper, "mausac");
        }

        public List<MauSac> GetAll()
        {
            return SearchBy(null, _rowMapper , "mausac");
        }

        public long insert(MauSac mauSac)
        {
            string query = @"
                INSERT INTO MauSac 
                (
                    mamau, tenmau, trangthai
                ) 
                VALUES 
                (
                    @mamau, @tenmau, @trangthai
                );";
            return Save(query,
                 mauSac.Mamau,
                 mauSac.Tenmau,
                 mauSac.Trangthai
             );
        }

         public void update(MauSac mauSac)
        {
            string query = @"
            UPDATE mauSac 
            SET 
                tenmau = @tenmau,
                trangthai = @trangthai
                WHERE 
            masp = @masp;"; 

            Update(query,
                mauSac.Tenmau,
                mauSac.Trangthai,
                mauSac.Mamau  
            );
        }

      
    }
}
