namespace GastosPersonales.Models;

public class Transaccion
{
    public string? Descripcion { get; set; }
    public double Monto { get; set; }
    public string? Tipo { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now; 
    
    public string MontoConSigno => (Tipo == "Ingreso" ? "+" : "-") + Monto.ToString(); 

    public Color ColorMonto => Tipo == "Ingreso" ? Colors.Green : Colors.Red;
}

