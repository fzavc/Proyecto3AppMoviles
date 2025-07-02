using GastosPersonales.ViewModels;

namespace GastosPersonales.Views;

public partial class MainPage : ContentPage
{
    MainViewModel vm;

    public MainPage()
    {
        InitializeComponent();
        vm = new MainViewModel();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await vm.CargarTransacciones(); 
    }

      private async void OnAgregarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TransaccionPage());
    }
}
