using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaTime.Core
{
    public class GameThread
    {
        private static GameThread _instance;
        private Thread updateThread;
        private readonly int Interval = 100;
        private List<Func<int, Task>> UpdateMethods = new List<Func<int, Task>>();

        protected GameThread()
        {
        }

        public static GameThread Instance()
        {
            if (_instance == null)
            {
                _instance = new GameThread();
                _instance.Start();
            }
            
            return _instance;
        }
        
        private void Start()
        {
            updateThread = new Thread(UpdateLoop);
            updateThread.IsBackground = true;
            updateThread.Start();
        }

        private void UpdateLoop()
        {
            while (true)
            {
                DoStuff().Wait();
                Thread.Sleep(Interval);
            }
        }

        internal void Subscribe(IUpdate updater) 
        {
            UpdateMethods.Add(interval => updater.Update(interval));
        }

        private async Task DoStuff()
        {
            var tasks = new List<Task>();
            foreach (var method in UpdateMethods)
            {
                tasks.Add(method.Invoke(Interval));
            }
            await Task.WhenAll(tasks).ConfigureAwait(false);
        }
    }
}
