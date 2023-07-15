using System;
using Game.Utils;

namespace Db.OrderParameters
{
    [Serializable]
    public struct OrderParameters
    {
        public int Level;
        public ECourierType RequiredCourierType;
    }
}