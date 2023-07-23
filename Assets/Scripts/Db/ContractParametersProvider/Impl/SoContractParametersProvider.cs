using System;
using System.Collections.Generic;
using Game.Utils;
using UnityEngine;

namespace Db.ContractParametersProvider.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(SoContractParametersProvider), fileName = nameof(SoContractParametersProvider))]
    public class SoContractParametersProvider : ScriptableObject, 
        IContractParametersProvider
    {
        [KeyValue(nameof(ContractParameters.ShopLevel))]
        [SerializeField] private List<ContractParameters> contractParameters;

        public ContractParameters Get(int deliverySourceLevel)
        {
            foreach (var deliveryParameter in contractParameters)
            {
                if (deliveryParameter.ShopLevel == deliverySourceLevel)
                    return deliveryParameter;
            }
            
            throw new Exception($"[SoContractParametersProvider] " +
                                $"Can't find SoContractParametersProvider for level: {deliverySourceLevel}");
        }
    }
}