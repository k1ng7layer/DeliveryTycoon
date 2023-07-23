using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Game.AI.Data;
using Game.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.CHANGE_TARGET_PATH)]
    public class ChangeTargetActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.CHANGE_TARGET;
    }
    
    public class ChangeTargetActionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;
        private readonly GameContext _game;
        private readonly ActionContext _action;

        public ChangeTargetActionBuilder(OrderContext order, 
            GameContext game,
            ActionContext action)
        {
            _order = order;
            _game = game;
            _action = action;
        }
        
        public override string Name => TaskNames.CHANGE_TARGET;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                var activeOrderUid = entity.ActiveOrder.Value;
                var activeOrder = _order.GetEntityWithUid(activeOrderUid);
                var currentTargetData = entity.RouteTarget.Value;

                Vector3 destination;
                ERouteTarget target;
                var destinationUid = activeOrder.Destination.DestinationUid;
                var destinationEntity = _game.GetEntityWithUid(destinationUid);
                switch (currentTargetData.RouteTargetType)
                {
                    case ERouteTarget.Customer:
                        var officeEntity = _game.DeliveryOfficeEntity;
                        destination = officeEntity.ReceptionPoint.Value;
                        target = ERouteTarget.Office;
                        entity.ReplaceRouteTarget(new RouteTargetData(destination, target));
                        destinationEntity.IsBusy = false;
                        //entity.IsMoving = true;
                        break;
                    case ERouteTarget.Shop:
                    {
                        var destinationPosition = destinationEntity.ReceptionPoint.Value;
                        
                        destination = destinationPosition;
                        target = ERouteTarget.Customer;
                        entity.ReplaceRouteTarget(new RouteTargetData(destination, target));
                        //entity.IsMoving = true;
                        break;
                    }
                    case ERouteTarget.Office:
                        entity.RemoveRouteTarget();
                        _action.CreateEntity().AddCompleteOrder(activeOrderUid);
                        activeOrder.ReplaceOrderStatus(EOrderStatus.Completed);
                        break;
                }

                return TaskStatus.Success;
                
            });
    }
}