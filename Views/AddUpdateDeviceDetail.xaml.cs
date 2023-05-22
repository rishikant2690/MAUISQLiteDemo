using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class AddUpdateDeviceDetail : ContentPage
{
    public AddUpdateDeviceDetail(AddUpdateDeviceDetailViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}