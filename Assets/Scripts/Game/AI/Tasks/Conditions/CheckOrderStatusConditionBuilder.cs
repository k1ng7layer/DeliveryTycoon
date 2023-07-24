using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Trees;
using Game.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Conditions
{
    [Serializable, NodeMenuItem(TaskNames.CHECK_ORDER_STATUS_PATH)]
    public class CheckOrderStatusConditionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;

        [SerializeField] private EOrderStatus orderStatus;
        
        public override Dictionary<string, object> Values =>
            new()
            {
                { "OrderStatus", orderStatus }
            };
        
        public override string name => TaskNames.CHECK_ORDER_STATUS;
    }
    
    public class CheckOrderStatusConditionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;

        public CheckOrderStatusConditionBuilder(OrderContext order)
        {
            _order = order;
        }
        
        public override string Name => TaskNames.CHECK_ORDER_STATUS;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) =>
            builder.Condition(Name,
                () =>
                {
                    var orderStatus = (EOrderStatus) taskValues["OrderStatus"];
                    var activeOrderUid = entity.ActiveOrder.Value;
                    var orderEntity = _order.GetEntityWithUid(activeOrderUid);
                    var actualStatus = orderEntity.OrderStatus.Value;

                    return actualStatus == orderStatus;
                    
                });
    }
}