using Bakim.Core.CrossCuttingConcerns.Caching;
using Bakim.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bakim.Core.Utilities.Helpers.File;
using Bakim.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakim.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IFileHelper, FileHelper>();
            services.AddSingleton<Stopwatch>();
        }
    }
}
