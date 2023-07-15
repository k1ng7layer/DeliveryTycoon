using System.Collections.Generic;
using Core.Systems;
using Game.UI.GameHud.Windows;
using JCMG.EntitasRedux;
using SimpleUi.Signals;
using Zenject;

namespace Ecs.Action.Systems
{
    public class StartGameSystem : ReactiveSystem<ActionEntity>
    {
        private readonly SignalBus _signalBus;
        private readonly List<IUiInitializable> _uiInitializables;

        public StartGameSystem(ActionContext action,
            SignalBus signalBus,
            List<IUiInitializable> uiInitializables) : base(action)
        {
            _signalBus = signalBus;
            _uiInitializables = uiInitializables;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.StartGame);

        protected override bool Filter(ActionEntity entity) => entity.IsStartGame && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                foreach (var uiInitializable in _uiInitializables)
                {
                    uiInitializable.Initialize();
                }
                
                _signalBus.OpenWindow<GameHudWindow>();
            }
        }
    }
}