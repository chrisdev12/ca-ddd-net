using Application.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddMediatR(configuration =>
    {
      configuration.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
    });
    services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

    services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();

    return services;
  }
}
