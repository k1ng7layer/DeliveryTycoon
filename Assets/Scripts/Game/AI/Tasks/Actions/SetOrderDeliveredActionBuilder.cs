using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Game.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.SET_ORDER_DELIVERED_PATH)]
    public class SetOrderDeliveredActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.SET_ORDER_DELIVERED;
    }
    
    public class SetOrderDeliveredActionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;
        private readonly GameContext _game;

        public SetOrderDeliveredActionBuilder(OrderContext order, 
            GameContext game)
        {
            _order = order;
            _game = game;
        }
        
        public override string Name => TaskNames.SET_ORDER_DELIVERED;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                var activeOrderUid = entity.ActiveOrder.Value;
                var activeOrderEntity = _order.GetEntityWithUid(activeOrderUid);
                activeOrderEntity.ReplaceOrderStatus(EOrderStatus.Delivered);
                var destinationUid = activeOrderEntity.Destination.DestinationUid;
                var destinationEntity = _game.GetEntityWithUid(destinationUid);
                destinationEntity.IsBusy = false;
                
                return TaskStatus.Success;

            });
    }
}