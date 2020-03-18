using PizzaTime.Aws.Sdk.Cognito;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SignInController : MonoBehaviour
{
    public InputField UsernameField;
    public InputField PasswordField;

    private readonly AuthService _authService = new AuthService();

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
        _authService.Username = un;
        _authService.Password = pw;
        string token = "";

        var thread = new System.Threading.Thread(() => {
            token = _authService.SignIn().Result;
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
        _authService.Username = un;
        _authService.Password = pw;       

        string token = "";

        var thread = new System.Threading.Thread(() => {
            token = _authService.Register().Result;
        });

        thread.Start();

        while (thread.IsAlive)
        {
            yield return null;
        }

        Debug.Log($"Access Token: {token}");
    }
}