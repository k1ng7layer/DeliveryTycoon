using Ecs.Views.Linkable.Impl;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Views.Customers
{
    public class CustomerSpotView : ObjectView
    {
        [SerializeField] private Transform receptionSpotTransform;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            var customerEntity = (GameEntity)entity;
            
            customerEntity.AddReceptionPoint(receptionSpotTransform.position);
        }
    }
}