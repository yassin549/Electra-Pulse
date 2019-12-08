using itcrafts.BL;
using itcrafts.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.DL.FH
{
    public class AuditLogFH: IAuditLogDL
    {
        public void Audit(AuditLog log)
        {
            Utils.FH.AddData("AuditLog", AuditLog.Schema, new Dictionary<string, object?> {
                ["Id"] = Utils.FH.GetUniqueId(),
                ["Timestamp"] = DateTime.Now,
                ["UserId"] = log.GetUserId(),
                ["ActionType"] = (int) log.GetActionType(),
                ["Status"] = (int) log.GetAuditStatus(),
                ["Description"] = log.GetDescription(),
            });
        }

        public List<AuditLog> GetAuditLog()
        {
            var auditLogs = new List<AuditLog>();
            var table = Utils.FH.LoadData("AuditLog", AuditLog.Schema);
            foreach (var row in table)
            {
                auditLogs.Add(new AuditLog(
                    (int) row["Id"]!,
                    (DateTime)row["Timestamp"]!,
                    (ActionType)row["ActionType"]!,
                    (string)row["Description"]!,
                    (AuditStatus)row["Status"]!,
                    (int?)row["UserId"]
                ));
            }
            return auditLogs;
        }
    }
}
