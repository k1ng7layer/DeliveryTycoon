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
            context.CreateCollector(OrderMatcher.AvailableOrders);

        protected override bool Filter(OrderEntity entity) 
            => entity.HasContract 
            && entity.HasAvailableOrders 
            && entity.AvailableOrders.Value == 0 
            && !entity.IsDestroyed;

        protected override void Execute(List<OrderEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.ReplaceContractStatus(EContractStatus.Completed);
                var contractUid = entity.Uid.Value;

                var orders = _order.GetEntitiesWithOwner(contractUid);

                foreach (var order in orders)
                {
                    order.IsDestroyed = true;
                }

                var shopUid = entity.Owner.Value;
                var shop = _game.GetEntityWithUid(shopUid);
                
                shop.RemoveContractProvider();
                
                entity.IsDestroyed = true;
                
                _action.CreateEntity().AddStartNextContractTimer(shopUid);
            }    
        }
    }
}