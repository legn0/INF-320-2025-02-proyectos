using SQLite;

namespace GastosApp.Models;

public class Transaccion
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Glosa { get; set; } = string.Empty;

    public double Monto { get; set; }

    public DateTime Fecha { get; set; }

    public bool EsIngreso { get; set; }
}
