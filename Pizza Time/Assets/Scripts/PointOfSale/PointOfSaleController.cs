using System.Collections.Generic;
using UnityEngine;
using PizzaTime.Core.PointOfSale.Interfaces;
using Screen = PizzaTime.Core.PointOfSale.Screen;
using System.Linq;

public class PointOfSaleController : MonoBehaviour
{
    IEnumerable<IPointOfSaleView> views;

    private void Start()
    {        
        views = GetComponentsInChildren<IPointOfSaleView>();        
        
        if (views != null)
        {
            TryActivateScreen(views.First().Screen);
        }
    }

    public void TryActivateScreen(string screenToActivate)
    {
        if (views != null)
        {
            var screen = views.SingleOrDefault(v => v.Screen.ToString() == screenToActivate);
            if(screen != null) TryActivateScreen(screen.Screen);
        }
    }

    public void TryActivateScreen(Screen screenToActivate)
    {
        if (views != null)
        {
            foreach (var view in views) view.Active = false;

            var screen = views.SingleOrDefault(v => v.Screen == screenToActivate);
            if (screen != null) screen.Active = true;
        }
    }    
}