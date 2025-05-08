using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectMaui.Models
{
    public class Workout
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int DurationMinutes { get; set; }
        public string Notes { get; set; }
        public List<Exercise> Exercises { get; set; } = new();
        public List<ExerciseEntry> Exercisess { get; set; } = new List<ExerciseEntry>();

        public override string ToString()
        {
            return Title;
        }

    }
}
