using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Workouts.Pages
{
    public class CreateNewWorkoutPage : ContentPage
    {
        Grid grid = new Grid
        {
            RowSpacing = 1,
            ColumnSpacing = 0,
            RowDefinitions =
                {
                    new RowDefinition{Height=150 },
                    new RowDefinition{Height=GridLength.Auto },
                    new RowDefinition{Height=100}

                },
            ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition()

                }
        };

        int exerciseCounter = 1;
        StackLayout header = null;
        StackLayout body = null;
        StackLayout buttons = null;
        StackLayout body2 = null;
        public CreateNewWorkoutPage()
        {
            Title = "Create New Workout";

           
            header = new StackLayout();
            body = new StackLayout();
            body2 = new StackLayout();
            buttons = new StackLayout();

            grid.Children.Add(new BoxView(),0,0);
            

            Label workoutName = new Label { FontSize = 16, Text = "Workout Name" };
            Entry workout = new Entry { Placeholder = "Workout...", PlaceholderColor = Color.DimGray };
            Entry description = new Entry { Placeholder = "Description/Notes", PlaceholderColor = Color.DimGray };
            Label exercises = new Label { FontSize = 16, Text = "Exercises" };
            Entry exerciseName = new Entry { Placeholder = "1. Exercise name...", PlaceholderColor = Color.DimGray };
            Button AddExercise = new Button { Text = "Add Exercise", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            Button SaveWorkout = new Button { Text = "Save Workout", VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
           
            //Row 0 column 0
            header.Children.Add(workoutName);
            header.Children.Add(workout);
            header.Children.Add(description);
            header.Children.Add(exercises);
            grid.Children.Add(header, 0, 0);

            //row 2 column 1
            body.Children.Add(exerciseName);
            grid.Children.Add(body, 0, 1);

            //Row 2 column 1
            grid.Children.Add(body2, 1, 1);
            
            //Row 3 column 0 and 1
            grid.Children.Add(AddExercise, 0, 2);
            grid.Children.Add(SaveWorkout, 1, 2);
            AddExercise.Clicked += OnButtonClicked;

            Content = grid;

        }

        public void OnButtonClicked(object sender, EventArgs args)
        {
            
            exerciseCounter++;
            Entry exerciseName = new Entry { Placeholder = exerciseCounter + ". Exercise name..." , PlaceholderColor = Color.DimGray };

            if (exerciseCounter <= 14)
            {
                body.Children.Add(exerciseName);
            }
            else if (exerciseCounter > 14 && exerciseCounter <= 28)
            {
                body2.Children.Add(exerciseName);
            }
        }
    }
}