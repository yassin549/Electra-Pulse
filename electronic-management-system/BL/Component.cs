using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    public class Component: Abstract.Entity
    {
        Category Category;
        int Stock;

        public Component(int id, string name, string description, Category category, int stock): base(id, name, description)
        {
            Category = category;
            Stock = stock;
        }
    }
}
