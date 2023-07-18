using JCMG.EntitasRedux;

namespace Game.Services.TimeProvider.Impl
{
    public class UnityTimeProvider : ITimeProvider, 
        IUpdateSystem, 
        IFixedUpdateSystem
    {
        public float Time => UnityEngine.Time.time;
        public float DeltaTime { get; private set; }
        public float FixedDeltaTime { get; private set; }
        
        public void Update()
        {
            DeltaTime = UnityEngine.Time.deltaTime;
        }

        public void FixedUpdate()
        {
            FixedDeltaTime = UnityEngine.Time.fixedDeltaTime;
        }
    }
}