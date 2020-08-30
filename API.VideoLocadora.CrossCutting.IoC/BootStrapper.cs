using API.VideoLocadora.Application;
using API.VideoLocadora.Application.Interfaces;
using API.VideoLocadora.Data.Repository;
using API.VideoLocadora.Domain.Inferfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.VideoLocadora.CrossCutting.IoC
{
    public static class BootStrapper
    { 
        public static IServiceCollection AddBootStrapperIoC(
            this IServiceCollection services
            )
        {
            //services
            services.AddSingleton<IClientAppService, ClientAppService>();
            services.AddSingleton<IFilmAppService, FilmAppService>();
            services.AddSingleton<IRentalAppService, RentalAppService>();

            //repositories
            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddSingleton<IFilmRepository, FilmRepository>();
            services.AddSingleton<IRentRepository, RentRepository>();

            return services;
        }

    }
}
