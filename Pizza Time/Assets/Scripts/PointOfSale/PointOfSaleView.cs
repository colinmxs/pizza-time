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

    public bool IsActive { get; set; } = false;

    public CanvasGroup CanvasGroup { get; private set; }

    private void Awake()
    {
        CanvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if(IsActive && !CanvasGroup.interactable)
        {
            Activate();
        }
    }

    public void Activate()
    {
        IsActive = true;
        Debug.Log("Activate");
        CanvasGroup.interactable = true;
        CanvasGroup.alpha = 1;
        OnActivate.Invoke();
    }

    public void Deactivate()
    {
        IsActive = false;
        CanvasGroup.interactable = false;
        CanvasGroup.alpha = 0;
    }
}
