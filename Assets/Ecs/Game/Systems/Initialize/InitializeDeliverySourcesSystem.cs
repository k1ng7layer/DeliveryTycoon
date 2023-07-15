using Game.Services.GameLevelProvider;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Initialize
{
    public class InitializeDeliverySourcesSystem : IInitializeSystem
    {
        private readonly IGameLevelProvider _gameLevelProvider;
        private readonly GameContext _game;

        public InitializeDeliverySourcesSystem(IGameLevelProvider gameLevelProvider, 
            GameContext game)
        {
            _gameLevelProvider = gameLevelProvider;
            _game = game;
        }
        
        public void Initialize()
        {
            var sources = _gameLevelProvider.GameLevelView.DeliveryShops;

            foreach (var source in sources)
            {
                var deliverySourceEntity = _game.CreateEntity();

                deliverySourceEntity.IsDeliverySource = true;
                deliverySourceEntity.AddLink(source);
                deliverySourceEntity.AddPosition(source.transform.position);
                deliverySourceEntity.AddUid(UidGenerator.UidGenerator.Next());
                deliverySourceEntity.AddLevel(source.ShopParameters.ShopLevel);
                
                source.Link(deliverySourceEntity, _game);
            }
        }
    }
}