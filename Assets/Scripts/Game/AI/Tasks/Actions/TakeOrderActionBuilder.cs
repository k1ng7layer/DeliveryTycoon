using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using Game.AI.Data;
using Game.Services.RandomProvider;
using Game.Utils;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.TAKE_ORDER_PATH)]
    public class TakeOrderActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.TAKE_ORDER;
    }
    
    public class TakeOrderActionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;
        private readonly IRandomProvider _randomProvider;
        private readonly GameContext _game;

        public TakeOrderActionBuilder(OrderContext order, 
            IRandomProvider randomProvider,
            GameContext game)
        {
            _order = order;
            _randomProvider = randomProvider;
            _game = game;
        }
        
        public override string Name => TaskNames.TAKE_ORDER;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
        
                var contractUid = entity.ActiveContract.Value;
                var courierUid = entity.Uid.Value;
                var contractEntity = _order.GetEntityWithUid(contractUid);
                var orders = _order.GetEntitiesWithOwner(contractUid);

                var freeOrders = new List<OrderEntity>();

                foreach (var order in orders)
                {
                    if(!order.HasPerformer)
                        freeOrders.Add(order);
                }

                var rnd = _randomProvider.Range(0, freeOrders.Count - 1);
                
                
                var randomOrder = freeOrders[rnd];
                var orderUid = randomOrder.Uid.Value;
                entity.ReplaceActiveOrder(orderUid);
                randomOrder.AddPerformer(courierUid);
                var orderSourceUid = randomOrder.Source.DeliverySourceUid;
                var orderSourceEntity = _game.GetEntityWithUid(orderSourceUid);
                var orderSourceReception = orderSourceEntity.ReceptionPoint.Value;

                randomOrder.ReplaceOrderStatus(EOrderStatus.InProgress);
                
                entity.ReplaceRouteTarget(new RouteTargetData(orderSourceReception, ERouteTarget.Shop));
                
                var ordersAmount = contractEntity.AvailableOrders.Value;
                contractEntity.ReplaceAvailableOrders(--ordersAmount);
                
                return TaskStatus.Success;

            });
    }
}