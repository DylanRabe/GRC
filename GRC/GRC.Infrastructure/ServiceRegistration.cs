//set up Infra Component like Sql server
//creer un methode etendue pour ajouter le Dbcontext
//Migration separer du model
using GRC.Domain;
using GRC.Infrastructure.Configuration;
using GRC.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GRC.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services , string ConnectionString)
    {
        //apres SqlModelconf
        services.AddSingleton<IModelConfiguration, SqlModelConfiguration>();
        services.AddDbContext<GrcContext>(options =>
        {
            options.UseSqlServer(ConnectionString, sqlOptions =>
        {
            sqlOptions.MigrationsAssembly(typeof(ServiceRegistration).Assembly.FullName);
        });
        });
        return services;
    }
}