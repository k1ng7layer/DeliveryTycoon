using JCMG.EntitasRedux;

namespace Ecs.Delivery.Components
{
    [Order]
    [Event(EventTarget.Self)]
    public class DurationComponent : IComponent
    {
        public float Value;
    }
}