using PizzaTime.Core.Customers;
using PizzaTime.Core.Food.Core;
using PizzaTime.Core.Orders;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class OrdersPageController : MonoBehaviour
{
    public PointOfSaleScreenController screenController;
    public RectTransform content;
    public GameObject orderButtonPrefab;
    public int Page = 0;
    public IEnumerable<OrdersScreenViewModel> Orders { get; private set; }
    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if (canvasGroup.interactable && Input.GetKeyDown(KeyCode.F11)) screenController.SignOut();
    }

    public void Redraw()
    {
        var orders = screenController.GetOrders(Page).ToList();
        Orders = orders.Select(o => new OrdersScreenViewModel(o)).ToList();
    }

    public class OrdersScreenViewModel
    {
        public int OrderNo { get; }
        public string Customer { get; }
        public string OrderType { get; }
        public bool Paid { get; }
        public string OrderTime { get; }

        public OrdersScreenViewModel(Order order)
        {
            OrderNo = order.Id;
            Customer = $"{order.Customer.LastName}, {order.Customer.FirstName}";
            OrderType = order.Type.ToString();
            Paid = order.PaymentStatus;
            OrderTime = order.OrderTime.ToString("hh:mm tt"); // 07:00 AM // 12 hour clock // hour is always 2 digits
        }
    }
}
