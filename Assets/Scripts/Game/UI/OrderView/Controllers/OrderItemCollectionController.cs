using System;
using System.Collections.Generic;
using Ecs.UidGenerator;
using Game.UI.OrderView.Views;
using Game.Utils;
using SimpleUi.Abstracts;
using UniRx;

namespace Game.UI.OrderView.Controllers
{
    public class OrderItemCollectionController : UiController<OrderItemMenuView>,
        IOrderPopupController
    {
        private readonly ActionContext _action;
        private readonly Dictionary<Uid, OrderItemView> _orderItemsTable = new();

        public OrderItemCollectionController(ActionContext action)
        {
            _action = action;
        }

        public void OnOrderCreated(OrderEntity orderEntity)
        {
            var orderItemView = View.OrderItemCollectionView.Create();
            var orderUid = orderEntity.Uid.Value;
            var orderStatus = orderEntity.OrderStatus.Value;
            
            if(!_orderItemsTable.ContainsKey(orderUid))
                _orderItemsTable.Add(orderUid, orderItemView);

            var courierType = orderEntity.Courier.Type;
            var courierAmount = orderEntity.CourierAmount.Value;

            orderItemView.courierAmountText.text = $"Courier amount required: {courierAmount}";
            orderItemView.courierTypeText.text = $"Courier type required: {courierType}";

            orderItemView.TakeOrderButton.OnClickAsObservable().Subscribe(_ => TakeOrder(orderUid)).AddTo(orderItemView.gameObject);
            
            ChangeOrderStatus(orderEntity, orderStatus);
        }

        public void ChangeOrderStatus(OrderEntity deliveryEntity, EOrderStatus eOrderStatus)
        {
            var orderUid = deliveryEntity.Uid.Value;
            var hasOrderView = _orderItemsTable.TryGetValue(orderUid, out var view);

            if (!hasOrderView)
                throw new Exception(
                    $"[{nameof(OrderItemCollectionController)}] there is no order with uid {orderUid} registered in OrderItemMenuView");
            
            view.Enable(eOrderStatus == EOrderStatus.Accessible);
        }

        private void TakeOrder(Uid orderUid)
        {
            var orderItemView = _orderItemsTable[orderUid];
            View.OrderItemCollectionView.Remove(orderItemView);
            
            _action.CreateEntity().AddTakeOrder(orderUid);
        }
    }
}