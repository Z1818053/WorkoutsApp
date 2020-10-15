using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Workouts.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;

namespace Workouts.ViewModels
{
    public class NewWorkoutViewModel : BaseViewModel
    {
        private string _text;
        private string _description;
        public ObservableCollection<exercises> ExercisesList { get; set;}
        public ObservableCollection<exercises> SelectedItem { get; set; }
        private string _exercise;
        private exercises _selectedExercise;



        public NewWorkoutViewModel()
        {
            ExercisesList = new ObservableCollection<exercises>();
            SelectedItem = new ObservableCollection<exercises>();
            AddExerciseCommand = new Command(AddExercise);
            DeleteExerciseCommand = new Command(DeleteExercise);
            SaveCommand = new Command(OnSave, ValidateSave);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }


        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_text);
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

            ExercisesList.Add(newExercise);

            Exercise = "";

        }

        private void DeleteExercise()
        {
            if (SelectedExercise != null)
            {
                ExercisesList.Remove(SelectedExercise);
            }
            
        }
        
        public exercises SelectedExercise
        {
            get
            {
                return _selectedExercise;
            }
            set
            {
                if (_selectedExercise != value)
                    _selectedExercise = value;
                //OnPropertyChanged("SelectedStop"); //U should implement this method using INotifyPropertyChanged
            }
        }

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        public string Exercise
        {
           
            get => _exercise;
            set => SetProperty(ref _exercise, value);
            
        }
        public Command SaveCommand { get; }
        public Command AddExerciseCommand { get; }
        public Command DeleteExerciseCommand { get; set; }

        private async void OnSave()
        {
            workout newItem = new workout()
            {
                Id = Guid.NewGuid().ToString(),
                name = Text,
                workoutDescription = Description,
                workoutExercises = ExercisesList
                
            };

            

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Application.Current.MainPage.Navigation.PopAsync();
        }


    }
}