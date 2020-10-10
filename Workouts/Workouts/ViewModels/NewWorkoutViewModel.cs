using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Workouts.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace Workouts.ViewModels
{
    public class NewWorkoutViewModel : BaseViewModel
    {
        private string text;
        private string description;
        public ObservableCollection<string> ExercisesList { get; set;}
        //private List<string> ExercisesList { get; set; }

        private string exercise;
        //public List<string> exer = new List<string>();

        public NewWorkoutViewModel()
        {
            ExercisesList = new ObservableCollection<string>();
            //ExercisesList = new List<string>();
            AddExerciseCommand = new Command(AddExercise);
            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        private async void AddExercise()
        {
            exercises newExercise = new exercises()
            {
                Id = Guid.NewGuid().ToString(),
                name = Exercise,

            };

            //put a breakpoint here when you run and inpect the values of the Exercise. 
             await exerciseStore.AddItemAsync(newExercise);

            ExercisesList.Add(newExercise.name);

        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Exercise
        {
           
            get => exercise;
            set => SetProperty(ref exercise, value);
            
        }
        public Command SaveCommand { get; }
        public Command AddExerciseCommand { get; }

        private async void OnSave()
        {
            workout newItem = new workout()
            {
                Id = Guid.NewGuid().ToString(),
                name = Text,
                workoutDescription = Description,
                //workoutExercises = ExercisesList
                
            };

            

            await DataStore.AddItemAsync(newItem);
            //await exerciseStore.AddItemAsync(newExercise);

            // This will pop the current page off the navigation stack
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}