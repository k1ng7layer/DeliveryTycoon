using System.Collections.Generic;
using Game.Services.Spawn;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Common
{
    public class InstantiateSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _game;
        private readonly ISpawnService _spawnService;

        public InstantiateSystem(
            GameContext game, 
            ISpawnService spawnService) : base(game)
        {
            _game = game;
            _spawnService = spawnService;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.Instantiate.Added());

        protected override bool Filter(GameEntity entity) => entity.IsInstantiate && !entity.IsDestroyed;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var view = _spawnService.Spawn(entity);
                
                view.Link(entity, _game);
                
                entity.ReplaceLink(view);
            }
        }
    }
}