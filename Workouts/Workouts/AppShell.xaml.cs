using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workouts.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Workouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(WorkoutDetailPage), typeof(WorkoutDetailPage));
            Routing.RegisterRoute(nameof(AllWorkoutsPage), typeof(AllWorkoutsPage));
        }
    }
}