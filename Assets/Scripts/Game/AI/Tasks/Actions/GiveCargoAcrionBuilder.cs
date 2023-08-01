using System;
using System.Collections.Generic;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Trees;
using GraphProcessor;
using Plugins.NgpBehaviourTreeDesigner.Nodes;
using UnityEngine;

namespace Game.AI.Tasks.Actions
{
    [Serializable, NodeMenuItem(TaskNames.SWITCH_CARGO_PATH)]
    public class SwitchCargoActionNode : ABehaviourTreeNode
    {
        [GraphProcessor.Input("In"), Vertical]
        public float input;

        [SerializeField] private bool setCargo;
        
        public override Dictionary<string, object> Values =>
            new()
            {
                { "Cargo", setCargo }
            };
        
        public override string name => TaskNames.SWITCH_CARGO;
    }
    
    public class SwitchCargoActionBuilder : ATaskBuilder
    {
        public override string Name => TaskNames.SWITCH_CARGO;

        public override void
            Fill(BehaviorTreeBuilder builder, GameEntity entity, Dictionary<string, object> taskValues) => builder.Do(
            Name,
            () =>
            {

                var cargo = (bool) taskValues["Cargo"];
                
                entity.IsCargo = cargo;

                return TaskStatus.Success;
                
            });
    }
}