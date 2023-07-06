using Core.SceneLoading;
using Game.UI.LoadingWindow.Views;
using SimpleUi.Abstracts;
using UnityEngine;
using Zenject;

namespace Game.UI.LoadingWindow.Controllers
{
    public class FirstStartLoadingController : UiController<FirstStartView>, 
        ITickable
    {
        private readonly ISceneLoadingManager _sceneLoadingManager;

        public FirstStartLoadingController(ISceneLoadingManager sceneLoadingManager)
        {
            _sceneLoadingManager = sceneLoadingManager;
        }
        
        public void Tick()
        {
            View.textLoading.text = Mathf.RoundToInt(_sceneLoadingManager.GetProgress() * 100) + "% loaded";
        }
    }
}