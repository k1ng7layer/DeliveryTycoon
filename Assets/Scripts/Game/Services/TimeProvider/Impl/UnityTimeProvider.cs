using JCMG.EntitasRedux;
using UnityEngine;

namespace Game.Services.TimeProvider.Impl
{
    public class UnityTimeProvider : ITimeProvider, 
        IUpdateSystem, 
        IFixedUpdateSystem
    {
        public float DeltaTime { get; private set; }
        public float FixedDeltaTime { get; private set; }
        
        public void Update()
        {
            DeltaTime = Time.deltaTime;
        }

        public void FixedUpdate()
        {
            FixedDeltaTime = Time.fixedDeltaTime;
        }
    }
}