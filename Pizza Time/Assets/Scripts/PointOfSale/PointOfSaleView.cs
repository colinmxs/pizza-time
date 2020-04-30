using PizzaTime.Core.PointOfSaleMachinev2;
using UnityEngine;
using UnityEngine.Events;
using Screen = PizzaTime.Core.PointOfSaleMachinev2.Screen;

[RequireComponent(typeof(CanvasGroup))]
public class PointOfSaleView : MonoBehaviour, IView
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

    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }   

    public void Activate()
    {
        Debug.Log("Activate");
        canvasGroup.interactable = true;
        canvasGroup.alpha = 1;
        OnActivate.Invoke();
    }

    public void Deactivate()
    {
        canvasGroup.interactable = false;
        canvasGroup.alpha = 0;
    }
}
