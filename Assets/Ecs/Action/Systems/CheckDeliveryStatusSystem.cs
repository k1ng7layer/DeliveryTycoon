using System.Collections.Generic;
using Game.Services.OrderStatusService;
using Game.UI.OrderView.Controllers;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Action.Systems
{
    public class CheckDeliveryStatusSystem : ReactiveSystem<ActionEntity>
    {
        private static readonly ListPool<DeliveryEntity> DeliveryEntityPool = ListPool<DeliveryEntity>.Instance;
        
        private readonly IOrderStatusService _orderStatusService;
        private readonly IOrderPopupController _orderPopupController;
        private readonly IGroup<DeliveryEntity> _pendingOrdersGroup;

        public CheckDeliveryStatusSystem(
            ActionContext action,
            DeliveryContext delivery,
            IOrderStatusService orderStatusService,
            IOrderPopupController orderPopupController) : base(action)
        {
            _orderStatusService = orderStatusService;
            _orderPopupController = orderPopupController;

            _pendingOrdersGroup = delivery.GetGroup(DeliveryMatcher.AllOf(DeliveryMatcher.Delivery, 
                    DeliveryMatcher.DeliveryStatus)
                .NoneOf(DeliveryMatcher.InWork, DeliveryMatcher.Destroyed));
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.CheckDeliveryStatus);

        protected override bool Filter(ActionEntity entity) => entity.IsCheckDeliveryStatus && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var pendingOrders = DeliveryEntityPool.Spawn();

                _pendingOrdersGroup.GetEntities(pendingOrders);

                foreach (var pendingOrder in pendingOrders)
                {
                    var currenStatus = pendingOrder.DeliveryStatus.Value;
                    
                    var newStatus = _orderStatusService.GetStatus(pendingOrder);

                    if (currenStatus != newStatus)
                    {
                        pendingOrder.ReplaceDeliveryStatus(newStatus);
                        
                        _orderPopupController.ChangeOrderStatus(pendingOrder, newStatus);
                    }
                    
                }

                DeliveryEntityPool.Despawn(pendingOrders);
            }
        }
    }
}