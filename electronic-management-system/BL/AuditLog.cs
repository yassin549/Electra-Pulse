using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    public enum ActionType
    {
        Read,
        Create,
        Update,
        Delete
    }

    public enum AuditStatus
    {
        Failed,
        Success
    }

    public class AuditLog
    {
        int Id;
        DateTime Timestamp;
        ActionType ActionType;
        string Description;
        AuditStatus Status;
        int? UserId;

        public int GetId()
        {
            return Id;
        }

        public DateTime GetTimestamp()
        {
            return Timestamp;
        }

        public ActionType GetActionType()
        {
            return ActionType;
        }

        public string GetDescription()
        {
            return Description;
        }

        public AuditStatus GetAuditStatus()
        {
            return Status;
        }

        public int? GetUserId()
        {
            return UserId;
        }

        public AuditLog(int id, DateTime timestamp, ActionType actionType, string description, AuditStatus auditStatus, int? userId)
        {
            Id = id;
            Timestamp = timestamp;
            ActionType = actionType;
            Description = description;
            Status = auditStatus;
            UserId = userId;
        }

        public AuditLog(ActionType actionType, AuditStatus auditStatus, string description, int? userId)
        {
            Id = 0;
            Timestamp = DateTime.Now;
            Status = auditStatus;
            ActionType = actionType;
            Description = description;
            UserId = userId;
        }

        public static (string[], Type[]) Schema = (
            ["Id", "Timestamp", "UserId", "ActionType", "Status", "Description"],
            [typeof(int), typeof(DateTime), typeof(int), typeof(int), typeof(int), typeof(string)]
        );
    }
}
