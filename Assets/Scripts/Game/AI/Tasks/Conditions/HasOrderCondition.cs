using System;
using Game.AI.Tasks.Abstraction;
using UnityEngine;
using Zenject;

namespace Game.AI.Tasks.Conditions
{
    public class HasOrderCondition : AConditionalTask
    {
        [Inject] private GameContext _game;

        protected override Func<bool> Condition(GameEntity entity) => () =>
        {
            Debug.Log("HasOrderCondition");
            
            return true;
        };
    }
}