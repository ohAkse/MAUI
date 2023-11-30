using System.Windows.Input;
using System.Collections.ObjectModel;
using MauiPractice.Model;
using MauiPractice.Service;
using MauiPractice.View;


namespace MauiPractice.ViewModel;

public class MainPageViewModel : BaseViewModel
{
    #region Commands
    public ICommand AddCountCommand { get; set; }
    public ICommand AddJsonCommand { get; set; }
    public ICommand AddJsonItemCommand { get; set; }
    public ICommand ItemTappedCommand { get; set; }
    public ICommand TouchDialogCommand {get; set;}
    #endregion
    #region Properties
    private int _addCount;
    public int AddCount
    {
        get => _addCount;
        set
        {
            if (_addCount != value)
            {
                _addCount = value;
                OnPropertyChanged(nameof(AddCount));
            }
        }
    }
    private string _jsonString;
    public string JsonString
    {
        get => _jsonString;
        set
        {
            if (_jsonString != value)
            {
                _jsonString = value;
                OnPropertyChanged(nameof(JsonString));
            }
        }
    }
    private ObservableCollection<JsonInfo> _jsonInfos;
    public ObservableCollection<JsonInfo> JsonInfos
    {
        get => _jsonInfos;
        set
        {
            _jsonInfos = value;
            OnPropertyChanged(nameof(JsonInfos));
        }
    }
    private readonly INetworkService _networkService;
    private readonly IDialogService _dialogService;
    #endregion
    #region Constructor
    public MainPageViewModel(INetworkService networkService, IDialogService dialogService)
    {
        //생성자 의존성 주입
        this._networkService = networkService;
        this._dialogService = dialogService;
        //Command 세팅
        AddCountCommand = new Command(ExecuteAddCommand);
        AddJsonCommand = new Command(ExcuteJsonCommand);
        AddJsonItemCommand = new Command(ExcuteJsonItemCommand);
        ItemTappedCommand = new Command(ExecuteItemTappedCommand);
        TouchDialogCommand = new Command(ExecuteDialogCommand);
    }
    #endregion
    #region Execute Functions
    private void ExecuteAddCommand(object parameter)
    {
        AddCount++;
    }
    private void ExcuteJsonItemCommand(object parameter)
    {
        Task.Run(async () =>
        {
            try
            {
                List<JsonInfo> jsonData = await _networkService.GetJsonDataAsync();

                JsonInfos = new ObservableCollection<JsonInfo>(jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        });
    }
    private void ExcuteJsonCommand(object parameter)
    {
        Task.Run(async () =>
        {
            try
            {
                var result = await _networkService.GetJsonDataAsync().ConfigureAwait(false);
                JsonString = result.ToJsonString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        });
    }
    private async void ExecuteItemTappedCommand(object item)
    {
        var selectedItem = item as JsonInfo;
        Console.WriteLine($"id -> {selectedItem.id} body -> {selectedItem.body}");        
        await Shell.Current.GoToAsync("//Home");//AppShell에서 Route설정후 화면전환가능
    }
    private async void ExecuteDialogCommand(object item)
    {
        await _dialogService.ShowAlertAsync("테스트용","테스트용메세지","이게몽미");
    }
    #endregion
}

