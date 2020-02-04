using Amazon.Lambda.Core;
using Amazon.Polly;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace PizzaTime.VoiceEngine
{
    public class Function
    {
        private readonly App app;

        public Function()
        {
            var awsAccessKeyId = "";
            var secretAccessKey = "";
            var pollyClient = new Amazon.Polly.AmazonPollyClient(awsAccessKeyId, secretAccessKey, new AmazonPollyConfig());
            app = new App(pollyClient);
        }

        public async Task FunctionHandler(string input, ILambdaContext context)
        {
            //await app.Speak(input);
        }
    }
}
