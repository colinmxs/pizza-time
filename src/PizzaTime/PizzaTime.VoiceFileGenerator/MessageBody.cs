using Amazon.Polly;

namespace PizzaTime.VoiceFileGenerator
{
    class MessageBody
    {
        public string Input { get; internal set; }
        public VoiceId Voice { get; internal set; }
        public string Type { get; internal set; }
    }
}
