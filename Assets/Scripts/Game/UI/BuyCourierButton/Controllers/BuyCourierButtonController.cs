using Game.UI.BuyCourierButton.Views;
using SimpleUi.Abstracts;
using UniRx;
using Zenject;

namespace Game.UI.BuyCourierButton.Controllers
{
    public class BuyCourierButtonController : UiController<BuyCourierButtonView>, 
        IInitializable
    {
        private readonly ActionContext _action;

        public BuyCourierButtonController(ActionContext action)
        {
            _action = action;
        }
        
        public void Initialize()
        {
            View.buyButton.OnClickAsObservable().Subscribe(_ => BuyCourier());
        }

        private void BuyCourier()
        {
            _action.CreateEntity().IsBuyCourier = true;
        }
    }
}