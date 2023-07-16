using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Game.Systems.Ai
{
    public class BehaviourTreeUpdateSystem : IUpdateSystem
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
 
        private readonly IGroup<GameEntity> _aiGroup;
        
        public BehaviourTreeUpdateSystem(GameContext game)
        {
            _aiGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Ai, GameMatcher.BehaviourTree)
                .NoneOf(GameMatcher.Destroyed));
        }
        
        public void Update()
        {
            var aiEntities = EntityPool.Spawn();
            _aiGroup.GetEntities(aiEntities);

            foreach (var aiEntity in aiEntities)
            {
                var behaviourTree = aiEntity.BehaviourTree.Value;
                
                behaviourTree.Tick();
            }
            
            EntityPool.Despawn(aiEntities);
        }
    }
}