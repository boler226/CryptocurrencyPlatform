using CryptocurrencyPlatform.Domain.Interfaces.Services;
using CryptocurrencyPlatform.Infrastructure.Exceptions.Delegation.Unauthorized;
using CryptocurrencyPlatform.Infrastructure.Services;
using CryptocurrencyPlatform.WPF.ViewModels;
using CryptocurrencyPlatform.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CryptocurrencyPlatform.WPF {
    public partial class App : System.Windows.Application {
        public static IHost AppHost { get; private set; }

        public App() {
            AppHost = Host.CreateDefaultBuilder()
               .ConfigureAppConfiguration((context, config) => {
                   config.AddJsonFile("appsettings.json", false, true);
               })
                .ConfigureServices((context, services) => {
                    services.AddTransient<MainWindow>();
                    services.AddTransient<MainWindowViewModel>();
                    services.AddTransient<AssetViewModel>();

                    services.AddTransient<UnauthorizedDelegatingHandler>();

                    services.AddCoincapClient<IAssetService, AssetService>(context.Configuration);
                    services.AddCoincapClient<IRateService, RateService>(context.Configuration);
                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e) {
            await AppHost.StartAsync();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e) {
            await AppHost.StopAsync();
            AppHost.Dispose();
            base.OnExit(e);
        } 
    }
}
