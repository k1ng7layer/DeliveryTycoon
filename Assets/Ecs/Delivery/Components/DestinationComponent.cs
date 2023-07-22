using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Delivery.Components
{
    [Order]
    public class DestinationComponent : IComponent
    {
        public Vector3 Value;
    }
}