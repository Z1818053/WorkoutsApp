using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Workouts.Models
{
    public class workout
    {
        public string Id { get; set; }

        public string name { get; set; }

        public string workoutDescription { get; set; }

        public ObservableCollection<exercises> workoutExercises { get; set; }

    }
}
