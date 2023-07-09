using Core.Systems;
using Core.Systems.Impls;
using Ecs.Extensions;

namespace Installers.Game.Ecs
{
    public class EcsContextsInstaller : EcsContextsInstallerBase
    {
        protected override void BindContexts()
        {
            BindContext<GameContext>();
            BindContext<InputContext>();
            BindContext<ActionContext>();
            BindContext<DeliveryContext>();
            
            Container.BindDestroyedCleanup<GameContext, GameEntity>(GameMatcher.Destroyed);
            Container.BindDestroyedCleanup<InputContext, InputEntity>(InputMatcher.Destroyed);
            Container.BindDestroyedCleanup<ActionContext, ActionEntity>(ActionMatcher.Destroyed);
            Container.BindDestroyedCleanup<DeliveryContext, DeliveryEntity>(DeliveryMatcher.Destroyed);
            
            BindEventSystem<GameEventSystems>();
            BindEventSystem<DeliveryEventSystems>();
   

            var mainFeature = new GameFeature();

            Container.Bind<GameFeature>().FromInstance(mainFeature).WhenInjectedInto<Bootstrap>();
        }
    }
}