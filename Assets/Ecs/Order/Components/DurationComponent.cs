using JCMG.EntitasRedux;

namespace Ecs.Order.Components
{
    [Order]
    [Event(EventTarget.Self)]
    public class DurationComponent : IComponent
    {
        public float Value;
    }
}