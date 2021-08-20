using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiFastReport.Data;
using FastReport.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace ApiFastReport
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Relatório com FastReport e NET Core 5", 
                    Version = "v1",
                    TermsOfService = new Uri("http://www.marquessoftware.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Marcelo Marques de Lima",
                        Email = "comercial@marquessoftware.com",
                        Url = new Uri("http://www.marquessoftware.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termos de Licenciamento de uso da API"
                    }
                });
            });

            FastReport.Utils.RegisteredObjects.AddConnection(typeof(MySqlDataConnection));

            var serverVersion = new MySqlServerVersion(new Version(8,0,26));
            var connectionString = Configuration.GetConnectionString("MyDb");

            services.AddDbContext<MyContext>(
                DbContextOptions => DbContextOptions
                    .UseMySql(connectionString, serverVersion)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                    {
                         c.SwaggerEndpoint("/swagger/v1/swagger.json", "Relatório em FastReport");
                         c.RoutePrefix = string.Empty;
                    });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseFastReport();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
