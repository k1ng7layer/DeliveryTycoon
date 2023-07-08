using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Components.Common
{
    [Game]
    [Event(EventTarget.Self)]
    public class RotationComponent : IComponent
    {
        public Quaternion Value;
    }
}