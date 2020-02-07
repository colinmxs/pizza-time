﻿using Amazon.Polly;
using Amazon.Polly.Model;
using Amazon.S3;
using Microsoft.Extensions.Configuration;
using System.IO;
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

        internal async Task ProcessAsync(MessageBody message)
        {             
            var request = new SynthesizeSpeechRequest()
            {
                Engine = Engine.Neural,
                LanguageCode = LanguageCode.EnUS,
                OutputFormat = OutputFormat.Mp3,
                Text = message.Input,
                TextType = TextType.Text,
                VoiceId = VoiceId.Matthew
            };

            var pollyResult = await polly.SynthesizeSpeechAsync(request);
            var memStream = new MemoryStream();
            pollyResult.AudioStream.CopyTo(memStream);            
            await s3.UploadObjectFromStreamAsync(bucketName, $"{message.Voice}/{message.Type}/{message.Input.Replace(' ', '-')}", memStream, null);
        }
    }
}
