using CryptocurrencyPlatform.Domain.Entities;
using CryptocurrencyPlatform.Domain.Interfaces.Services;
using CryptocurrencyPlatform.WPF.Commands;
using CryptocurrencyPlatform.WPF.DTOs.Asset;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CryptocurrencyPlatform.WPF.ViewModels {
    public class AssetViewModel : ViewModelBase {
        private readonly IAssetService _assetService;
        public ObservableCollection<AssetCardDto> AssetCards { get; set; } = new();
        public ICommand LoadAssetsCommand { get; }

        public AssetViewModel(IAssetService assetService) {
            _assetService = assetService;
            LoadAssetsCommand = new RelayCommand(async _ => await LoadAssets(), _ => true);
            _ = LoadAssets();
        }

        public async Task LoadAssets() {
            try {
                var assets = await _assetService.GetList(null, CancellationToken.None, 20, 0);
                AssetCards.Clear();
                foreach (var asset in assets)
                    AssetCards.Add(new AssetCardDto {
                        Name = asset.Name,
                        Symbol = asset.Symbol,
                        PriceUsd = Convert.ToDecimal(asset.PriceUsd, System.Globalization.CultureInfo.InvariantCulture),
                        ChangePercent24Hr = asset.ChangePercent24Hr + "%"

                    });
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "LoadAssets Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
