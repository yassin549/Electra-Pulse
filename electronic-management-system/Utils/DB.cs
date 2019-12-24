using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using itcrafts_lib;

namespace itcrafts.Utils
{
    public class DB
    {
        public static string ConnectionString = $"Server={Config.GetServerName()};Database={Config.GetDatabase()};Trusted_Connection=True;";
        public static List<Dictionary<string, object?>> GetDataInPair(SqlDataReader reader)
        {
            var data = new List<Dictionary<string, object?>>();
            while (reader.Read())
            {
                var row = new Dictionary<string, object?>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnName = reader.GetName(i);
                    object? columnValue = reader.GetValue(i);
                    if (reader.IsDBNull(i))
                    {
                        columnValue = null;
                    }
                    row[columnName] = columnValue;
                }
                data.Add(row);
            }
            return data;
        }

        public static List<Dictionary<string, object?>> ExecuteAndGetDataSet(string query)
        {
            var dbClient = new SqlConnection(ConnectionString);
            dbClient.Open();
            var reader = new SqlCommand(query, dbClient).ExecuteReader();
            var data = GetDataInPair(reader);
            reader.Close();
            dbClient.Close();
            return data;
        }

        public static List<Dictionary<string, object?>> GetTableInDataSet(string tableName)
        {
            return ExecuteAndGetDataSet($"SELECT * FROM [{tableName}]");
        }

        public static int Execute(string query)
        {
            var dbClient = new SqlConnection(ConnectionString);
            dbClient.Open();
            int affectedRows = new SqlCommand(query, dbClient).ExecuteNonQuery();
            dbClient.Close();
            return affectedRows;
        }
    }
}
