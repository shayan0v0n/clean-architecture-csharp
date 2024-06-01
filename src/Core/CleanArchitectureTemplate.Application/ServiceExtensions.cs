using AutoMapper;
using CleanArchitectureTemplate.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CleanArchitectureTemplate.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly());
                //.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                //.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>))
                //.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
                //.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

        }
    }
}
