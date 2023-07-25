using Game.UI.BuyCourierButton.Controllers;
using Game.UI.CouriersView.Controllers;
using Game.UI.TouchInput.Controllers;
using Game.UI.Wallet.Controllers;
using SimpleUi;

namespace Game.UI.GameHud.Windows
{
    public class GameHudWindow : WindowBase
    {
        public override string Name => "GameHud";
        
        protected override void AddControllers()
        {
            //AddController<OrderItemCollectionController>();
            AddController<BuyCourierButtonController>();
            AddController<WalletController>();
            AddController<CouriersUiController>();
            AddController<TouchInputController>();
        }
    }
}