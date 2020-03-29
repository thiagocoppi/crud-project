using Domain.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureFluentValidatorDomain(this IServiceCollection services)
        {
            return services;
        }

        public static void RegisterAllTypes<T>(this IServiceCollection services)
        {
            services.AddScoped<INotificationContext, NotificationContext>();

            var typeInterface = typeof(T);

            AppDomain
                .CurrentDomain
                .GetAssemblies()
                .SelectMany(r => r.GetTypes())
                .Where(r => typeInterface.IsAssignableFrom(r))
                .ToList()
                .ForEach(types =>
                {
                    var interfacesServices = types.GetInterfaces().Where(r => r.Name != "IDomainService").ToList();
                    if (interfacesServices.Count > 0)
                    {
                        foreach (var interfaceEach in interfacesServices)
                        {
                            services.AddScoped(interfaceEach, types);
                        }
                    }
                });
        }
    }
}