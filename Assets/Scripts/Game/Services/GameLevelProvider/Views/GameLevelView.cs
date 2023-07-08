using Cinemachine;
using Ecs.Views.Camera;
using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace Game.Services.GameLevelProvider.Views
{
    public class GameLevelView : MonoBehaviour
    {
        [SerializeField] private VirtualCameraView virtualCameraView;
        [SerializeField] private PhysicalCameraView physicalCameraView;
        [SerializeField] private CameraFollowView cameraFollowView;
        
        
        public VirtualCameraView VirtualCameraView => virtualCameraView;
        public PhysicalCameraView PhysicalCameraView => physicalCameraView;
        public CameraFollowView CameraFollowView => cameraFollowView;
    }
}