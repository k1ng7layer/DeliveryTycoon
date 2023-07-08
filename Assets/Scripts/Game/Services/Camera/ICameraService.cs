using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace Game.Services.Camera
{
    public interface ICameraService
    {
        UnityEngine.Camera PhysicalCamera { get; set; }
        CinemachineVirtualCamera ActiveCamera { get; }
        void SetActiveCamera(ECameraType cameraType);
        void SetCMBrain(CinemachineBrain brain);
        void AttachVirtualCameras(IReadOnlyDictionary<ECameraType, CinemachineVirtualCamera> cameras);
        void AddFreeLookCamera(CinemachineFreeLook cinemachineFreeLook);
        void SetCameraTarget(Transform transform);
        void SetCameraLookAt(Transform transform);
        void SetUpdateMethod(CinemachineBrain.UpdateMethod updateMethod);
    }
}