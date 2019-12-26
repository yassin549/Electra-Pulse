using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib
{
    public enum StorageMode
    {
        FileHandling,
        Database
    }

    public class Config
    {
        static string Database = "itcrafts";
        static string ServerName = "DESKTOP-L5MARVR\\SQLEXPRESS";
        static StorageMode StorageMode = StorageMode.Database;

        public static string GetDatabase()
        {
            return Database;
        }

        public static void SetDatabase(string database)
        {
            Database = database;
        }

        public static string GetServerName()
        {
            return ServerName;
        }

        public static void SetServerName(string servername)
        {
            ServerName = servername;
        }

        public static void SetStorageMode(StorageMode storageMode)
        {
            StorageMode = storageMode;
        }

        public static bool IsFHMode()
        {
            return StorageMode == StorageMode.FileHandling;
        }
    }
}
