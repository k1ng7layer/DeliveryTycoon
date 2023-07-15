using Ecs.Views.Linkable.Impl;
using UnityEngine;
using UnityEngine.AI;

namespace Ecs.Views.Courier
{
    public class CourierView : ObjectView  
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
    }
}