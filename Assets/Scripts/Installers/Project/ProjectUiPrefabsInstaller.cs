using Game.UI.LoadingWindow.Controllers;
using Game.UI.LoadingWindow.Views;
using SimpleUi;
using UnityEngine;
using Zenject;

namespace Installers.Project
{
    [CreateAssetMenu(menuName = "Installers/ProjectUiPrefabsInstaller", fileName = "ProjectUiPrefabsInstaller")]
    public class ProjectUiPrefabsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private FirstStartView initialLaunchView;

        public override void InstallBindings()
        {
            var canvasView = Container.InstantiatePrefabForComponent<Canvas>(canvas);
            var canvasTransform = canvasView.transform;
            Container.BindUiView<FirstStartLoadingController, FirstStartView>(initialLaunchView, canvasTransform);
        }
    }
}