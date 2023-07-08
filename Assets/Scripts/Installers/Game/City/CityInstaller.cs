using Ecs.Game.Systems.Camera;
using Ecs.Game.Systems.Initialize;
using Ecs.Input.Systems;
using Game.Services.Camera.Impl;
using Game.Services.GameLevelProvider.Impl;
using Game.Services.GameLevelProvider.Views;
using Game.Services.Input.Impl;
using Game.Services.TimeProvider.Impl;
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
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<CameraService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<UnityInputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnityTimeProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameLevelProvider>().AsSingle().WithArguments(gameLevelView);
        }

        private void BindSystems()
        {
            Container.BindInterfacesAndSelfTo<InitializeGameSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitializeInputSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<InitializeCameraSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<EmitInputSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraMovementSystem>().AsSingle();
        }
    }
}