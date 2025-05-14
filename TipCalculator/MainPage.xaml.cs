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

	private void OnTipPercentageSliderValueChanged(object sender, ValueChangedEventArgs e){
		viewModel.TipPercentageSliderValueChanged(e.NewValue);
	}

	
}

public class IntToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int intValue)
        {
            return intValue.ToString();
        }
        return "0";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string stringValue && int.TryParse(stringValue, out int result))
        {
            return result;
        }
        return 0;
    }
}



