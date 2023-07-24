using System.Collections.Generic;
using Db.OrderParameters;
using Ecs.Order.Extensions;
using Game.Services.DeliveryDestinationService;
using Game.Services.DeliveryPriceService;
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
        private readonly IOrderParametersProvider _orderParametersProvider;

        public CreateOrderSystem(ActionContext action, 
            OrderContext order, 
            GameContext game,
            IDeliveryPriceService deliveryPriceService,
            IDeliveryTargetService deliveryTargetService,
            IOrderParametersProvider orderParametersProvider) : base(action)
        {
            _order = order;
            _game = game;
            _deliveryPriceService = deliveryPriceService;
            _deliveryTargetService = deliveryTargetService;
            _orderParametersProvider = orderParametersProvider;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.CreateOrder);

        protected override bool Filter(ActionEntity entity) => entity.HasCreateOrder && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var orderData = entity.CreateOrder.Value;
                
                var contractUid = orderData.ContractUid;
                var contractEntity = _order.GetEntityWithUid(contractUid);
                var shopUid = contractEntity.Owner.Value;
                
                var deliverySourceEntity = _game.GetEntityWithUid(shopUid);
                var deliverySourcePosition = deliverySourceEntity.Position.Value;
               
                var deliverySourceLevel = deliverySourceEntity.Level.Value;
                
                var deliveryTargetPosition = _deliveryTargetService.GetDeliveryTarget();
                var courierType = GetRandomCourierType(deliverySourceLevel);
                var orderEntity = _order.CreateOrder(deliverySourcePosition, deliveryTargetPosition);
              
                orderEntity.AddSource(shopUid);
                orderEntity.AddItemsAmount(2); //TODO:
                orderEntity.AddOwner(contractUid);
                orderEntity.AddCourier(courierType);
                orderEntity.AddReward(orderData.Reward);

                orderEntity.AddOrderStatus(EOrderStatus.Created);
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