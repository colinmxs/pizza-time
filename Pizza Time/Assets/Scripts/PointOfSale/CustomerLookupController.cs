using PizzaTime.Core.PointOfSale;
using PizzaTime.Core.PointOfSale.Requests;
using System;
using UnityEngine;

public class CustomerLookupController : MonoBehaviour
{
    public CustomerResultsController ResultsComponent;
    public string SearchValue { get; set; }

    LookupProperty LookupProperty;
    IPointOfSaleMachine pos;

    private void Start()
    {        
        pos = PointOfSaleMachineController.Instance.POS;
    }

    public void Search()
    {
        var request = new LookupCustomerRequest()
        {
            LookupProperty = LookupProperty,
            SearchValue = SearchValue
        };
        var result = pos.LookupCustomer(request);
        if (result.Success)
        {
            ResultsComponent.SearchResults = result.Customers;
            ResultsComponent.DrawResults(1);
        }
    }

    public void SetLookupProperty(string lookupProperty)
    {
        LookupProperty = (LookupProperty)Enum.Parse(typeof(LookupProperty), lookupProperty);
    }
}
