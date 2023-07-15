using System;
using UnityEngine;

namespace Db.OrderParameters.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(SoOrderParametersProvider), fileName = nameof(SoOrderParametersProvider))]
    public class SoOrderParametersProvider : ScriptableObject, 
        IOrderParametersProvider
    {
        [SerializeField] private OrderParameters[] parametersArray;
        
        public OrderParameters Get(int level)
        {
            for (var i = 0; i < parametersArray.Length; i++)
            {
                var parameters = parametersArray[i];
                if (parameters.Level == level)
                    return parameters;
            }

            throw new Exception($"[{nameof(SoOrderParametersProvider)}] Can't find order parameter for order level: {level}");
        }
    }
}