using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Courier
{
    [Game]
    [Order]
    public class CourierComponent : IComponent
    {
        public ECourierType Type;
    }
}