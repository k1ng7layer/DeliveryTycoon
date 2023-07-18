using Db.Ai;
using Ecs.Views.Linkable.Impl;
using Game.AI.Data;
using JCMG.EntitasRedux;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Ecs.Views.Courier
{
    public class CourierView : ObjectView, 
        IRouteTargetAddedListener
    {
        [SerializeField] private EAiType aiType;
        [SerializeField] private NavMeshAgent navMeshAgent;

        [Inject] private DiContainer container;

        private GameEntity _courierEntity;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            _courierEntity = (GameEntity)entity;
            
            _courierEntity.AddAi(aiType);
            
            _courierEntity.AddRouteTargetAddedListener(this);
        }

        public void OnRouteTargetAdded(GameEntity entity, RouteTargetData value)
        {
           
        }
    }
}