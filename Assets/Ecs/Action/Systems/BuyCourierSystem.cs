using System.Collections.Generic;
using Db.EmployeeSettings;
using Game.UI.CouriersView.Controllers;
using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems
{
    public class BuyCourierSystem : ReactiveSystem<ActionEntity>
    {
        private readonly ActionContext _action;
        private readonly GameContext _game;
        private readonly IEmployeeSettingsProvider _employeeSettingsProvider;
        private readonly ICouriersUiController _couriersUiController;

        public BuyCourierSystem(ActionContext action, 
            GameContext game,
            IEmployeeSettingsProvider employeeSettingsProvider,
            ICouriersUiController couriersUiController) : base(action)
        {
            _action = action;
            _game = game;
            _employeeSettingsProvider = employeeSettingsProvider;
            _couriersUiController = couriersUiController;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.BuyCourier);

        protected override bool Filter(ActionEntity entity) => entity.IsBuyCourier && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var wallet = _game.Wallet.Value;
                
                var courierSettings = _employeeSettingsProvider.Get(ECourierType.Foot);
                
                if(wallet < courierSettings.Cost)
                    continue;

                var totalCouriers = _game.TotalEmployees.Value;
                
                _game.ReplaceTotalEmployees(++totalCouriers);
                
                _couriersUiController.SetEmployees(totalCouriers);

                _action.CreateEntity().AddChangeCoins(courierSettings.Cost);
            }
        }
    }
}