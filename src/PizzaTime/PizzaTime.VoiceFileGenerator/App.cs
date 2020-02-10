using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTime.VoiceFileGenerator
{
    class App
    {
        private readonly IAmazonPolly polly;
        private readonly IAmazonS3 s3;
        private readonly IConfiguration configuration;
        private string bucketName => configuration[nameof(bucketName)];

        public App(IAmazonPolly polly, IAmazonS3 s3, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.polly = polly;
            this.s3 = s3;
        }

        internal async Task ProcessAsync(IEnumerable<MessageBody> messages)
        {
            var tasks = new List<Task>();
            var getVoices = await polly.DescribeVoicesAsync(new DescribeVoicesRequest { Engine = Engine.Neural });
            foreach (var message in messages) 
            {
                var request = new SynthesizeSpeechRequest()
                {
                    Engine = Engine.Neural,
                    LanguageCode = LanguageCode.EnUS,
                    OutputFormat = OutputFormat.Mp3,
                    Text = message.Input,
                    TextType = TextType.Text
                };

                if (message.Voice == "All")
                {
                    foreach (var voice in getVoices.Voices)
                    {
                        request.VoiceId = voice.Id;
                        tasks.Add(ProcessCore(request, message));
                    }
                }
                else 
                {
                    var voice = getVoices.Voices.Single(v => v.Name == message.Voice);
                    request.VoiceId = voice.Id;
                    tasks.Add(ProcessCore(request, message));
                }
            }
            await Task.WhenAll(tasks);
        }

        private async Task ProcessCore(SynthesizeSpeechRequest request, MessageBody message)
        {
            var pollyResult = await polly.SynthesizeSpeechAsync(request);
            var memStream = new MemoryStream();
            pollyResult.AudioStream.CopyTo(memStream);
            await s3.UploadObjectFromStreamAsync(bucketName, $"{message.Voice}/{message.Type}/{message.Input.Replace(' ', '-').Replace('.', '-')}.mp3", memStream, null);
        }
    }
}
