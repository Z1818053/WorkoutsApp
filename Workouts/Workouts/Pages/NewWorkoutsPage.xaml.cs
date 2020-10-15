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

        public ViewCell lastCell;
        public NewWorkoutPage()
        {
            
            InitializeComponent();
            BindingContext = new NewWorkoutViewModel();   

        }

        private void ViewCell_Tapped(object sender, System.EventArgs e)
        {
            if (lastCell != null)
                lastCell.View.BackgroundColor = Color.Transparent;
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = Color.DarkGray;
                lastCell = viewCell;
            }
        }

    }
}
