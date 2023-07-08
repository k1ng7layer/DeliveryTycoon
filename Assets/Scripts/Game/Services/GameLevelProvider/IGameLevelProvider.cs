using Game.Services.GameLevelProvider.Views;

namespace Game.Services.GameLevelProvider
{
    public interface IGameLevelProvider
    {
        GameLevelView GameLevelView { get;}
    }
}