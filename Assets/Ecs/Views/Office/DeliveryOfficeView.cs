using Ecs.Views.Linkable.Impl;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Office
{
    public class DeliveryOfficeView : ObjectView
    {
        [SerializeField] private Transform courierSpawnTransform;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            var officeEntity = (GameEntity)entity;
            
            officeEntity.AddCourierSpawnPoint(courierSpawnTransform.position);
        }
    }
}