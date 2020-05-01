using PizzaTime.Core.PointOfSaleMachinev2.Modules.SignIn;
using UnityEngine;

[RequireComponent(typeof(PointOfSaleView))]
public class SignInPanelController : MonoBehaviour
{
    private SignInModule _module;

    private void Start()
    {
        var view = GetComponent<PointOfSaleView>();
        _module = new SignInModule(
            new SignInModuleConfiguration
            {
                Passcode = "admin"
            },
            PointOfSaleMachineController.Instance.POS, 
            view);
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