namespace MauiPractice;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel(new NetworkService(new HttpClient()));
	}
}

