using System.Collections.Generic;
using Ecs.UidGenerator;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Order
{
    [Order]
    public class AttachedCustomersComponent : IComponent
    {
        public List<Uid> Value;
    }
}