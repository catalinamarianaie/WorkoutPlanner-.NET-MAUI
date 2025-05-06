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

        public string ReprDisplay
        {
            get { return $"{Sets}×{Reps}"; }
            set { /* necesar pentru binding, chiar dacă nu folosești setterul */ }
        }

    }
}
