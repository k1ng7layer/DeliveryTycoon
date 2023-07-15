using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Delivery.Components
{
    [Delivery]
    public class SourcePositionComponent : IComponent
    {
        public Vector3 Value;
    }
}