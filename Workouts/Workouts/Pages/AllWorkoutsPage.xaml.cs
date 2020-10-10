using Workouts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Workouts.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllWorkoutsPage : ContentPage
    {

        AllWorkoutsModel _viewModel;

        public AllWorkoutsPage()
        {
            InitializeComponent();
            BindingContext =_viewModel = new AllWorkoutsModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }

    
}