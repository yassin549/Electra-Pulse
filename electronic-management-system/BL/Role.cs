using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.BL
{
    public class Role
    {
        static (string[], Type[]) Schema = (
            ["Id", "UserId", "Role"],
            [typeof(int), typeof(int), typeof(int)]
        );

        public static (string[], Type[]) GetSchema()
        {
            return Schema;
        }

        public static string GetLabel(RoleType role)
        {
            switch (role)
            {
                case RoleType.Admin:
                    return "Admin";
                case RoleType.HumanResourceManager:
                    return "Human Resource Manager";
                case RoleType.InventoryManager:
                    return "Inventory Manager";
                case RoleType.SupplyChainManager:
                    return "Supply Chain Manager";
                case RoleType.ManufacturingEngineer:
                    return "Manufacturing Engineer";
                case RoleType.QualityAssuranceEngineer:
                    return "Quality Assurance Engineer";
                default:
                    return "";
            }
        }

        public static List<string> GetLabelsOfRoles(List<RoleType> roles)
        {
            return roles.Select(r => GetLabel(r)).ToList();
        }
    }

    public enum RoleType
    {
        Admin,
        HumanResourceManager,
        InventoryManager,
        SupplyChainManager,
        ManufacturingEngineer,
        QualityAssuranceEngineer
    }
}
