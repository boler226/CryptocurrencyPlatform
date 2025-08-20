using CryptocurrencyPlatform.Domain.Interfaces.Services;
using CryptocurrencyPlatform.WPF.DTOs.Rate;
using System.Collections.ObjectModel;
using System.Windows;

namespace CryptocurrencyPlatform.WPF.ViewModels {
    public class RateViewModel : ViewModelBase {
        private readonly IRateService _rateService;

        public ObservableCollection<RateDto> Rates { get; set; } = new();

        private RateDto? _fromCurrency;
        public RateDto? FromCurrency {
            get => _fromCurrency;
            set {
                _fromCurrency = value;
                OnPropertyChanged();
                ConvertCurrency();
            }
        }

        private RateDto? _toCurrency;
        public RateDto? ToCurrency {
            get => _toCurrency;
            set {
                _toCurrency = value;
                OnPropertyChanged();
                ConvertCurrency();
            }
        }

        private decimal _amount;
        public decimal Amount {
            get => _amount;
            set {
                _amount = value;
                OnPropertyChanged();
                ConvertCurrency();
            }
        }

        private decimal _result;
        public decimal Result {
            get => _result;
            set {
                _result = value;
                OnPropertyChanged();
            }
        }

        public RateViewModel(IRateService rateService) {
            _rateService = rateService;
            _ = LoadRates();
        }

        public async Task LoadRates() {
            try {
                var rates = await _rateService.GetListAsync(null, CancellationToken.None);
                Rates.Clear();

                foreach (var rate in rates) {
                    Rates.Add(new RateDto {
                        Symbol = rate.Symbol,
                        CurrencySymbol = rate.CurrencySymbol,
                        Type = rate.Type,
                        RateUsd = Convert.ToDecimal(rate.RateUsd, System.Globalization.CultureInfo.InvariantCulture)
                    });
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "LoadRates Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ConvertCurrency() {
            if (FromCurrency == null || ToCurrency == null || Amount <= 0) {
                Result = 0;
                return;
            }

            decimal amountInUsd = Amount * FromCurrency.RateUsd;
            Result = amountInUsd / ToCurrency.RateUsd;
        }
    }
}
