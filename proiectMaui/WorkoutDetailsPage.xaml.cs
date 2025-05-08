using proiectMaui.Models;
using Microsoft.Maui.Controls;
using System.Linq;

namespace proiectMaui;

[QueryProperty(nameof(Workout), "workout")]
public partial class WorkoutDetailsPage : ContentPage
{
    public Workout Workout { get; set; }

    public WorkoutDetailsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (Workout != null)
        {
            titleLabel.Text = Workout.Title;
            typeLabel.Text = Workout.Type;
            dateLabel.Text = $"Data: {Workout.Date:dd MMMM yyyy}";
            durationLabel.Text = $"Durată: {Workout.DurationMinutes} minute";
            notesLabel.Text = Workout.Notes;
            notesLabel.IsVisible = !string.IsNullOrWhiteSpace(Workout.Notes);

            if (Workout.Exercisess != null && Workout.Exercisess.Any())
            {
                exerciseList.ItemsSource = Workout.Exercisess;
                exerciseList.IsVisible = true;
            }
            else
            {
                exerciseList.IsVisible = false;
            }
        }
        else
        {
            titleLabel.Text = "Nicio selecție";
            notesLabel.Text = "Deschide un antrenament din listă pentru a vedea detaliile.";
            notesLabel.TextColor = Colors.Gray;
            notesLabel.IsVisible = true;
            exerciseList.IsVisible = false;
        }
    }
}
