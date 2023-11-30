using System.Windows.Input;
using MauiPractice.View;

namespace MauiPractice.ViewModel;

public class FirstPageViewModel : BaseViewModel
{

    public ICommand NavigationCommand {get; set;}

	public FirstPageViewModel()
	{
        
        NavigationCommand = new Command(ExecuteNavigationCommand);
	}

    private async void ExecuteNavigationCommand(object o)
    {
        MainDetailPage mainDetailPage = new MainDetailPage(new MainPageDetailViewModel());
        await Application.Current.MainPage.Navigation.PushAsync(mainDetailPage);
    }
}


