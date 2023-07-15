using System;
using Game.Utils;
using UnityEngine;

namespace Db.EmployeeSettings.Impl
{
    [CreateAssetMenu(menuName = "Settings/" + nameof(SoEmployeeSettingsProvider), fileName = nameof(SoEmployeeSettingsProvider))]
    public class SoEmployeeSettingsProvider : ScriptableObject, 
        IEmployeeSettingsProvider
    {
        [SerializeField] 
        [KeyValue(nameof(EmployeeSettings.CourierType))] private EmployeeSettings[] employeeSettings;

        public EmployeeSettings Get(ECourierType courierType)
        {
            foreach (var setting in employeeSettings)
            {
                if (setting.CourierType == courierType)
                    return setting;
            }

            throw new Exception($"[{nameof(SoEmployeeSettingsProvider)}] Can't find EmployeeSettings with " +
                                $"courierType: {courierType}");
        }
    }
}