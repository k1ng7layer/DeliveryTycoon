using System;
using System.Collections.Generic;
using Game.Utils;
using UnityEngine;
using RangeInt = Game.Utils.RangeInt;

namespace Db.DeliverySourceParametersProvider.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(SoDeliverySourceParametersProvider), fileName = nameof(SoDeliverySourceParametersProvider))]
    public class SoDeliverySourceParametersProvider : ScriptableObject, 
        IDeliverySourceParametersProvider
    {
        [KeyValue(nameof(DeliverySourceParameters.Level))]
        [SerializeField] private List<DeliverySourceParameters> deliverySourceParametersList;

        [SerializeField] private RangeInt itemsPerDeliveryRange;

        public RangeInt ItemsPerDeliveryRange => itemsPerDeliveryRange;

        public DeliverySourceParameters Get(int deliverySourceLevel)
        {
            foreach (var deliveryParameter in deliverySourceParametersList)
            {
                if (deliveryParameter.Level == deliverySourceLevel)
                    return deliveryParameter;
            }
            
            throw new Exception($"[SoDeliverySourceParametersProvider] " +
                                $"Can't find DeliverySourceParameters for level: {deliverySourceLevel}");
        }
    }
}