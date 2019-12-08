using itcrafts.BL;
using itcrafts_lib.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.FH
{
    internal class WorkstationFH : IWorkstationDL
    {
        public List<Workstation> GetWorkstations()
        {
            var table = itcrafts.Utils.FH.LoadData("Workstation", Workstation.GetSchema());
            var dataSet = new List<Workstation>();
            foreach (var row in table)
            {
                var workstation = new Workstation(row);
                dataSet.Add(workstation);
            }
            return dataSet;
        }
        public bool AddWorkstation(Workstation workstation)
        {
            var lines = itcrafts.Utils.FH.LoadData("Workstation", Workstation.GetSchema());
            lines.Add(new Dictionary<string, object?>
            {
                ["Id"] = itcrafts.Utils.FH.GetUniqueId(),
                ["ProductionLineId"] = workstation.GetProductionLineId(),
                ["Name"] = workstation.GetName()
            });
            itcrafts.Utils.FH.SaveData("Workstation", lines);
            return true;
        }
        public bool UpdateWorkstation(int workstationId, Workstation workstation)
        {
            var lines = itcrafts.Utils.FH.LoadData("Workstation", Workstation.GetSchema());
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                if ((int)line["Id"]! == workstationId)
                {
                    line["Id"] = workstation.GetId();
                    line["ProductionLineId"] = workstation.GetProductionLineId();
                    line["Name"] = workstation.GetName();
                }
            }
            itcrafts.Utils.FH.SaveData("Workstation", lines);
            return true;
        }
        public bool RemoveWorkstation(int workstationId)
        {
            var lines = itcrafts.Utils.FH.LoadData("Workstation", Workstation.GetSchema());
            lines.RemoveAll(l => (int)l["Id"]! == workstationId);
            itcrafts.Utils.FH.SaveData("Workstation", lines);
            return true;
        }
    }
}
