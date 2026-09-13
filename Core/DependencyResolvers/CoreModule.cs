using Autofac.Core;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    //bu class uygulama seviyesinde servis bağımlılıklarımız çözümleyeceğimiz yerdir
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();             //memory injection eklendi(IMemoryCache) ve arka planda bir tane ICacheManager instance'ı oluştu.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();      //yarın öbürgün microsoft yerine redis kullanırsan Memory yerin Redis yazman yeterlidir.
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
