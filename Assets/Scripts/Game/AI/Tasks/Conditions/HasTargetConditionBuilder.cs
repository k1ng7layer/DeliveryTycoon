﻿using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.HAS_TARGET_PATH)]
    public class HasTargetConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.HAS_TARGET;
    }
    
    public class HasTargetConditionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.HAS_TARGET;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () => entity.HasRouteTarget);
    }
}