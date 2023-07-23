using System.Collections.Generic;
using Game.AI.Data;
using Game.Utils;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Action.Systems.Order
{
    public class TakeOrderSystem : ReactiveSystem<ActionEntity>
    {
        private static readonly ListPool<GameEntity> GameEntityPool = ListPool<GameEntity>.Instance;

        private readonly GameContext _game;
        private readonly OrderContext _order;
        private readonly IGroup<GameEntity> _freeCouriersGroup;

        public TakeOrderSystem(ActionContext action, 
            GameContext game,
            OrderContext order) : base(action)
        {
            _game = game;
            _order = order;

            _freeCouriersGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Courier)
                .NoneOf(GameMatcher.Busy, GameMatcher.Destroyed));
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.TakeOrder);

        protected override bool Filter(ActionEntity entity) => entity.HasTakeOrder && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var orderUid = entity.TakeOrder.OrderUid;
                var orderEntity = _order.GetEntityWithUid(orderUid);
                var courier = GetFreeCourier();
                var courierUid = courier.Uid.Value;
               
                var orderSourceUid = orderEntity.Source.DeliverySourceUid;
                var orderSourceEntity = _game.GetEntityWithUid(orderSourceUid);
                var orderSourceReception = orderSourceEntity.ReceptionPoint.Value;
                
                orderEntity.AddPerformer(courierUid);
                courier.ReplaceActiveOrder(orderUid);
                courier.ReplaceRouteTarget(new RouteTargetData(orderSourceReception, ERouteTarget.Shop));
                courier.IsBusy = true;
            }
        }

        private GameEntity GetFreeCourier()
        {
            GameEntity freeCourier = null;
            
            var couriers = GameEntityPool.Spawn();
            _freeCouriersGroup.GetEntities(couriers);

            foreach (var courier in couriers)
            {
                freeCourier = courier;
            }
            
            GameEntityPool.Despawn(couriers);

            return freeCourier;
        }
    }
}