using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteDemo.Models;
using SQLiteDemo.Services;
using SQLiteDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.ViewModels
{
    public partial class DeviceListPageViewModel : ObservableObject
    {
        public static List<DeviceModel> DevicesListForSearch { get; private set; } = new List<DeviceModel>();
        public ObservableCollection<DeviceModel> Devices { get; set; } = new ObservableCollection<DeviceModel>();

        private readonly IDeviceService _DeviceService;
        public DeviceListPageViewModel(IDeviceService DeviceService)
        {
            _DeviceService = DeviceService;
        }



        [RelayCommand]
        public async void GetDeviceList()
        {
            Devices.Clear();
            var DeviceList = await _DeviceService.GetDeviceList();
            if (DeviceList?.Count > 0)
            {
                DeviceList = DeviceList.OrderBy(f => f.FullName).ToList();
                foreach (var Device in DeviceList)
                {
                    Devices.Add(Device);
                }
                DevicesListForSearch.Clear();
                DevicesListForSearch.AddRange(DeviceList);
            }
        }


        [RelayCommand]
        public async void AddUpdateDevice()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateDeviceDetail));
        }

        [RelayCommand]
        public async void EditDevice(DeviceModel DeviceModel)
        {
            var navParam = new Dictionary<string, object>();
            navParam.Add("DeviceDetail", DeviceModel);
            await AppShell.Current.GoToAsync(nameof(AddUpdateDeviceDetail), navParam);
        }

        [RelayCommand]
        public async void DeleteDevice(DeviceModel DeviceModel)
        {
            var delResponse = await _DeviceService.DeleteDevice(DeviceModel);
            if (delResponse > 0)
            {
                GetDeviceList();
            }
        }


        [RelayCommand]
        public async void DisplayAction(DeviceModel DeviceModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Select Option", "OK", null, "Edit", "Delete");
            if (response == "Edit")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("DeviceDetail", DeviceModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateDeviceDetail), navParam);
            }
            else if (response == "Delete")
            {
                var delResponse = await _DeviceService.DeleteDevice(DeviceModel);
                if (delResponse > 0)
                {
                    GetDeviceList();
                }
            }
        }
    }
}
