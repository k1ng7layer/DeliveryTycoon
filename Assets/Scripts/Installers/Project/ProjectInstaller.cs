using Core.LoadingProcessor.Impls;
using Core.SceneLoading;
using Game.Services.SceneLoading.Impls;
using Game.UI.LoadingWindow.Windows;
using Zenject;

namespace Installers.Project
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoadingManager>().To<SceneLoadingManager>().AsSingle();
            Container.BindInterfacesTo<LoadingProcessor>().AsSingle();
       
            SignalBusInstaller.Install(Container);

            InstallProjectWindows();
        }

        private void InstallProjectWindows()
        {
            Container.BindInterfacesAndSelfTo<FirstStartLoadingWindow>().AsSingle();
        }
    }
}