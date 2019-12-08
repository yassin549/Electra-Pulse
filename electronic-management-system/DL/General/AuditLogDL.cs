using itcrafts.BL;
using itcrafts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.DL.General
{
    public class AuditLogDL
    {
        public static List<AuditLog> GetAuditLogs()
        {
            var auditLogs = ObjectHandler.GetAuditLogDL().GetAuditLog();
            return auditLogs.FindAll(
                l => !(l.GetActionType() == ActionType.Read && l.GetDescription().Contains("Log In"))
            );
        }

        public static List<AuditLog> GetAccessLogs()
        {
            var auditLogs = ObjectHandler.GetAuditLogDL().GetAuditLog();
            return auditLogs.FindAll(
                l => l.GetActionType() == ActionType.Read && l.GetDescription().Contains("Log In")
            );
        }
    }
}
