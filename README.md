# Rest.ApiClient
You can install this as a nuget package from nuget packet manager with the package name **Rest.ApiClient** 

<img width="969" alt="image" src="https://github.com/harikrishnakada/Rest.ApiClient/assets/26791983/ae2ee6ca-e40f-4a18-a220-f56d389d4b39">


Register the dependencies in the order

First register the necessary authentication providers.   
If the Rest API uses Azure AD authentication, then use  
`services.AddSingleton<AzureAdAuthenticationProvider>();`  

if you need to register the custom authentication with a custom header and value. You can use  
`services.AddSingleton(x => new CustomAuthenticationHeaderProvider("<autth_header_name>", "<auth_header_value>"));`  

If there is no authentication required for the Rest API, no need to register any providers

Now register the API client  
`services.RegisterApiClient()`

Inject the IApiClient to the class. 
If the Rest API has no authentication, then use `AuthenticationKind.None`
       
    public class DummyApiProvider 
    {
      private readonly IApiClient _apiClient;
      public DummyApiProvider(IApiClient apiClient)
      {
        _apiClient = apiClient;
      }

      public async Task GetData()
      {
        var httpReq = new HttpRequestMessage(HttpMethod.Get, new Uri("https://d4b24e62-24eb-47a6-ab77-7355e5d.mock.pstmn.io/GetByTagNumber"));
        var data = await _apiClient.SendAsync(httpReq, AuthenticationKind.None);
      }
    }

For Azure AD authentication, make sure the below app settings are configured. And then use `AuthenticationKind.AzureAdAuthentication`  
`AZURE_CLIENT_ID:""`       
`AZURE_CLIENT_SECRET:""`    
`AUTHORITY_URI:""`    
`AZURE_TENANT_ID:""`   
`SERVICE_PRINCIPAL_SCOPES:""`   

     public async Task GetData()
      {
        var httpReq = new HttpRequestMessage(HttpMethod.Get, new Uri("https://d4b24e62-24eb-47a6-ab77-7355e5d88454.mock.pstmn.io/GetByTagNumber"));
        var data = await _apiClient.SendAsync(httpReq, AuthenticationKind.AzureAdAuthentication);
      }
         

