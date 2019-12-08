using itcrafts_lib.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.General
{
    public class ComponentDL
    {
        public static CRUD GetCRUD()
        {
            return new CRUD(
                "Component",
                (
                    ["Id", "Name", "Description", "Category"],
                    [typeof(int), typeof(string), typeof(string), typeof(int)]
                ),
                d =>
                {
                    return $"INSERT INTO [Component] ([Name], Description, Category) VALUES ('{(string)d["Name"]!}', '{(string)d["Description"]!}', {(int)d["Category"]!})";
                },
                d =>
                {
                    return $"UPDATE [Component] SET Name='{(string)d["Name"]!}', Description='{(string)d["Description"]!}', Category={(int)d["Category"]!}";
                }
            );
        }
    }
}
