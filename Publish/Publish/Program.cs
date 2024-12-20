using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Publish.Util;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext to the services container
builder.Services.AddDbContextFactory<ResourceContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"), o => o.UseNetTopologySuite()));



var app = builder.Build();

//app.ConfigDB();

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
