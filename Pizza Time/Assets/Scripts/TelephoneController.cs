using PizzaTime.Core;
using PizzaTime.Core.Conversations;
using PizzaTime.Core.Orders;
using PizzaTime.Core.Phones;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TelephoneController : MonoBehaviour
{
    public SeederController Seeder;
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
        new CallDispatcher(callService, phoneSystem);
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
                _audioSource.Stop();
                _image.sprite = WithoutReciever;
                _telephone.Call.Conversation.SayThing += Conversation_SayThing;
                var greeting = _telephone.Call.Caller.ThingsToSay.Where(tts => tts.Category == ThingToSayCategory.PhoneGreeting).FirstOrDefault();
                _telephone.Call.Conversation.Say(greeting, _telephone.Call.Caller);                
                break;
            case PhoneLine.State.Holding:
                break;
        }
    }

    //private IEnumerator Converse(IConversation conversation)
    //{
    //    while (true)
    //    {
    //        var ftts = participant2.ThingsToSay.First();
    //        await conversation.Say(ftts, participant2);
    //        Console.WriteLine("...");
    //        Console.WriteLine("Speech Options:");
    //        var i = 0;
    //        foreach (var item in participant1.ThingsToSay)
    //        {
    //            Console.WriteLine($"Choice {i}::{item.Category.Name}");
    //            i++;
    //        }
    //        int @int = Convert.ToInt32(Console.ReadLine());
    //        ftts = participant1.ThingsToSay.Skip(@int).First();
    //        await conversation.Say(ftts, participant1);
    //    }
    //}

    private void Conversation_SayThing(PizzaTime.Core.Conversations.IThingToSay obj)
    {
        
    }
}
