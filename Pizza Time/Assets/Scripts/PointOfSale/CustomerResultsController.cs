using PizzaTime.Core.Customers;
using PizzaTime.Core.PointOfSale;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomerResultsController : MonoBehaviour
{
    public CustomerDetailsController CustomerDetails;
    public IEnumerable<(Customer, string)> SearchResults { get; set; }
    public IPointOfSaleMachine pos;
    public GameObject ResultButtonPrefab;
    public List<Button> ResultButtons;
    public VerticalLayoutGroup ResultsPanel;
    public int PageSize;
    public int Page;
    bool isFocused = false;

    private void Awake()
    {
        for (int i = 0; i < PageSize; i++)
        {
            var button = Instantiate(ResultButtonPrefab, ResultsPanel.transform).GetComponent<Button>();
            button.gameObject.SetActive(false);
            ResultButtons.Add(button);
        }
    }

    private void Start()
    {
        pos = PointOfSaleMachineController.Instance.POS;
    }

    public void DrawResults(int page)
    {
        var pageData = SearchResults.Skip((page - 1) * PageSize).Take(PageSize);
        for (int i = 0; i < PageSize; i++)
        {
            var button = ResultButtons[i];
            button.onClick.RemoveAllListeners();
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
                isFocused = true;
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

            button.onClick.AddListener(() =>
            {
                CustomerDetails.Customer = customer;
                CustomerDetails.Select();
                isFocused = false;
            });
            button.gameObject.SetActive(true);
            button.GetComponentInChildren<Text>().text = $"{customer.Item1.LastName}, {customer.Item1.FirstName}";
        }
    }

    private void Update()
    {
        if (!ResultButtons.Any(b => b.isActiveAndEnabled) || !isFocused) return;
        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Page > 1) Page--;

            Debug.Log(Page);
            DrawResults(Page);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {            
            if (Page < SearchResults.Count()/PageSize) Page++;
            Debug.Log(Page);
            DrawResults(Page);
        }
    }
}
