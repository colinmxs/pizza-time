using PizzaTime.Core.PointOfSaleMachinev2.Triggers;

namespace PizzaTime.Core.PointOfSaleMachinev2.Modules.Menu
{
    public class MenuModule : PointOfSaleModule
    {
        public MenuModule(MenuModuleConfiguration config, PointOfSaleMachine pos, IView view) : base(pos, view)
        {
            var screenConfig = pos.ViewRouter.Configure(view.Screen);
            TriggersRepo.NavigateTo.ApplyTo(screenConfig);
        }

        public void Handle(MenuOptionNavigationRequest request)
        {
            ViewRouter.Fire(TriggersRepo.NavigateTo.ParameterizedTrigger, request.Screen);
        }
    }
}
