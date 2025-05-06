using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiectMaui.Models
{
    public class Exercise
    {
        public string? Name { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Reps} x {Sets}";
        }
    }
}
