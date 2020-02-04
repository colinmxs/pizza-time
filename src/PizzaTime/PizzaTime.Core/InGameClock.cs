using System;
using System.Threading;

namespace PizzaTime.Core
{
    public class InGameClock
    {
        public DateTime CurrentTime { get; private set; }
        public int TimeMultiplier { get; }
        public DateTime StartTime { get; set; }
        
        private int Interval = 100;
        private Thread updateThread;
        
        public InGameClock(int timeMultiplier)
        {
            TimeMultiplier = timeMultiplier;            
        }

        public void Start()
        {
            CurrentTime = StartTime;
            updateThread = new Thread(UpdateLoop);
            updateThread.IsBackground = true;
            updateThread.Start();
        }

        private void UpdateLoop()
        {
            while (true)
            {
                UpdateClock();
                Thread.Sleep(Interval);
            }
        }

        private void UpdateClock() 
        {
            CurrentTime = CurrentTime.AddMilliseconds(Interval * TimeMultiplier);
        }
    }
}
