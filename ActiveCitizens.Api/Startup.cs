using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ActiveCitizens.Core;
using ActiveCitizens.Core.Interfaces;
using Microsoft.AspNetCore.Mvc.Cors;

namespace ActiveCitizens.Api
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

            services.AddDbContext<ActiveCitizensContext>();
            services.AddScoped<IMarkerRepository, MarkerRepository>();
            services.AddScoped<IAuthentificationService, AuthentificationService>();

            services.AddCors();
            services.AddMvc(option => option.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(options => options.WithOrigins("https://localhost:5001")
                                                     .AllowAnyMethod()
                                                     .AllowAnyHeader()
                                                     .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseHttpsRedirection();

            app.UseMvc();

        }
    }
}
