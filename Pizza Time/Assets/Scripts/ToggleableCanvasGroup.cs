using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ToggleableCanvasGroup : MonoBehaviour
{
    public bool Active;
    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Update()
    {
        if (!canvasGroup.interactable && Active)
        {
            canvasGroup.interactable = true;
            canvasGroup.alpha = 1;            
        }
        else if (canvasGroup.interactable && !Active)
        {
            canvasGroup.interactable = false;
            canvasGroup.alpha = 0;
        }
    }
}
