using CoinTracker.API.Clients;
using CoinTracker.API.Clients.Interfaces;
using CoinTracker.API.Services;
using CoinTracker.API.Services.Interfaces;
using CoinTracker.Core.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<HttpResponseExceptionFilter>();
});

// Add services
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAddressesService, AddressesService>();
builder.Services.AddMemoryCache();

// Add clients
builder.Services.AddHttpClient(
    "BlockChainAddressInfoClient",
    client => client.BaseAddress = new Uri("https://blockchain.info"));

builder.Services.AddScoped<IAddressInfoClient, BlockChainAddressInfoClient>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();
