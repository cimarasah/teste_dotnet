using AMcom.Teste.DAL.Interface.UnitOfWork;
using AMcom.Teste.DAL.UnitOfWork;
using AMcom.Teste.Service.Interface.Mapper;
using AMcom.Teste.Service.Interface.Service;
using AMcom.Teste.Service.Mapper;
using AMcom.Teste.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace AMcom.Teste.IoC
{
    public static class DependencyInjector
    {
        public static void Register(IServiceCollection services)
        {
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();
            services.TryAddScoped<IUbsService, UbsService>();
            services.TryAddScoped<IUbsMapper,UbsMapper>();
        }
    }
}
