using CryptocurrencyPlatform.WPF.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace CryptocurrencyPlatform.WPF.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public ICommand ShowHomeCommand { get; }
        private readonly HomeViewModel _homeViewModel;

        private object? _currentViewModel;
        public object? CurrentViewModel {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel() {
            _homeViewModel = App.AppHost.Services.GetRequiredService<HomeViewModel>();
            ShowHomeCommand = new RelayCommand(_ => CurrentViewModel = _homeViewModel, _ => true);
            CurrentViewModel = _homeViewModel;
        }
    }
}
