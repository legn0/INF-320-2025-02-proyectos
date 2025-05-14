using Microsoft.Maui.Controls;
using System.Globalization;

namespace TipCalculator;

public partial class MainPage : ContentPage
{
	// int count = 0;
	private TipCalculatorViewModel viewModel;

	public MainPage()
	{
		InitializeComponent();
		viewModel = new TipCalculatorViewModel();
		BindingContext = viewModel;
	}

	public void OnTipPercentageSliderValueChanged(object sender, ValueChangedEventArgs e){
		viewModel.OnTipPercentageSliderValueChanged((int)e.NewValue); 
        // Se incluye el int para realizar el cambio de tipo, pues se recibe un double
	}


	
}

public class IntToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is int intValue)
        {
            return intValue.ToString();
        }
        return "0";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string stringValue && int.TryParse(stringValue, out int result))
        {
            return result;
        }
        return 0;
    }

    //Se incluyeron los signos "?" para evitar lanzamiento de warnings debido a posible valor null recibido 
    //(no deberia ocurrir, pero la función Convert() está adaptada para recibir ese caso tambien)
}



