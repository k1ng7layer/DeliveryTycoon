using SimpleUi.Abstracts;
using TMPro;
using UnityEngine.UI;

namespace Game.UI.DeliverySourceShop.Views
{
    public class ShopWindowView : UiView
    {
        public Button EngageContractButton;
        public Button CloseArea;
        public Button IncreaseCouriersBtn;
        public Button ReduceCouriersBtn;
        public Button ChangeCouriersBtn;
        public TextMeshProUGUI SelectedCouriersAmountText;
        public TextMeshProUGUI ShopName;
        public TextMeshProUGUI CourierTypeText;
        public TextMeshProUGUI RequiredCourierAmountText;
        public TextMeshProUGUI ContractTotalRewardText;
        public TextMeshProUGUI OrdersAmountText;
    }
}