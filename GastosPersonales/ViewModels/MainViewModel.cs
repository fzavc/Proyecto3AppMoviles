using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GastosPersonales.Models;

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

    public MainViewModel()
    {
        CargarTransacciones();
    }

    [RelayCommand]
    public async Task AgregarTransaccion(Transaccion t)
    {
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
