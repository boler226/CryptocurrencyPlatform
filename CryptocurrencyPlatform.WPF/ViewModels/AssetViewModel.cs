using CryptocurrencyPlatform.Domain.Entities;
using CryptocurrencyPlatform.Domain.Interfaces.Services;
using CryptocurrencyPlatform.WPF.Commands;
using CryptocurrencyPlatform.WPF.DTOs.Asset;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace CryptocurrencyPlatform.WPF.ViewModels {
    public class AssetViewModel : ViewModelBase {
        private readonly IAssetService _assetService;
        public ObservableCollection<AssetCardDto> AssetCards { get; set; } = new();
        public ObservableCollection<AssetCardDto> FilteredAssetCards { get; set; } = new();

        private string searchQuery;
        public string SearchQuery {
            get => searchQuery;
            set {
                searchQuery = value;
                OnPropertyChanged();
                ApplyFilter();
            }
        }
        
        public ICommand SortByPriceAscCommand { get; }
        public ICommand SortByPriceDescCommand { get; }
        public ICommand SortByChangeAscCommand { get; }
        public ICommand SortByChangeDescCommand { get; }


        public AssetViewModel(IAssetService assetService) {
            _assetService = assetService;

            SortByPriceAscCommand = new RelayCommand(_ => ApplySort(x => x.PriceUsd), _ => true);
            SortByPriceDescCommand = new RelayCommand(_ => ApplySortDescending(x => x.PriceUsd), _ => true);
            SortByChangeAscCommand = new RelayCommand(_ => ApplySort(x => x.ChangePercent24Hr), _ => true);
            SortByChangeDescCommand = new RelayCommand(_ => ApplySortDescending(x => x.ChangePercent24Hr), _ => true);
            _ = LoadAssets();
        }

        public async Task LoadAssets() {
            try {
                var assets = await _assetService.GetList(null, CancellationToken.None);
                AssetCards.Clear();
                foreach (var asset in assets)
                    AssetCards.Add(new AssetCardDto {
                        Name = asset.Name,
                        Symbol = asset.Symbol,
                        PriceUsd = Convert.ToDecimal(asset.PriceUsd, System.Globalization.CultureInfo.InvariantCulture),
                        ChangePercent24Hr = asset.ChangePercent24Hr + "%"

                    });

                FilteredAssetCards.Clear();
                foreach (var item in AssetCards)
                    FilteredAssetCards.Add(item);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "LoadAssets Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void ApplyFilter() {
            var filtered = AssetCards
                .Where(x => string.IsNullOrEmpty(SearchQuery) || x.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList();

            FilteredAssetCards.Clear();
            foreach (var item in filtered)
                FilteredAssetCards.Add(item);
        }

        private void ApplySort<TKey>(Func<AssetCardDto, TKey> keySelector) {
            var sorted = FilteredAssetCards.OrderBy(keySelector).ToList();

            FilteredAssetCards.Clear();
            foreach (var item in sorted) 
                FilteredAssetCards.Add(item);
        }

        private void ApplySortDescending<TKey>(Func<AssetCardDto, TKey> keySelector) {
            var sorted = FilteredAssetCards.OrderByDescending(keySelector).ToList();

            FilteredAssetCards.Clear();
            foreach (var item in sorted)
                FilteredAssetCards.Add(item);
        }
    }
}
