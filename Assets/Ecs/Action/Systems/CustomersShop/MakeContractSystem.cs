using System.Collections.Generic;
using Game.Utils;
using Game.Utils.Contract;
using Game.Utils.Order;
using JCMG.EntitasRedux;
using Zenject;

namespace Ecs.Action.Systems.CustomersShop
{
    public class MakeContractSystem : ReactiveSystem<ActionEntity>
    {
        private static readonly ListPool<GameEntity> GameEntityPool = ListPool<GameEntity>.Instance;
            
        private readonly ActionContext _action;
        private readonly GameContext _game;
        private readonly OrderContext _order;
        private readonly IGroup<GameEntity> _freeCouriersGroup;

        public MakeContractSystem(ActionContext action, 
            GameContext game,
            OrderContext order) : base(action)
        {
            _action = action;
            _game = game;
            _order = order;
            
            _freeCouriersGroup = game.GetGroup(GameMatcher.AllOf(GameMatcher.Courier)
                .NoneOf(GameMatcher.Busy, GameMatcher.Destroyed));
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.MakeContract);

        protected override bool Filter(ActionEntity entity) => entity.HasMakeContract && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var newContractData = entity.MakeContract.Value;

                var shopUid = newContractData.ShopUid;
                var contractor = _game.GetEntityWithUid(shopUid);

                contractor.IsPartner = true;

                var contractUid = contractor.ContractProvider.ContractUid;
                
                var contractEntity = _order.GetEntityWithUid(contractUid);
                var contractData = contractEntity.Contract.Value;
                
                contractEntity.ReplaceContractStatus(EContractStatus.InProgress);
                contractEntity.ReplaceAvailableOrders(contractData.OrdersAmount);
                
                var totalReward = contractEntity.Reward.Value;
                var rewardPerOrder = totalReward / contractData.OrdersAmount;
                
                for (var i = 0; i < contractData.OrdersAmount; i++)
                {
                    _action.CreateEntity().AddCreateOrder(new CreateOrderData(contractUid, rewardPerOrder));
                }
                
                _action.CreateEntity().AddAttachCouriersToContract(new ChangeCouriersData(contractUid, newContractData.CouriersAmount));
            }
        }

        private HashSet<GameEntity> GetFreeCouriers(int amount)
        {
            var result = new HashSet<GameEntity>();

            var couriers = GameEntityPool.Spawn();
            _freeCouriersGroup.GetEntities(couriers);

            foreach (var courier in couriers)
            {
                result.Add(courier);
                amount--;
                
                if(amount == 0)
                    break;
            }
            
            GameEntityPool.Despawn(couriers);

            return result;
        }
    }
}