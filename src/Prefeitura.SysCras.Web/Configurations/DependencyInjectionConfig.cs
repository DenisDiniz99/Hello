﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Prefeitura.SysCras.Business.Contracts;
using Prefeitura.SysCras.Business.Notifications;
using Prefeitura.SysCras.Business.Services;
using Prefeitura.SysCras.Data.Context;
using Prefeitura.SysCras.Data.Repositories;

namespace Prefeitura.SysCras.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            //Contexto
            services.AddScoped<SysContext>();

            //Repositórios
            services.AddScoped<IAssuntoAtendimentoRepositorio, AssuntoAtendimentoRepositorio>();
            services.AddScoped<IAtendimentoRepositorio, AtendimentoRepositorio>();
            services.AddScoped<ICargoRepositorio, CargoRepositorio>();
            services.AddScoped<ICidadaoRepositorio, CidadaoRepositorio>();
            services.AddScoped<IColaboradorRepositorio, ColaboradorRepositorio>();
            services.AddScoped<ISetorRepositorio, SetorRepositorio>();

            //Serviços
            services.AddScoped<IAssuntoAtendimentoServico, AssuntoAtendimentoServico>();
            services.AddScoped<IAtendimentoServico, AtendimentoServico>();
            services.AddScoped<ICargoServico, CargoServico>();
            services.AddScoped<ICidadaoServico, CidadaoServico>();
            services.AddScoped<IColaboradorServico, ColaboradorServico>();
            services.AddScoped<ISetorServico, SetorServico>();

            //Notificador
            services.AddScoped<INotificador, Notificador>();

            //Automapper
            services.AddAutoMapper(typeof(Startup));

            return services;
        }
    }
}
