using Stateless;
using System;

namespace PizzaTime.Core.PointOfSaleMachinev2.Triggers
{
    internal class ScreenTrigger
    {
        private readonly Trigger _trigger;
        private readonly Screen _screen;

        internal ScreenTrigger(Trigger trigger, Screen screen)
        {
            _trigger = trigger;
            _screen = screen;
        }

        internal void ApplyTo(StateMachine<Screen, Trigger>.StateConfiguration config)
        {
            config.Permit(_trigger, _screen);
        }
    }

    internal class ScreenTriggerWithParameters<T>
    {
        private readonly Trigger _trigger;
        private readonly Func<T, Screen> _selector;

        public StateMachine<Screen, Trigger>.TriggerWithParameters<T> ParameterizedTrigger;

        internal ScreenTriggerWithParameters(Trigger trigger, Func<T, Screen> selector)
        {
            _trigger = trigger;
            _selector = selector;            
        }

        internal void ApplyTo(StateMachine<Screen, Trigger>.StateConfiguration config)
        {
            if(ParameterizedTrigger == null)
            {
                ParameterizedTrigger = config.Machine.SetTriggerParameters<T>(_trigger);
            }

            config.PermitDynamic(ParameterizedTrigger, _selector);
        }
    }
}
