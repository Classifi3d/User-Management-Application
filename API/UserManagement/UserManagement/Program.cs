using System.Text;
using BusinessLogicLayer.Service;
using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

//using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder
    .Services
    .AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition(
            "oauth2",
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Description =
                    "Standard Authorization Header Using The Bearer Scheme (\"bearer {token}\")",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
            }
        );
        ;
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });
builder
    .Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)
            ),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Add CORS
var allowSpecificOrigin = "_myAllowSpecificOrigins";

builder
    .Services
    .AddCors(options =>
    {
        options.AddPolicy(
            allowSpecificOrigin,
            builder =>
            {
                builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            }
        );
    });

//  SQL-Server
builder
    .Services
    .AddDbContext<ApplicationDbContext>(
        options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("UserManagementSQLServerConnectionString")
            )
    );

//  MySQL
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseMySQL(builder.Configuration.GetConnectionString("UserManagementMySQLConnectionString")));
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserService,UserService>();
//builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
//builder.Services.AddScoped <ICountriesService, CountriesService>();
//builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
//);
//builder.Services.AddScoped<DbContext, ApplicationDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//InsertDataOperation repo

app.UseCors(allowSpecificOrigin);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
