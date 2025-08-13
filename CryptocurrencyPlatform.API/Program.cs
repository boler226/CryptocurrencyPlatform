using CryptocurrencyPlatform.Domain.Interfaces.Services;
using CryptocurrencyPlatform.Infrastructure.Exceptions.Delegation.Unauthorized;
using CryptocurrencyPlatform.Infrastructure.Extensions;
using CryptocurrencyPlatform.Infrastructure.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

ExceptionExtensions.AddExceptionHandlers(builder.Services);
builder.Services.AddTransient<UnauthorizedDelegatingHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IAssetService, AssetService>(client => {
    client.BaseAddress = new Uri("https://rest.coincap.io/v3/");

    client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", builder.Configuration["BearerAuth:Value"]);
}).AddHttpMessageHandler<UnauthorizedDelegatingHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();