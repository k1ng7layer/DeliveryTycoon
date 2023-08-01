using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Order.Components
{
    [Order]
    public class DestinationComponent : IComponent
    {
        public Uid DestinationUid;
    }
}