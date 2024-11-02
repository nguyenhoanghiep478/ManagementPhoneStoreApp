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
            int parameterIndex = 0; 
            foreach (var parameter in parameters)
            {
            
                if (parameter is List<long> list)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        var listItem = list[j];
                        if (listItem == null)
                        {
                            command.Parameters.AddWithValue($"@param{parameterIndex}", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue($"@param{parameterIndex}", listItem);
                        }
                        parameterIndex++; 
                    }
                }
                else
                {
                    if (parameter == null)
                    {
                        command.Parameters.AddWithValue($"@param{parameterIndex}", DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue($"@param{parameterIndex}", parameter);
                    }
                    parameterIndex++;
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
            {           SetParameter(command, parameters);
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
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if(by != null)
            {
                foreach (Criteria criteria in by)
                {
                    if (criteria.Operation == ":")
                    {
                        query += $" AND {criteria.Key} = @{criteria.Key}";
                        parameters.Add(new MySqlParameter($"@{criteria.Key}", criteria.Value));
                    }
                    else if (criteria.Operation == ">")
                    {
                        query += $" AND {criteria.Key} > @{criteria.Key}";
                        parameters.Add(new MySqlParameter($"@{criteria.Key}", criteria.Value));
                    }
                    else if (criteria.Operation == "<")
                    {
                        query += $" AND {criteria.Key} < @{criteria.Key}";
                        parameters.Add(new MySqlParameter($"@{criteria.Key}", criteria.Value));
                    }
                    else if (criteria.Operation == "LIKE")
                    {
                        query += $" AND {criteria.Key} LIKE @{criteria.Key}";
                        parameters.Add(new MySqlParameter($"@{criteria.Key}", $"%{criteria.Value}%"));
                    }
                    else if (criteria.Operation == "IN")
                    {
                        var inValues = (List<int>)criteria.Value;
                        var inParameters = new List<string>();

                        for (int i = 0; i < inValues.Count; i++)
                        {
                            var paramName = $"@{criteria.Key}_in_{i}";
                            inParameters.Add(paramName);
                            parameters.Add(new MySqlParameter(paramName, inValues[i]));
                        }

                        query += $" AND {criteria.Key} IN ({string.Join(",", inParameters)})";
                    }
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
