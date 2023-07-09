using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Action.Components
{
    [Action]
    public class CreateDeliveryComponent : IComponent
    {
        public Uid DeliverySourceUid;
    }
}