using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Input.Components
{
    [Input]
    public class InputVectorComponent : IComponent
    {
        public Vector3 Value;
    }
}