namespace PizzaTime.Console
{
    using Amazon;
    using Amazon.Polly;
    using Microsoft.Extensions.Configuration;
    using PizzaTime.VoiceEngine;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddUserSecrets<Program>();
            var config = configBuilder.Build();
            var awsAccessKeyId = config["AWSKeyId"];
            var secretAccessKey = config["AWSSecret"];
            var pollyClient = new Amazon.Polly.AmazonPollyClient(awsAccessKeyId, secretAccessKey, new AmazonPollyConfig 
            {
                RegionEndpoint = RegionEndpoint.USWest2
            });
            var app = new App(pollyClient);
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "PizzaTime.Console.TextFile1.txt";
            var textToSpeechString = "";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                textToSpeechString = reader.ReadToEnd();
            }

            await app.Speak(textToSpeechString);
        }
    }
}
