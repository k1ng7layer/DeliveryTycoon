using Ecs.Game.Systems;
using Ecs.Game.Systems.Initialize;
using Game.UI.MainMenu.Windows;
using Zenject;

namespace Installers.Game.MainMenu
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuInitializeSystem>().AsSingle();
            Container.DeclareSignal<MainMenuWindow>();
            Container.BindInterfacesAndSelfTo<MainMenuWindow>().AsSingle();
        }
    }
}