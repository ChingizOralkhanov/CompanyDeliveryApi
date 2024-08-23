using Company.Delivery.Api.AppStart;
using Company.Delivery.Api.Extensions.Mapper;
using Company.Delivery.Database;
using Company.Delivery.Domain;
using Company.Delivery.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DeliveryDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));
builder.Services.AddTransient<IWaybillService, WaybillService>();
builder.Services.AddDeliveryControllers();
builder.Services.AddDeliveryApi();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<WaybillProfile>();
    cfg.AddProfile<CargoItemProfile>();
});
var app = builder.Build();

app.UseDeliveryApi();
app.MapControllers();

app.Run();