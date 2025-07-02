using SQLite;

namespace GastosApp.Models;

[Table("Settings")]
public class Settings
{
    [PrimaryKey, Column("Key")]
    public string Key { get; set; }
    public string Value { get; set; }
}