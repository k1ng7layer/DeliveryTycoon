using Game.Services.GameLevelProvider;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Initialize
{
    public class InitializeDeliverySourcesSystem : IInitializeSystem
    {
        private readonly IGameLevelProvider _gameLevelProvider;
        private readonly GameContext _game;
        private readonly ActionContext _action;

        public InitializeDeliverySourcesSystem(IGameLevelProvider gameLevelProvider, 
            GameContext game, 
            ActionContext action
            )
        {
            _gameLevelProvider = gameLevelProvider;
            _game = game;
            _action = action;
        }
        
        public void Initialize()
        {
            var sources = _gameLevelProvider.GameLevelView.DeliveryShops;

            foreach (var source in sources)
            {
                var deliverySourceEntity = _game.CreateEntity();
                var uid = UidGenerator.UidGenerator.Next();
                deliverySourceEntity.IsOrderSource = true;
                deliverySourceEntity.AddLink(source);
                deliverySourceEntity.AddPosition(source.transform.position);
                deliverySourceEntity.AddUid(uid);
                deliverySourceEntity.AddLevel(source.ShopParameters.ShopLevel);
                
                source.Link(deliverySourceEntity, _game);
                
                if(source.LaunchContractTimerOnGameStart)
                    _action.CreateEntity().AddStartNextContractTimer(uid);
            }
        }
    }
}