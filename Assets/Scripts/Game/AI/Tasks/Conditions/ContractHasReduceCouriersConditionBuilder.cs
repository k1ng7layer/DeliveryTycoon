using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.CONTRACT_REDUCE_PATH)]
    public class ContractHasReduceCouriersConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.CONTRACT_REDUCE;
    }
    
    public class ContractHasReduceCouriersConditionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;

        public ContractHasReduceCouriersConditionBuilder(OrderContext order)
        {
            _order = order;
        }
        
        public override string Name => TaskNames.CONTRACT_REDUCE;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () =>
                {
                    var activeContractUid = entity.ActiveContract.Value;
                    var contractEntity = _order.GetEntityWithUid(activeContractUid);

                    return contractEntity.HasCouriersToFreeNumber;
                });
    }
}