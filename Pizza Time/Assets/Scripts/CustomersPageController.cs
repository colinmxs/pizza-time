using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CustomersPageController : MonoBehaviour
{
    public PointOfSaleScreenController screenController;
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
    }
}
