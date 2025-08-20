using CryptocurrencyPlatform.WPF.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace CryptocurrencyPlatform.WPF.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public ICommand ShowAssetCommand { get; }
        public ICommand ShowRateCommand { get; }

        private readonly AssetViewModel _assetViewModel;
        private readonly RateViewModel _rateViewModel;

        private object? _currentViewModel;
        public object? CurrentViewModel {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public MainWindowViewModel() {
            _assetViewModel = App.AppHost.Services.GetRequiredService<AssetViewModel>();
            _rateViewModel = App.AppHost.Services.GetRequiredService<RateViewModel>();

            ShowAssetCommand = new RelayCommand(_ => CurrentViewModel = _assetViewModel, _ => true);
            ShowRateCommand = new RelayCommand(_ => CurrentViewModel = _rateViewModel, _ => true);

            CurrentViewModel = _assetViewModel;
        }
    }
}
