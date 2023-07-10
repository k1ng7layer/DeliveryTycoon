using System.Collections.Generic;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems
{
    public class CreateContractSystem : ReactiveSystem<ActionEntity>
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;

        public CreateContractSystem(ActionContext action, 
            GameContext game) : base(action)
        {
            _action = action;
            _game = game;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.CreateContract);

        protected override bool Filter(ActionEntity entity) => entity.HasCreateContract && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var contractorUid = entity.CreateContract.ShopUid;

                var contractor = _game.GetEntityWithUid(contractorUid);

                contractor.IsPartner = true;
                
                _action.CreateEntity().AddStartNextDeliveryTimer(contractorUid);
            }
        }
    }
}