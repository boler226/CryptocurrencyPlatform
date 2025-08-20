using CryptocurrencyPlatform.WPF.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace CryptocurrencyPlatform.WPF.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public ICommand ShowAssetCommand { get; }
        private readonly AssetViewModel _assetViewModel;

        private object? _currentViewModel;
        public object? CurrentViewModel {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel() {
            _assetViewModel = App.AppHost.Services.GetRequiredService<AssetViewModel>();
            ShowAssetCommand = new RelayCommand(_ => CurrentViewModel = _assetViewModel, _ => true);
            CurrentViewModel = _assetViewModel;
        }
    }
}
