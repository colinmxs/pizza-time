using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTime.Core
{
    public class PhoneSystem : IUpdate
    {
        public IEnumerable<PhoneLine> PhoneLines { get; }
        public double ChanceModifier { get; set; } = 0.01f;
        private Random random = new Random();
        private ICallService _callService;        

        public PhoneSystem(ICallService callService)
        {
            _callService = callService;
            var gameThread = GameThread.Instance();
            gameThread.Subscribe(this);
            PhoneLines = new List<PhoneLine>
            {
                new PhoneLine(),
                new PhoneLine(),
                new PhoneLine()
            };
        }

        public Task Update(int interval)
        {
            var multiplier = interval / 100;
            var next = random.NextDouble();
            if ((1d - (ChanceModifier * multiplier)) <= next)
            {
                var line = PhoneLines.FirstOrDefault(p => p.Status == PhoneLine.State.OnHook);
                if (line != null) 
                {
                    line.Dialed("Colin");
                }
            }
            return Task.CompletedTask;
        }        
    }
}
