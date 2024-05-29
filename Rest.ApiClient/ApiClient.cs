using Rest.ApiClient.Auth;

using System.Security.Authentication;

namespace Rest.ApiClient
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IAuthenticationProvider _azureAdAuthenticationProvider;
        private readonly IAuthenticationProvider _customAuthenticationHeaderProvider;

        public ApiClient(HttpClient httpClient, AzureAdAuthenticationProvider azureAdAuthenticationProvider, CustomAuthenticationHeaderProvider customAuthenticationHeaderProvider)
        {
            _httpClient = httpClient;
            _azureAdAuthenticationProvider = azureAdAuthenticationProvider;
            _customAuthenticationHeaderProvider = customAuthenticationHeaderProvider;
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, AuthenticationKind authenticationKind)
        {
            var _authenticationProvider = GetAuthenticationProvider(authenticationKind);

            if (_authenticationProvider == null)
            {
                throw new UnauthorizedAccessException("The _authenticationProvider is null. Please provide a valid authenication provider.");
            }
            request = await _authenticationProvider.AcquireAndSetAuthenticationHeaderAsync(request);
            var response = await _httpClient.SendAsync(request);
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(errorMessage);
            }
            return response;
        }


        private IAuthenticationProvider? GetAuthenticationProvider(AuthenticationKind authenticationKind)
        {
            if (authenticationKind == AuthenticationKind.AzureAdAuthentication)
                return _azureAdAuthenticationProvider;
            else if(authenticationKind == AuthenticationKind.CustomAuthenticationHeaderProvider)
                return _customAuthenticationHeaderProvider;

            return null;
        }

    }
}
