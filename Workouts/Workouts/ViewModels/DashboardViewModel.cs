using Workouts.Pages;
using Xamarin.Forms;

namespace Workouts.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        public DashboardViewModel()
        {
            Title = "Dashboard";
            ThemeSelectionPageCommand = new Command(ThemeSelectionPageCommandExecute);
            GoToProfilePageCommand = new Command(GoToProfilePageCommandExecute);
            GoToAllWorkoutsPageCommand = new Command(GoToAllWorkoutsPageCommandExecute);
        }

        /// <summary>
        /// Command to invoke when you want to navigate to the ThemeSelection page
        /// </summary>
        public Command ThemeSelectionPageCommand { get; set; }
        private void ThemeSelectionPageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ThemeSelectionPage());
        }

        /// <summary>
        /// Command to invoke when you want to navigate to Profile page
        /// </summary>
        public Command GoToProfilePageCommand { get; set; }
        private void GoToProfilePageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new MyProfilePage());
        }
        public Command GoToAllWorkoutsPageCommand { get; set; }
        private void GoToAllWorkoutsPageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AllWorkoutsPage());
        }


    }
}
