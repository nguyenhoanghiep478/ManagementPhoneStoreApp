using DAO.utils;
using System;
using System.Collections.Generic;
using State.Utils;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface IGenericDAO<T>
    {
        List<T> Query(string sql, IRowMapper<T> rowMapper, params object[] parameters);
        void Update(string sql, params object[] parameters);
        long Save(string sql, params object[] parameters);
        int Count(string sql, params object[] parameters);

        List<T> SearchBy(List<Criteria> by ,IRowMapper<T> rowMapper,string tableName);
    }

}
