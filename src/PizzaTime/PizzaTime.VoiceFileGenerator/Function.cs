using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Lambda.Core;
using Amazon.Polly;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        public async Task FunctionHandler(string input, ILambdaContext context)
        {
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            List<MessageBody> messages = new List<MessageBody>();
            foreach (var line in lines)
            {
                var columns = line.Split("\t");
                if (columns[0] != "Voice") 
                {
                    messages.Add(new MessageBody
                    {
                        Voice = columns[0],
                        Type = columns[1],
                        Input = columns[2]
                    });
                }                
            }

            var app = new App(Polly, S3, Configuration);            
            await app.ProcessAsync(messages);
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