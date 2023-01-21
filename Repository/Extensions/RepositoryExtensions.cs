using Microsoft.Extensions.DependencyInjection;
using Repository.Impl;

namespace Repository.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
