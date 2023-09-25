using Ecs.Action.Systems;
using Ecs.Action.Systems.Coins;
using Ecs.Action.Systems.Contract;
using Ecs.Action.Systems.Courier;
using Ecs.Action.Systems.CustomersShop;
using Ecs.Action.Systems.Order;
using Ecs.Game.Systems.Ai;
using Ecs.Game.Systems.Camera;
using Ecs.Game.Systems.Common;
using Ecs.Game.Systems.Initialize;
using Ecs.Input.Systems;
using Ecs.Order.Systems.Contract;
using Ecs.Order.Systems.Order;
using Game.Services.Camera.Impl;
using Game.Services.ContractStatusService.Impl;
using Game.Services.Customers.Impl;
using Game.Services.DeliveryDestinationService.Impl;
using Game.Services.DeliveryPriceService.Impl;
using Game.Services.DeliveryTargetTimeService.Impl;
using Game.Services.EmployeeRepository.Impl;
using Game.Services.GameLevelProvider.Impl;
using Game.Services.GameLevelProvider.Views;
using Game.Services.Input.Impl;
using Game.Services.InteractableRepository.Impl;
using Game.Services.OrderProvider.Impl;
using Game.Services.OrderStatusService.Impl;
using Game.Services.PointerRaycastService;
using Game.Services.PointerRaycastService.Impl;
using Game.Services.RandomProvider.Impl;
using Game.Services.Spawn.Impl;
using Game.Services.TimeProvider.Impl;
using Game.UI.DeliverySourceShop.Windows;
using Game.UI.GameHud.Windows;
using UnityEngine;
using Zenject;

namespace Installers.Game.City
{
    public class CityInstaller : MonoInstaller
    {
        [SerializeField] private GameLevelView gameLevelView;
        
        public override void InstallBindings()
        {
            BindServices();
            BindSystems();
            StartGameSystems();
            BindWindows();
            BindGameObjectRepositories();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<CameraService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UnityInputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnityTimeProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<SystemRandomProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameLevelProvider>().AsSingle().WithArguments(gameLevelView);
            Container.BindInterfacesAndSelfTo<RandomDeliveryTargetTimeService>().AsSingle();
            Container.BindInterfacesAndSelfTo<DefaultDeliveryPriceService>().AsSingle();
            Container.BindInterfacesAndSelfTo<DeliveryRandomTargetService>().AsSingle();
            Container.BindInterfacesAndSelfTo<OrderStatusService>().AsSingle();
            Container.BindInterfacesAndSelfTo<DiSpawnService>().AsSingle();
            Container.BindInterfacesAndSelfTo<ContractStatusService>().AsSingle();
            Container.BindInterfacesAndSelfTo<CourierRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<CustomersProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<OrderProvider>().AsSingle();
            Container.Bind<IRaycastProvider>().To<RaycastProvider>().AsSingle();
        }

        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<InitializeGameSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitializeCustomersSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitializeInputSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitializeCameraSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitializeDeliverySourcesSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitializeDeliveryOfficeSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<AiInitializeSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<EmitInputSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraMovementSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<NextContractTimerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreateContractSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreateOrderSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<MakeContractSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<SelectShopSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<StartNextContractTimerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<BuyCourierSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangeCoinsSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CreateCourierSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CheckOrderStatusSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InstantiateSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<BehaviourTreeUpdateSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CompleteOrderSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CompleteContractSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ChangeCouriersInContractSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<ReduceContractCouriersSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<TouchInputSystem>().AsSingle();
        }

        private void BindWindows()
        {
            Container.BindInterfacesAndSelfTo<ShopViewWindow>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameHudWindow>().AsSingle();
        }

        private void StartGameSystems()
        {
            Container.BindInterfacesAndSelfTo<StartGameSystem>().AsSingle();
        }

        private void BindGameObjectRepositories()
        {
            Container.BindInterfacesAndSelfTo<InteractableObjectRepository>().FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}