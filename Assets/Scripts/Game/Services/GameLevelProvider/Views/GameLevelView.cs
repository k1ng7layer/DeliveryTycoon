using System.Collections.Generic;
using Ecs.Views.Camera;
using Ecs.Views.Customers;
using Ecs.Views.Linkable.Impl;
using Ecs.Views.Shops;
using Helpers.Autolink;
using UnityEngine;

namespace Game.Services.GameLevelProvider.Views
{
    public class GameLevelView : MonoBehaviour, IAutolinkObject
    {
        [SerializeField] private VirtualCameraView virtualCameraView;
        [SerializeField] private PhysicalCameraView physicalCameraView;
        [SerializeField] private CameraFollowView cameraFollowView;
        [SerializeField] private List<ShopView> deliveryShops;
        [SerializeField] private List<CustomerSpotView> customerSpotViews;
        
        public VirtualCameraView VirtualCameraView => virtualCameraView;
        public PhysicalCameraView PhysicalCameraView => physicalCameraView;
        public CameraFollowView CameraFollowView => cameraFollowView;
        public List<ShopView> DeliveryShops => deliveryShops;
        public List<CustomerSpotView> CustomerSpotViews => customerSpotViews;
        
        public void Autolink()
        {
            var shops = Object.FindObjectsOfType<ShopView>();
            
            deliveryShops.Clear();

            foreach (var shop in shops)
            {
                deliveryShops.Add(shop);
            }
        }
    }
}