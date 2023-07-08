using System;
using System.Collections.Generic;
using Cinemachine;
using Ecs.Views.Linkable.Impl;
using Game.Services.Camera;
using Game.Utils;
using JCMG.EntitasRedux;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Camera
{
    public class VirtualCameraView : ObjectView
    {
        [SerializeField] [KeyValue(nameof(VirtualCameraSettings.cameraType))] 
        private List<VirtualCameraSettings> cameraSettings;

        [Inject] private readonly ICameraService _cameraService;
        
        private Dictionary<ECameraType, CinemachineVirtualCamera> _virtualCameras;

        public Dictionary<ECameraType, CinemachineVirtualCamera> VirtualVirtualCameras
        {
            get
            {
                if (_virtualCameras == null)
                {
                    _virtualCameras = new Dictionary<ECameraType, CinemachineVirtualCamera>();
                    
                    foreach (var cameraSetting in cameraSettings)
                    {
                        _virtualCameras.Add(cameraSetting.cameraType, cameraSetting.virtualCamera);
                    }
                }

                return _virtualCameras;
            }
        }

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);
            
            var vcEntity = (GameEntity)entity;
        }

        public override void OnPositionAdded(GameEntity entity, Vector3 value)
        {
            _cameraService.ActiveCamera.transform.position = value;
        }

        public override void OnRotationAdded(GameEntity entity, Quaternion value)
        {
            _cameraService.ActiveCamera.transform.rotation = value;
        }
    }
    
    [Serializable]
    public struct VirtualCameraSettings
    {
        public ECameraType cameraType;
        public CinemachineVirtualCamera virtualCamera;
    }
}