using SimpleUi.Abstracts;
using UnityEngine.UI;

namespace Game.UI.OrderView.Views
{
    public class OrderItemView : UiView
    {
        public string OrderRequirements;
        public Button TakeOrderButton;

        public void Enable(bool value)
        {
            TakeOrderButton.interactable = value;
        }
    }
}