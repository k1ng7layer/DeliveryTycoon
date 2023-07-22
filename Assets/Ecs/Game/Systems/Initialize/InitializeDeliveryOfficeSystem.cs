using Game.Services.GameLevelProvider;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Initialize
{
    public class InitializeDeliveryOfficeSystem : IInitializeSystem
    {
        private readonly GameContext _game;
        private readonly IGameLevelProvider _gameLevelProvider;

        public InitializeDeliveryOfficeSystem(GameContext game, 
            IGameLevelProvider gameLevelProvider)
        {
            _game = game;
            _gameLevelProvider = gameLevelProvider;
        }
        
        public void Initialize()
        {
            var officeView = _gameLevelProvider.GameLevelView.DeliveryOfficeView;
            var deliveryOfficeEntity = _game.CreateEntity();
            
            deliveryOfficeEntity.IsDeliveryOffice = true;
            
            deliveryOfficeEntity.AddLink(officeView);
            
            officeView.Link(deliveryOfficeEntity, _game);
        }
    }
}