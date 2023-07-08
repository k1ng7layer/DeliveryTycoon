using Db.Camera;
using Db.Camera.Impl;
using UnityEngine;
using Zenject;

namespace Installers.Game.Settings
{
    [CreateAssetMenu(menuName = "Installers/" + nameof(GameSettingsInstaller), fileName = nameof(GameSettingsInstaller))]
    public class GameSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private CameraParameters cameraParameters;
        
        public override void InstallBindings()
        {
            Container.Bind<ICameraParameters>().To<CameraParameters>().FromInstance(cameraParameters);
        }
    }
}