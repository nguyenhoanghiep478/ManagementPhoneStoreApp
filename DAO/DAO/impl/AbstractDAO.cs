using DAO.utils;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using State.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace DAO.impl
{
    public class AbstractDAO<T> : IGenericDAO<T>
    {
        private string connectionString = "Server=localhost;Database=quanlikhohang;User ID=root;Password=123456;Port=3306;";

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        private void SetParameter(MySqlCommand command, params object[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                if (parameter == null)
                {
                    command.Parameters.AddWithValue($"@param{i}", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue($"@param{i}", parameter);
                }
            }
        }

        private void CloseObjects(IDbConnection connection, IDbCommand command, IDataReader reader)
        {
            reader?.Close();
            command?.Dispose();
            connection?.Close();
        }

        public List<T> Query(string sql, IRowMapper<T> rowMapper, params object[] parameters)
        {
            var results = new List<T>();
            using (var connection = GetConnection())
            using (var command = new MySqlCommand(sql, connection))
            {
                SetParameter(command, parameters);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(rowMapper.MapRow(reader));
                    }
                }
            }
            return results;
        }

        public void Update(string sql, params object[] parameters)
        {
            using (var connection = GetConnection())
            using (var command = new MySqlCommand(sql, connection))
            {
                SetParameter(command, parameters);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public long Save(string sql, params object[] parameters)
        {
            long id = 0;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;
                SetParameter(command, parameters);
                connection.Open();
                command.ExecuteNonQuery();
                id = command.LastInsertedId;
            }
            return id;
        }

        public int Count(string sql, params object[] parameters)
        {
            int count = 0;
            using (var connection = GetConnection())
            using (var command = new MySqlCommand(sql, connection))
            {
                SetParameter(command, parameters);
                connection.Open();
                count = Convert.ToInt32(command.ExecuteScalar());
            }
            return count;
        }

        public List<T> SearchBy(List<Criteria> by,IRowMapper<T> rowMapper,string tableName)
        {
            var results = new List<T>();
            string query = $"SELECT * FROM {tableName} WHERE 1 = 1";
            List<SqlParameter> parameters = new List<SqlParameter>();

            foreach(Criteria criteria in by)
            {
                if (criteria.Operation == ":")
                {
                    query += $" AND {criteria.Key} = @{criteria.Key}";
                    parameters.Add(new SqlParameter($"@{criteria.Key}", criteria.Value));
                }
                else if (criteria.Operation == ">")
                {
                    query += $" AND {criteria.Key} > @{criteria.Key}";
                    parameters.Add(new SqlParameter($"@{criteria.Key}", criteria.Value));
                }
                else if (criteria.Operation == "<")
                {
                    query += $" AND {criteria.Key} < @{criteria.Key}";
                    parameters.Add(new SqlParameter($"@{criteria.Key}", criteria.Value));
                }
                else if (criteria.Operation == "LIKE")
                {
                    query += $" AND {criteria.Key} LIKE @{criteria.Key}";
                    parameters.Add(new SqlParameter($"@{criteria.Key}", $"%{criteria.Value}%"));
                }
                else if (criteria.Operation == "IN")
                {
                    var inValues = (List<int>)criteria.Value;
                    query += $" AND {criteria.Key} IN ({string.Join(",", inValues)})";
                }
            }

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(rowMapper.MapRow(reader));
                        }
                    }
                }
            }
           

            return results;
        }
    }
}
