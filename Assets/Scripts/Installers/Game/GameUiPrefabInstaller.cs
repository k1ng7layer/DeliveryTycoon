using Game.UI.BuyCourierButton.Controllers;
using Game.UI.BuyCourierButton.Views;
using Game.UI.CouriersView.Controllers;
using Game.UI.CouriersView.Views;
using Game.UI.DeliverySourceShop.Controllers;
using Game.UI.DeliverySourceShop.Views;
using Game.UI.MainMenu.Controllers;
using Game.UI.MainMenu.Views;
using Game.UI.OrderView.Views;
using Game.UI.Wallet.Controllers;
using Game.UI.Wallet.Views;
using SimpleUi;
using UnityEngine;
using Zenject;

namespace Installers.Game
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameUiPrefabInstaller), fileName = nameof(GameUiPrefabInstaller))]
    public class GameUiPrefabInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [Space] [SerializeField] private MainMenuView mainMenuView;
        [SerializeField] private ShopWindowView shopWindowView;
        [SerializeField] private OrderItemMenuView orderItemMenuView;
        [SerializeField] private BuyCourierButtonView buyCourierButtonView;
        [SerializeField] private WalletView walletView;
        [SerializeField] private CouriersView couriersView;

        public override void InstallBindings()
        {
            var canvasView = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasView.transform;
            
            Container.BindUiView<MainMenuController, MainMenuView>(mainMenuView, canvasTransform);
            Container.BindUiView<ContractWindowController, ShopWindowView>(shopWindowView, canvasTransform);
            //Container.BindUiView<OrderItemCollectionController, OrderItemMenuView>(orderItemMenuView, canvasTransform);
            
            Container.BindUiView<BuyCourierButtonController, BuyCourierButtonView>(buyCourierButtonView, canvasTransform);
            Container.BindUiView<WalletController, WalletView>(walletView, canvasTransform);
            Container.BindUiView<CouriersUiController, CouriersView>(couriersView, canvasTransform);
        }
    }
}