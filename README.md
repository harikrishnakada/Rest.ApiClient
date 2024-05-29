# Rest.ApiClient

Register the dependecies

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
         

