using Game.AI.Data;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Ai
{
    [Game]
    [Event(EventTarget.Self)]
    public class RouteTargetComponent : IComponent
    {
        public RouteTargetData Value;
    }
}