using CleanArchitectureTemplate.Domain.Identity;
using CleanArchitectureTemplate.Domain.Services;
using CleanArchitectureTemplate.Shared.Security.JwtToken;
using CleanArchitectureTemplate.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            //services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IUserContext, UserContext>();
        }
    }
}
