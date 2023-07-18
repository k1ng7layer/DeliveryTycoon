using System.Collections.Generic;
using Game.AI;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Initialize
{
    public class AiInitializeSystem : ReactiveSystem<GameEntity>
    {
        private readonly IBehaviourTreeFactory _behaviourTreeFactory;

        public AiInitializeSystem(
            GameContext game,
            IBehaviourTreeFactory behaviourTreeFactory
        ) : base(game)
        {
            _behaviourTreeFactory = behaviourTreeFactory;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
            => context.CreateCollector(GameMatcher.Ai);

        protected override bool Filter(GameEntity entity)
            => entity.HasAi && !entity.HasBehaviourTree && !entity.IsDestroyed;
		
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                var behaviorTree = _behaviourTreeFactory.Create(gameEntity);
                gameEntity.AddBehaviourTree(behaviorTree);
            }
        }
    }
}