using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Courier
{
    [Game]
    [Delivery]
    public class CourierComponent : IComponent
    {
        public ECourierType Type;
    }
}