using itcrafts_lib.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts_lib.DL.General
{
    public class DeviceTestDL
    {
        public static CRUD GetCRUD()
        {
            return new CRUD(
                "DeviceTest",
                (
                    ["Id", "DeviceId", "Title", "Performance", "Body", "Timestamp"],
                    [typeof(int), typeof(int), typeof(string), typeof(int), typeof(string), typeof(DateTime)]
                ),
                d =>
                {
                    return $"INSERT INTO [DeviceTest] (DeviceId, Title, Performance, Body) VALUES ({(int)d["DeviceId"]!}, '{(string)d["Title"]!}', {(int)d["Performance"]!}, '{(string)d["Body"]!}')";
                },
                d =>
                {
                    return $"UPDATE [DeviceTest] SET DeviceId={(int)d["DeviceId"]!}, Title='{(string)d["Title"]!}', Performance={(int)d["Performance"]!}, Body='{(string)d["Body"]!}'";
                }
            );
        }
    }
}
