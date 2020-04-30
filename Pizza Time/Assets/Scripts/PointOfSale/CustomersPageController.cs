using PizzaTime.Core.Customers;
using PizzaTime.Core.PointOfSaleMachinev2.Modules.AddOrUpdateCustomer;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PointOfSaleView))]
public class CustomersPageController : MonoBehaviour
{
    private AddOrUpdateCustomerModule _module;
    
    public InputField FirstName;
    public InputField LastName;
    public InputField Phone;
    public InputField Address;
    public InputField City;
    public InputField Remarks;

    public void SaveCustomer(bool addOrder = false)
    {
        string firstName = FirstName.text;
        var lastName = LastName.text;
        var phone = Phone.text;
        var address = Address.text;
        var zip = City.text;
        var remarks = Remarks.text;

        var customer = new Customer(firstName, lastName, phone)
        {
            Address = address,
            ZipCode = zip
        };
        var addCustomer = new AddOrUpdateCustomerRequest
        {
            Customer = customer,
            Remarks = remarks,
            AddOrder = addOrder
        };

        _ = _module.Handle(addCustomer);        
    }

    public void Cancel()
    {
        _module.Cancel();
    }

    public void AddOrder()
    {
        SaveCustomer(true);
    }

    private void Start()
    {        
        _module = new AddOrUpdateCustomerModule(
            new AddOrUpdateCustomerModuleConfiguration(),
            PointOfSaleMachineController.Instance.POS,
            GetComponent<PointOfSaleView>());
    }
}
