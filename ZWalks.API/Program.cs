using System.Collections.Immutable;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NZWalks.Infrastructure.Contracts;
using NZWalks.Infrastructure.Repository;
using NZWalks.NZWalks.Infrastructure.Entities;
using NZWalks.Service;
using NZWalks.Service.Contracts;
using NZWalks.Service.Service;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NZWalks.NZWalks.Service.Contracts;
using NZWalks.NZWalks.Service.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authentication",
        Description = "Enter bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "Jwt",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.Schema
        }
    };
    options.AddSecurityDefinition(securityScheme.Reference.Id,securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] {}}
    });
});
builder.Services.AddDbContext<NzwalksDbContext>(options =>
                            options.UseSqlServer(builder.Configuration.GetConnectionString("NZWalksConnection")));
builder.Services.AddTransient<IRegionService, RegionService>();
builder.Services.AddTransient<IRegionRepository, RegionRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJwtTokenHandler,JwtTokenHandler>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
     {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                           builder.Configuration["Jwt:Key"]))
     });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
