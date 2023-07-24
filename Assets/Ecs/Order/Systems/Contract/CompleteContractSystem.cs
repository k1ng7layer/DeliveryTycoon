using System.Collections.Generic;
using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Order.Systems.Contract
{
    public class CompleteContractSystem : ReactiveSystem<OrderEntity>
    {
        private readonly OrderContext _order;
        private readonly GameContext _game;
        private readonly ActionContext _action;

        public CompleteContractSystem(OrderContext order, 
            GameContext game,
            ActionContext action) : base(order)
        {
            _order = order;
            _game = game;
            _action = action;
        }

        protected override ICollector<OrderEntity> GetTrigger(IContext<OrderEntity> context) =>
            context.CreateCollector(OrderMatcher.OrderStatus);

        protected override bool Filter(OrderEntity entity) 
            => entity.HasOrderStatus
               && entity.OrderStatus.Value == EOrderStatus.Completed 
            && !entity.IsDestroyed;

        protected override void Execute(List<OrderEntity> entities)
        {
            foreach (var entity in entities)
            {
                var contractUid = entity.Owner.Value;
                var contractEntity = _order.GetEntityWithUid(contractUid);
                
                var orders = _order.GetEntitiesWithOwner(contractUid);
                
                var hasActiveOrders = HasActiveOrders(orders);
                
                if(hasActiveOrders)
                    continue;
                
                entity.ReplaceContractStatus(EContractStatus.Completed);
                
                foreach (var order in orders)
                {
                    order.IsDestroyed = true;
                }

                var shopUid = contractEntity.Owner.Value;
                var shop = _game.GetEntityWithUid(shopUid);
                
                shop.RemoveContractProvider();
                
                entity.IsDestroyed = true;
                
                _action.CreateEntity().AddStartNextContractTimer(shopUid);
            }    
        }

        private bool HasActiveOrders(HashSet<OrderEntity> orderEntities)
        {
            bool result = false;
            
            foreach (var order in orderEntities)
            {
                var orderStatus = order.OrderStatus.Value;

                if (orderStatus != EOrderStatus.Completed)
                {
                    result = true;
                    break;
                }
                    
            }

            return result;
        }
    }
}