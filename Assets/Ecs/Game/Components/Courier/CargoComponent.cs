using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Courier
{
    [Game]
    [Event(EventTarget.Self)]
    [Event(EventTarget.Self, EventType.Removed)]
    public class CargoComponent : IComponent
    {
        
    }
}