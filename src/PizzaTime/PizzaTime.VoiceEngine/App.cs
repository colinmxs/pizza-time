using Amazon.Polly;
using Amazon.Polly.Model;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaTime.VoiceEngine
{
    public class App
    {
        private readonly IAmazonPolly pollyClient;

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

            var streamMp3 = new StreamMp3();
            var buffer = streamMp3.StartBuffering(result.AudioStream);

            while (!streamMp3.IsReadyToPlay)
            {
                Thread.Sleep(100);
            }

            var playTask = streamMp3.StartPlaying();

            await playTask;
            await buffer;
        }
    }
}
