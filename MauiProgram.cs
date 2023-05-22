using SQLiteDemo.Services;
using SQLiteDemo.ViewModels;
using SQLiteDemo.Views;

namespace SQLiteDemo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<IDeviceService, DeviceService>();


        //Views Registration
        builder.Services.AddSingleton<DeviceListPage>();
        builder.Services.AddTransient<AddUpdateDeviceDetail>();


        //View Modles 
        builder.Services.AddSingleton<DeviceListPageViewModel>();
        builder.Services.AddTransient<AddUpdateDeviceDetailViewModel>();


        return builder.Build();
    }
}
