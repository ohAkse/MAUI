


using System.Windows.Input;

namespace MauiPractice.ViewModel;

public class MainPageDetailViewModel : BaseViewModel
{
	public ICommand TouchDialogCommand { get; set; }

	private readonly IDialogService _dialogService;
	public MainPageDetailViewModel(IDialogService dialogService)
	{
		_dialogService = dialogService;
		TouchDialogCommand = new Command(ExecuteDialogCommand);
	}
	public MainPageDetailViewModel(){}

	private async void ExecuteDialogCommand(object item)
	{
		var b = await _dialogService.ShowConfirmationAsync("메세지","확인눌러볼까요?");
		Console.WriteLine(b);
	}
}


