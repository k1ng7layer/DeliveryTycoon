using System;
using UniBT;

namespace Game.AI.Tasks.Abstraction
{
    public abstract class AConditionalTask : Conditional, 
        ILinkedTask
    {
        private GameEntity _entity;
        private Func<bool> _condition;

        protected override void OnStart()
        {
            _condition = Condition(_entity);
        }

        protected sealed override bool IsUpdatable() => _condition();

        public void Link(GameEntity gameEntity)
        {
            _entity = gameEntity;
        }

        protected abstract Func<bool> Condition(GameEntity entity);
    }
}