using Amazon.Polly;

namespace PizzaTime.VoiceFileGenerator
{
    public class MessageBody
    {
        public string Input { get; set; }
        public string Voice { get; set; }
        public string Type { get; set; }
    }
}
