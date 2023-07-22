using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Order.Components
{
    [Order]
    public class SourcePositionComponent : IComponent
    {
        public Vector3 Value;
    }
}