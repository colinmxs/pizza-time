using PizzaTime.Core.PointOfSale.Requests;
using UnityEngine;

namespace Assets.Scripts.PointOfSale
{
    class SignInScreenController : MonoBehaviour
    {
        public PointOfSaleScreenController screenController;


        public void SignIn(string password)
        {
            var request = new SignInRequest
            {
                Passcode = password
            };
            var result = screenController.pos.SignIn(request);
            if (result.Success) screenController.TryActivateScreen("Menu");
        }
    }
}
