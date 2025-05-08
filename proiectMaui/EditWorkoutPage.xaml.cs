using proiectMaui.Models;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proiectMaui;

public partial class EditWorkoutPage : ContentPage
{
    private Workout _workout;
    private List<ExerciseEntry> tempExercises = new();

    public EditWorkoutPage()
    {
        InitializeComponent();
    }

    public void SetWorkout(Workout workout)
    {
        _workout = workout;

        // Populeaz? câmpurile cu datele existente
        titleEntry.Text = _workout.Title;
        typePicker.SelectedItem = _workout.Type;
        datePicker.Date = _workout.Date;
        durationEntry.Text = _workout.DurationMinutes.ToString();
        notesEditor.Text = _workout.Notes;
        tempExercises = new List<ExerciseEntry>(_workout.Exercisess);

        // Actualizeaz? lista de exerci?ii
        UpdateExerciseList();
    }

    private void UpdateExerciseList()
    {
        exerciseList.ItemsSource = null;
        exerciseList.ItemsSource = tempExercises;
    }

    private void OnEditExerciseClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is ExerciseEntry exercise)
        {
            // Po?i deschide un popup pentru a edita exerci?iul
            var index = tempExercises.IndexOf(exercise);
            if (index >= 0)
            {
                // Simulare de editare simpl?
                tempExercises[index].Reps += 1;
                tempExercises[index].Sets += 1;
                UpdateExerciseList();
            }
        }
    }

    private void OnDeleteExerciseClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is ExerciseEntry exercise)
        {
            tempExercises.Remove(exercise);
            UpdateExerciseList();
        }
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        // Salveaz? modific?rile
        _workout.Title = titleEntry.Text;
        _workout.Type = typePicker.SelectedItem?.ToString();
        _workout.Date = datePicker.Date;
        _workout.DurationMinutes = int.Parse(durationEntry.Text);
        _workout.Notes = notesEditor.Text;
        _workout.Exercisess = new List<ExerciseEntry>(tempExercises);

        await WorkoutData.SaveAsync();
        await DisplayAlert("Succes", "Antrenamentul a fost actualizat!", "OK");
        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        // Revine la pagina principal? f?r? a salva
        await Navigation.PopAsync();
    }
}
