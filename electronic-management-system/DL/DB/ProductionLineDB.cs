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
    internal class ProductionLineDB : IProductionLineDL
    {
        public List<ProductionLine> GetProductionLines()
        {
            var table = itcrafts.Utils.DB.ExecuteAndGetDataSet("SELECT * FROM [ProductionLine]");
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
            try
            {
                itcrafts.Utils.DB.Execute($"INSERT INTO [ProductionLine] (Name, Description) VALUES ('{productionLine.GetName()}', '{productionLine.GetDescription()}')");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateProductionLine(int productionLineId, ProductionLine productionLine)
        {
            try
            {
                itcrafts.Utils.DB.Execute($"UPDATE [ProductionLine] SET Name='{productionLine.GetName()}', Description='{productionLine.GetDescription()}' WHERE Id={productionLineId}");
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveProductionLine(int productionLineId)
        {
            try
            {
                itcrafts.Utils.DB.Execute($"DELETE FROM [ProductionLine] WHERE Id={productionLineId}");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
