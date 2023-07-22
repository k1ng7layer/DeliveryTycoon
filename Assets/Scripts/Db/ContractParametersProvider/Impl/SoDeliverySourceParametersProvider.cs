using System;
using System.Collections.Generic;
using Game.Utils;
using UnityEngine;

namespace Db.ContractParametersProvider.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(SoContractParametersProviderProvider), fileName = nameof(SoContractParametersProviderProvider))]
    public class SoContractParametersProviderProvider : ScriptableObject, 
        IContractParametersProvider
    {
        [KeyValue(nameof(ContractParameters.ShopLevel))]
        [SerializeField] private List<ContractParameters> deliverySourceParametersList;

        public ContractParameters Get(int deliverySourceLevel)
        {
            foreach (var deliveryParameter in deliverySourceParametersList)
            {
                if (deliveryParameter.ShopLevel == deliverySourceLevel)
                    return deliveryParameter;
            }
            
            throw new Exception($"[SoDeliverySourceParametersProvider] " +
                                $"Can't find DeliverySourceParameters for level: {deliverySourceLevel}");
        }
    }
}