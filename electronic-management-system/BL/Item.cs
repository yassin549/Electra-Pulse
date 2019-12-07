using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    public class Item: Abstract.Entity
    {
        public Item(int id, string name, string description): base(id, name, description) { }
    }
}
