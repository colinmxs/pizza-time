using Amazon.Polly;
using Amazon.Polly.Model;
using NAudio.Wave;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaTime.VoiceEngine
{
    public class App
    {
        private readonly IAmazonPolly pollyClient;
        public byte[] buffer = new byte[1024 * 16];

        public App(IAmazonPolly polly)
        {
            pollyClient = polly;
        }

        public async Task Speak(string input)
        {
            var request = new SynthesizeSpeechRequest()
            {
                Engine = Engine.Neural,
                LanguageCode = LanguageCode.EnUS,
                OutputFormat = OutputFormat.Mp3,               
                Text = input,
                TextType = TextType.Text,
                VoiceId = VoiceId.Matthew
            };

            var result = await pollyClient.SynthesizeSpeechAsync(request);

            var mp3Streamer = new Mp3Streamer();
            await mp3Streamer.StreamMp3(result.AudioStream);
        }
    }
}
