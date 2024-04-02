using Microsoft.Extensions.DependencyInjection;
using Route.C41.MVC.BLL.Interfaces;
using Route.C41.MVC.BLL.UnitsOfWork;
using Route.C41.MVC.PL.Helpers.AutoMappingProfiles;

namespace Route.C41.MVC.PL.Helpers.DIExtentions
{
    public static class ApplicationServiceExtentions
    {
        public static void AddServiceExtentions(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(M => M.AddProfile<MappingProfiles>());
        }
    }
}
