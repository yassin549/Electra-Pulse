using itcrafts_lib.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.General
{
    public class DeviceDefectDL
    {
        public static CRUD GetCRUD()
        {
            return new CRUD(
                "DeviceDefect",
                (
                    ["Id", "DeviceId", "Category", "Description", "Timestamp"],
                    [typeof(int), typeof(int), typeof(int), typeof(string), typeof(DateTime)]
                ),
                d =>
                {
                    return $"INSERT INTO [DeviceDefect] (DeviceId, Description, Category) VALUES ({(int)d["DeviceId"]!}, '{(string)d["Description"]!}', {(int)d["Category"]!})";
                },
                d =>
                {
                    return $"UPDATE [DeviceDefect] SET DeviceId={(int)d["DeviceId"]!}, Description='{(string)d["Description"]!}', Category={(int)d["Category"]!}";
                }
            );
        }
    }
}
