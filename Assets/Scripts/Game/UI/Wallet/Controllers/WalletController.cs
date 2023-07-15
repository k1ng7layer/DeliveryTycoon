using Game.UI.Wallet.Views;
using SimpleUi.Abstracts;

namespace Game.UI.Wallet.Controllers
{
    public class WalletController : UiController<WalletView>, 
        ICoinWalletUiController
    {
        public void SetCoins(float value)
        {
            View.coinsBalanceText.text = $"Coins: {value}";
        }
    }
}