using SimpleUi.Abstracts;
using TMPro;
using UnityEngine.UI;

namespace Game.UI.OrderView.Views
{
    public class OrderItemView : UiView
    {
        public TextMeshProUGUI courierTypeText;
        public TextMeshProUGUI courierAmountText;
        
        public Button TakeOrderButton;

        public void Enable(bool value)
        {
            TakeOrderButton.interactable = value;
        }
    }
}