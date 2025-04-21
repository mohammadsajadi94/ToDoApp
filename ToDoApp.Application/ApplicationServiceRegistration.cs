using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace ToDoApp.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationServiceRegistration).Assembly);
            return services;
        }
    }
}
