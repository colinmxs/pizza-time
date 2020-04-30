using PizzaTime.Core.PointOfSaleMachinev2.Modules.SignIn;
using UnityEngine;

[RequireComponent(typeof(PointOfSaleView))]
public class SignInPanelController : MonoBehaviour
{
    private SignInModule _module;

    private void Start()
    {       
        _module = new SignInModule(
            new SignInModuleConfiguration
            {
                Passcode = "admin"
            },
            PointOfSaleMachineController.Instance.POS, 
            GetComponent<PointOfSaleView>());
    }

    public void SignIn(string password)
    {
        var request = new SignInRequest
        {
            Passcode = password
        };
        _ = _module.Handle(request);
    }
}