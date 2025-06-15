// Models/Transaccion.cs
namespace GastosPersonales.Models;

public class Transaccion
{
    public string? Descripcion { get; set; }
    public double Monto { get; set; }
    public string? Tipo { get; set; } // "Ingreso" o "Gasto"
    public DateTime Fecha { get; set; } = DateTime.Now; // <- Nueva propiedad
    // Propiedad para mostrar el monto con signo + o -
    public string MontoConSigno => (Tipo == "Ingreso" ? "+" : "-") + Monto.ToString();

    // Propiedad para bindear el color del monto (esto es un ejemplo simple)
    public Color ColorMonto => Tipo == "Ingreso" ? Colors.Green : Colors.Red;
}

