using System.Collections.Generic;
using Db.OrderParameters;
using Ecs.Order.Extensions;
using Game.Services.DeliveryDestinationService;
using Game.Services.DeliveryPriceService;
using Game.Services.DeliveryTargetTimeService;
using Game.Services.OrderStatusService;
using Game.Services.RandomProvider;
using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.Order
{
    public class CreateOrderSystem : ReactiveSystem<ActionEntity>
    {
        private readonly OrderContext _order;
        private readonly GameContext _game;
        private readonly IDeliveryPriceService _deliveryPriceService;
        private readonly IDeliveryTargetService _deliveryTargetService;
        private readonly IDeliveryTargetTimeService _deliveryTargetTimeService;
        private readonly IRandomProvider _randomProvider;
        private readonly IOrderParametersProvider _orderParametersProvider;
        private readonly IOrderStatusService _orderStatusService;

        public CreateOrderSystem(ActionContext action, 
            OrderContext order, 
            GameContext game,
            IDeliveryPriceService deliveryPriceService,
            IDeliveryTargetService deliveryTargetService,
            IDeliveryTargetTimeService deliveryTargetTimeService,
            IRandomProvider randomProvider,
            IOrderParametersProvider orderParametersProvider,
            IOrderStatusService orderStatusService) : base(action)
        {
            _order = order;
            _game = game;
            _deliveryPriceService = deliveryPriceService;
            _deliveryTargetService = deliveryTargetService;
            _deliveryTargetTimeService = deliveryTargetTimeService;
            _randomProvider = randomProvider;
            _orderParametersProvider = orderParametersProvider;
            _orderStatusService = orderStatusService;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.CreateOrder);

        protected override bool Filter(ActionEntity entity) => entity.HasCreateOrder && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var sourceUid = entity.CreateOrder.DeliverySourceUid;
                
                var deliverySourceEntity = _game.GetEntityWithUid(sourceUid);
                var deliverySourcePosition = deliverySourceEntity.Position.Value;
               
                var deliverySourceLevel = deliverySourceEntity.Level.Value;
                
                var deliveryTargetPosition = _deliveryTargetService.GetDeliveryTarget();

                var orderEntity = _order.CreateOrder(deliverySourcePosition, deliveryTargetPosition);
                orderEntity.AddSource(sourceUid);
                orderEntity.AddItemsAmount(2); //TODO:
                var deliveryPrice = _deliveryPriceService.CalculateDeliveryPrice(orderEntity);

                var courierType = GetRandomCourierType(deliverySourceLevel);

                var requiredCourierAmount = _randomProvider.Range(1, 1);
                
                orderEntity.AddCourier(courierType);
                orderEntity.AddPrice(deliveryPrice);

                orderEntity.AddOrderStatus(EOrderStatus.InProgress);
                
                //_orderPopupController.OnOrderCreated(orderEntity);
            }
        }
        

        private ECourierType GetRandomCourierType(int sourceLevel)
        {
            var orderParameters = _orderParametersProvider.Get(sourceLevel);

            var courierType = orderParameters.RequiredCourierType;

            return courierType;
        }
    }
}