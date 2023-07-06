using Project.Managers;
using Zenject;

namespace Installers.Project
{
    public class SplashInstaller : MonoInstaller
    { 
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SplashManager>().AsSingle().NonLazy();
        }
    }
}