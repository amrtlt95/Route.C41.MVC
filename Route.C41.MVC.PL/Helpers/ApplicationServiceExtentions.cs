using Microsoft.Extensions.DependencyInjection;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.BLL.UnitsOfWork;

namespace Route.C41.MVC.PL.Helpers
{
    public static class ApplicationServiceExtentions
    {
        public static void AddServiceExtentions(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
