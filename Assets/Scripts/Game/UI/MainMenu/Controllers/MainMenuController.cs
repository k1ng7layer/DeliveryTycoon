using Core.SceneLoading;
using Game.UI.MainMenu.Views;
using SimpleUi.Abstracts;
using UniRx;
using Zenject;

namespace Game.UI.MainMenu.Controllers
{
    public class MainMenuController : UiController<MainMenuView>, 
        IInitializable
    {
        private readonly ISceneLoadingManager _loadingManager;

        public MainMenuController(ISceneLoadingManager loadingManager)
        {
            _loadingManager = loadingManager;
        }
        
        public void Initialize()
        {
            View.loadGameButton.OnClickAsObservable().Subscribe(_ => { LoadGame(); }).AddTo(View);
        }

        private void LoadGame()
        {
            _loadingManager.LoadGameLevel(ELevelName.StartLevel);
        }
    }
}