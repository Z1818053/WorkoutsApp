using System;
using System.Collections.Generic;
using System.Text;

namespace Workouts.Models
{
    public class exercises
    {
        public string Id { get; set; }

        public string WorkoutId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int sets { get; set; }
    }
}
