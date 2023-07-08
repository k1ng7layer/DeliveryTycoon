using Cinemachine;
using Ecs.Views.Linkable.Impl;
using Game.Services.Camera;
using JCMG.EntitasRedux;
using UnityEngine;
using Zenject;

namespace Ecs.Views.Camera
{
    public class PhysicalCameraView : ObjectView
    {
        [SerializeField] private CinemachineBrain cameraBrain;
        [SerializeField] private UnityEngine.Camera camera;

        public UnityEngine.Camera Camera => camera;
        
        public CinemachineBrain CinemachineBrain => cameraBrain;
        
        public override void Link(IEntity entity, IContext context)
        {
            base.Link(entity, context);
            
            var cameraEntity = (GameEntity)entity;
        }
    }
}