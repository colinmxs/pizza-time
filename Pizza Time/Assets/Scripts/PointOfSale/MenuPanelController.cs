using PizzaTime.Core.PointOfSaleMachinev2.Modules.Menu;
using UnityEngine;
using Screen = PizzaTime.Core.PointOfSaleMachinev2.Screen;

[RequireComponent(typeof(PointOfSaleView))]
public class MenuPanelController : MonoBehaviour
{
    private MenuModule _module;

    private void Start()
    {
        _module = new MenuModule(
            new MenuModuleConfiguration(),
            PointOfSaleMachineController.Instance.POS,
            GetComponent<PointOfSaleView>());
    }

    public void SelectOrders()
    {
        SelectMenuOption(Screen.Orders);
    }

    public void SelectAddOrder()
    {
        SelectMenuOption(Screen.AddOrder);
    }

    public void SelectCustomers()
    {
        SelectMenuOption(Screen.Customers);
    }

    public void SelectAddCustomer()
    {
        SelectMenuOption(Screen.AddCustomer);
    }

    public void SelectSignIn()
    {
        SelectMenuOption(Screen.SignIn);
    }

    private void SelectMenuOption(Screen screen)
    {
        _module.Handle(new MenuOptionNavigationRequest
        {
            Screen = screen
        });
    }
}