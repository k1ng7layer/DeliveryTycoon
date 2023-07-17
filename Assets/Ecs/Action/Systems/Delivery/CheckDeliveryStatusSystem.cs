using System.Collections.Generic;
using Game.Services.OrderStatusService;
using Game.UI.OrderView.Controllers;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Action.Systems.Delivery
{
    public class CheckDeliveryStatusSystem : ReactiveSystem<ActionEntity>
    {
        private static readonly ListPool<OrderEntity> DeliveryEntityPool = ListPool<OrderEntity>.Instance;
        
        private readonly IOrderStatusService _orderStatusService;
        private readonly IOrderPopupController _orderPopupController;
        private readonly IGroup<OrderEntity> _pendingOrdersGroup;

        public CheckDeliveryStatusSystem(
            ActionContext action,
            OrderContext order,
            IOrderStatusService orderStatusService,
            IOrderPopupController orderPopupController) : base(action)
        {
            _orderStatusService = orderStatusService;
            _orderPopupController = orderPopupController;

            _pendingOrdersGroup = order.GetGroup(OrderMatcher.AllOf(OrderMatcher.Order, 
                    OrderMatcher.OrderStatus)
                .NoneOf(OrderMatcher.InWork, OrderMatcher.Destroyed));
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.CheckOrderStatus);

        protected override bool Filter(ActionEntity entity) => entity.IsCheckOrderStatus && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var pendingOrders = DeliveryEntityPool.Spawn();

                _pendingOrdersGroup.GetEntities(pendingOrders);

                foreach (var pendingOrder in pendingOrders)
                {
                    var currenStatus = pendingOrder.OrderStatus.Value;
                    
                    var newStatus = _orderStatusService.GetStatus(pendingOrder);

                    if (currenStatus != newStatus)
                    {
                        pendingOrder.ReplaceOrderStatus(newStatus);
                        
                        _orderPopupController.ChangeOrderStatus(pendingOrder, newStatus);
                    }
                    
                }

                DeliveryEntityPool.Despawn(pendingOrders);
            }
        }
    }
}