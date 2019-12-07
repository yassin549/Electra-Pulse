using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using itcrafts.BL.Abstract;

namespace itcrafts.BL
{
    public class TestingStep: ProcessStep
    {
        public TestingStep(int Id, string Name, string Description): base(Id, Name, Description) { }
    }
}
