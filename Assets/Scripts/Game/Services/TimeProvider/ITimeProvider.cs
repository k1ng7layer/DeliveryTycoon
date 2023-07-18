namespace Game.Services.TimeProvider
{
    public interface ITimeProvider
    {
        float Time { get; }
        float DeltaTime { get; }
        float FixedDeltaTime { get; }
    }
}