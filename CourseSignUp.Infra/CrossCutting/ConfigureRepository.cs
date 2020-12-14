using CourseSignUp.Domain.Repository;
using CourseSignUp.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services)
        {
            services.AddScoped<ICourseSignUpRepository, CourseSignUpRepository>();
            services.AddScoped<ISignUpToCourseRepository, SignUpToCourseRepository>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
        }
    }
}