using System;
using System.Threading.Tasks;

namespace PizzaTime.Core
{
    public class Telephone : IUpdate
    {
        enum Status
        {
            Open,
            InUse,
            Connecting,
            Ringing
        }

        public double ChanceModifier { get; set; } = 0.01f;
        public bool IsRinging => State == Status.Ringing;
        public bool IsInUse => State == Status.InUse;
        private Status State;
        private Random random = new Random();
        private ICallService _callService;
        private Call _currentCall;

        public Telephone(ICallService callService)
        {
            _callService = callService;
            var gameThread = GameThread.Instance();
            gameThread.Subscribe(this);
        }

        public Task Update(int interval)
        {
            if (State == Status.Open) 
            {
                var multiplier = interval / 100;
                var next = random.NextDouble();
                if ((1d - (ChanceModifier * multiplier)) <= next)
                {
                    State = Status.Connecting;
                    //_currentCall = await _callService.GetCall().ConfigureAwait(false);
                    State = Status.Ringing;
                }
            }
            return Task.CompletedTask;
        }

        public Conversation AnswerCall()
        {
            State = Status.InUse;
            return new Conversation();// null; _currentCall.Conversation;
        }

        public void EndCall()
        {
            _currentCall = null;
            State = Status.Open;
        }
    }
}
