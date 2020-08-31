using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.VideoLocadora.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API.VideoLocadora
{
    public class Startup
    {
        public IConfiguration Conf { get; }

        public Startup(IConfiguration conf)
        {
            Conf = conf; 
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddBootStrapperIoC();
            services.AddCors();
            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API - Video Locadora",
                    Description = "REST Video Locadora",
                    Contact = new OpenApiContact()
                    {
                        Name = "Victor Cavichiolli",
                        Email = "xvictorprado@gmail.com",
                        Url = new Uri("https://github.com/cavicchioli")
                    },
                });

                c.EnableAnnotations();

            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCors();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Video Locadora v1");
            });
        }
    }
}
