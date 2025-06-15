using GastosPersonales.Models;
using GastosPersonales.ViewModels;

namespace GastosPersonales.Views;

public partial class TransaccionPage : ContentPage
{
    private MainViewModel vm;

    public TransaccionPage()
    {
        InitializeComponent();
        vm = new MainViewModel();
        BindingContext = vm;
    }

    private void OnIngresoClicked(object sender, EventArgs e)
    {
        var transaccion = new Transaccion
        {
            Descripcion = descEntry.Text,
            Monto = double.TryParse(montoEntry.Text, out double m) ? m : 0,
            Tipo = "Ingreso"
        };

        vm.AgregarTransaccionCommand.Execute(transaccion);
        Navigation.PopAsync();
    }

    private void OnGastoClicked(object sender, EventArgs e)
    {
        var transaccion = new Transaccion
        {
            Descripcion = descEntry.Text,
            Monto = double.TryParse(montoEntry.Text, out double m) ? m : 0,
            Tipo = "Gasto"
        };

        vm.AgregarTransaccionCommand.Execute(transaccion);
        Navigation.PopAsync();
    }
}

