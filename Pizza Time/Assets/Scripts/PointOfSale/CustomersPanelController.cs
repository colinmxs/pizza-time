using UnityEngine;
using PizzaTime.Core.PointOfSaleMachinev2.Modules.LookupCustomers;

[RequireComponent(typeof(PointOfSaleView))]
public class CustomersPanelController : MonoBehaviour
{
    public LookupCustomersModule Module;

    private void Start()
    {
        Module = new LookupCustomersModule(
            new LookupCustomerModuleConfig(),
            PointOfSaleMachineController.Instance.POS,
            GetComponent<PointOfSaleView>());
    }
}
