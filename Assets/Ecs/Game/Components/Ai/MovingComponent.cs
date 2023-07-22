using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Ai
{
    [Game]
    [Event(EventTarget.Self)]
    [Event(EventTarget.Self, EventType.Removed)]
    public class MovingComponent : IComponent
    {
        
    }
}