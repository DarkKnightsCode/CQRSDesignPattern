using CQRSDesignPattern.Models;
using CQRSDesignPattern.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Register the Mediator Service
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//Add Database Context Service to register the DB
 builder.Services.AddDbContext<CfdbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnectionString")));

//Register repository Interface and Repository for Injecting Dependencies
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

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
