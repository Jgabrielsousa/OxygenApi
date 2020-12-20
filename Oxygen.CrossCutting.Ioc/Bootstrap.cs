using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oxygen.Application.Validations.Pipeline;
using Oxygen.Data.Context;
using Oxygen.Data.Repository;
using Oxygen.Domain.Interfaces.IRepository;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Oxygen.CrossCutting.Ioc
{
    public static class Bootstrap
    {
        private const string APPLICATION_NAMESPACE = "Oxygen.Application";

        public static void RegisterDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("oxygenConnection");

            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });


            services.AddDbContextPool<OxygenDbContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Oxygen.Data")));
        }

        public static IApplicationBuilder RunMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<OxygenDbContext>())
                {
                    context.Database.Migrate();
                }
            }
            return app;
        }


        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<OxygenDbContext>();
            services.AddScoped<IClientRepository, ClientRepository>();
        }


        public static void RegisterMediatorServices(this IServiceCollection services) {

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(VaidacaoRequestsBehavior<,>));


            var currentAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            AssemblyScanner.FindValidatorsInAssemblies(currentAssemblies)
              .ForEach(c => services.AddScoped(c.InterfaceType, c.ValidatorType));


            services.AddMediatR(currentAssemblies);

            
        }



    }
}
