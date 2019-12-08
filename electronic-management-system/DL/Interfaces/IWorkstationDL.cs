using itcrafts.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.Interfaces
{
    public interface IWorkstationDL
    {
        List<Workstation> GetWorkstations();
        bool AddWorkstation(Workstation workstation);
        bool UpdateWorkstation(int workstationId, Workstation workstation);
        bool RemoveWorkstation(int workstationId);
    }
}
