using System;
using Game.Utils;

namespace Db.EmployeeSettings
{
    [Serializable]
    public class EmployeeSettings
    {
        public ECourierType CourierType;
        public float Cost;
    }
}