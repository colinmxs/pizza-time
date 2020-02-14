using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Core.Phones
{
    public interface IPhoneSystem
    {
        void TryConnect(IPhoneCall phoneCall);
    }

    public class PhoneSystem : IPhoneSystem
    {
        public IEnumerable<PhoneLine> PhoneLines { get; }

        public PhoneSystem(int availableLines)
        {
            var lines = new List<PhoneLine>();
            for (int i = 0; i < availableLines; i++)
            {
                lines.Add(new PhoneLine());
            }

            PhoneLines = new List<PhoneLine>(lines);
        }

        public void TryConnect(IPhoneCall phoneCall)
        {
            var line = PhoneLines.FirstOrDefault(p => p.Status == PhoneLine.State.OnHook);
            if (line != null)
            {
                line.InitiateCall(phoneCall);
            }
        }
    }
}
