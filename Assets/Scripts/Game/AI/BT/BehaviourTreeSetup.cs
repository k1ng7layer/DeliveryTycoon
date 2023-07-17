using Game.AI.Tasks.Abstraction;
using UniBT;
using Zenject;

namespace Game.AI.BT
{
    public class BehaviourTreeSetup : BehaviorTree
    {
        [Inject] private DiContainer _container;
        
        private GameEntity _entity;
        
        public BehaviorTree InitializeBtWithEntity(GameEntity entity)
        {
            _entity = entity;

            var tree = Setup(Root.Child);

            return tree;
        }
        
        private BehaviorTree Setup(NodeBehavior nodeBehavior)
        {
            if (nodeBehavior is ILinkedTask linkedTask)
            {
                linkedTask.Link(_entity);
            }

            if (nodeBehavior is AConditionalTask conditional)
            {
                if (conditional.Child != null)
                    Setup(conditional.Child);
            }
            
            if (nodeBehavior is Composite composite)
            {
                foreach (var child in composite.Children)
                {
                    _container.Inject(nodeBehavior);
                    
                    Setup(child);
                }
            }

            return this;
        }
    }
}