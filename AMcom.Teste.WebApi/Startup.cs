using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMcom.Teste.DAL.Data;
using AMcom.Teste.IoC;
using AMcom.Teste.WebApi.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace AMcom.Teste.WebApi
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
            services.AddEntityFrameworkInMemoryDatabase();
            DependencyInjector.Register(services);

            services
             .AddDbContext<DatabaseContext>((sp, options) =>
             {
                 options.UseInMemoryDatabase()
                     .UseInternalServiceProvider(sp);
             });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Info
                {
                    Title = "UBS API",
                    Description = "Teste de desenvolvimento .NET (C#) - AMcom",
                    Version = "v1",
                    Contact = new Contact()
                    {
                        Name = "Cimara Sá",
                        Email = "cimarasah@gmail.com",
                        Url = new Uri("https://github.com/cimarasah/teste_dotnet").ToString()
                    }
                }); ;

                
            });


        }

       public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            

            app.UseHttpsRedirection();
           // app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "UBS API v1");
            });
            app.UseMvc();
        }
    }
}
