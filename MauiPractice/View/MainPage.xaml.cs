using MauiPractice.viewModel;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
namespace MauiPractice;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel(new NetworkService(new HttpClient()));
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();;
    }


}

