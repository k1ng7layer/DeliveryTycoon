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
    [Serializable, NodeMenuItem(TaskNames.GO_TO_SHOP_PATH)]
    public class GoToShopActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.GO_TO_SHOP;
    }
    
    public class GoToShopActionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;
        private readonly GameContext _game;

        public GoToShopActionBuilder(OrderContext order, 
            GameContext game)
        {
            _order = order;
            _game = game;
        }
        
        public override string Name => TaskNames.GO_TO_SHOP;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                var activeOrderUid = entity.ActiveOrder.Value;
                var activeOrder = _order.GetEntityWithUid(activeOrderUid);
                var contractUid = activeOrder.Owner.Value;
                var contractEntity = _order.GetEntityWithUid(contractUid);
                var shopUid = contractEntity.Owner.Value;
                var shopEntity = _game.GetEntityWithUid(shopUid);
                var receptionPoint = shopEntity.ReceptionPoint.Value;
                
                entity.ReplaceRouteTarget(new RouteTargetData(receptionPoint, ERouteTarget.Shop));
                entity.IsCargo = false;

                return TaskStatus.Success;
                
            });
    }
}