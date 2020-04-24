using UnityEngine;

namespace Assets.Scripts.PointOfSale
{
    public class MenuViewController : MonoBehaviour
    {
        public PointOfSaleController screenController;

        public void SelectMenuOption(string option)
        {
            screenController.TryActivateScreen(option);
        }
    }
}
