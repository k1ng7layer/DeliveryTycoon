using Ecs.Views.Linkable.Impl;
using Game.AI.BT;
using Game.AI.Tasks.Abstraction;
using JCMG.EntitasRedux;
using UniBT;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Ecs.Views.Courier
{
    public class CourierView : ObjectView  
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private BehaviourTreeSetup behaviourTreeSetup;

        [Inject] private DiContainer container;

        private GameEntity _courierEntity;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            _courierEntity = (GameEntity)entity;
            
            var behaviorTree = behaviourTreeSetup.InitializeBtWithEntity(_courierEntity);

            _courierEntity.AddBehaviourTree(behaviourTreeSetup);
        }
        
        // private void SetupBT()
        // {
        //     var root = behaviorTree.Root;
        //     Setup(root.Child);
        //     // if (root.Child is Composite composite)
        //     // {
        //     //     foreach (var child in composite.Children)
        //     //     {
        //     //         container.Inject(child);
        //     //         
        //     //         if (child is AActionTask actionTask)
        //     //         {
        //     //             actionTask.Link(_courierEntity);
        //     //         }
        //     //     }
        //     // }
        //     //
        //     // if (root.Child is AActionTask actionTask1)
        //     // {
        //     //     actionTask1.Link(_courierEntity);
        //     // }
        // }

        void Setup(NodeBehavior nodeBehavior)
        {
            if (nodeBehavior is AActionTask actionTask)
            {
                actionTask.Link(_courierEntity);
            }
            
            if (nodeBehavior is Composite composite)
            {
                foreach (var child in composite.Children)
                {
                    container.Inject(nodeBehavior);
                    
                    Setup(child);
                }
            }
        }
        
    }
}