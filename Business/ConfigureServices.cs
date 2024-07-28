using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prueba.Infraestructure.InternalService.Interface;
using Prueba.Infraestructure.InternalService.Service;
using PruebaApi.Business.BLL;
using PruebaApi.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.Business
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Business
            services.AddScoped(typeof(IUsuarioBLL), typeof(UsuarioBLL));
            services.AddScoped(typeof(IUsuarioServiceBLL), typeof(UsuarioServiceBLL));
            services.AddScoped(typeof(IPersonaBLL), typeof(PersonaBLL));
            services.AddScoped(typeof(IPersonaServiceBLL), typeof(PersonaServiceBLL));
            #endregion

            #region Infraestructure
            services.AddScoped(typeof(IApiBLL), typeof(ApiBLL));
            services.AddScoped(typeof(IServiceApiBLL), typeof(ServiceApiBLL));
            #endregion

            return services;
        }
    }
}
