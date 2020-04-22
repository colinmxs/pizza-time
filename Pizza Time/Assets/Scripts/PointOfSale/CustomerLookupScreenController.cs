using PizzaTime.Core.Customers;
using PizzaTime.Core.PointOfSale.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomerLookupScreenController : MonoBehaviour
{
    public PointOfSaleScreenController screenController;
    public GameObject ResultButtonPrefab;
    public string SearchValue { get; set; }
    public InputField[] Inputs;
    public List<Button> ResultButtons;
    public VerticalLayoutGroup ResultsPanel;
    public int PageSize;
    public int Page;

    private void Start()
    {
        for (int i = 0; i < PageSize; i++)
        {
            var button = Instantiate(ResultButtonPrefab, ResultsPanel.transform).GetComponent<Button>();
            button.gameObject.SetActive(false);
            ResultButtons.Add(button);
        }
    }

    IEnumerable<(Customer, string)> SearchResults { get; set; }
    LookupProperty LookupProperty;

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
            SearchResults = result.Customers;
        }
        DrawResults(1);
    }

    private void DrawResults(int page)
    {
        var pageData = SearchResults.Skip((page - 1) * PageSize).Take(PageSize);
        for (int i = 0; i < PageSize; i++)
        {
            var button = ResultButtons[i];
            var customer = pageData.Skip(i).Take(1).SingleOrDefault();
            if (customer.Item1 == null)
            {
                button.gameObject.SetActive(false);
                continue;
            }
            if (i == 0)
            {
                button.Select();
                button.OnSelect(null);
                button.navigation = new Navigation
                {
                    mode = Navigation.Mode.Explicit,
                    selectOnUp = null,
                    selectOnDown = ResultButtons[1]
                };                
            }
            else
            {
                button.navigation = new Navigation
                {
                    mode = Navigation.Mode.Vertical
                };
            }
            button.gameObject.SetActive(true);
            button.GetComponentInChildren<Text>().text = $"{customer.Item1.LastName}, {customer.Item1.FirstName}";
        }
    }

    public void SetLookupProperty(string lookupProperty)
    {
        LookupProperty = (LookupProperty)Enum.Parse(typeof(LookupProperty), lookupProperty);
    }
    
    public void ClearInputs()
    {
        foreach (var input in Inputs)
        {
            input.text = string.Empty;
        }
    }
}
