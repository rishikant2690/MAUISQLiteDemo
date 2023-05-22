using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Models
{
    public class DeviceModel
    {
        [PrimaryKey, AutoIncrement]
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; }
        [Ignore]
        public string FullName => $"{DeviceName}";
    }
}
