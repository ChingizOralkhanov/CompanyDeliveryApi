using Company.Delivery.Api.AppStart;
using Company.Delivery.Api.Extensions.Mapper;

var builder = WebApplication.CreateBuilder(args);

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