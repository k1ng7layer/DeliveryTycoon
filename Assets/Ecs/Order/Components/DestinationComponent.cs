using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Order.Components
{
    [Order]
    public class DestinationComponent : IComponent
    {
        public Vector3 Value;
    }
}