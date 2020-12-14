using CourseSignUp.Services;
using CourseSignUp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService (IServiceCollection services)
        {
            // Transient, create a new instance by use
            services.AddTransient<ICourseSignUpService, CourseSignUpService>();
            services.AddTransient<ISignUpToCourseService, SignUpToCourseService>();
            services.AddTransient<IStatisticsService, StatisticsService>();
        }
    }
}