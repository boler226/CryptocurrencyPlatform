using CryptocurrencyPlatform.Domain.Interfaces.Services;
using CryptocurrencyPlatform.Infrastructure.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IAssetService, AssetService>(client => {
    client.BaseAddress = new Uri("https://rest.coincap.io/v3/");

    client.DefaultRequestHeaders.Authorization =
        new AuthenticationHeaderValue("Bearer", builder.Configuration["BearerAuth:Value"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
