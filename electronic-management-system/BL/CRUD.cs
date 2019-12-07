using itcrafts.BL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace itcrafts_lib.BL
{
    public class CRUD
    {
        protected (string[], Type[]) Schema;
        protected string TableName;
        protected Func<Dictionary<string, object?>, string> InsertQuery;
        protected Func<Dictionary<string, object?>, string> UpdateQuery;

        public CRUD(string tableName, (string[], Type[]) schema, Func<Dictionary<string, object?>, string> insertQuery, Func<Dictionary<string, object?>, string> updateQuery)
        {
            TableName = tableName;
            Schema = schema;
            InsertQuery = insertQuery;
            UpdateQuery = updateQuery;
        }

        public List<Dictionary<string, object?>> GetAll()
        {
            if (Config.IsFHMode())
            {
                return itcrafts.Utils.FH.LoadData(TableName, Schema);
            }
            else
            {
                Debug.WriteLine(TableName);
                return itcrafts.Utils.DB.ExecuteAndGetDataSet($"SELECT * FROM [{TableName}]");
            }
        }

        public bool Add(Dictionary<string, object?> data)
        {
            if (Config.IsFHMode())
            {
                var entities = GetAll();
                var newData = new Dictionary<string, object?>();
                newData["Id"] = itcrafts.Utils.FH.GetUniqueId();
                foreach (var kvp in data)
                {
                    if (kvp.Key != "Id") newData.Add(kvp.Key, kvp.Value);
                }
                entities.Add(newData);
                itcrafts.Utils.FH.SaveData(TableName, entities);
                return true;
            }
            else
            {
                string query = InsertQuery(data);
                try
                {
                    itcrafts.Utils.DB.Execute(query);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Update(int dataId, Dictionary<string, object?> data)
        {
            if (Config.IsFHMode())
            {
                var entities = GetAll();
                for (int i = 0; i < entities.Count; i++)
                {
                    var entity = entities[i];
                    if ((int)entity["Id"]! == dataId)
                    {
                        var newData = new Dictionary<string, object?>();
                        newData["Id"] = dataId;
                        foreach (var kvp in data)
                        {
                            if (kvp.Key != "Id") newData.Add(kvp.Key, kvp.Value);
                        }
                        entities[i] = newData;
                    }
                }
                itcrafts.Utils.FH.SaveData(TableName, entities);
                return true;
            }
            else
            {
                string query = UpdateQuery(data) + $" WHERE Id={dataId}";
                try
                {
                    itcrafts.Utils.DB.Execute(query);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public bool Delete(int dataId)
        {
            if (Config.IsFHMode())
            {
                var entities = GetAll();
                entities.RemoveAll(e => (int)e["Id"]! == dataId);
                itcrafts.Utils.FH.SaveData(TableName, entities);
                return true;
            }
            else
            {
                try
                {
                    itcrafts.Utils.DB.Execute($"DELETE FROM [{TableName}] WHERE Id={dataId}");
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
