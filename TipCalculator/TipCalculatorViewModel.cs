using Android.Health.Connect.DataTypes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class TipCalculatorViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PerPersonTotal))]
    [NotifyPropertyChangedFor(nameof(PerPersonTotalFormatted))]
    [NotifyPropertyChangedFor(nameof(SubTotal))]
    [NotifyPropertyChangedFor(nameof(SubTotalFormatted))]
    [NotifyPropertyChangedFor(nameof(Tip))]
    [NotifyPropertyChangedFor(nameof(TipFormatted))]
    private float _bill;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PerPersonTotal))]
    [NotifyPropertyChangedFor(nameof(PerPersonTotalFormatted))]
    [NotifyPropertyChangedFor(nameof(SubTotal))]
    [NotifyPropertyChangedFor(nameof(SubTotalFormatted))]
    [NotifyPropertyChangedFor(nameof(Tip))]
    [NotifyPropertyChangedFor(nameof(TipFormatted))]
    [NotifyPropertyChangedFor(nameof(TipPercentageFormatted))]
    private int _tipPercentage;


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PerPersonTotal))]
    [NotifyPropertyChangedFor(nameof(PerPersonTotalFormatted))]
    [NotifyPropertyChangedFor(nameof(SubTotal))]
    [NotifyPropertyChangedFor(nameof(SubTotalFormatted))]
    [NotifyPropertyChangedFor(nameof(Tip))]
    [NotifyPropertyChangedFor(nameof(TipFormatted))]
    [NotifyPropertyChangedFor(nameof(CanDecrement))]
    private int _amountOfPeople;

    [ObservableProperty]
    private bool _canDecrement;

    //PONERLE OBSERVABLE PROPERTY Y LESERO
    ///
    public float PerPersonTotal => (Bill+(Bill*TipPercentage/100))/AmountOfPeople;
    public float SubTotal => Bill/AmountOfPeople;
    public float Tip => Bill*TipPercentage/100;

    public TipCalculatorViewModel()
    {
        _bill = 0;
        _tipPercentage = 10;
        _amountOfPeople = 1;
        UpdateCanDecrement();
        Console.WriteLine("🟢 TipCalculatorViewModel iniciado");
    }

    [RelayCommand]
    public void OnBillChanged(int value)
    {
        Console.WriteLine($"Nuevo Bill: {value}");
    }

    [RelayCommand]
    public void OnTenPercentTip(){
        TipPercentage = 10;
    }

    [RelayCommand]
    public void OnFifteenPercentTip(){
        TipPercentage = 15;
    }

    [RelayCommand]
    public void OnTwentyPercentTip(){
        TipPercentage = 20;
    }

    [RelayCommand]
    public void OnTipPercentageSliderValueChanged(int value){
        TipPercentage = value;
    }


    private void UpdateCanDecrement()
    {
        CanDecrement = AmountOfPeople > 1;
     }

    [RelayCommand]
    public void OnIncreaseAmountOfPeople(){
        AmountOfPeople++;
        UpdateCanDecrement();
        Console.WriteLine($"People: {AmountOfPeople}");
    }

    [RelayCommand]
    public void OnDecreaseAmountOfPeople(){
        AmountOfPeople--;
        UpdateCanDecrement();
    }

    public string PerPersonTotalFormatted => $"${PerPersonTotal:F2}";
    public string SubTotalFormatted => $"${SubTotal:F2}";
    public string TipFormatted => $"${Tip:F2}";
    public string TipPercentageFormatted => $"{TipPercentage}%";

}
// SE PUEDE COMPRIMIR MÁS