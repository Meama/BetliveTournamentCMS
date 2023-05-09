using System.Reflection;
using Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Meama.Common.EFCore.Extentions;
using Infrastructure.Email.Abstraction;
using Infrastructure.Image.Abstraction;
using Microsoft.Extensions.Configuration;
using Infrastructure.Email.Configuration;
using Infrastructure.Image.Configuration;
using Infrastructure.Image.Implementation;
using Infrastructure.Email.Implementation;
using Meama.Common.Settings.SQL.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TournamentContext>(configuration, Assembly.GetExecutingAssembly().GetName().Name);
        services.AddSettingWithSQL(configuration);
        services.Configure<EmailOptions>(configuration.GetSection(nameof(EmailOptions)));
        services.AddScoped<IMailService, MailService>();

        services.Configure<BlobInfoOption>(configuration.GetSection(nameof(BlobInfoOption)));
        services.AddScoped<IImageUploadService, ImageUploadService>();

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddEntityFrameworkStores<TournamentContext>();

        return services;
    }
}