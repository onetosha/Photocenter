using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Photocenter.DAL.Interfaces;
using Photocenter.DAL.Repositories;
using Photocenter.Helpers;
using Photocenter.Services.Implementations;
using Photocenter.Services.Interfaces;
using System.Text;

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

services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.UseRouting();

app.MapControllers();

app.Run();
