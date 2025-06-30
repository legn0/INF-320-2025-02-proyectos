using GastosApp.Models;
using SQLite;

namespace GastosApp.Services;

public class DatabaseService
{
    private SQLiteAsyncConnection? _db;

    private async Task Init()
    {
        if (_db != null)
            return;

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "transacciones.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        await _db.CreateTableAsync<Transaccion>();
    }

    public async Task<List<Transaccion>> GetTransaccionesAsync()
    {
        await Init();
        if (_db == null)
            throw new InvalidOperationException("Database not initialized.");
        return await _db.Table<Transaccion>().OrderByDescending(t => t.Fecha).ToListAsync();
    }

    public async Task AddTransaccionAsync(Transaccion transaccion)
    {
        await Init();
        if (_db == null)
            throw new InvalidOperationException("Database not initialized.");
        await _db.InsertAsync(transaccion);
    }
}
