namespace ColorMaker;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{

		InitializeComponent();
		Color color = Color.FromRgb((Byte)0,(Byte)0,(Byte)0);
		ColorRectangle.Fill = new SolidColorBrush(color);
	}


	static int[] rgb = {0, 0, 0};
	static string hex = "000000";

	private void updateColor(int r, int g, int b){
		hex = r.ToString("X2")+g.ToString("X2")+b.ToString("X2");
		rgb[0] = r;
		rgb[1] = g;
		rgb[2] = b;
		Color color = Color.FromRgb((Byte)r,(Byte)g,(Byte)b);
		ColorRectangle.Fill = new SolidColorBrush(color);
		HexLabel.Text = "#"+hex;

	}


	private void onRedSliderChanged(object sender, EventArgs e)
	{
		updateColor((int)RedSlider.Value, rgb[1], rgb[2]);
	}

	private void onGreenSliderChanged(object sender, EventArgs e)
	{
		updateColor(rgb[0], (int)GreenSlider.Value, rgb[2]);
	}

	private void onBlueSliderChanged(object sender, EventArgs e)
	{
		updateColor(rgb[0], rgb[1], (int)BlueSlider.Value);
	}

	private void OnGenerateRandomColor(object sender, EventArgs e){
		
		Random rnd = new Random();
		int r_rand = rnd.Next(0,256);
		int g_rand = rnd.Next(0,256);
		int b_rand = rnd.Next(0,256); 
		RedSlider.Value = r_rand;
		GreenSlider.Value = g_rand;
		BlueSlider.Value = b_rand;
		updateColor(r_rand, g_rand, b_rand);
	}

	private void onCopyToClipboard(object sender, EventArgs e){
		Clipboard.Default.SetTextAsync(hex);
	}

		// private void OnCounterClicked(object sender, EventArgs e)
	// {
	// 	count++;

	// 	if (count == 1)
	// 		CounterBtn.Text = $"Clicked {count} time";
	// 	else
	// 		CounterBtn.Text = $"Clicked {count} times";

	// 	SemanticScreenReader.Announce(CounterBtn.Text);
	// }
}


