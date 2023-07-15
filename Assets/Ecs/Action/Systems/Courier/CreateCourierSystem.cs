using System.Collections.Generic;
using JCMG.EntitasRedux;

namespace Ecs.Action.Systems.Courier
{
    public class CreateCourierSystem : ReactiveSystem<ActionEntity>
    {
        private readonly GameContext _game;

        public CreateCourierSystem(ActionContext action, 
            GameContext game) : base(action)
        {
            _game = game;
        }

        protected override ICollector<ActionEntity> GetTrigger(IContext<ActionEntity> context) =>
            context.CreateCollector(ActionMatcher.CreateCourier);

        protected override bool Filter(ActionEntity entity) => entity.HasCreateCourier && !entity.IsDestroyed;

        protected override void Execute(List<ActionEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDestroyed = true;

                var courierTypeToCreate = entity.CreateCourier.Type;

                var deliveryOffice = _game.DeliveryOfficeEntity;
                var courierSpawnPoint = deliveryOffice.CourierSpawnPoint.Value;
                
                var courierEntity = _game.CreateEntity();
                
                courierEntity.AddCourier(courierTypeToCreate);
                courierEntity.AddPosition(courierSpawnPoint);
                courierEntity.AddPrefab("Courier");
            }
        }
    }
}