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
    [Serializable, NodeMenuItem(TaskNames.GO_TO_OFFICE_PATH)]
    public class GoToOfficeActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;
		
        public override string name => TaskNames.GO_TO_OFFICE;
    }
    
    public class GoToOfficeActionBuilder : ATaskBuilder
    {
        private readonly OrderContext _order;
        private readonly GameContext _game;

        public GoToOfficeActionBuilder(OrderContext order, 
            GameContext game)
        {
            _order = order;
            _game = game;
        }
        
        public override string Name => TaskNames.GO_TO_OFFICE;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {
                var officeEntity = _game.DeliveryOfficeEntity;
                
                var receptionPoint = officeEntity.ReceptionPoint.Value;
                
                entity.ReplaceRouteTarget(new RouteTargetData(receptionPoint, ERouteTarget.Office));
                entity.IsCargo = false;

                return TaskStatus.Success;
                
            });
    }
}