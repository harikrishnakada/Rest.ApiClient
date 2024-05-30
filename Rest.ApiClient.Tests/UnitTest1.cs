using Microsoft.Extensions.DependencyInjection;

using Rest.ApiClient.Auth;

namespace Rest.ApiClient.Tests
{
    public class UnitTest1 : IClassFixture<DependencyInjectionFixture>
    {
        private readonly IApiClient _apiClient;

        public UnitTest1(DependencyInjectionFixture fixture)
        {
            _apiClient = fixture.ServiceProvider.GetService<IApiClient>();
        }

        [Fact]
        public async Task Test1()
        {
            var rm = new HttpRequestMessage(HttpMethod.Get, "https://4943cc8d-c60e-4b81-89f6-be3c1482e17b.mock.pstmn.io/test");
            var resa = await _apiClient.SendAsync(rm, AuthenticationKind.None);
            resa.EnsureSuccessStatusCode();
        }
    }
}