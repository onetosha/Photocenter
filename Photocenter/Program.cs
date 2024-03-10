using Photocenter.DAL;
using Photocenter.DAL.Interfaces;
using Photocenter.DAL.Repositories;
using Photocenter.Services.Implementations;
using Photocenter.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddDbContext<ApplicationDBContext>();
services.AddControllers();

services.AddScoped<IClientRepository, ClientRepository>();
services.AddScoped<IClientService, ClientService>();
services.AddScoped<IServiceRepository, ServiceRepository>();
services.AddScoped<IServiceService, ServiceService>();
services.AddScoped<IOrderRepository, OrderRepository>();
services.AddScoped<IOrderService, OrderService>();

services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.MapControllers();

app.Run();
