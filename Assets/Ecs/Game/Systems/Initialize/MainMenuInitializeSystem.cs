using Game.UI.MainMenu.Windows;
using SimpleUi.Signals;
using Zenject;

namespace Ecs.Game.Systems.Initialize
{
    public class MainMenuInitializeSystem : IInitializable
    {
        private readonly SignalBus _signalBus;

        public MainMenuInitializeSystem(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            _signalBus.OpenWindow<MainMenuWindow>();
        }
    }
}