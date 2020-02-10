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
    public AudioClip RingClip;
    public AudioClip DialToneClip;
    private AudioSource AudioSource;
    private Telephone Telephone;
    private Conversation Conversation = null;

    private void Awake()
    {
        Image = GetComponent<Image>();
        AudioSource = GetComponent<AudioSource>();
        Telephone = new Telephone(null);
    }

    private void Update()
    {
        HandleRecieverSwap();
        HandleToggleRinger();
        HandleToggleDialtone();
        HandleAnswerPhoneCall();
        HandleEndPhoneCall();
    }

    private void HandleToggleDialtone()
    {
        if (!Telephone.IsRinging && !Telephone.IsInUse) 
        {
            if (!AudioSource.isPlaying && !RecieverHungUp)
            {
                AudioSource.clip = DialToneClip;
                AudioSource.Play();
            }
            else if (AudioSource.isPlaying && AudioSource.clip == DialToneClip && RecieverHungUp)
            {
                AudioSource.Stop();
            }
        }        
    }

    private void HandleEndPhoneCall()
    {
        if (Telephone.IsInUse && (RecieverHungUp || Conversation == null))
        {
            Telephone.EndCall();
        }
    }

    private void HandleAnswerPhoneCall()
    {
        if(Telephone.IsRinging && !RecieverHungUp)
        {
            var conversation = Telephone.AnswerCall();
            //AudioSource.clip = GetConversationClip(conversation);
        }
    }

    private void HandleToggleRinger()
    {
        if (RecieverHungUp) 
        {
            if (Telephone.IsRinging && !AudioSource.isPlaying)
            {
                AudioSource.clip = RingClip;
                AudioSource.Play();
            }            
        }
        if (!Telephone.IsRinging && AudioSource.clip == RingClip && AudioSource.isPlaying)
        {
            AudioSource.Stop();
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
