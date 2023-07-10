using Game.UI.DeliverySourceShop.Views;
using SimpleUi.Abstracts;
using UniRx;
using Zenject;

namespace Game.UI.DeliverySourceShop.Controllers
{
    public class ShopWindowController : UiController<ShopWindowView>, IInitializable
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;

        public ShopWindowController(ActionContext action, 
            GameContext game)
        {
            _action = action;
            _game = game;
        }
        
        public void Initialize()
        {
            View.EngageContractButton.OnClickAsObservable().Subscribe(_ => MakeContract());
        }

        private void MakeContract()
        {
            var currentShopUid = _game.SelectedShop.ShopUid;
            
            _action.CreateEntity().AddMakeContract(currentShopUid);
        }

        public override void OnShow()
        {
            var currentShopUid = _game.SelectedShop.ShopUid;
            var currentShop = _game.GetEntityWithUid(currentShopUid);
            var currentShopName = currentShop.ShopName.Value;

            View.ShopName.text = currentShopName;
        }
    }
}