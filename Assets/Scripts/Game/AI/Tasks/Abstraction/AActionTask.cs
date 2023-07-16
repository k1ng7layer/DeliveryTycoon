using System;
using UniBT;
using Action = UniBT.Action;

namespace Game.AI.Tasks.Abstraction
{
    public abstract class AActionTask : Action, ILinkedTask
    {
        private readonly NodeBehavior _nodeBehavior;
        
        private Func<Status> _updatedLogic;

        private GameEntity Entity { get; set; }

        public override void Start()
        {
            base.Start();
            
            _updatedLogic = DoWork(Entity);
        }
        
        public void Link(GameEntity gameEntity)
        {
            Entity = gameEntity;
        }
        
        protected sealed override Status OnUpdate() => _updatedLogic();

        protected abstract Func<Status> DoWork(GameEntity entity);
    }
}