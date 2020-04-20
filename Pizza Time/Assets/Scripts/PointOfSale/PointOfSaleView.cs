using PizzaTime.Core.PointOfSale.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Screen = PizzaTime.Core.PointOfSale.Screen;

[RequireComponent(typeof(CanvasGroup))]
public class PointOfSaleView : MonoBehaviour, IPointOfSaleView
{
    public UnityEvent OnActivate;
    public Screen screen;
    public Screen Screen 
    { 
        get 
        {
            return screen;
        } 
    }
    public bool Active 
    {
        get; set;
    }

    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }   

    public void Update()
    {
        if(!canvasGroup.interactable && Active)
        {
            canvasGroup.interactable = true;
            canvasGroup.alpha = 1;
            OnActivate.Invoke();
        }
        else if(canvasGroup.interactable && !Active)
        {
            canvasGroup.interactable = false;
            canvasGroup.alpha = 0;
        }
    }
}
