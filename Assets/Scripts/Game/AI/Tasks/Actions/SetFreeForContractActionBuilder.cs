using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.SET_FREE_FOR_CONTRACTS_PATH)]
    public class SetFreeForContractActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.SET_FREE_FOR_CONTRACTS;
    }
    
    public class SetFreeForContractActionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.SET_FREE_FOR_CONTRACTS;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                entity.IsBusy = false;
                entity.RemoveRouteTarget();
                entity.RemoveActiveContract();
                
                if(entity.HasActiveOrder)
                    entity.RemoveActiveOrder();
                
                return TaskStatus.Success;
            });
    }
}