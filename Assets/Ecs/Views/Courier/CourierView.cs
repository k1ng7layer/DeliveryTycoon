using Db.Ai;
using Ecs.Views.Linkable.Impl;
using Game.AI.Data;
using Game.Utils;
using Game.Utils.Courier;
using JCMG.EntitasRedux;
using UnityEngine;
using UnityEngine.AI;

namespace Ecs.Views.Courier
{
    public class CourierView : ObjectView, 
        IRouteTargetAddedListener,
        IMovingAddedListener,
        IMovingRemovedListener
    {
        [SerializeField] private EAiType aiType;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private Animator animator;
        [SerializeField] private CourierParameters courierParameters;
        

        private GameEntity _courierEntity;

        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);

            _courierEntity = (GameEntity)entity;
            
            _courierEntity.AddAi(aiType);
            _courierEntity.AddCourierParameters(courierParameters);
            
            _courierEntity.AddRouteTargetAddedListener(this);
            _courierEntity.AddMovingAddedListener(this);
            _courierEntity.AddMovingRemovedListener(this);
        }

        public void OnRouteTargetAdded(GameEntity entity, RouteTargetData value)
        {
            navMeshAgent.SetDestination(value.Destination);
        }

        private void Update()
        {
            _courierEntity.Position.Value = navMeshAgent.transform.position;
        }

        public void OnMovingAdded(GameEntity entity)
        {
            animator.SetBool(AnimationKeys.Move, true);
        }

        public void OnMovingRemoved(GameEntity entity)
        {
            animator.SetBool(AnimationKeys.Move, false);
        }
    }
}