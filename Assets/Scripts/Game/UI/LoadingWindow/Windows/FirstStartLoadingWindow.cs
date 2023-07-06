using Game.UI.LoadingWindow.Controllers;
using SimpleUi;

namespace Game.UI.LoadingWindow.Windows
{
    public class FirstStartLoadingWindow : WindowBase
    {
        public override string Name => "FirstStartLoading";
        
        protected override void AddControllers()
        {
            AddController<FirstStartLoadingController>();
        }
    }
}