using itcrafts.BL;
using itcrafts.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.DL.DB
{
    public class AuditLogDB: IAuditLogDL
    {
        public void Audit(AuditLog log)
        {
            string userId = log.GetUserId() == null ? "NULL" : log.GetUserId().ToString()!;
            Utils.DB.Execute($"INSERT INTO [AuditLog] (ActionType, Description, [Status], UserId) VALUES ({(int) log.GetActionType()}, '{log.GetDescription()}', {(int)log.GetAuditStatus()}, {userId})");
        }

        public List<AuditLog> GetAuditLog()
        {
            var table = Utils.DB.ExecuteAndGetDataSet("SELECT * FROM [AuditLog]");
            var auditLogs = new List<AuditLog>();
            foreach (var row in table)
            {
                var auditLog = new AuditLog(
                    (int)row["Id"]!,
                    (DateTime)row["Timestamp"]!,
                    (ActionType)row["ActionType"]!,
                    (string)row["Description"]!,
                    (AuditStatus)row["Status"]!,
                    (int?)row["UserId"]
                );
                auditLogs.Add(auditLog);
            }
            return auditLogs;
        }
    }
}
