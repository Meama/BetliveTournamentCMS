using MediatR;
using Infrastructure;
using FluentValidation;
using System.Reflection;
using Application.Policy;
using Application.Options;
using Meama.Common.Upload.Files;
using Application.PipelineBehaviours;
using Application.Healper.Abstraction;
using Microsoft.Extensions.Configuration;
using Meama.Common.AutoMapper.Extentions;
using Application.Healper.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var policies = ProjectPolicys.GetProjectPermissions();
        foreach (var policyName in policies)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(policyName, policy =>
                {
                    policy.RequireClaim("Permission", policyName);
                });
            });
        }

        var assembly = Assembly.GetExecutingAssembly();
        services.AddInfrastructure(configuration);

        services.AddMediatR(typeof(ApplicationExtension));
        services.AddValidatorsFromAssembly(assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddMapperWithProfiles();

        services.Configure<SettingeServiceOptions>(configuration.GetSection(nameof(SettingeServiceOptions)));
        services.Configure<JwtSettingsOptions>(configuration.GetSection(nameof(JwtSettingsOptions)));

        services.AddFilesUploadWithAzureBlobStorage(configuration, shouldUseTinyPng: true);
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}