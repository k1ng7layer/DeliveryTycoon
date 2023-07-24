using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Game.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.FINISH_ORDER_PATH)]
    public class FinishOrderActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.FINISH_ORDER;
    }
    
    public class FinishOrderActionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;

        public FinishOrderActionBuilder(OrderContext order)
        {
            _order = order;
        }
        
        public override string Name => TaskNames.FINISH_ORDER;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                var activeOrderUid = entity.ActiveOrder.Value;
                var activeOrder = _order.GetEntityWithUid(activeOrderUid);
                
                activeOrder.ReplaceOrderStatus(EOrderStatus.Completed);
                
                return TaskStatus.Success;
                
            });
    }
}