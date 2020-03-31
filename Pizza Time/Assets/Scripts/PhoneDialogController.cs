using PizzaTime.Core.Conversations;
using PizzaTime.Core.Phones;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PhoneDialogController : MonoBehaviour
{
    public float TypeSpeed;
    public Text Text;
    public Transform ButtonPanel;
    public GameObject DialogButton;
    IPhoneCall PhoneCall;        

    IEnumerator ScrollAddToText(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            Text.text += input[i];
            yield return new WaitForSeconds(TypeSpeed);
        }        
    }

    internal void StartDialog(IPhoneCall phoneCall)
    {
        Text.text = "";
        PhoneCall = phoneCall;
        PhoneCall.Conversation.SayThing += Conversation_SayThing;

        var greeting = PhoneCall.Player.ThingsToSay.Where(tts => tts.Category == ThingToSayCategory.PhoneGreeting).FirstOrDefault();
        PhoneCall.Conversation.Say(greeting, PhoneCall.Player).Wait();
    }

    private void Conversation_SayThing(IThingToSay obj, IConversationParticipant cp)
    {
        Text.text = "";
        StartCoroutine(HandleSayThing(obj, cp));        
    }

    IEnumerator HandleSayThing(IThingToSay tts, IConversationParticipant cp)
    {
        DisableDialogOptions();
        yield return StartCoroutine(ScrollAddToText(tts.Text));
        if (cp == PhoneCall.Player)
        {
            yield return new WaitForSeconds(1f);
            RespondToPlayer();
        }
        else UpdateDialogOptions();
    }

    private void UpdateDialogOptions()
    {
        foreach(var tts in PhoneCall.Player.ThingsToSay)
        {
            var localTts = tts;
            var button = Instantiate(DialogButton, ButtonPanel);
            button.GetComponentInChildren<Text>().text = tts.Text;
            button.GetComponent<Button>().onClick.AddListener(() => PhoneCall.Conversation.Say(localTts, PhoneCall.Player));
        }
    }

    private void RespondToPlayer()
    {
        var thingsToSay = PhoneCall.Caller.ThingsToSay;
        PhoneCall.Conversation.Say(thingsToSay.First(), PhoneCall.Caller);
    }

    private void DisableDialogOptions()
    {
        var buttons = ButtonPanel.GetComponentsInChildren(typeof(Button));
        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }
    }
}
