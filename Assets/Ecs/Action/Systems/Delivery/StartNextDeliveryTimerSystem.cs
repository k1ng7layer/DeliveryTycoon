using System.Collections.Generic;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.Delivery
{
    public class StartNextDeliveryTimerSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;

        public StartNextDeliveryTimerSystem(ActionContext action, 
            GameContext game) : base(action)
        {
            _game = game;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.StartNextDeliveryTimer);

        protected override bool Filter(ActionEntity entity) => entity.HasStartNextDeliveryTimer && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var shopUid = entity.StartNextDeliveryTimer.DeliverySourceUid;

                var deliverySourceEntity = _game.GetEntityWithUid(shopUid);
                
                deliverySourceEntity.ReplaceNextDeliveryTimer(5f);

            }
        }
    }
}