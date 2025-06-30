using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GastosApp.Models;
using GastosApp.Services;

namespace GastosApp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------
    public ObservableCollection<Transaccion> Transacciones { get; set; } = new();

    public Action<string, string, string>? MostrarAlerta;
    public ICommand CancelarCommand { get; }
    private readonly DatabaseService _db;
    private string _glosa = string.Empty;
    private string _monto = string.Empty;
    private DateTime _fecha = DateTime.Today;
    private bool _esIngreso;

    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------

    public string Glosa
    {
        get => _glosa;
        set { _glosa = value; OnPropertyChanged(); }
    }

    public string Monto
    {
        get => _monto;
        set { _monto = value; OnPropertyChanged(); }
    }

    public DateTime Fecha
    {
        get => _fecha;
        set { _fecha = value; OnPropertyChanged(); }
    }

    public bool EsIngreso
    {
        get => _esIngreso;
        set { _esIngreso = value; OnPropertyChanged(); }
    }

    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------

    public ICommand AgregarCommand { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------

    public MainViewModel(DatabaseService db)
    {
        _db = db;
        AgregarCommand = new Command(async () => await AgregarTransaccion());
        _ = CargarTransacciones();
        CancelarCommand = new Command(() => CancelarFormulario());

    }

    private async Task CargarTransacciones()
    {
        var lista = await _db.GetTransaccionesAsync();
        Transacciones.Clear();
        foreach (var t in lista)
            Transacciones.Add(t);
    }

    private async Task AgregarTransaccion()
    {
        if (string.IsNullOrWhiteSpace(Glosa) || string.IsNullOrWhiteSpace(Monto))
        {
            MostrarAlerta?.Invoke("Error", "Por favor completa todos los campos", "OK");
            return;
        }

        if (!double.TryParse(Monto, out double monto) || monto <= 0)
        {
            MostrarAlerta?.Invoke("Error", "El monto debe ser mayor a 0", "OK");
            return;
        }

        var nueva = new Transaccion
        {
            Glosa = Glosa,
            Monto = monto,
            Fecha = Fecha,
            EsIngreso = EsIngreso
        };

        await _db.AddTransaccionAsync(nueva);

        Glosa = string.Empty;
        Monto = string.Empty;
        EsIngreso = false;
        Fecha = DateTime.Today;

        MostrarAlerta?.Invoke("Éxito", "Transacción registrada", "OK");

        await CargarTransacciones();
    }

    private void CancelarFormulario()
    {
        Glosa = string.Empty;
        Monto = string.Empty;
        Fecha = DateTime.Today;
        EsIngreso = false;
    }

    private void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    //-----------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------------
}

