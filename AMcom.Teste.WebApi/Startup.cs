using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMcom.Teste.DAL.Data;
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
            services.AddDbContext<DatabaseContext>(opt => 
            opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UbsDatabase;Trusted_Connection=True;ConnectRetryCount=0",
                sqlOptions => sqlOptions.UseNetTopologySuite()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new Info {
                    Title = "Meus Ubs",
                    Description = "Teste de desenvolvimento .NET (C#) - AMcom",
                    Version = "V1",
                    License = new License
                    {
                        Name = "Acesse codigo via GitHub",
                        Url = new Uri("https://github.com/cimarasah/teste_dotnet").ToString()
                    }
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test.Web.Api");
                c.RoutePrefix = string.Empty;
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
