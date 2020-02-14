using Stateless;
using System;

namespace PizzaTime.Core.Phones
{
    public class PhoneLine
    {
        enum Trigger
        {
            IncomingCallDetected,
            PhonePickedUp,
            HoldButtonPressed,
            PhoneHungUp,
            CallDisconnected
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
        StateMachine<State, Trigger>.TriggerWithParameters<IPhoneCall> _incomingCallTrigger;

        IPhoneCall _call;

        public PhoneLine()
        {
            _machine = new StateMachine<State, Trigger>(() => Status, s => Status = s);

            _incomingCallTrigger = _machine.SetTriggerParameters<IPhoneCall>(Trigger.IncomingCallDetected);

            _machine.Configure(State.OnHook)
              .Permit(Trigger.IncomingCallDetected, State.Ringing)
              .Permit(Trigger.PhonePickedUp, State.OffHook);

            _machine.Configure(State.Ringing)
                .OnEntryFrom(_incomingCallTrigger, call => OnDialed(call))
              .Permit(Trigger.PhonePickedUp, State.Connected)
              .Permit(Trigger.CallDisconnected, State.OnHook);

            _machine.Configure(State.Connected)
                .OnEntry(t => StartCallTimer())
                .OnExit(t => StopCallTimer())
              .Permit(Trigger.HoldButtonPressed, State.Holding)
              .Permit(Trigger.PhoneHungUp, State.OnHook)
              .Permit(Trigger.CallDisconnected, State.OffHook);

            _machine.Configure(State.Holding)
                .SubstateOf(State.Connected)
                .Permit(Trigger.HoldButtonPressed, State.Connected);

            _machine.Configure(State.OffHook)
                .Permit(Trigger.PhoneHungUp, State.OnHook);

            _machine.OnTransitioned(t => Console.WriteLine($"OnTransitioned: {t.Source} -> {t.Destination} via {t.Trigger}({string.Join(", ", t.Parameters)})"));
        }
        
        void OnDialed(IPhoneCall call)
        {
            _call = call;
            Console.WriteLine("[Phone Call] placed for : [{0}]", _call);
        }

        void StartCallTimer()
        {
            Console.WriteLine("[Timer:] Call started at {0}", DateTime.Now);
        }

        void StopCallTimer()
        {
            Console.WriteLine("[Timer:] Call ended at {0}", DateTime.Now);
        }

        internal void InitiateCall(IPhoneCall call)
        {
            _machine.Fire(_incomingCallTrigger, call);
        }

        internal void Disconnect()
        {
            _machine.Fire(Trigger.CallDisconnected);
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
    }
}
