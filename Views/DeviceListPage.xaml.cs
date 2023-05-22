using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class DeviceListPage : ContentPage
{
    private DeviceListPageViewModel _viewMode;
    public DeviceListPage(DeviceListPageViewModel viewModel)
	{
		InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetDeviceListCommand.Execute(null);
    }
}