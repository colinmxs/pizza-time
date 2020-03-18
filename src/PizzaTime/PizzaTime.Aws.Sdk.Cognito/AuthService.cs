using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Runtime;
using System.Threading.Tasks;

namespace PizzaTime.Aws.Sdk.Cognito
{
    public class AuthService : IRegister, ISignIn
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private const string _userPoolId = "us-east-1_o2C8XywN3";
        private const string _clientId = "1u14d4v907ohdb6bhr9m9kkorn";
        private AmazonCognitoIdentityProviderClient _client;
        
        public AuthService()
        {
            _client = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), RegionEndpoint.USEast1);
        }

        public async Task<string> Register()
        {
            //Sign up user
            var spRequest = new SignUpRequest
            {
                Password = Password,
                Username = Username,
                ClientId = _clientId
            };

            await _client.SignUpAsync(spRequest);

            return await SignIn();
        }

        public async Task<string> SignIn()
        {
            //sign in user
            var siRequest = new AdminInitiateAuthRequest() 
            {
                ClientId = $"{ _clientId }",
                UserPoolId = $"{ _userPoolId }",
                AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH      
            };
            siRequest.AuthParameters.Add("USERNAME", Username);
            siRequest.AuthParameters.Add("PASSWORD", Password);

            var res = await _client.AdminInitiateAuthAsync(siRequest);
            //if(res.AuthenticationResult)
            return res.AuthenticationResult.AccessToken;
        }
    }
}
