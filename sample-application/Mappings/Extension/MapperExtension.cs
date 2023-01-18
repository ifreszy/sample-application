using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_application.Mappings.Extension
{
    public static class MapperExtension
    {
        public static void AddMappers(this IServiceCollection services)
        {
            var mapper = Mapper.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
