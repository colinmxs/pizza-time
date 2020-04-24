using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInteractableToFalse : MonoBehaviour
{
    IEnumerable<CanvasGroup> canvasGroups;

    private void Start()
    {
        canvasGroups = GetComponentsInChildren<CanvasGroup>();
    }

    public void KeyboardClack()
    {
        foreach (var group in canvasGroups)
        {
            group.interactable = false;
        }
    }
}
