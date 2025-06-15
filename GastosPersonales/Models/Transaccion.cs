// Models/Transaccion.cs
namespace GastosPersonales.Models;

public class Transaccion
{
    public string? Descripcion { get; set; }
    public double Monto { get; set; }
    public string? Tipo { get; set; } // "Ingreso" o "Gasto"
}

