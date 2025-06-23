namespace GastosPersonales.Models;

public class Transaccion
{
    public string? Descripcion { get; set; }
    public double Monto { get; set; }
    public string? Tipo { get; set; } // Si es tipo "Ingreso" o tipo "Gasto"
    public DateTime Fecha { get; set; } = DateTime.Now; // Para mostrar la  fecha
    
    public string MontoConSigno => (Tipo == "Ingreso" ? "+" : "-") + Monto.ToString(); // Muestra el monto con signo + o -

    public Color ColorMonto => Tipo == "Ingreso" ? Colors.Green : Colors.Red;// Muestra el color del monto
}

