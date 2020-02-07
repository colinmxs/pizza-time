using System.Threading.Tasks;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using Amazon.Polly;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace PizzaTime.VoiceFileGenerator
{
    public class Function
    {
        public Function() : this(LambdaConfiguration.Configuration) { }
        public Function(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
        {
            var app = new App(Polly, S3, Configuration);
            foreach (var message in evnt.Records)
            {
                var messageBody = JsonConvert.DeserializeObject<MessageBody>(message.Body);
                await app.ProcessAsync(messageBody);
            }
        }

        internal static IConfiguration Configuration { get; private set; }
        
        IAmazonPolly Polly => ServiceProvider.GetService<IAmazonPolly>();

        IAmazonS3 S3 => ServiceProvider.GetService<IAmazonS3>();

        ServiceProvider _serviceProvider;
        ServiceProvider ServiceProvider
        {
            get
            {
                if (_serviceProvider == null)
                {
                    var serviceCollection = new ServiceCollection();
                    ConfigureServices(serviceCollection);

                    // create service provider
                    _serviceProvider = serviceCollection.BuildServiceProvider();
                }
                return _serviceProvider;
            }
        }

        void ConfigureServices(IServiceCollection services)
        {
            var options = new AWSOptions
            {
                Region = RegionEndpoint.USWest2
            };

            // add dependencies here
            services.AddScoped(sp => { return options.CreateServiceClient<IAmazonS3>(); });
            services.AddScoped(sp => { return options.CreateServiceClient<IAmazonPolly>(); });
        }
    }
}