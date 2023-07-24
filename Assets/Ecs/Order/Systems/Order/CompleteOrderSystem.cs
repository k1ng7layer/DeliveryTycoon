using System.Collections.Generic;
using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Order.Systems.Order
{
    public class CompleteOrderSystem : ReactiveSystem<OrderEntity>
    {
        private readonly OrderContext _order;
        private readonly GameContext _game;
        private readonly ActionContext _action;

        public CompleteOrderSystem(OrderContext order, 
            GameContext game, 
            ActionContext action) : base(order)
        {
            _order = order;
            _game = game;
            _action = action;
        }

        protected override ICollector<OrderEntity> GetTrigger(IContext<OrderEntity> context) =>
            context.CreateCollector(OrderMatcher.OrderStatus);

        protected override bool Filter(OrderEntity entity) => entity.IsOrder && entity.HasOrderStatus &&
                                                              entity.OrderStatus.Value == EOrderStatus.Completed
                                                              && !entity.IsDestroyed;

        protected override void Execute(List<OrderEntity> entities)
        {
            foreach (var entity in entities)
            {
                var courierUid = entity.Performer.PerformerUid;
                var courierEntity = _game.GetEntityWithUid(courierUid);
                
                var price = entity.Reward.Value;
                
                //courierEntity.RemoveActiveOrder();

                //courierEntity.IsBusy = false;
                
                _action.CreateEntity().AddChangeCoins(price);
                
                var contractUid = entity.Owner.Value;
                var contractEntity = _order.GetEntityWithUid(contractUid);
                var ordersAmount = contractEntity.AvailableOrders.Value;
                
                //TODO: should be replaced when courier take order
            }
        }
    }
}