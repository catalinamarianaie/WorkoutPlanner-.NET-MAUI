using proiectMaui.Models;
namespace proiectMaui;

public partial class AddWorkoutPage : ContentPage
{
    public AddWorkoutPage()
    {
        InitializeComponent();
        exercisePicker.ItemsSource = ExerciseTypes.Types;
    }
    private List<Exercise> addedExercises = new();

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Validare simplă
        if (string.IsNullOrWhiteSpace(titleEntry.Text) || typePicker.SelectedIndex == -1 || string.IsNullOrWhiteSpace(durationEntry.Text))
        {
            DisplayAlert("Eroare", "Completează toate câmpurile obligatorii!", "OK");
            return;
        }

        var workout = new Workout
        {
            Title = titleEntry.Text,
            Type = typePicker.SelectedItem.ToString(),
            Date = datePicker.Date,
            DurationMinutes = int.Parse(durationEntry.Text),
            Notes = notesEditor.Text,
            Exercises = addedExercises.ToList()
        };


        WorkoutData.Workouts.Add(workout);
        await WorkoutData.SaveAsync();
        DisplayAlert("Succes", "Antrenamentul a fost salvat!", "OK");

        // Curăță formularul
        titleEntry.Text = string.Empty;
        typePicker.SelectedIndex = -1;
        durationEntry.Text = string.Empty;
        notesEditor.Text = string.Empty;
        datePicker.Date = DateTime.Today;

    }

    private void OnAddExerciseClicked(object sender, EventArgs e)
    {
        if (exercisePicker.SelectedItem is not string name ||
            !int.TryParse(repsEntry.Text, out int reps) ||
            !int.TryParse(setsEntry.Text, out int sets))
        {
            DisplayAlert("Eroare", "Completează corect toate câmpurile pentru exercițiu!", "OK");
            return;
        }

        var exercise = new Exercise
        {
            Name = name,
            Reps = reps,
            Sets = sets
        };

        addedExercises.Add(exercise);

        exerciseList.ItemsSource = null;
        exerciseList.ItemsSource = addedExercises;

        // Curățare câmpuri
        exercisePicker.SelectedIndex = -1;
        repsEntry.Text = "";
        setsEntry.Text = "";
    }

}