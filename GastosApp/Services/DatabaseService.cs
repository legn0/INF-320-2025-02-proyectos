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
        await _db.CreateTableAsync<Settings>();
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

    public async Task SaveSettingAsync(string key, string value)
    {
        await Init();
        if (_db == null)
            throw new InvalidOperationException("Database not initialized.");

        var setting = await _db.FindAsync<Settings>(key);
        if (setting == null)
        {
            await _db.InsertAsync(new Settings { Key = key, Value = value });
        }
        else
        {
            setting.Value = value;
            await _db.UpdateAsync(setting);
        }
    }

    public async Task<string> GetSettingAsync(string key)
    {
        await Init();
        if (_db == null)
            throw new InvalidOperationException("Database not initialized.");

        var setting = await _db.FindAsync<Settings>(key);
        return setting?.Value ?? string.Empty;
    }
}
