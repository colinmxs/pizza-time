using PizzaTime.Core;
using UnityEngine;
using UnityEngine.UI;

public class TelephoneController : MonoBehaviour
{
    public Sprite WithReciever;
    public Sprite WithoutReciever;
    private Image Image;
    private bool RecieverHungUp = true;
    private Telephone Telephone;

    private void Awake()
    {
        Image = GetComponent<Image>();
        Telephone = new Telephone(null);
    }

    private void Update()
    {
        HandleRecieverSwap();
        if (Telephone.IsRinging)
        {
            Debug.Log("TELHPONE RIGING");
        }
    }

    private void HandleRecieverSwap()
    {
        if (RecieverHungUp && Image.sprite == WithoutReciever)
        {
            Image.sprite = WithReciever;
        }
        else if (!RecieverHungUp && Image.sprite == WithReciever)
        {
            Image.sprite = WithoutReciever;
        }
    }

    public void ToggleReciever()
    {
        RecieverHungUp = !RecieverHungUp;        
    }
}
