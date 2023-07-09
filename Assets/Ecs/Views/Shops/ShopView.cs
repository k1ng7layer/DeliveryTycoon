using Ecs.Views.Linkable.Impl;
using UnityEngine;

namespace Ecs.Views.Shops
{
    public class ShopView : ObjectView
    {
        [SerializeField] private int deliverySourceLevel;

        public int DeliverySourceLevel => deliverySourceLevel;
    }
}