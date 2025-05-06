using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace proiectMaui.Models
{
    public static class WorkoutData
    {
        public static ObservableCollection<Workout> Workouts { get; set; } = new();

        private static string filePath = Path.Combine(FileSystem.AppDataDirectory, "workouts.json");

        public static async Task LoadAsync()
        {
            if (File.Exists(filePath))
            {
                string json = await File.ReadAllTextAsync(filePath);
                var items = JsonSerializer.Deserialize<List<Workout>>(json);
                if (items != null)
                {
                    Workouts.Clear();
                    foreach (var item in items)
                    {
                        if (item.Exercisess == null)
                            System.Diagnostics.Debug.WriteLine($"⚠️ Workout fără exerciții: {item.Title}");

                        item.Exercisess ??= new List<ExerciseEntry>();
                        Workouts.Add(item);
                    }


                }
            }
        }

        public static async Task SaveAsync()
        {
            var json = JsonSerializer.Serialize(Workouts.ToList());
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
