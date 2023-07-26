using System.Collections.Generic;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Action.Systems.Contract
{
    public class ReduceContractCouriersSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly OrderContext _order;

        public ReduceContractCouriersSystem(ActionContext action, 
            GameContext game, 
            OrderContext order) : base(action)
        {
            _game = game;
            _order = order;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.ReduceContractCouriers);

        protected override bool Filter(ActionEntity entity) => entity.HasReduceContractCouriers && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var reduceData = entity.ReduceContractCouriers.Value;

                var contract = _order.GetEntityWithUid(reduceData.ContractUid);

                var absNumber = Mathf.Abs(reduceData.CouriersAmount);
                
                contract.ReplaceCouriersToFreeNumber(absNumber);
            }
        }
    }
}