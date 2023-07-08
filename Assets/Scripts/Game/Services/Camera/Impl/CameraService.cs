using System.Collections.Generic;
using Cinemachine;
using Core.Systems;
using UnityEngine;

namespace Game.Services.Camera.Impl
{
    public class CameraService : ICameraService, 
        ILateSystem
    {
        private IReadOnlyDictionary<ECameraType, CinemachineVirtualCamera> _camerasMap =
            new Dictionary<ECameraType, CinemachineVirtualCamera>();
        private CinemachineBrain _cinemachineBrain;
        private CinemachineFreeLook _cinemachineFreeLook;
        private Transform _cameraFollowTarget;
        private Transform _cameraLookAt;

        public UnityEngine.Camera PhysicalCamera { get; set; }
        public CinemachineVirtualCamera ActiveCamera { get; private set; }
        
        
        public void SetActiveCamera(ECameraType cameraType)
        {
            Debug.Log($"CameraService SetActiveCamera {cameraType}");
            if(ActiveCamera != null)
                ActiveCamera.gameObject.SetActive(false);
            
            if (_camerasMap.ContainsKey(cameraType))
            {
                var activeCamera = _camerasMap[cameraType];
                activeCamera.gameObject.SetActive(true);
                ActiveCamera = activeCamera;
            }
        }

        public void SetCMBrain(CinemachineBrain brain)
        {
            _cinemachineBrain = brain;
        }

        public void AttachVirtualCameras(IReadOnlyDictionary<ECameraType, CinemachineVirtualCamera> cameras)
        {
            Debug.Log($"CameraService AttachVirtualCameras");
            _camerasMap = cameras;
        }

        public void AddFreeLookCamera(CinemachineFreeLook cinemachineFreeLook)
        {
            _cinemachineFreeLook = cinemachineFreeLook;
        }

        public void SetCameraTarget(Transform transform)
        {
            Debug.Log($"CameraService SetCameraTarget {transform}");
            _cameraFollowTarget = transform;
            
            if (ActiveCamera != null)
            {
                ActiveCamera.Follow = transform;
            }
        }

        public void SetCameraLookAt(Transform transform)
        {
            Debug.Log($"CameraService SetCameraLookAt {transform}");
            _cameraLookAt = transform;

            if (ActiveCamera != null)
            {
                ActiveCamera.LookAt = transform;
            }
        }

        public void SetUpdateMethod(CinemachineBrain.UpdateMethod updateMethod)
        {
            _cinemachineBrain.m_UpdateMethod = updateMethod;
        }

        public void Late()
        {
            // if(_cinemachineBrain != null)
            //     _cinemachineBrain.ManualUpdate();
        }
    }
}