using Amazon.CDK;
using Amazon.CDK.AWS.Cognito;

namespace PizzaTime.Aws.Cdk.Cognito
{
    public class CognitoStack : Stack
    {
        internal CognitoStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            var userPool = new UserPool(this, "UserPool", new UserPoolProps 
            {
                
            });
        }
    }
}
