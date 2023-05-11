using Application;
using Api.Middleware;
using Application.Policy;
using Api.BackgroundServices;
using Microsoft.OpenApi.Models;
using Meama.Common.JWTAuthentication;
using Meama.Policys.PolicyTypes.Extentions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var configuration = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", false, true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.InstallJWT(configuration);
builder.Services.AddHostedService<AddSuperAdminBackgroundService>();

builder.Services.AddApplication(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.AddErrorHandler();
app.UseHttpsRedirection();

app.UseAuthentication();
app.AddAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();