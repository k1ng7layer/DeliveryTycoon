using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Order.Components
{
    [Order]
    public class PerformerComponent : IComponent
    {
        [EntityIndex]
        public Uid PerformerUid;
    }
}