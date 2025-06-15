using GastosPersonales.ViewModels; // Add this line if MainViewModel is in this namespace

namespace GastosPersonales;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}

