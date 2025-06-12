// Services/BaseDatos.cs
using SQLite;
using System.IO;

public class BaseDatos
{
    private static SQLiteAsyncConnection db;

    public static async Task Init()
    {
        if (db != null) return;

        var ruta = Path.Combine(FileSystem.AppDataDirectory, "finanzas.db");
        db = new SQLiteAsyncConnection(ruta);
        await db.CreateTableAsync<Transaccion>();
    }

    public static Task<List<Transaccion>> Obtener() => db.Table<Transaccion>().ToListAsync();

    public static Task Insertar(Transaccion transaccion) => db.InsertAsync(transaccion);
}
