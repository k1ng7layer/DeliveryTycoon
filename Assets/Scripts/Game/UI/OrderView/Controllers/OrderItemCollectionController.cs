using System;
using System.Collections.Generic;
using Ecs.UidGenerator;
using Game.UI.OrderView.Views;
using Game.Utils;
using SimpleUi.Abstracts;

namespace Game.UI.OrderView.Controllers
{
    public class OrderItemCollectionController : UiController<OrderItemMenuView>,
        IOrderPopupController
    {
        private readonly DeliveryContext _delivery;
        private readonly Dictionary<Uid, OrderItemView> _orderItemsTable = new();

        public OrderItemCollectionController(DeliveryContext delivery)
        {
            _delivery = delivery;
        }

        public void OnOrderCreated(DeliveryEntity deliveryEntity)
        {
            var orderItemView = View.OrderItemCollectionView.Create();
            var orderUid = deliveryEntity.Uid.Value;
            
            if(!_orderItemsTable.ContainsKey(orderUid))
                _orderItemsTable.Add(orderUid, orderItemView);
        }

        public void ChangeOrderStatus(DeliveryEntity deliveryEntity, EOrderStatus eOrderStatus)
        {
            var orderUid = deliveryEntity.Uid.Value;
            var hasOrderView = _orderItemsTable.TryGetValue(orderUid, out var view);

            if (!hasOrderView)
                throw new Exception(
                    $"[{nameof(OrderItemCollectionController)}] there is no order with uid {orderUid} registered in OrderItemMenuView");
            
            view.Enable(eOrderStatus == EOrderStatus.Accessible);
        }
    }
}