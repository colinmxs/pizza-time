using Stateless;
using System;
using System.Threading.Tasks;

namespace PizzaTime.Core
{
    public class PhoneLine : IUpdate
    {
        enum Trigger
        {
            IncomingCallDetected,
            PhonePickedUp,
            HoldButtonPressed,
            PhoneHungUp
        }

        public enum State
        {
            OnHook,
            OffHook,
            Ringing,
            Connected,
            Holding
        }

        public State Status { get; private set; } = State.OnHook;

        StateMachine<State, Trigger> _machine;
        StateMachine<State, Trigger>.TriggerWithParameters<string> _incomingCallTrigger;

        string _callee;

        public PhoneLine()
        {
            _machine = new StateMachine<State, Trigger>(() => Status, s => Status = s);

            _incomingCallTrigger = _machine.SetTriggerParameters<string>(Trigger.IncomingCallDetected);

            _machine.Configure(State.OnHook)
              .Permit(Trigger.IncomingCallDetected, State.Ringing)
              .Permit(Trigger.PhonePickedUp, State.OffHook);

            _machine.Configure(State.Ringing)
                .OnEntryFrom(_incomingCallTrigger, callee => OnDialed(callee))
              .Permit(Trigger.PhonePickedUp, State.Connected);

            _machine.Configure(State.Connected)
                .OnEntry(t => StartCallTimer())
                .OnExit(t => StopCallTimer())
              .Permit(Trigger.HoldButtonPressed, State.Holding)
              .Permit(Trigger.PhoneHungUp, State.OnHook);

            _machine.Configure(State.Holding)
                .SubstateOf(State.Connected)
                .Permit(Trigger.HoldButtonPressed, State.Connected);

            _machine.Configure(State.OffHook)
                .Permit(Trigger.PhoneHungUp, State.OnHook);

            _machine.OnTransitioned(t => Console.WriteLine($"OnTransitioned: {t.Source} -> {t.Destination} via {t.Trigger}({string.Join(", ", t.Parameters)})"));
        }
        
        void OnDialed(string callee)
        {
            _callee = callee;
            Console.WriteLine("[Phone Call] placed for : [{0}]", _callee);
        }

        void StartCallTimer()
        {
            Console.WriteLine("[Timer:] Call started at {0}", DateTime.Now);
        }

        void StopCallTimer()
        {
            Console.WriteLine("[Timer:] Call ended at {0}", DateTime.Now);
        }

        public void Dialed(string callee)
        {
            _machine.Fire(_incomingCallTrigger, callee);
        }

        public void PickedUp()
        {
            _machine.Fire(Trigger.PhonePickedUp);
        }

        public void HungUp()
        {
            _machine.Fire(Trigger.PhoneHungUp);
        }

        public void HoldButtonPressed()
        {
            _machine.Fire(Trigger.HoldButtonPressed);
        }

        public Task Update(int interval)
        {
            throw new NotImplementedException();
        }
    }
}
