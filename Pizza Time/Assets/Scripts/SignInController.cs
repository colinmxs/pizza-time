using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SignInController : MonoBehaviour
{
    public InputField UsernameField;
    public InputField PasswordField;

    public void SignIn() 
    {
        var un = UsernameField.text;
        var pw = PasswordField.text;

        Debug.Log("Sign In");
        Debug.Log($"UN: {un}");
        Debug.Log($"PW: {pw}");
        StartCoroutine(SignIn(un, pw));
    }

    IEnumerator SignIn(string un, string pw)
    {
        string token = "";

        var thread = new System.Threading.Thread(() => {
        });
        
        thread.Start();
        
        while (thread.IsAlive)
        {
            yield return null;
        }

        Debug.Log($"Access Token: {token}");
    }

    public void Register()
    {
        var un = UsernameField.text;
        var pw = PasswordField.text;
        StartCoroutine(Register(un, pw));
    }

    IEnumerator Register(string un, string pw)
    {

        string token = "";

        var thread = new System.Threading.Thread(() => {
        });

        thread.Start();

        while (thread.IsAlive)
        {
            yield return null;
        }

        Debug.Log($"Access Token: {token}");
    }
}