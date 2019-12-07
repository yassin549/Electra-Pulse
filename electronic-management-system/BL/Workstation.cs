using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    public class Workstation
    {
        int Id;
        int ProductionLineId;
        string Name;
        public static (string[], Type[]) Schema = (
            ["Id", "ProductionLineId", "Name"],
            [typeof(int), typeof(int), typeof(string)]
        );

        public static (string[], Type[]) GetSchema()
        {
            return Schema;
        }

        public int GetId() {  return Id; }
        public int GetProductionLineId() {  return ProductionLineId; }
        public string GetName() { return Name; }

        public Workstation(int id, int productionLineId, string name)
        {
            Id = id;
            ProductionLineId = productionLineId;
            Name = name;
        }

        public Workstation(Dictionary<string, object?> data)
        {
            Id = (int)data["Id"]!;
            ProductionLineId = (int)data["ProductionLineId"]!;
            Name = (string)data["Name"]!;
        }

        public static bool IsNameValid(string name)
        {
            return name.Length > 5 && name.Length < 25;
        }
    }
}
