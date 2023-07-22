using Db.Ai;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Ai
{
    [Game]
    public class AiComponent : IComponent
    {
        public EAiType Value;
    }
}