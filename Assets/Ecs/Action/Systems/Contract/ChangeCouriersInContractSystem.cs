using System.Collections.Generic;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.Contract
{
    public class ChangeCouriersInContractSystem : ReactiveSystem<ActionEntity>
    {
        public ChangeCouriersInContractSystem(ActionContext action) : base(action)
        {
            
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.ChangeCouriersInContract);

        protected override bool Filter(ActionEntity entity) => entity.HasChangeCouriersInContract && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var changeData = entity.ChangeCouriersInContract.Value;
                
                
            }
        }
    }
}