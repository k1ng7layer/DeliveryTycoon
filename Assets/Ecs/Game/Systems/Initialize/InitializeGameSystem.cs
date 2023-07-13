using Game.Services.Input;
using Game.UI.GameHud.Windows;
using Game.UI.Wallet.Controllers;
using JCMG.EntitasRedux;
using SimpleUi.Signals;
using Zenject;

namespace Ecs.Game.Systems.Initialize
{
    public class InitializeGameSystem : IInitializeSystem
    {
        private const float StartCoins = 100f;
        
        private readonly IGameInputService _gameInputService;
        private readonly SignalBus _signalBus;
        private readonly GameContext _game;
        private readonly ICoinWalletUiController _coinWalletUiController;

        public InitializeGameSystem(IGameInputService gameInputService,
            SignalBus signalBus,
            GameContext game,
            ICoinWalletUiController coinWalletUiController)
        {
            _gameInputService = gameInputService;
            _signalBus = signalBus;
            _game = game;
            _coinWalletUiController = coinWalletUiController;
        }
        
        public void Initialize()
        {
            _gameInputService.Enable();

            _game.ReplaceWallet(StartCoins);
            _game.ReplaceTotalEmployees(0);
            
            _coinWalletUiController.SetCoins(StartCoins);
            
            _signalBus.OpenWindow<GameHudWindow>();
        }
    }
}