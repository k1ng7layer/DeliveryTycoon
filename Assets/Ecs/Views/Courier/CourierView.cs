using Db.Ai;
using Ecs.Views.Linkable.Impl;
using Game.AI.Data;
using Game.Utils.Courier;
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
        [SerializeField] private CourierParameters courierParameters;

        [Inject] private DiContainer container;

        private GameEntity _courierEntity;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            _courierEntity = (GameEntity)entity;
            
            _courierEntity.AddAi(aiType);
            _courierEntity.AddCourierParameters(courierParameters);
            
            _courierEntity.AddRouteTargetAddedListener(this);
        }

        public void OnRouteTargetAdded(GameEntity entity, RouteTargetData value)
        {
            navMeshAgent.SetDestination(value.Destination);
        }

        private void Update()
        {
            _courierEntity.Position.Value = navMeshAgent.transform.position;
        }
    }
}