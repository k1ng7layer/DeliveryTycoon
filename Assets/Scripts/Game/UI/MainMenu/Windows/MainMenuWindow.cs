using Game.UI.MainMenu.Controllers;
using SimpleUi;

namespace Game.UI.MainMenu.Windows
{
    public class MainMenuWindow : WindowBase
    {
        public override string Name => "MainMenu";
        
        protected override void AddControllers()
        {
            AddController<MainMenuController>();
        }
    }
}