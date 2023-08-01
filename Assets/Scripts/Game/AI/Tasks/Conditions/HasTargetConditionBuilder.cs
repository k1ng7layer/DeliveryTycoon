using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using Game.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.HAS_TARGET_PATH)]
    public class HasTargetConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;

        [SerializeField] private ERouteTarget target;
        
        public override Dictionary<string, object> Values =>
            new()
            {
                { "Target", target }
            };
        
        public override string name => TaskNames.HAS_TARGET;
    }
    
    public class HasTargetConditionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.HAS_TARGET;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () =>
                {
                    var target = (ERouteTarget) taskValues["Target"];

                    if (target == ERouteTarget.Any)
                        return entity.HasRouteTarget;
                    
                    return entity.HasRouteTarget && entity.RouteTarget.Value.RouteTargetType == target;
                });
    }
}