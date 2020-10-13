using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Workouts.ViewModels;
using Workouts.Models;

namespace Workouts.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class NewWorkoutPage : ContentPage
    {
        //private List<exercises> exercises;
        int exerciseCounter = 1;
        public NewWorkoutPage()
        {
            
            InitializeComponent();
            BindingContext = new NewWorkoutViewModel();   

        }


        public void AddExercises(object sender, EventArgs args)
        { 

            //exerciseCounter++;
            //Entry newExercise = new Entry { Placeholder = "Exercise Name...", PlaceholderColor = Color.DimGray};
            //newExercise.BindingContext = "{Binding Exercise, Mode=TwoWay}";
            //exerciseGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            //exerciseGrid.Children.Add(newExercise, 0, exerciseCounter);
            
        }

        private void Entry_Completed(object sender, EventArgs e)
        {

        }
    }
}
