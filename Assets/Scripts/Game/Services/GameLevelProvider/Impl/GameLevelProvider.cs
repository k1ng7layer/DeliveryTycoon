using Game.Services.GameLevelProvider.Views;

namespace Game.Services.GameLevelProvider.Impl
{
    public class GameLevelProvider : IGameLevelProvider
    {
        public GameLevelProvider(GameLevelView gameLevelView)
        {
            GameLevelView = gameLevelView;
        }
        
        public GameLevelView GameLevelView { get;}
    }
}