using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Delivery.Components
{
    [Order]
    public class SourcePositionComponent : IComponent
    {
        public Vector3 Value;
    }
}