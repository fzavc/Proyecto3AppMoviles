using GastosPersonales.ViewModels; // Add this line if MainViewModel is in this namespace

namespace GastosPersonales;

public partial class App : Application
{
    public App()
{
    InitializeComponent();
    var vm = new MainViewModel();
    MainPage = new NavigationPage(new MainPage { BindingContext = vm });
    Task.Run(() => vm.CargarTransacciones()); // cargar al inicio
}

}
