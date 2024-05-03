using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.ApiClient.Tests
{
    public class DependencyInjectionFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public DependencyInjectionFixture()
        {
            var serviceCollection = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }

}
