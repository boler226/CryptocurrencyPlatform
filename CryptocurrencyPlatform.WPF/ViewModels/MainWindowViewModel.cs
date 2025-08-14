using CryptocurrencyPlatform.WPF.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace CryptocurrencyPlatform.WPF.ViewModels {
    public class MainWindowViewModel : INotifyPropertyChanged {
        public ICommand ShowHomeCommand { get; }

        private object _currentViewModel;
        public object CurrentViewModel {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel() {
            ShowHomeCommand = new RelayCommand(_ => CurrentViewModel = new HomeViewModel(), _ => true);

            CurrentViewModel = new HomeViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
