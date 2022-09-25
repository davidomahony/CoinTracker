using CoinTracker.API.Clients;
using CoinTracker.API.Clients.Interfaces;
using CoinTracker.API.Services;
using CoinTracker.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Add services
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAddressesService, AddressesService>();
builder.Services.AddMemoryCache();

// Add clients
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
