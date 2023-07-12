using Game.UI.DeliverySourceShop.Controllers;
using Game.UI.DeliverySourceShop.Views;
using Game.UI.MainMenu.Controllers;
using Game.UI.MainMenu.Views;
using Game.UI.OrderView.Controllers;
using Game.UI.OrderView.Views;
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

        public override void InstallBindings()
        {
            var canvasView = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasView.transform;
            
            Container.BindUiView<MainMenuController, MainMenuView>(mainMenuView, canvasTransform);
            Container.BindUiView<ShopWindowController, ShopWindowView>(shopWindowView, canvasTransform);
            Container.BindUiView<OrderItemCollectionController, OrderItemMenuView>(orderItemMenuView, canvasTransform);
        }
    }
}