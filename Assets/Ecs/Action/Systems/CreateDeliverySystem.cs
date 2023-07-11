using System.Collections.Generic;
using Db.DeliveryParametersProvider;
using Ecs.Delivery.Extensions;
using Game.Services.DeliveryDestinationService;
using Game.Services.DeliveryPriceService;
using Game.Services.DeliveryTargetTimeService;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems
{
    public class CreateDeliverySystem : ReactiveSystem<ActionEntity>
    {
        private readonly DeliveryContext _delivery;
        private readonly GameContext _game;
        private readonly IDeliveryPriceService _deliveryPriceService;
        private readonly IDeliveryTargetService _deliveryTargetService;
        private readonly IDeliveryTargetTimeService _deliveryTargetTimeService;
        private readonly IDeliveryParametersProvider _deliveryParametersProvider;

        public CreateDeliverySystem(ActionContext action, 
            DeliveryContext delivery, 
            GameContext game,
            IDeliveryPriceService deliveryPriceService,
            IDeliveryTargetService deliveryTargetService,
            IDeliveryTargetTimeService deliveryTargetTimeService,
            IDeliveryParametersProvider deliveryParametersProvider) : base(action)
        {
            _delivery = delivery;
            _game = game;
            _deliveryPriceService = deliveryPriceService;
            _deliveryTargetService = deliveryTargetService;
            _deliveryTargetTimeService = deliveryTargetTimeService;
            _deliveryParametersProvider = deliveryParametersProvider;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.CreateDelivery);

        protected override bool Filter(ActionEntity entity) => entity.HasCreateDelivery && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var sourceUid = entity.CreateDelivery.DeliverySourceUid;
                
                var deliverySourceEntity = _game.GetEntityWithUid(sourceUid);
                var deliverySourcePosition = deliverySourceEntity.Position.Value;
               
                var deliverySourceLevel = deliverySourceEntity.Level.Value;
                
                var deliveryTargetPosition = _deliveryTargetService.GetDeliveryTarget();

                var deliveryTargetTime = _deliveryTargetTimeService.GetDeliveryTargetTime(deliverySourceLevel);
                
                var deliveryEntity = _delivery.CreateDelivery(deliveryTargetTime, deliverySourcePosition, deliveryTargetPosition);
                deliveryEntity.AddSource(sourceUid);
                deliveryEntity.AddAmount(2); //TODO:
                var deliveryPrice = _deliveryPriceService.CalculateDeliveryPrice(deliveryEntity);
                
                deliveryEntity.AddPrice(deliveryPrice);
              
            }
        }
    }
}