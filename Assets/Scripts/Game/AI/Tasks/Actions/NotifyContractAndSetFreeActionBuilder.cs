using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.NOTIFY_CONTRACT_AND_SET_FREE_PATH)]
    public class NotifyContractAndSetFreeActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.NOTIFY_CONTRACT_AND_SET_FREE;
    }
    
    public class NotifyContractAndSetFreeActionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;

        public NotifyContractAndSetFreeActionBuilder(OrderContext order)
        {
            _order = order;
        }
        
        public override string Name => TaskNames.NOTIFY_CONTRACT_AND_SET_FREE;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                var activeContractUid = entity.ActiveContract.Value;
                var activeContractEntity = _order.GetEntityWithUid(activeContractUid);
                var setFreeNumber = activeContractEntity.CouriersToFreeNumber.Value;
                var newValue = setFreeNumber - 1;
                
                if(newValue <= 0)
                    activeContractEntity.RemoveCouriersToFreeNumber();
                else  activeContractEntity.ReplaceCouriersToFreeNumber(newValue);
                
                return TaskStatus.Success;
            });
    }
}