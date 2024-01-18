using HumAnalysis.Domain.Entity;
using HumAnalysis.Service.Implementations;
using HumAnalysis.Service.Interfaces;
using HumanAnalysis.DAL.Interfaces;
using HumanAnalysis.DAL.Repositories;

namespace HumAnalysis.WebAPI
{
    public static class StartupInit
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IContourRepository<YearContour>, ContourYearRepository>();
            services.AddScoped<IContourRepository<MonthContour>, ContourMonthRepository>();
            services.AddScoped<IContourRepository<PhysicalContour>, ContourPhysicalRepository>();
            services.AddScoped<IContourRepository<EmotionalContour>, ContourEmotionalRepository>();
            services.AddScoped<IContourRepository<IntellectualContour>, ContourIntellectualRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICalculationService, CalculationService>();
        }
    }
}
