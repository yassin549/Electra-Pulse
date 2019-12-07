using itcrafts.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.BL.Abstract
{
    internal class EntityWithCategory: Entity
    {
        int Category;
        public EntityWithCategory(int id, string name, string description, int category): base(id, name, description)
        {
            Category = category;
        }

        public int GetCategory()
        {
            return Category;
        }

        public EntityWithCategory(Dictionary<string, object?> data): base(data)
        {
            Category = (int)data["Category"]!;
        }
        public static new (string[], Type[]) Schema = (
            ["Id", "Name", "Description", "Category"],
            [typeof(int), typeof(string), typeof(string), typeof(int)]
        );
    }
}
