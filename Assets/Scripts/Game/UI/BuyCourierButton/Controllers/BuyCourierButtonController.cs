using Core.Systems;
using Db.EmployeeSettings;
using Game.UI.BuyCourierButton.Views;
using Game.Utils;
using SimpleUi.Abstracts;
using UniRx;
using UnityEngine;

namespace Game.UI.BuyCourierButton.Controllers
{
    public class BuyCourierButtonController : UiController<BuyCourierButtonView>,
        IWalletAddedListener,
        IUiInitializable
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;
        private readonly IEmployeeSettingsProvider _employeeSettingsProvider;

        public BuyCourierButtonController(ActionContext action, 
            GameContext game, 
            IEmployeeSettingsProvider employeeSettingsProvider)
        {
            _action = action;
            _game = game;
            _employeeSettingsProvider = employeeSettingsProvider;
        }
        
        public void Initialize()
        {
            _game.WalletEntity.AddWalletAddedListener(this);
            View.buyButton.OnClickAsObservable().Subscribe(_ => BuyCourier());
        }

        private void BuyCourier()
        {
            _action.CreateEntity().AddBuyCourier(ECourierType.Foot);
        }

        public void OnWalletAdded(GameEntity entity, float value)
        {
            var employeeSettings = _employeeSettingsProvider.Get(ECourierType.Foot);
            
            var canBuy = value >= employeeSettings.Cost;
            
            View.buyButton.image.color = canBuy ? Color.green : Color.red;
            View.buyButton.interactable = canBuy;
        }
    }
}