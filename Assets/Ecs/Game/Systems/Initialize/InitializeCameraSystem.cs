using Game.Services.Camera;
using Game.Services.GameLevelProvider;
using JCMG.EntitasRedux;
using UnityEngine;
using Zenject;

namespace Ecs.Game.Systems.Initialize
{
    public class InitializeCameraSystem : IInitializeSystem
    {
        private readonly GameContext _game;
        private readonly IGameLevelProvider _gameLevelProvider;
        private readonly ICameraService _cameraService;
        private readonly DiContainer _container;

        public InitializeCameraSystem(GameContext game, 
            IGameLevelProvider gameLevelProvider,
            ICameraService cameraService,
            DiContainer container)
        {
            _game = game;
            _gameLevelProvider = gameLevelProvider;
            _cameraService = cameraService;
            _container = container;
        }
        
        public void Initialize()
        {
            CreatePhysicalCamera();
            CreateVirtualCamera();
            CreateCameraFollow();
        }

        private void CreateCameraFollow()
        {
            var view = _gameLevelProvider.GameLevelView.CameraFollowView;
            var cameraFollowEntity = _game.CreateEntity();
            cameraFollowEntity.IsCameraGlobalTarget = true;
            cameraFollowEntity.AddPosition(view.transform.position);
            var viewRotationEuler = view.transform.rotation.eulerAngles;
            var viewRotation = new Vector3(viewRotationEuler.x, viewRotationEuler.y, viewRotationEuler.z);
            
            cameraFollowEntity.AddRotation(Quaternion.Euler(viewRotation));
            cameraFollowEntity.AddLink(view);
            view.Link(cameraFollowEntity, _game);
            
            _cameraService.SetCameraLookAt(view.transform);
            _cameraService.SetCameraTarget(view.transform);
        }

        private void CreatePhysicalCamera()
        {
            var view = _gameLevelProvider.GameLevelView.PhysicalCameraView;
            
            var cameraEntity = _game.CreateEntity();
            cameraEntity.IsPhysicalCamera = true;
            cameraEntity.AddLink(view);
            cameraEntity.AddPosition(view.transform.position);
            cameraEntity.AddRotation(view.transform.rotation);
            
            view.Link(cameraEntity, _game);

            _cameraService.PhysicalCamera = view.Camera;
            _cameraService.SetCMBrain(view.CinemachineBrain);
        }

        private void CreateVirtualCamera()
        {
            var view = _gameLevelProvider.GameLevelView.VirtualCameraView;
            
            _cameraService.AttachVirtualCameras(view.VirtualVirtualCameras);
            _cameraService.SetActiveCamera(ECameraType.FreeLook);
            
            var virtualCameraEntity = _game.CreateEntity();
            virtualCameraEntity.IsVirtualCamera = true;
            virtualCameraEntity.AddLink(view);
            virtualCameraEntity.AddPosition(view.transform.position);
            virtualCameraEntity.AddRotation(view.transform.rotation);
            
            view.Link(virtualCameraEntity, _game);
            
            _container.Inject(view);
        }
    }
}