using System.Collections.Generic;
using Db.ContractParametersProvider;
using Ecs.UidGenerator;
using Game.Services.ContractStatusService;
using Game.Services.Customers;
using Game.UI.DeliverySourceShop.Controllers;
using Game.Utils.Contract;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Action.Systems.Contract
{
    public class CreateContractSystem : ReactiveSystem<ActionEntity>
    {
        private static readonly ListPool<GameEntity> EntityPool = ListPool<GameEntity>.Instance;
        
        private readonly GameContext _game;
        private readonly OrderContext _order;
        private readonly IContractParametersProvider _contractParametersProvider;
        private readonly IContractStatusService _contractStatusService;
        private readonly IContractWindowController _contractWindowController;
        private readonly ICustomersProvider _customersProvider;

        public CreateContractSystem(ActionContext action, 
            GameContext game,
            OrderContext order,
            IContractParametersProvider contractParametersProvider,
            IContractStatusService contractStatusService,
            IContractWindowController contractWindowController,
            ICustomersProvider customersProvider) : base(action)
        {
            _game = game;
            _order = order;
            _contractParametersProvider = contractParametersProvider;
            _contractStatusService = contractStatusService;
            _contractWindowController = contractWindowController;
            _customersProvider = customersProvider;
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
                contractEntity.AddOwner(sourceUid);

                var contractStatus = _contractStatusService.GetStatus(contractEntity);
                contractEntity.ReplaceContractStatus(contractStatus);

                _contractWindowController.ChangeContractStatus(contractStatus, contractEntity);

                AttachCustomers(contractEntity, contractParameters);
            }
        }

        private void AttachCustomers(OrderEntity contractEntity, ContractParameters contractParameters)
        {
            var customers = EntityPool.Spawn();
                
            _customersProvider.GetRandomCustomers(customers, contractParameters.OrdersAmount);
            
            var customersUidList = new List<Uid>();
            
            foreach (var customer in customers)
            {
                var customerUid = customer.Uid.Value;
                customersUidList.Add(customerUid);
            }
            
            contractEntity.ReplaceAttachedCustomers(customersUidList);
            
            EntityPool.Despawn(customers);
        }
    }
}