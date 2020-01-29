using PizzaTime.Core.PointOfSale;
using PizzaTime.Core.PointOfSale.Interfaces;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PointOfSaleView : MonoBehaviour, IPointOfSaleView
{
    public InputField focusableInput;
    public Button focusableButton;

    public PointOfSaleMachine.Screen screen;
    public PointOfSaleMachine.Screen Screen 
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

    public void Start()
    {
        //if (canvasGroup.interactable && Active)
        //{
        //    if (focusableButton != null) focusableButton.Select();
        //    else if (focusableInput != null)
        //    {
        //        focusableInput.Select();
        //        focusableInput.ActivateInputField();
        //    }
        //}
    }

    public void Update()
    {
        if(!canvasGroup.interactable && Active)
        {
            canvasGroup.interactable = true;
            canvasGroup.alpha = 1;

            if (focusableButton != null) focusableButton.Select();
            else if (focusableInput != null)
            {
                focusableInput.Select();                    
                focusableInput.ActivateInputField();
            }
        }
        else if(canvasGroup.interactable && !Active)
        {
            canvasGroup.interactable = false;
            canvasGroup.alpha = 0;
        }
    }
}
