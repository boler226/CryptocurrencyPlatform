using CryptocurrencyPlatform.Domain.Interfaces.Services;
using CryptocurrencyPlatform.Infrastructure.Exceptions.Delegation.Unauthorized;
using CryptocurrencyPlatform.Infrastructure.Services;
using CryptocurrencyPlatform.WPF.ViewModels;
using CryptocurrencyPlatform.WPF.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;
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
                    services.AddTransient<HomeViewModel>();

                    services.AddTransient<UnauthorizedDelegatingHandler>();

                    services.AddHttpClient<IAssetService, AssetService>(client => {
                        client.BaseAddress = new Uri("https://rest.coincap.io/v3/");

                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", context.Configuration["BearerAuth:Value"]);
                    }).AddHttpMessageHandler<UnauthorizedDelegatingHandler>();
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
