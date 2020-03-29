using Application.Commands.Empresas.Create;
using Application.Commands.Fornecedores.Create;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection ConfigureMidiatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }

        public static IServiceCollection ConfigureFluentValidatorApplication(this IServiceCollection services)
        {
            services.AddMvc().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<CreateEmpresaCommandValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<CreateFornecedorCommandValidator>();
            });

            return services;
        }
    }
}