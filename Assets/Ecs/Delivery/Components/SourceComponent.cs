using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Delivery.Components
{
    [Delivery]
    public class SourceComponent : IComponent
    {
        public Uid DeliverySourceUid;
    }
}