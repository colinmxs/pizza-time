using PizzaTime.Core;
using PizzaTime.Core.Phones;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TelephoneController : MonoBehaviour
{
    public Sprite WithReciever;
    public Sprite WithoutReciever;
    private Image _image;

    public AudioClip RingClip;
    public AudioClip DialToneClip;
    private AudioSource _audioSource;

    private PhoneLine telephone;
    private PhoneLine.State knownState;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();
        var phoneSystem = new PhoneSystem(1);
        telephone = phoneSystem.PhoneLines.First();
        var callDispatcher = new CallDispatcher();
        knownState = telephone.Status;
    }

    private void Update()
    {
        if(telephone.Status != knownState)
        {
            Redraw();
            knownState = telephone.Status;
        }
    }

    public void OnClick()
    {
        if (_image.sprite == WithReciever) telephone.PickedUp();
        else telephone.HungUp();
    }

    public void Redraw()
    {
        Debug.Log(telephone.Status);
        switch (telephone.Status)
        {
            case PhoneLine.State.OnHook:
                _image.sprite = WithReciever;
                _audioSource.Stop();
                break;
            case PhoneLine.State.OffHook:
                _image.sprite = WithoutReciever;
                _audioSource.clip = DialToneClip;
                _audioSource.Play();
                break;
            case PhoneLine.State.Ringing:
                _audioSource.clip = RingClip;
                _audioSource.Play();
                break;
            case PhoneLine.State.Connected:
                _image.sprite = WithoutReciever;
                break;
            case PhoneLine.State.Holding:
                break;
        }
    }
}
