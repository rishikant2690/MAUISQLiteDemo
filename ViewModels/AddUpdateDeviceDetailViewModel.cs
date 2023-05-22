using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SQLiteDemo.Models;
using SQLiteDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.ViewModels
{
    [QueryProperty(nameof(DeviceDetail), "DeviceDetail")]
    public partial class AddUpdateDeviceDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private DeviceModel _DeviceDetail = new DeviceModel();

        private readonly IDeviceService _DeviceService;
        public AddUpdateDeviceDetailViewModel(IDeviceService DeviceService)
        {
            _DeviceService = DeviceService;
        }

        [RelayCommand]
        public async void AddUpdateDevice()
        {
            int response = -1;
            if (DeviceDetail.DeviceID > 0)
            {
                response = await _DeviceService.UpdateDevice(DeviceDetail);
            }
            else
            {
                response = await _DeviceService.AddDevice(new Models.DeviceModel
                {
                    DeviceName = DeviceDetail.DeviceName,
                    Location = DeviceDetail.Location,
                    Comment = DeviceDetail.Comment,
                });
            }

        

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Device Info Saved", "Record Saved", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Heads Up!", "Something went wrong while adding record", "OK");
            }
        }

    }
}
