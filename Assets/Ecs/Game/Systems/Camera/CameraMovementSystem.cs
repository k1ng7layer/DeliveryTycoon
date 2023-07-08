﻿using Db.Camera;
using Game.Services.Camera;
using Game.Services.Input;
using Game.Services.TimeProvider;
using JCMG.EntitasRedux;
using UnityEngine;

namespace Ecs.Game.Systems.Camera
{
    public class CameraMovementSystem : IUpdateSystem
    {
        private readonly GameContext _game;
        private readonly InputContext _input;
        private readonly ITimeProvider _timeProvider;
        private readonly ICameraParameters _cameraParameters;
        private readonly ICameraService _cameraService;

        public CameraMovementSystem(GameContext game,
            InputContext input,
            ITimeProvider timeProvider,
            ICameraParameters cameraParameters,
            ICameraService cameraService)
        {
            _game = game;
            _input = input;
            _timeProvider = timeProvider;
            _cameraParameters = cameraParameters;
            _cameraService = cameraService;
        }
        
        public void Update()
        {
            var inputVector = _input.InputEntity.InputVector.Value;
            if(inputVector.sqrMagnitude == 0)
                return;

            var followObject = _game.CameraGlobalTargetEntity;

            var objPosition = followObject.Position.Value;
            var objRotation = followObject.Rotation.Value;
            var dir = objRotation * inputVector;
            objPosition += dir * _timeProvider.DeltaTime * _cameraParameters.MovementSpeed;

            followObject.ReplacePosition(objPosition);
        }
    }
}