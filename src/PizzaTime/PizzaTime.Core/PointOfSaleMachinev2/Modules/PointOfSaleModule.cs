using Stateless;

namespace PizzaTime.Core.PointOfSaleMachinev2.Modules
{
    public abstract class PointOfSaleModule
    {
        internal StateMachine<Screen, Trigger> ViewRouter { get; }

        internal IView View { get; set; }

        internal PointOfSaleModule(PointOfSaleMachine pos, IView view)
        {
            View = view;            
            ViewRouter = pos.ViewRouter;
            pos.Modules.Add(View.Screen, this);
            pos.ViewRouter.Activate();
        }        
    }
}
