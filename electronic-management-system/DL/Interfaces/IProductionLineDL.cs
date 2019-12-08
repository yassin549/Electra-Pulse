using itcrafts.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.Interfaces
{
    public interface IProductionLineDL
    {
        List<ProductionLine> GetProductionLines();
        bool AddProductionLine(ProductionLine productionLine);
        bool UpdateProductionLine(int productionLineId, ProductionLine productionLine);
        bool RemoveProductionLine(int productionLineId);
    }
}
