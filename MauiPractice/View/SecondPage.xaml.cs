
using MauiPractice.ViewModel;

namespace MauiPractice.View;

public partial class SecondPage : ContentPage
{
    public SecondPage(SecondPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}

