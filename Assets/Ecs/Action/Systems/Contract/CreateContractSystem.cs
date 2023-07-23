using System.Collections.Generic;
using Db.ContractParametersProvider;
using Game.Services.ContractStatusService;
using Game.UI.DeliverySourceShop.Controllers;
using Game.Utils.Contract;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.Contract
{
    public class CreateContractSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;
        private readonly OrderContext _order;
        private readonly IContractParametersProvider _contractParametersProvider;
        private readonly IContractStatusService _contractStatusService;
        private readonly IContractWindowController _contractWindowController;

        public CreateContractSystem(ActionContext action, 
            GameContext game,
            OrderContext order,
            IContractParametersProvider contractParametersProvider,
            IContractStatusService contractStatusService,
            IContractWindowController contractWindowController) : base(action)
        {
            _game = game;
            _order = order;
            _contractParametersProvider = contractParametersProvider;
            _contractStatusService = contractStatusService;
            _contractWindowController = contractWindowController;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.CreateContract);

        protected override bool Filter(ActionEntity entity) => entity.HasCreateContract && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var sourceUid = entity.CreateContract.Source;

                var sourceEntity = _game.GetEntityWithUid(sourceUid);
                var sourceLevel = sourceEntity.Level.Value;
                var contractUid = UidGenerator.UidGenerator.Next();
                var contractParameters = _contractParametersProvider.Get(sourceLevel);
                
                sourceEntity.AddContractProvider(contractUid);
                
                var contractEntity = _order.CreateEntity();
                
                contractEntity.AddContract(new ContractData(contractParameters.CouriersAmount, 
                    contractParameters.OrdersAmount, contractParameters.CourierType));
                    
                contractEntity.AddUid(contractUid);
                contractEntity.AddReward(contractParameters.Reward);
                contractEntity.AddAvailableOrders(contractParameters.OrdersAmount);

                var contractStatus = _contractStatusService.GetStatus(contractEntity);
                _contractWindowController.ChangeContractStatus(contractStatus, contractEntity);
            }
        }
        
    }
}