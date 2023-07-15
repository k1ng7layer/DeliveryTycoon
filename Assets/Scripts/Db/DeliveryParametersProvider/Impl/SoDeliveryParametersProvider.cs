using System;
using System.Collections.Generic;
using Game.Utils;
using UnityEngine;
using RangeInt = Game.Utils.RangeInt;

namespace Db.DeliveryParametersProvider.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(SoDeliveryParametersProvider), fileName = nameof(SoDeliveryParametersProvider))]
    public class SoDeliveryParametersProvider : ScriptableObject, 
        IDeliveryParametersProvider
    {
        [KeyValue(nameof(DeliveryItemsParameters.ItemsAmount))]
        [SerializeField] private List<DeliveryItemsParameters> deliveryItemsAmountParameters;
        
        [SerializeField] private RangeInt itemsPerDeliveryRange;
        [SerializeField] private float minDeliveryPrice;
        [SerializeField] private float distanceRateMultiplier;

        public float DistanceRateMultiplier => distanceRateMultiplier;

        public RangeInt ItemsPerDeliveryRange => itemsPerDeliveryRange;

        public float MinDeliveryPrice => minDeliveryPrice;

        public float GetItemAmountPriceMultiplier(int itemAmount)
        {
            foreach (var deliveryItems in deliveryItemsAmountParameters)
            {
                if (deliveryItems.ItemsAmount == itemAmount)
                    return deliveryItems.PriceMultiplier;
            }
            
            throw new Exception($"[SoDeliveryParametersProvider] " +
                                $"Can't find PriceMultiplier for itemAmount: {itemAmount}");
        }
    }
}