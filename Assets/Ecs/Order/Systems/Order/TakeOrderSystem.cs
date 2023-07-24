using System.Collections.Generic;
using Game.AI.Data;
using Game.Utils;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Order.Systems.Order
{
    public class TakeOrderSystem : ReactiveSystem<OrderEntity>
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly OrderContext _order;
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _freeCouriersGroup;

        public TakeOrderSystem(OrderContext order, 
            GameContext game
        ) : base(order)
        {
            _order = order;
            _game = game;
            
            _freeCouriersGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Courier)
                .NoneOf(GameMatcher.Busy, GameMatcher.Destroyed, GameMatcher.ActiveOrder));
        }

        protected override ICollector<OrderEntity> GetTrigger(IContext<OrderEntity> context)
            => context.CreateCollector(OrderMatcher.Order);

        protected override bool Filter(OrderEntity entity)
            => entity.IsOrder && entity.OrderStatus.Value == EOrderStatus.Created && !entity.IsDestroyed;
		
        protected override void Execute(List<OrderEntity> entities)
        {
            foreach (var orderEntity in entities)
            {
                var contractUid = orderEntity.Owner.Value;
                var attachedCouriers = _game.GetEntitiesWithOwner(contractUid);
                var orderUid = orderEntity.Uid.Value;
                var contractEntity = _order.GetEntityWithUid(contractUid);

                var couriers = EntityPool.Spawn();
                _freeCouriersGroup.GetEntities(couriers);
                
                foreach (var courier in couriers)
                {
                    var courierUid = courier.Uid.Value;
                    
                    var orderSourceUid = orderEntity.Source.DeliverySourceUid;
                    var orderSourceEntity = _game.GetEntityWithUid(orderSourceUid);
                    var orderSourceReception = orderSourceEntity.ReceptionPoint.Value;
                
                    orderEntity.AddPerformer(courierUid);
                    courier.ReplaceActiveOrder(orderUid);
                    courier.ReplaceActiveContract(contractUid);
                    courier.ReplaceRouteTarget(new RouteTargetData(orderSourceReception, ERouteTarget.Shop));
                    courier.IsBusy = true;
                    orderEntity.ReplaceOrderStatus(EOrderStatus.InProgress);
                    
                    var ordersAmount = contractEntity.AvailableOrders.Value;
                    contractEntity.ReplaceAvailableOrders(--ordersAmount);
                    
                    break;
                }
                
                EntityPool.Despawn(couriers);
            }
        }
    }
}