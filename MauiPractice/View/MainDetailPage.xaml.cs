using MauiPractice.ViewModel;

namespace MauiPractice.View;

public partial class MainDetailPage : ContentPage
{
    public MainDetailPage(MainPageDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}

