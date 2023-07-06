using Ecs.Views;
using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Common
{
    [Game]
    [Event(EventTarget.Self, EventType.Removed)]
    public class LinkComponent : IComponent
    {
        public ILinkableView View;
    }
}