using System.Text.Json;
using proiectMaui.Models;
namespace proiectMaui;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
        exerciseTypeList.ItemsSource = ExerciseTypes.Types;
        workoutCountLabel.Text = $"Ai {WorkoutData.Workouts.Count} antrenamente salvate. Doresti sa le stergi?";

    }

    private void OnAddExerciseTypeClicked(object sender, EventArgs e)
    {
        var text = exerciseTypeEntry.Text?.Trim();
        if (!string.IsNullOrEmpty(text) && !ExerciseTypes.Types.Contains(text))
        {
            ExerciseTypes.Types.Add(text);
            exerciseTypeEntry.Text = "";
            RefreshExerciseTypeList();
            ExerciseTypes.SaveAsync();
        }
    }

    private void OnDeleteExerciseTypeClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.CommandParameter is string toRemove)
        {
            ExerciseTypes.Types.Remove(toRemove);
            RefreshExerciseTypeList();
            ExerciseTypes.SaveAsync();
        }
    }

    private async void OnDeleteAllWorkoutsClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirmare", "Esti sigur ca vrei sa stergi toate antrenamentele?", "Da", "Nu");
        if (confirm)
        {
            WorkoutData.Workouts.Clear();
            await WorkoutData.SaveAsync();
            await DisplayAlert("Succes", "Toate antrenamentele au fost sterse.", "OK");
        }
        workoutCountLabel.Text = "Ai 0 antrenamente salvate. Doresti sa le stergi?";

    }


    private void RefreshExerciseTypeList()
    {
        exerciseTypeList.ItemsSource = null;
        exerciseTypeList.ItemsSource = ExerciseTypes.Types;
    }

    private void OnToggleThemeClicked(object sender, EventArgs e)
    {
        var currentTheme = Application.Current.UserAppTheme;
        if (currentTheme == AppTheme.Dark)
        {
            Application.Current.UserAppTheme = AppTheme.Light;
            themeToggleButton.Text = "Comuta mod intunecat";
        }
        else
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
            themeToggleButton.Text = "Comuta mod luminos";
        }
    }

}