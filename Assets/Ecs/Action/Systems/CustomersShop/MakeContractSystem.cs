using System.Collections.Generic;
using Game.Services.RandomProvider;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.CustomersShop
{
    public class MakeContractSystem : ReactiveSystem<ActionEntity>
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;
        private readonly OrderContext _order;
        private readonly IRandomProvider _randomProvider;

        public MakeContractSystem(ActionContext action, 
            GameContext game,
            OrderContext order,
            IRandomProvider randomProvider) : base(action)
        {
            _action = action;
            _game = game;
            _order = order;
            _randomProvider = randomProvider;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.MakeContract);

        protected override bool Filter(ActionEntity entity) => entity.HasMakeContract && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var newContractData = entity.MakeContract.Value;

                var shopUid = newContractData.ShopUid;
                var contractor = _game.GetEntityWithUid(shopUid);

                contractor.IsPartner = true;

                var contractUid = contractor.ContractProvider.ContractUid;
                
                var contractEntity = _order.GetEntityWithUid(contractUid);
                var contractData = contractEntity.Contract.Value;
                
                _action.CreateEntity().AddCreateOrder(shopUid);
            }
        }
    }
}