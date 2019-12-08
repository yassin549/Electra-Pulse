using itcrafts_lib.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.General
{
    public class MaterialDL
    {
        public static CRUD GetCRUD()
        {
            return new CRUD(
                "Material",
                (
                    ["Id", "Name", "Description"],
                    [typeof(int), typeof(string), typeof(string)]
                ),
                d =>
                {
                    return $"INSERT INTO [Material] ([Name], Description) VALUES ('{(string)d["Name"]!}',  '{(string)d["Description"]!}')";
                },
                d =>
                {
                    return $"UPDATE [Material] SET Name='{(string)d["Name"]!}', Description='{(string)d["Description"]!}'";
                }
            );
        }
    }
}
