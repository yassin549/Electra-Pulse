using itcrafts.BL;
using itcrafts.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.Utils
{
    public class Logger
    {
        public static void Log(ActionType actionType, AuditStatus status, string description, int? userId = null)
        {
            IAuditLogDL auditLogDL = ObjectHandler.GetAuditLogDL();
            auditLogDL.Audit(new AuditLog(actionType, status, description, userId));
        }
    }
}
