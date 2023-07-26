using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.HAS_ORDER_PATH)]
    public class HasOrderConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.HAS_ORDER; 
    }
    
    public class HasOrderConditionBuilder : ATaskBuilder        
    {
        public override string Name => TaskNames.HAS_ORDER;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () => entity.HasActiveOrder);
    }
}