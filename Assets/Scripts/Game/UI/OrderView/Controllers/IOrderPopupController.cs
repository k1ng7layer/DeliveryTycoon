using Game.Utils;

namespace Game.UI.OrderView.Controllers
{
    public interface IOrderPopupController
    {
        void OnOrderCreated(OrderEntity orderEntity);
        void ChangeOrderStatus(OrderEntity orderEntity, EOrderStatus eOrderStatus);
    }
}