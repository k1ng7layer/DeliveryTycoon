using JCMG.EntitasRedux;

namespace Ecs.Delivery.Components
{
    [Delivery]
    [Event(EventTarget.Self)]
    public class DurationComponent : IComponent
    {
        public float Value;
    }
}