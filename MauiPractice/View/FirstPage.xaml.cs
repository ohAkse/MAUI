

using MauiPractice.ViewModel;

namespace MauiPractice.View;

public partial class FirstPage : ContentPage
{
    public FirstPage(FirstPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}

