using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace proiectMaui.Models
{
    public static class ExerciseTypes
    {
        public static List<string> Types { get; set; } = new()
        {
            "Flotări", "Genuflexiuni", "Abdomene", "Tracțiuni", "Alergare"
        };

        public static async Task SaveAsync()
        {
            var json = JsonSerializer.Serialize(Types);
            var path = Path.Combine(FileSystem.AppDataDirectory, "exercise_types.json");
            await File.WriteAllTextAsync(path, json);
        }

        public static async Task LoadAsync()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, "exercise_types.json");
            if (File.Exists(path))
            {
                var json = await File.ReadAllTextAsync(path);
                var list = JsonSerializer.Deserialize<List<string>>(json);
                if (list != null)
                {
                    Types = list;
                }
            }
        }
    }
}
