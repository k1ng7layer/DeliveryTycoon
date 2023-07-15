using SimpleUi.Abstracts;

namespace Game.UI.CouriersView.Controllers
{
    public class CouriersUiController : UiController<CouriersView.Views.CouriersView>, 
        ICouriersUiController
    {
        public void SetEmployees(int value)
        {
            View.employeesCountText.text = $"Couriers: {value}";
        }
    }
}