using Microsoft.Extensions.DependencyInjection;
using SahaBT.Core.Repositories.Abstract;
using SahaBT.Core.Repositories.Concrete;
using SahaBT.Core.UnitOfWork.Abstract;
using SahaBT.Core.UnitOfWork.Concrete;
using SahaBT.Service.Abstract;
using SahaBT.Service.Concrete;

namespace SahaBT.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ILessonRepository, LessonRepository>();
            serviceCollection.AddScoped<IStudentRepository, StudentRepository>();
            serviceCollection.AddScoped<IStudentLessonRepository, StudentLessonRepository>();
            serviceCollection.AddScoped<IStudentService, StudentService>();
            serviceCollection.AddScoped<IRedisService, RedisService>();
            return serviceCollection;
        }
    }
}
