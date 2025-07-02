using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GastosApp.Models;
using GastosApp.Services;

namespace GastosApp.ViewModels;

public class HomeViewModel : INotifyPropertyChanged
{
    private readonly DatabaseService _db;
    private double _balance;
    private double _ingresos;
    private double _egresos;
    private string _userName;

    public ObservableCollection<Transaccion> Transacciones { get; set; } = new();
    public ICommand NavegarANuevaTransaccionCommand { get; }

    public double Balance
    {
        get => _balance;
        set { _balance = value; OnPropertyChanged(); }
    }

    public double Ingresos
    {
        get => _ingresos;
        set { _ingresos = value; OnPropertyChanged(); }
    }

    public double Egresos
    {
        get => _egresos;
        set { _egresos = value; OnPropertyChanged(); }
    }

    public string UserName
    {
        get => _userName;
        set { _userName = value; OnPropertyChanged(); }
    }

    public HomeViewModel(DatabaseService db)
    {
        _db = db;
        NavegarANuevaTransaccionCommand = new Command(async () => await NavegarANuevaTransaccion());
        LoadUserName();
    }

    public void CargarDatos()
    {
        _ = Task.Run(async () =>
        {
            var transacciones = await _db.GetTransaccionesAsync();
            if (App.Current != null)
            {
                App.Current.Dispatcher.Dispatch(() =>
                {
                    Transacciones.Clear();
                    foreach (var t in transacciones)
                    {
                        Transacciones.Add(t);
                    }
                    CalcularBalance();
                });
            }
        });
    }

    private async void LoadUserName()
    {
        UserName = await _db.GetSettingAsync("UserName") ?? "Usuario";
    }

    public async Task UpdateUserName(string newName)
    {
        UserName = newName;
        await _db.SaveSettingAsync("UserName", newName);
    }

    private void CalcularBalance()
    {
        Ingresos = Transacciones.Where(t => t.EsIngreso).Sum(t => t.Monto);
        Egresos = Transacciones.Where(t => !t.EsIngreso).Sum(t => t.Monto);
        Balance = Ingresos - Egresos;
    }

    private async Task NavegarANuevaTransaccion()
    {
        await Shell.Current.GoToAsync("MainPage");
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}
