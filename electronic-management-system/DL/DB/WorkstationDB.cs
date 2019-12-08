using itcrafts.BL;
using itcrafts_lib.DL.FH;
using itcrafts_lib.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.DB
{
    internal class WorkstationDB : IWorkstationDL
    {
        public List<Workstation> GetWorkstations()
        {
            var table = itcrafts.Utils.DB.ExecuteAndGetDataSet("SELECT * FROM [Workstation]");
            var dataSet = new List<Workstation>();
            foreach (var row in table)
            {
                var Workstation = new Workstation(row);
                dataSet.Add(Workstation);
            }
            return dataSet;
        }
        public bool AddWorkstation(Workstation workstation)
        {
            try
            {
                itcrafts.Utils.DB.Execute($"INSERT INTO [Workstation] (ProductionLineId, [Name]) VALUES ({workstation.GetProductionLineId()}, '{workstation.GetName()}')");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateWorkstation(int workstationId, Workstation workstation)
        {
            try
            {
                itcrafts.Utils.DB.Execute($"UPDATE [Workstation] SET ProductionLineId={workstation.GetProductionLineId()}, Name='{workstation.GetName()}' WHERE Id={workstationId}");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveWorkstation(int WorkstationId)
        {
            try
            {
                itcrafts.Utils.DB.Execute($"DELETE FROM [Workstation] WHERE Id={WorkstationId}");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
