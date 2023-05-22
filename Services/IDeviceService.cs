using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Services
{
    public interface IDeviceService
    {
        Task<List<DeviceModel>> GetDeviceList();
        Task<int> AddDevice(DeviceModel DeviceModel);
        Task<int> DeleteDevice(DeviceModel DeviceModel);
        Task<int> UpdateDevice(DeviceModel DeviceModel);
    }
}
