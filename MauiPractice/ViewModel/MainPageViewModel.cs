using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MauiPractice;
public class MainPageViewModel : INotifyPropertyChanged
{
    public ICommand AddCountCommand { get; set;}
    public ICommand AddJsonCommand { get; set;}

    public event PropertyChangedEventHandler PropertyChanged;

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

    private readonly NetworkService service;

    public MainPageViewModel(NetworkService service) {
        //생성자 의존성 주입
        this.service = service;

        //Command 세팅
        AddCountCommand = new Command(ExecuteAddCommand, CanExecuteCommand);
        AddJsonCommand = new Command(ExcuteJsonCommand, CanExecuteCommand);
    }


    private bool CanExecuteCommand(object parameter)
    {
        return true;
    }

    private void ExecuteAddCommand(object parameter)
    {
        AddCount++;
    }

private void ExcuteJsonCommand(object parameter)
{
    Task.Run(async () =>
    {
        try
        {
            var result = await service.GetJsonData();
            JsonString = result.ToJsonString();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    });   
}


    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}