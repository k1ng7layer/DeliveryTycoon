using Db.Camera;
using Db.Camera.Impl;
using Db.DeliveryParametersProvider;
using Db.DeliveryParametersProvider.Impl;
using Db.DeliverySourceParametersProvider;
using Db.DeliverySourceParametersProvider.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Game.Settings
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CameraParameters cameraParameters;
        [SerializeField] private SoDeliverySourceParametersProvider deliverySourceParametersProvider;
        [SerializeField] private SoDeliveryParametersProvider deliveryParametersProvider;
        
        public override void InstallBindings()
        {
            Container.Bind<ICameraParameters>().To<CameraParameters>().FromInstance(cameraParameters);
            Container.Bind<IDeliverySourceParametersProvider>().To<SoDeliverySourceParametersProvider>().FromInstance(deliverySourceParametersProvider).AsSingle();
            Container.Bind<IDeliveryParametersProvider>().To<SoDeliveryParametersProvider>().FromInstance(deliveryParametersProvider).AsSingle();
        }
    }
}