using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using Rest.ApiClient.Auth;
using Rest.ApiClient.Extensions.Registrations;

namespace Rest.ApiClient.Tests
{

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddSingleton<AzureAdAuthenticationProvider>();
            //services.AddSingleton(x => new CustomAuthenticationHeaderProvider("x-api-key", ""));

            // Add your dependencies here
            services.RegisterApiClient();

        
        }
    }

}
