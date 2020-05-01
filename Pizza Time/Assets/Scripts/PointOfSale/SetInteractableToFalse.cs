using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetInteractableToFalse : MonoBehaviour
{
    IEnumerable<PointOfSaleView> views;    

    private void Start()
    {
        views = GetComponentsInChildren<PointOfSaleView>();
        views.Single(v => v.Screen == PizzaTime.Core.PointOfSaleMachinev2.Screen.SignIn).IsActive = true;
    }

    public void KeyboardClack()
    {
        foreach (var view in views)
        {            
            view.CanvasGroup.interactable = false;
        }
    }
}
