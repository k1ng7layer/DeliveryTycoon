using Game.Services.GameLevelProvider;
using Game.Services.Input;
using Game.UI.Wallet.Controllers;
using JCMG.EntitasRedux;

namespace Ecs.Game.Systems.Initialize
{
    public class InitializeGameSystem : IInitializeSystem
    {
        private const float StartCoins = 1000f;
        
        private readonly IGameInputService _gameInputService;
        private readonly GameContext _game;
        private readonly ActionContext _action;
        private readonly ICoinWalletUiController _coinWalletUiController;
        private readonly IGameLevelProvider _gameLevelProvider;

        public InitializeGameSystem(IGameInputService gameInputService,
            GameContext game,
            ActionContext action,
            ICoinWalletUiController coinWalletUiController,
            IGameLevelProvider gameLevelProvider)
        {
            _gameInputService = gameInputService;
            _game = game;
            _action = action;
            _coinWalletUiController = coinWalletUiController;
            _gameLevelProvider = gameLevelProvider;
        }
        
        public void Initialize()
        {
            _gameInputService.Enable();

            _game.ReplaceWallet(StartCoins);
            _game.ReplaceTotalEmployees(0);
            _game.ReplaceStandbyEmployees(0);
            
            _coinWalletUiController.SetCoins(StartCoins);

            _action.CreateEntity().IsStartGame = true;
        }
    }
}