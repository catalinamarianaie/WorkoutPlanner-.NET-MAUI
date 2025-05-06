using proiectMaui.Models;
namespace proiectMaui;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        workoutList.ItemsSource = WorkoutData.Workouts;

        UpdateVisibility();

        
        WorkoutData.Workouts.CollectionChanged += (s, e) => UpdateVisibility();
    }
    private void UpdateVisibility()
    {
        bool isEmpty = WorkoutData.Workouts.Count == 0;
        workoutList.IsVisible = !isEmpty;
        emptyMessageLabel.IsVisible = isEmpty;
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Workout selectedWorkout)
        {
            bool confirm = await DisplayAlert("Confirmare", $"Sigur vrei sa stergi antrenamentul de „{selectedWorkout.Title}”?", "Da", "Nu");
            if (confirm)
            {
                WorkoutData.Workouts.Remove(selectedWorkout);
                await WorkoutData.SaveAsync();
            }
        }
    }
    private async void OnWorkoutSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Workout selectedWorkout)
        {
            await Navigation.PushAsync(new WorkoutDetailsPage(selectedWorkout));

            // deselecteaz? dup? navigare
            workoutList.SelectedItem = null;
        }
    }


}