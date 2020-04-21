using PizzaTime.Core.Customers;
using PizzaTime.Core.PointOfSale.Requests;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerLookupScreenController : MonoBehaviour
{
    public PointOfSaleScreenController screenController;
    public string SearchValue { get; set; }
    public LookupProperty LookupProperty { get; set; }

    List<Customer> SearchResults { get; set; }

    public void Search()
    {
        var request = new LookupCustomerRequest() 
        {
            LookupProperty = LookupProperty,
            SearchValue = SearchValue
        };
        var result = screenController.pos.LookupCustomer(request);

        if (result.Success)
        {

        }
    }

    private string GetSearchValue()
    {
        throw new NotImplementedException();
    }

    private LookupProperty GetLookupProperty()
    {
        throw new NotImplementedException();
    }
}
