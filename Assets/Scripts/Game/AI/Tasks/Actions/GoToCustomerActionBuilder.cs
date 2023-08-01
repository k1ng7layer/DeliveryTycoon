using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Game.AI.Data;
using Game.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.GO_TO_CUSTOMER_PATH)]
    public class GoToCustomerActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.GO_TO_CUSTOMER;
    }
    
    public class GoToCustomerActionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;
        private readonly GameContext _game;

        public GoToCustomerActionBuilder(OrderContext order, 
            GameContext game)
        {
            _order = order;
            _game = game;
        }
        
        public override string Name => TaskNames.GO_TO_CUSTOMER;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                var activeOrderUid = entity.ActiveOrder.Value;
                var activeOrder = _order.GetEntityWithUid(activeOrderUid);

                var destinationUid = activeOrder.Destination.DestinationUid;
                var destinationEntity = _game.GetEntityWithUid(destinationUid);
                
                var destinationPosition = destinationEntity.ReceptionPoint.Value;
                entity.ReplaceRouteTarget(new RouteTargetData(destinationPosition, ERouteTarget.Customer));
                entity.IsCargo = true;

                return TaskStatus.Success;
                
            });
    }
}