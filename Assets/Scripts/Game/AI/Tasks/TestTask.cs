using System;
using Game.AI.Tasks.Abstraction;
using UniBT;
using UnityEngine;
using Zenject;

namespace Game.AI.Tasks
{
    public class TestTask : AActionTask
    {
       [Inject] private readonly GameContext _game;

       protected override Func<Status> DoWork(GameEntity entity) => () =>
       {

           Debug.Log(entity.HasCourier);
            
           return Status.Success;
       };
    }
}