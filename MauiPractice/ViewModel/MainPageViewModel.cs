using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MauiPractice.Model;
using System.Globalization;

namespace MauiPractice.viewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region Commands
        public ICommand AddCountCommand { get; set; }
        public ICommand AddJsonCommand { get; set; }
        public ICommand AddJsonItemCommand { get; set; }
        public ICommand ItemTappedCommand { get; set; }
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
        private readonly NetworkService service;
        #endregion
        #region Constructor & CanExecuteCommand
        public MainPageViewModel(NetworkService service)
        {
            //생성자 의존성 주입
            this.service = service;

            //Command 세팅
            AddCountCommand = new Command(ExecuteAddCommand, CanExecuteCommand);
            AddJsonCommand = new Command(ExcuteJsonCommand, CanExecuteCommand);
            AddJsonItemCommand = new Command(ExcuteJsonItemCommand, CanExecuteCommand);
            ItemTappedCommand = new Command(ExecuteItemTappedCommand, CanExecuteCommand);
        }
        private bool CanExecuteCommand(object parameter)
        {
            return true;
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
                    List<JsonInfo> jsonData = await service.GetJsonDataAsync().ConfigureAwait(false);
                    
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
                    var result = await service.GetJsonDataAsync().ConfigureAwait(false);
                    JsonString = result.ToJsonString();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            });
        }
        private void ExecuteItemTappedCommand(object item)
        {
            var selectedItem = item as JsonInfo;
            Console.WriteLine($"id -> {selectedItem.id} body -> {selectedItem.body}");
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    #endregion
}