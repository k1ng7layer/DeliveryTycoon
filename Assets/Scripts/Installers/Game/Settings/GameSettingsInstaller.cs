using Db.Ai;
using Db.Ai.Impl;
using Db.Camera;
using Db.Camera.Impl;
using Db.ContractParametersProvider;
using Db.ContractParametersProvider.Impl;
using Db.DeliveryParametersProvider;
using Db.DeliveryParametersProvider.Impl;
using Db.EmployeeSettings;
using Db.EmployeeSettings.Impl;
using Db.OrderParameters;
using Db.OrderParameters.Impl;
using Db.PrefabBase;
using Db.PrefabBase.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Game.Settings
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CameraParameters cameraParameters;
        [SerializeField] private SoContractParametersProvider contractParametersProvider;
        [SerializeField] private SoDeliveryParametersProvider deliveryParametersProvider;
        [SerializeField] private SoEmployeeSettingsProvider employeeSettingsProvider;
        [SerializeField] private SoOrderParametersProvider orderParametersProvider;
        [SerializeField] private SoPrefabsBase prefabsBase;
        [SerializeField] private AiBTreeSettingsBase aiBTreeSettingsBase;
        
        public override void InstallBindings()
        {
            Container.Bind<ICameraParameters>().To<CameraParameters>().FromInstance(cameraParameters);
            Container.Bind<IContractParametersProvider>().To<SoContractParametersProvider>().FromInstance(contractParametersProvider).AsSingle();
            Container.Bind<IDeliveryParametersProvider>().To<SoDeliveryParametersProvider>().FromInstance(deliveryParametersProvider).AsSingle();
            Container.Bind<IEmployeeSettingsProvider>().To<SoEmployeeSettingsProvider>().FromInstance(employeeSettingsProvider).AsSingle();
            Container.Bind<IOrderParametersProvider>().To<SoOrderParametersProvider>().FromInstance(orderParametersProvider).AsSingle();
            Container.Bind<IPrefabsBase>().To<SoPrefabsBase>().FromInstance(prefabsBase).AsSingle();
            Container.Bind<IAiBTreeSettingsBase>().To<AiBTreeSettingsBase>().FromInstance(aiBTreeSettingsBase).AsSingle();
        }
    }
}