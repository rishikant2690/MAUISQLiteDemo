using SQLite;
using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Services
{
    public class DeviceService : IDeviceService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Device.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<DeviceModel>();
            }
        }

        public async Task<int> AddDevice(DeviceModel DeviceModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(DeviceModel);
        }

        public async Task<int> DeleteDevice(DeviceModel DeviceModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(DeviceModel);
        }

        public async Task<List<DeviceModel>> GetDeviceList()
        {
            await SetUpDb();
            var DeviceList = await _dbConnection.Table<DeviceModel>().ToListAsync();
            return DeviceList;
        }

        public async Task<int> UpdateDevice(DeviceModel DeviceModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(DeviceModel);
        }
    }
}
