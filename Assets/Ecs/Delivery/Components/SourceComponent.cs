using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Delivery.Components
{
    [Order]
    public class SourceComponent : IComponent
    {
        public Uid DeliverySourceUid;
    }
}