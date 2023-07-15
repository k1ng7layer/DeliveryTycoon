using Game.Services.GameLevelProvider;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Initialize
{
    public class InitializeCustomersSystem : IInitializeSystem
    {
        private readonly IGameLevelProvider _gameLevelProvider;
        private readonly GameContext _game;

        public InitializeCustomersSystem(IGameLevelProvider gameLevelProvider, 
            GameContext game)
        {
            _gameLevelProvider = gameLevelProvider;
            _game = game;
        }
        
        public void Initialize()
        {
            var customerSpotViews = _gameLevelProvider.GameLevelView.CustomerSpotViews;

            foreach (var customerSpotView in customerSpotViews)
            {
                var customerEntity = _game.CreateEntity();

                customerEntity.IsCustomer = true;
                customerEntity.AddPosition(customerSpotView.transform.position);
                customerEntity.AddUid(UidGenerator.UidGenerator.Next());
                customerEntity.AddLink(customerSpotView);
                
                customerSpotView.Link(customerEntity, _game);
            }
        }
    }
}