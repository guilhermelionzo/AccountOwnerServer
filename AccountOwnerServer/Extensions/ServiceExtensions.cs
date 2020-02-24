using Contracts;
using Entities;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOwnerServer.Extensions
{
    public static class ServiceExtensions
    {
        public static bool DOCKER_ENV = true;

        //CORS POLICY
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {

            services.Configure<IISOptions>(options =>
            {

            });
        }

        //Configure MySql
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            if (!DOCKER_ENV)
            {
                var connectionString = config["mysqlconnection:connectionString"];
                System.Diagnostics.Debug.WriteLine(connectionString);
                services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
            }
            else
            {
                services.AddDbContext<RepositoryContext>(o => o.UseInMemoryDatabase("accountowner"));
            }

        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }

}
