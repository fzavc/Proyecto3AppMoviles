// ViewModels/MainViewModel.cs
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace GastosPersonales.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<Transaccion> transacciones = new();

    [ObservableProperty]
    double balance;

    [ObservableProperty]
    double ingresos;

    [ObservableProperty]
    double gastos;

    [ObservableProperty]
    string descripcion;

    [ObservableProperty]
    double monto;

    [ObservableProperty]
    string tipo = "Ingreso";

    [RelayCommand]
    public async Task AgregarTransaccion(string tipo)
    {
        Tipo = tipo;
        var t = new Transaccion { Descripcion = descripcion, Monto = monto, Tipo = tipo };
        await BaseDatos.Insertar(t);
        await CargarTransacciones();
    }


    public async Task CargarTransacciones()
    {
        await BaseDatos.Init();
        var lista = await BaseDatos.Obtener();
        Transacciones = new(lista);
        CalcularTotales();
    }

    private void CalcularTotales()
    {
        Ingresos = Transacciones.Where(t => t.Tipo == "Ingreso").Sum(t => t.Monto);
        Gastos = Transacciones.Where(t => t.Tipo == "Gasto").Sum(t => t.Monto);
        Balance = Ingresos - Gastos;
    }
}
