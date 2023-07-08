using Game.Services.Input;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Initialize
{
    public class InitializeGameSystem : IInitializeSystem
    {
        private readonly IGameInputService _gameInputService;

        public InitializeGameSystem(GameContext game, 
            IGameInputService gameInputService)
        {
            _gameInputService = gameInputService;
        }
        
        public void Initialize()
        {
            _gameInputService.Enable();
        }
    }
}