using Game.UI.DeliverySourceShop.Views;
using SimpleUi.Abstracts;
using SimpleUi.Signals;
using UniRx;
using Zenject;

namespace Game.UI.DeliverySourceShop.Controllers
{
    public class ShopWindowController : UiController<ShopWindowView>, IInitializable
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;
        private readonly SignalBus _signalBus;

        public ShopWindowController(ActionContext action, 
            GameContext game,
            SignalBus signalBus)
        {
            _action = action;
            _game = game;
            _signalBus = signalBus;
        }
        
        public void Initialize()
        {
            View.EngageContractButton.OnClickAsObservable().Subscribe(_ => MakeContract()).AddTo(View.EngageContractButton);
            View.CloseArea.OnClickAsObservable().Subscribe(_ => Close()).AddTo(View.CloseArea);
        }

        private void MakeContract()
        {
            var currentShopUid = _game.SelectedShop.ShopUid;
            
            _action.CreateEntity().AddMakeContract(currentShopUid);
            View.EngageContractButton.interactable = false;
        }

        public override void OnShow()
        {
            var currentShopUid = _game.SelectedShop.ShopUid;
            var currentShop = _game.GetEntityWithUid(currentShopUid);
            var currentShopName = currentShop.ShopName.Value;

            View.ShopName.text = currentShopName;

            if (currentShop.IsPartner)
                View.EngageContractButton.interactable = false;
        }

        private void Close()
        {
            _signalBus.BackWindow();
        }
    }
}