using CryptocurrencyPlatform.Domain.Interfaces.Services;
using CryptocurrencyPlatform.Infrastructure.Exceptions.Delegation.Unauthorized;
using CryptocurrencyPlatform.Infrastructure.Extensions;
using CryptocurrencyPlatform.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

ExceptionExtensions.AddExceptionHandlers(builder.Services);
builder.Services.AddTransient<UnauthorizedDelegatingHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCoincapClient<IAssetService, AssetService>(builder.Configuration);
builder.Services.AddCoincapClient<IRateService, RateService>(builder.Configuration);

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