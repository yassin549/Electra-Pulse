using itcrafts.BL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.Utils
{
    public class FH
    {
        static string FolderName = "Files";
        static string Delimiter = "<%>";
        static string nullKeyword = "null";
        private static string CreateDirectory(string folderName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            var parentDirectory = Directory.GetParent(currentDirectory);
            string parentDirectoryPath = parentDirectory!.FullName;
            string newDirectoryPath = Path.Combine(parentDirectoryPath, folderName);
            if (Directory.Exists(newDirectoryPath))
            {
                return newDirectoryPath;
            }
            Directory.CreateDirectory(newDirectoryPath);
            return newDirectoryPath;
        }

        /// <summary>
        ///     Creates a file along with directory if it doesn"t exist, otherwise returns path of existing file
        /// </summary>
        private static string CreateFile(string fileName)
        {
            string directoryPath = CreateDirectory(FolderName);
            string file = $"{fileName}.txt";
            string newFilePath = Path.Combine(directoryPath, file);
            if (File.Exists(newFilePath))
            {
                return newFilePath;
            }
            using (File.Create(newFilePath)) { }

            while (!File.Exists(newFilePath))
            {
                System.Threading.Tasks.Task.Delay(100).Wait();
            }
            return newFilePath;
        }

        public static int GetUniqueId()
        {
            string filePath = CreateFile("Id");
            string content = File.ReadAllText(filePath);
            if (content.Length == 0) content = "1";
            int id = Convert.ToInt32(content);
            File.WriteAllText(filePath, (id + 1).ToString());
            return id;
        }

        /// <summary>
        /// This function is used to filter out text before saving them into file
        /// So that system doesn't break when loading data
        /// </summary>
        private static string Filter(string txt)
        {
            if (txt == nullKeyword) txt += "e";
            txt = txt.Replace(Delimiter, " ");
            return txt;
        }

        public static void SaveData(string repository, List<Dictionary<string, object?>> dataSet)
        {
            string filePath = CreateFile(repository);
            List<string> rows = [];
            foreach (var data in dataSet)
            {
                var dataInList = data.Values.ToList().Select(x => x == null ? nullKeyword : Filter(Convert.ToString(x)!));
                string row = string.Join(Delimiter, dataInList);
                rows.Add(row);
            }
            var content = string.Join('\n', rows);
            File.WriteAllText(filePath, content);
        }

        public static List<Dictionary<string, object?>> LoadData(string repository, (string[], Type[]) schema)
        {
            string[] keys = schema.Item1;
            Type[] types = schema.Item2;
            string filePath = CreateFile(repository);
            List<Dictionary<string, object?>> dataSet = [];
            string[] rows = File.ReadAllLines(filePath);
            foreach (var row in rows)
            {
                string[] cells = row.Split(Delimiter);
                var data = new Dictionary<string, object?>();
                if (cells.Length != keys.Length || cells.Length != types.Length) continue;
                for (int i = 0; i < cells.Length; i++)
                {
                    // Special case of null
                    if (cells[i] == nullKeyword)
                    {
                        data[keys[i]] = null;
                    }
                    else
                    {
                        data[keys[i]] = Convert.ChangeType(cells[i], types[i]);
                    }
                }
                dataSet.Add(data);
            }
            return dataSet;
        }

        public static void AddData(string repository, (string[], Type[]) schema, Dictionary<string, object?> data)
        {
            var dataSet = LoadData(repository, schema);
            dataSet.Add(data);
            SaveData(repository, dataSet);
        }

        public static void RemoveData(string repository, (string[], Type[]) schema, int id)
        {
            var rows = LoadData(repository, schema);
            rows.RemoveAll(l => (int)l["Id"]! == id);
            FH.SaveData(repository, rows);
        }
    }
}
