using Game.Utils;

namespace Game.UI.OrderView.Controllers
{
    public interface IOrderPopupController
    {
        void OnOrderCreated(DeliveryEntity deliveryEntity);
        void ChangeOrderStatus(DeliveryEntity deliveryEntity, EOrderStatus eOrderStatus);
    }
}