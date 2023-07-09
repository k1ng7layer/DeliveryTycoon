using System.Collections.Generic;
using Ecs.Views.Camera;
using Ecs.Views.Linkable.Impl;
using Ecs.Views.Shops;
using UnityEngine;

namespace Game.Services.GameLevelProvider.Views
{
    public class GameLevelView : MonoBehaviour
    {
        [SerializeField] private VirtualCameraView virtualCameraView;
        [SerializeField] private PhysicalCameraView physicalCameraView;
        [SerializeField] private CameraFollowView cameraFollowView;
        [SerializeField] private List<ShopView> deliveryShops;


        public VirtualCameraView VirtualCameraView => virtualCameraView;
        public PhysicalCameraView PhysicalCameraView => physicalCameraView;
        public CameraFollowView CameraFollowView => cameraFollowView;
        public List<ShopView> DeliveryShops => deliveryShops;
    }
}