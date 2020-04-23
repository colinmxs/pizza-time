using PizzaTime.Core.Customers;
using UnityEngine;
using UnityEngine.UI;

public class CustomerDetailsController : MonoBehaviour
{
    public Button EditButton;
    public Button AddOrderButton;

    private (Customer, string) _customer;
    public (Customer, string) Customer
    {
        get
        {
            return _customer;
        }
        set
        {
            Name.text = $"{value.Item1.FirstName} {value.Item1.LastName}";
            Phone.text = value.Item1.PhoneNumber;
            Address.text = value.Item1.Address;
            Remarks.text = value.Item2;
            _customer = value;
        }
    }
    public Text Name;
    public Text Phone;
    public Text Address;
    public Text Remarks;

    public void Select()
    {
        EditButton.Select();
        EditButton.OnSelect(null);
    }

    private void Start()
    {
        EditButton.onClick.AddListener(() => Edit());
        AddOrderButton.onClick.AddListener(() => AddOrder());
    }

    public void Edit()
    {
        Debug.Log("Edit " + Name);
    }

    public void AddOrder()
    {
        Debug.Log("Add Order " + Name);
    }
}
