using UnityEngine;

namespace Assets.Scripts.PointOfSale
{
    public class MenuViewController : MonoBehaviour
    {
        public PointOfSaleScreenController screenController;

        public void SelectMenuOption(string option)
        {
            screenController.TryActivateScreen(option);
        }
    }
}
