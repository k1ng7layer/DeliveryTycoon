using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Components.Common
{
    [Game]
    public class TransformComponent : IComponent
    {
        public Transform Value;
    }
}