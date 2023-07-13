using JCMG.EntitasRedux;

namespace Ecs.Game.Components.Wallet
{
    [Game]
    [Unique]
    [Event(EventTarget.Self)]
    public class WalletComponent : IComponent
    {
        public float Value;
    }
}