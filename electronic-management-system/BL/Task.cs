using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    public class Task: Abstract.Entity
    {
        public Task(int id, string name, string description): base(id, name, description) { }
    }
}
