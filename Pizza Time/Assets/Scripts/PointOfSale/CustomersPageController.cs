using PizzaTime.Core.Customers;
using PizzaTime.Core.PointOfSale;
using PizzaTime.Core.PointOfSale.Requests;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class CustomersPageController : MonoBehaviour
{
    public PointOfSaleScreenController screenController;
    public InputField FirstName;
    public InputField LastName;
    public InputField Phone;
    public InputField Address;
    public InputField City;
    public InputField Remarks;

    CanvasGroup canvasGroup;

    public void SaveCustomer()
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
            Remarks = remarks
        };

        var result = screenController.pos.AddOrUpdateCustomer(addCustomer);
        if (result.Success)
            screenController.TryActivateScreen(PizzaTime.Core.PointOfSale.Screen.Menu);
    }

    public void Cancel() 
    {
        screenController.TryActivateScreen(PizzaTime.Core.PointOfSale.Screen.Menu);
    }

    public void AddOrder()
    {
        SaveCustomer();
        screenController.TryActivateScreen(PizzaTime.Core.PointOfSale.Screen.AddOrder);
    }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();        
    }

    private void Update()
    {
        if (canvasGroup.interactable && Input.GetKeyDown(KeyCode.F11)) screenController.SignOut();
    }
}
