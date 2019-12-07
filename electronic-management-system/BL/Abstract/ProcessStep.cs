using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL.Abstract
{
    public abstract class ProcessStep: Entity
    {
        public ProcessStep(int id, string name, string description): base(id, name, description) {}
    }
}
