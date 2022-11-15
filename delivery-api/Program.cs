using delivery_api.Middleware;
using delivery_api.Models;
using delivery_api.Repository;
using delivery_api.Services;
using delivery_api.Services.Interfaces;
using delivery_api.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CourierDb")));
builder.Services.AddScoped<IValidator<CustomerDto>, CustomerDtoValidator>();
builder.Services.AddScoped<IValidator<CourierDto>, CourierDtoValidator>();
builder.Services.AddScoped<IValidator<DeliveryDto>, DeliveryDtoValidator>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICourierService, CourierService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//TODO:Add logic to customer service (postcustomer) 

