// Models/Transaccion.cs
using SQLite;

public class Transaccion
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Tipo { get; set; } // "Ingreso" o "Gasto"
    public string Descripcion { get; set; }
    public double Monto { get; set; }
}
