using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workouts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Workouts.Models;

namespace Workouts.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WorkoutDetailPage : ContentPage
    {
        public ViewCell lastCell;

        public WorkoutDetailPage(Models.workout item)
        {
            InitializeComponent();
            BindingContext = new WorkoutDetailViewModel(item);
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
