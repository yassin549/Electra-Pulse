using itcrafts.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.DL.Interfaces
{
    public interface IAuditLogDL
    {
        List<AuditLog> GetAuditLog();
        void Audit(AuditLog log);
    }
}
