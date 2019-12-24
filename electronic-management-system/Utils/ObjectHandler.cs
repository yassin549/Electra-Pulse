using itcrafts.DL.DB;
using itcrafts.DL.FH;
using itcrafts.DL.Interfaces;
using itcrafts_lib;
using itcrafts_lib.DL.DB;
using itcrafts_lib.DL.FH;
using itcrafts_lib.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.Utils
{
    public class ObjectHandler
    {
        static IUserDL UserDL = Config.IsFHMode() ? new UserFH() : new UserDB();
        static IAuditLogDL AuditLogDL = Config.IsFHMode() ? new AuditLogFH() : new AuditLogDB();
        static IProductionLineDL ProductionLineDL = Config.IsFHMode() ? new ProductionLineFH() : new ProductionLineDB();
        static IWorkstationDL WorkstationDL = Config.IsFHMode() ? new WorkstationFH() : new WorkstationDB();

        public static IUserDL GetUserDL()
        {
            return UserDL;
        }

        public static IAuditLogDL GetAuditLogDL()
        {
            return AuditLogDL;
        }

        public static IProductionLineDL GetProductionLineDL()
        {
            return ProductionLineDL;
        }

        public static IWorkstationDL GetWorkstationDL()
        {
            return WorkstationDL;
        }
    }
}
