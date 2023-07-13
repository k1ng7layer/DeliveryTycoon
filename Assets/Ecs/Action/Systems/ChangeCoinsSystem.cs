using System.Collections.Generic;
using Game.UI.Wallet.Controllers;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems
{
    public class ChangeCoinsSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly ICoinWalletUiController _coinWalletUiController;

        public ChangeCoinsSystem(ActionContext action, 
            GameContext game,
            ICoinWalletUiController coinWalletUiController) : base(action)
        {
            _game = game;
            _coinWalletUiController = coinWalletUiController;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.ChangeCoins);

        protected override bool Filter(ActionEntity entity) => entity.HasChangeCoins && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var diff = entity.ChangeCoins.Value;

                var wallet = _game.Wallet.Value;

                var newValue = wallet - diff;
                
                _game.ReplaceWallet(newValue);
                
                _coinWalletUiController.SetCoins(newValue);
            }
        }
    }
}