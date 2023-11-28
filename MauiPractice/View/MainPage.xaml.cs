using MauiPractice.ViewModel;
namespace MauiPractice;

public partial class MainPage : ContentPage
{

	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;

    }    
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}

