using PizzaTime.Core.Phones;
using System;
using System.Threading.Tasks;

namespace PizzaTime.Core
{
    class CallDispatcher : IUpdate
    {
        public double ChanceModifier { get; set; } = 0.01f;
        private Random random = new Random();
        private IPhoneCallService _callService;
        private IPhoneSystem _phoneSystem;

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
            var next = random.NextDouble();
            if ((1d - (ChanceModifier * multiplier)) <= next)
            {
                _phoneSystem.TryConnect(_callService.GetCall());
            }
            return Task.CompletedTask;
        }
    }
}
