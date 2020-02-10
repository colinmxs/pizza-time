using System;
using System.Threading.Tasks;

namespace PizzaTime.Core
{
    public class InGameClock : IUpdate
    {
        public DateTime CurrentTime { get; private set; }
        public int TimeMultiplier { get; }
        public DateTime StartTime { get; set; }
        
        public InGameClock(int timeMultiplier)
        {
            TimeMultiplier = timeMultiplier;            
        }

        public void Start()
        {
            CurrentTime = StartTime;
            var gameThread = GameThread.Instance();
            gameThread.Subscribe(this);
        }

        public Task Update(int interval) 
        {
            CurrentTime = CurrentTime.AddMilliseconds(interval * TimeMultiplier);
            return Task.CompletedTask;
        }
    }
}
