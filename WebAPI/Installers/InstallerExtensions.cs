using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Installers
{
    public static class InstallerExtensions
    {

        public static void InstallServiceInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>                                                                          // installers przechowuje znalezione przez propgram utworzone przez nas klasy instalatorów 
                typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();        //   ..
                                                                                                                                                                //   ..
            installers.ForEach(installers => installers.InstallServices(services, configuration));                                                              //  i dokonał rejestracji serwisów poprzez wykonanie metod InstallSerwices z tych klas
        }

    }
}
