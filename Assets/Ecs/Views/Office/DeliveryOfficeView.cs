using Ecs.Views.Linkable.Impl;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Office
{
    public class DeliveryOfficeView : ObjectView
    {
        [SerializeField] private Transform courierSpawnTransform;
        [SerializeField] private Transform receptionSpotTransform;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            var officeEntity = (GameEntity)entity;
            
            officeEntity.AddCourierSpawnPoint(courierSpawnTransform.position);
            officeEntity.AddReceptionPoint(receptionSpotTransform.position);
        }
    }
}