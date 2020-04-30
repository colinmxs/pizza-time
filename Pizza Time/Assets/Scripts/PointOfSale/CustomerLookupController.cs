using PizzaTime.Core.PointOfSaleMachinev2.Modules.LookupCustomers;
using System;
using UnityEngine;

public class CustomerLookupController : MonoBehaviour
{
    public CustomerResultsController ResultsComponent;
    public string SearchValue { get; set; }

    private LookupProperty LookupProperty;
    private LookupCustomersModule _module;

    private void Start()
    {
        _module = GetComponentInParent<CustomersPanelController>().Module;        
    }

    public void Search()
    {
        var request = new LookupCustomerRequest()
        {
            LookupProperty = LookupProperty,
            SearchValue = SearchValue
        };
        var result = _module.Handle(request);
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
