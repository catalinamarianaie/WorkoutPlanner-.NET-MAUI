using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectMaui.Models
{
    public class ExerciseEntry
    {
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

        public string ReprDisplay => $"{Name} - {Sets} seturi x {Reps} repetări";

    }
}
