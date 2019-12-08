using itcrafts.BL;
using itcrafts_lib.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.FH
{
    internal class ProductionLineFH : IProductionLineDL
    {
        public List<ProductionLine> GetProductionLines()
        {
            var table = itcrafts.Utils.FH.LoadData("ProductionLine", ProductionLine.GetSchema());
            var dataSet = new List<ProductionLine>();
            foreach (var row in table)
            {
                var productionLine = new ProductionLine(
                    (int)row["Id"]!,
                    (string)row["Name"]!,
                    (string)row["Description"]!
                );
                dataSet.Add(productionLine);
            }
            return dataSet;
        }
        public bool AddProductionLine(ProductionLine productionLine)
        {
            var lines = itcrafts.Utils.FH.LoadData("ProductionLine", ProductionLine.GetSchema());
            lines.Add(new Dictionary<string, object?>
            {
                ["Id"] = itcrafts.Utils.FH.GetUniqueId(),
                ["Name"] = productionLine.GetName(),
                ["Description"] = productionLine.GetDescription()
            });
            itcrafts.Utils.FH.SaveData("ProductionLine", lines);
            return true;
        }
        public bool UpdateProductionLine(int productionLineId, ProductionLine productionLine)
        {
            var lines = itcrafts.Utils.FH.LoadData("ProductionLine", ProductionLine.GetSchema());
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                if ((int)line["Id"]! == productionLineId)
                {
                    line["Id"] = productionLine.GetId();
                    line["Name"] = productionLine.GetName();
                    line["Description"] = productionLine.GetDescription();
                }
            }
            itcrafts.Utils.FH.SaveData("ProductionLine", lines);
            return true;
        }
        public bool RemoveProductionLine(int productionLineId)
        {
            var lines = itcrafts.Utils.FH.LoadData("ProductionLine", ProductionLine.GetSchema());
            lines.RemoveAll(l => (int)l["Id"]! == productionLineId);
            itcrafts.Utils.FH.SaveData("ProductionLine", lines);
            return true;
        }
    }
}
