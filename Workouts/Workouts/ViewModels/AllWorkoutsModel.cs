using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Workouts.Models;
using Workouts.Pages;
using Workouts.Services;

namespace Workouts.ViewModels
{
    public class AllWorkoutsModel : BaseViewModel
    {
            private workout _selectedItem;

            public ObservableCollection<workout> Workouts { get; }
            public ObservableCollection<exercises> Exercises { get; }
            public Command LoadItemsCommand { get; }
        //public Command AddItemCommand { get; }

        public Command<workout> ItemTapped { get; }

        public AllWorkoutsModel()
        {
            Title = "My Workouts";
            Workouts = new ObservableCollection<workout>();
            Exercises = new ObservableCollection<exercises>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            GoToNewWorkoutPageCommand = new Command(GoToNewWorkoutPageCommandExecute);

            ItemTapped = new Command<workout>(OnItemSelected);

            //AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Workouts.Clear();
                var workouts = await DataStore.GetItemsAsync(true);
                foreach (var item in workouts)
                {
                    Workouts.Add(item);
                }
                var exercises = await exerciseStore.GetItemsAsync(true);
                foreach (var item in exercises)
                {
                    Exercises.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public workout SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                //OnItemSelected(value);
            }
        }

        async void OnItemSelected(workout item)
        {
            if (item == null)
                return;

            var DetailPage = new WorkoutDetailPage();
            DetailPage.BindingContext = item;

            // This will push the ItemDetailPage onto the navigation stack
            await Application.Current.MainPage.Navigation.PushAsync(DetailPage);
        }

        public Command GoToNewWorkoutPageCommand { get; set; }

        private void GoToNewWorkoutPageCommandExecute()
        {
            Application.Current.MainPage.Navigation.PushAsync(new NewWorkoutPage());
        }
    }
}
