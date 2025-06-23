using GastosPersonales.Models;
using SQLite;

public static class BaseDatos
{
    static SQLiteAsyncConnection? db;

    public static async Task Init()
    {
        if (db != null)
            return;

        var ruta = Path.Combine(FileSystem.AppDataDirectory, "transacciones.db");
        db = new SQLiteAsyncConnection(ruta);
        await db.CreateTableAsync<Transaccion>();
    }

    public static async Task Insertar(Transaccion t) =>
        await db.InsertAsync(t);

    public static async Task<List<Transaccion>> Obtener() =>
        await db.Table<Transaccion>().ToListAsync();
}
