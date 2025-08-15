using CryptocurrencyPlatform.Domain.Interfaces.Services;
using CryptocurrencyPlatform.WPF.ViewModels;
using CryptocurrencyPlatform.WPF.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CryptocurrencyPlatform.WPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow(MainWindowViewModel vm) {
            InitializeComponent();
            DataContext = vm;
        }
    }
}