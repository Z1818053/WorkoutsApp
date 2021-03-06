﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Workouts.Models;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Workouts.ViewModels
{
    //[QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class WorkoutDetailViewModel : BaseViewModel
    {

        //Constructor
        public WorkoutDetailViewModel()
        {
            EditWorkoutCommand = new Command(EditWorkout);
            StartWorkoutCommand = new Command(StartWorkout);
        }

        public WorkoutDetailViewModel(workout item)
        {
            itemId = item.Id;
            text = item.name;
            workoutDescription = item.workoutDescription;
            WorkoutExercises = item.workoutExercises;

            EditWorkoutCommand = new Command(EditWorkout);
            StartWorkoutCommand = new Command(StartWorkout);
            DeleteExerciseCommand = new Command(DeleteExercise);

        }

        //Private Variables 
        private string itemId;
        private string text;
        private string workoutDescription;
        private ObservableCollection<exercises> WorkoutExercises;
        private exercises _selectedExercise;


        //Public Variable declaractions

        public string Id { get; set; }
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public string Description
        {
            get => workoutDescription;
            set => SetProperty(ref workoutDescription, value);
        }

        public ObservableCollection<exercises> workoutExercises
        {
            get => WorkoutExercises;
            set => SetProperty(ref WorkoutExercises, value);
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

        //Public Methods
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.name;
                Description = item.workoutDescription;
                workoutExercises = item.workoutExercises;
               
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public void EditWorkout()
        {
            
        }
        public void StartWorkout()
        {

        }

        private void DeleteExercise()
        {
            if (SelectedExercise != null)
            {
                WorkoutExercises.Remove(SelectedExercise);
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

        //Command Declarations
        public Command EditWorkoutCommand { get; set; }
        public Command StartWorkoutCommand { get; set; }
        public Command DeleteExerciseCommand { get; set; }

    }//end of public class
}//end of namespace
