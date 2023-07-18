using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Game.Utils.Extensions;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.MOVE_TO_TARGET_PATH)]
    public class MoveToTargetActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.MOVE_TO_TARGET;
    }
    
    public class MoveToTargetActionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.MOVE_TO_TARGET;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                var courierPosition = entity.Position.Value;

                var target = entity.RouteTarget.Value;

                var courierParameters = entity.CourierParameters.Value;
                var checkDistance = courierParameters.targetCheckDistance;
                var distance = (target.Destination - courierPosition).NoY().sqrMagnitude;
                
                Debug.Log($"distance = {distance}, checkDistance = {checkDistance * checkDistance}");
                if (distance <= checkDistance * checkDistance)
                {
                    return TaskStatus.Success;
                }

                return TaskStatus.Continue;

            });
    }
}