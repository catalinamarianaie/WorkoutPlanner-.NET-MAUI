using proiectMaui.Models;
namespace proiectMaui;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        workoutList.ItemsSource = WorkoutData.Workouts;
        BindingContext = WorkoutData.Workouts;

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
            // Navigheaz? la pagina de detalii ?i trimite Workout-ul selectat
            await Shell.Current.GoToAsync(nameof(WorkoutDetailsPage), true, new Dictionary<string, object>
        {
            { "workout", selectedWorkout }
        });

            // Reseteaz? selec?ia pentru a putea selecta acela?i antrenament de mai multe ori
            workoutList.SelectedItem = null;
        }
    }

    private async void OnEditWorkoutClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Workout selectedWorkout)
        {
            var editPage = new EditWorkoutPage();
            editPage.SetWorkout(selectedWorkout);
            await Navigation.PushAsync(editPage);
        }
    }










}