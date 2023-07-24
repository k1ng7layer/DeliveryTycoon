using System.Collections.Generic;
using Db.ContractParametersProvider;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.Order
{
    public class StartNextContractTimerSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly IContractParametersProvider _contractParametersProvider;

        public StartNextContractTimerSystem(ActionContext action, 
            GameContext game,
            IContractParametersProvider contractParametersProvider) : base(action)
        {
            _game = game;
            _contractParametersProvider = contractParametersProvider;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.StartNextContractTimer);

        protected override bool Filter(ActionEntity entity) => entity.HasStartNextContractTimer && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var shopUid = entity.StartNextContractTimer.DeliverySourceUid;

                var deliverySourceEntity = _game.GetEntityWithUid(shopUid);

                deliverySourceEntity.ReplaceNextContractTimer(2f);
            }
        }
    }
}