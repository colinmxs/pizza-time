using PizzaTime.Core.PointOfSaleMachinev2.Triggers;
using System;

namespace PizzaTime.Core.PointOfSaleMachinev2.Modules.SignIn
{
    public class SignInModule : PointOfSaleModule
    {
        private readonly string _passcode;

        public SignInModule(SignInModuleConfiguration config, PointOfSaleMachine pos, IView view) : base(pos, view)
        {
            _passcode = config.Passcode;
            var screenConfig = pos.ViewRouter.Configure(view.Screen);
            TriggersRepo.SignInToMenu.ApplyTo(screenConfig);            
        }

        public SignInResponse Handle(SignInRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var signedIn = request.Passcode == _passcode;
            if (signedIn) ViewRouter.Fire(Trigger.SignedIn);
            return new SignInResponse(signedIn);
        }
    }
}
