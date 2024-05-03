﻿using Rest.ApiClient.Auth;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rest.ApiClient.Extensions;

namespace Rest.ApiClient.Extensions.Registrations
{
    public static class DependencyRegistration
    {
        public static void RegisterApiClient(this IServiceCollection services)
        {
            services.AddHttpClient<IApiClient, ApiClient>()
                    .SetHandlerLifetime(TimeSpan.FromMinutes(5)).
                    AddRetryPolicy();

        }
    }
}
