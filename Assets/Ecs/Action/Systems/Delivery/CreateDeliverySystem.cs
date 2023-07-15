using System.Collections.Generic;
using Db.OrderParameters;
using Ecs.Delivery.Extensions;
using Game.Services.DeliveryDestinationService;
using Game.Services.DeliveryPriceService;
using Game.Services.DeliveryTargetTimeService;
using Game.Services.OrderStatusService;
using Game.Services.RandomProvider;
using Game.UI.OrderView.Controllers;
using Game.Utils;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.Delivery
{
    public class CreateDeliverySystem : ReactiveSystem<ActionEntity>
    {
        private readonly DeliveryContext _delivery;
        private readonly GameContext _game;
        private readonly IDeliveryPriceService _deliveryPriceService;
        private readonly IDeliveryTargetService _deliveryTargetService;
        private readonly IDeliveryTargetTimeService _deliveryTargetTimeService;
        private readonly IOrderPopupController _orderPopupController;
        private readonly IRandomProvider _randomProvider;
        private readonly IOrderParametersProvider _orderParametersProvider;
        private readonly IOrderStatusService _orderStatusService;

        public CreateDeliverySystem(ActionContext action, 
            DeliveryContext delivery, 
            GameContext game,
            IDeliveryPriceService deliveryPriceService,
            IDeliveryTargetService deliveryTargetService,
            IDeliveryTargetTimeService deliveryTargetTimeService,
            IOrderPopupController orderPopupController,
            IRandomProvider randomProvider,
            IOrderParametersProvider orderParametersProvider,
            IOrderStatusService orderStatusService) : base(action)
        {
            _delivery = delivery;
            _game = game;
            _deliveryPriceService = deliveryPriceService;
            _deliveryTargetService = deliveryTargetService;
            _deliveryTargetTimeService = deliveryTargetTimeService;
            _orderPopupController = orderPopupController;
            _randomProvider = randomProvider;
            _orderParametersProvider = orderParametersProvider;
            _orderStatusService = orderStatusService;
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
                deliveryEntity.AddItemsAmount(2); //TODO:
                var deliveryPrice = _deliveryPriceService.CalculateDeliveryPrice(deliveryEntity);

                var courierType = GetRandomCourierType(deliverySourceLevel);

                var requiredCourierAmount = _randomProvider.Range(1, 1);
                
                deliveryEntity.AddCourierAmount(requiredCourierAmount);
                deliveryEntity.AddCourier(courierType);
                deliveryEntity.AddPrice(deliveryPrice);


                var deliveryInitialStatus = _orderStatusService.GetStatus(deliveryEntity);
                
                deliveryEntity.AddDeliveryStatus(deliveryInitialStatus);
                
                _orderPopupController.OnOrderCreated(deliveryEntity);
            }
        }

        // private ECourierType GetRandomCourierType()
        // {
        //     var values = (ECourierType[])Enum.GetValues(typeof(ECourierType));
        //
        //     var random = _randomProvider.Range(0, values.Length - 1);
        //
        //     return values[random];
        // }
        
        private ECourierType GetRandomCourierType(int sourceLevel)
        {
            var orderParameters = _orderParametersProvider.Get(sourceLevel);

            var courierType = orderParameters.RequiredCourierType;

            return courierType;
        }
    }
}