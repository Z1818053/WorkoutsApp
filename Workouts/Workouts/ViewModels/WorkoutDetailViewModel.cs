using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Workouts.Models;
using Xamarin.Forms;

namespace Workouts.ViewModels
{
    //[QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class WorkoutDetailViewModel : BaseViewModel
    {
        public WorkoutDetailViewModel()
        {

        }

        private string itemId;
        private string text;
        private string workoutDescription;
        public string Id { get; set; }
        private exercises exerciseName;

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public exercises ExerciseName
        {
            get => exerciseName;
            set => SetProperty(ref exerciseName, value);
        }

        public string Description
        {
            get => workoutDescription;
            set => SetProperty(ref workoutDescription, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.name;
                Description = item.workoutDescription;
                //exerciseName = item.workoutExercises;
               
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
