using PizzaTime.Core.Phones;
using System;
using System.Threading.Tasks;

namespace PizzaTime.Core
{
    public class CallDispatcher : IUpdate
    {
        public double ChanceModifier { get; set; } = 0.001f;
        private readonly Random _random = new Random();
        private readonly IPhoneCallService _callService;
        private readonly IPhoneSystem _phoneSystem;

        public CallDispatcher(IPhoneCallService callService, IPhoneSystem phoneSystem)
        {
            var gameThread = GameThread.Instance();
            gameThread.Subscribe(this);
            _callService = callService;
            _phoneSystem = phoneSystem;
        }

        public Task Update(int interval)
        {
            var multiplier = interval / 100;
            var next = _random.NextDouble();
            if ((1d - (ChanceModifier * multiplier)) <= next)
            {
                _phoneSystem.TryConnect(_callService.GetCall());
            }
            return Task.CompletedTask;
        }
    }
}
