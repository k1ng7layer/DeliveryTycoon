using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Order.Components
{
    [Order]
    public class SourceComponent : IComponent
    {
        public Uid DeliverySourceUid;
    }
}