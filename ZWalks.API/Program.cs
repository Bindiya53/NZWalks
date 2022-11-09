using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using NZWalks.Infrastructure.Contracts;
using NZWalks.Infrastructure.Repository;
using NZWalks.NZWalks.Infrastructure.Entities;
using NZWalks.Service;
using NZWalks.Service.Contracts;
using NZWalks.Service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NzwalksDbContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnection")));
builder.Services.AddTransient<IRegionService, RegionService>();
builder.Services.AddTransient<IRegionRepository, RegionRepository>();



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
