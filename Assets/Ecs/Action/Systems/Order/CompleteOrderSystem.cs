using System.Collections.Generic;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.Order
{
    public class CompleteOrderSystem : ReactiveSystem<ActionEntity>
    {
        private readonly ActionContext _action;
        private readonly OrderContext _order;
        private readonly GameContext _game;

        public CompleteOrderSystem(ActionContext action, 
            OrderContext order,
            GameContext game) : base(action)
        {
            _action = action;
            _order = order;
            _game = game;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.CompleteOrder);

        protected override bool Filter(ActionEntity entity) => entity.HasCompleteOrder && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var orderUid = entity.CompleteOrder.OrderUid;
                var orderEntity = _order.GetEntityWithUid(orderUid);
                var courierUid = orderEntity.Owner.Value;
                var courierEntity = _game.GetEntityWithUid(courierUid);
                
                var price = orderEntity.Price.Value;
                
                courierEntity.RemoveActiveOrder();

                courierEntity.IsBusy = false;
                
                _action.CreateEntity().AddChangeCoins(price);
            }
        }
    }
}