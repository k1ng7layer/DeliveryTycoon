using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.HAS_FREE_ORDERS_PATH)]
    public class HasFreeOrdersConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.HAS_FREE_ORDERS;
    }
    
    public class HasFreeOrdersConditionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;

        public HasFreeOrdersConditionBuilder(OrderContext order)
        {
            _order = order;
        }
        
        public override string Name => TaskNames.HAS_FREE_ORDERS;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () =>
                {
                    var activeContractUid = entity.ActiveContract.Value;
                    
                    var orders = _order.GetEntitiesWithOwner(activeContractUid);
                    
                    bool result = false;
                    
                    foreach (var order in orders)
                    {
                        if(order.HasPerformer)
                            continue;

                        result = true;
                        break;
                    }

                    return result;
                    
                });
    }
}