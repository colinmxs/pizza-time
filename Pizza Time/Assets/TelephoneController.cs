using PizzaTime.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TelephoneController : MonoBehaviour
{
    public Sprite WithReciever;
    public Sprite WithoutReciever;
    private Image Image;
    private bool RecieverHungUp = true;
    private AudioClip AudioClip;
    private Telephone Telephone;

    private void Awake()
    {
        Image = GetComponent<Image>();
        Telephone = new Telephone(null);
    }

    private void Update()
    {
        HandleRecieverSwap();
        HandleToggleRinger();       
    }

    private void HandleToggleRinger()
    {
        if (Telephone.IsRinging)
        {
            
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
