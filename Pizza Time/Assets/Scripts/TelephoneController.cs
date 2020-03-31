using PizzaTime.Core;
using PizzaTime.Core.Orders;
using PizzaTime.Core.Phones;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TelephoneController : MonoBehaviour
{
    public SeederController Seeder;
    public PhoneDialogController Dialog;
    public Sprite WithReciever;
    public Sprite WithoutReciever;
    public AudioClip RingClip;
    public AudioClip DialToneClip;

    private AudioSource _audioSource;
    private Image _image;
    private PhoneLine _telephone;
    private PhoneLine.State _knownState;    

    private void Awake()
    {
        _image = GetComponent<Image>();
        _audioSource = GetComponent<AudioSource>();        
    }

    private void Start()
    {
        var phoneSystem = new PhoneSystem(1);
        _telephone = phoneSystem.PhoneLines.First();
        var callService = new PhoneCallService(Seeder.CustomerRepository, new OrderRepository(Seeder.Orders));
        var dispatcher = new CallDispatcher(callService, phoneSystem);
        dispatcher.ChanceModifier = .0001f;
        _knownState = _telephone.Status;
    }

    private void Update()
    {
        if(_telephone.Status != _knownState)
        {
            Redraw();
            _knownState = _telephone.Status;
        }
    }

    public void OnClick()
    {
        if (_image.sprite == WithReciever) _telephone.PickedUp();
        else _telephone.HungUp();
    }

    public void Redraw()
    {
        Debug.Log(_telephone.Status);
        switch (_telephone.Status)
        {
            case PhoneLine.State.OnHook:
                Dialog.gameObject.SetActive(false);
                _image.sprite = WithReciever;
                _audioSource.Stop();
                break;
            case PhoneLine.State.OffHook:
                Dialog.gameObject.SetActive(false);
                _image.sprite = WithoutReciever;
                _audioSource.clip = DialToneClip;
                _audioSource.Play();
                break;
            case PhoneLine.State.Ringing:
                _audioSource.clip = RingClip;
                _audioSource.Play();
                break;
            case PhoneLine.State.Connected:
                _audioSource.Stop();
                _image.sprite = WithoutReciever;
                Dialog.gameObject.SetActive(true);
                Dialog.StartDialog(_telephone.Call);
                break;
            case PhoneLine.State.Holding:
                break;
        }
    }

        //{
        //    var ftts = _telephone.Call.Caller.ThingsToSay.First();
        //    await conversation.Say(ftts, _telephone.Call.Caller);
        //    Console.WriteLine("...");
        //    Console.WriteLine("Speech Options:");
        //    var i = 0;
        //    foreach (var item in _telephone.Call.Player.ThingsToSay)
        //    {
        //        Console.WriteLine($"Choice {i}::{item.Category.Name}");
        //        i++;
        //    }
        //    int @int = Convert.ToInt32(Console.ReadLine());
        //    ftts = _telephone.Call.Player.ThingsToSay.Skip(@int).First();
        //    await conversation.Say(ftts, _telephone.Call.Player);
        //}
    
}
