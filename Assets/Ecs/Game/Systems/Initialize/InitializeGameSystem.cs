using Game.Services.Input;
using Game.UI.GameHud.Windows;
using JCMG.EntitasRedux;
using SimpleUi.Signals;
using Zenject;

namespace Ecs.Game.Systems.Initialize
{
    public class InitializeGameSystem : IInitializeSystem
    {
        private readonly IGameInputService _gameInputService;
        private readonly SignalBus _signalBus;

        public InitializeGameSystem(IGameInputService gameInputService,
            SignalBus signalBus)
        {
            _gameInputService = gameInputService;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _gameInputService.Enable();
            
            _signalBus.OpenWindow<GameHudWindow>();
        }
    }
}