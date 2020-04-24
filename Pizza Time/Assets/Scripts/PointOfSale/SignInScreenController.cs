using PizzaTime.Core.PointOfSale;
using PizzaTime.Core.PointOfSale.Requests;
using UnityEngine;

namespace Assets.Scripts.PointOfSale
{
    class SignInScreenController : MonoBehaviour
    {
        IPointOfSaleMachine pos;

        private void Start()
        {
            pos = PointOfSaleMachineController.Instance.POS;
        }

        public void SignIn(string password)
        {
            var request = new SignInRequest
            {
                Passcode = password
            };
            var result = pos.SignIn(request);
            //if (result.Success) screenController.TryActivateScreen("Menu");
        }
    }
}
