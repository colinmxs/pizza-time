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

        public PhoneSystem(ICallService callService, int availableLines)
        {
            _callService = callService;
            var gameThread = GameThread.Instance();
            gameThread.Subscribe(this);
            var lines = new List<PhoneLine>();
            for (int i = 0; i < availableLines; i++)
            {
                lines.Add(new PhoneLine());
            }

            PhoneLines = new List<PhoneLine>(lines);
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
                    var caller = _callService.GetCall();
                    line.Dialed(caller);
                }
            }
            return Task.CompletedTask;
        }        
    }
}
