using proiectMaui.Models;

namespace proiectMaui;

public partial class WorkoutDetailsPage : ContentPage
{
    public WorkoutDetailsPage(Workout workout)
    {
        InitializeComponent();

        if (workout == null)
        {
            Content = new StackLayout
            {
                Padding = 30,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new Label
                    {
                        Text = "Nu ai selectat niciun antrenament.\nTe rug?m s? alegi unul din pagina principal?.",
                        FontSize = 18,
                        HorizontalTextAlignment = TextAlignment.Center,
                        TextColor = Colors.Gray
                    },
                    new Button
                    {
                        Text = "Revenire la Acas?",
                        Command = new Command(async () => await Shell.Current.GoToAsync("..")),
                        HorizontalOptions = LayoutOptions.Center,
                        Margin = new Thickness(0, 20, 0, 0)
                    }
                }
            };

            return;
        }

        titleLabel.Text = workout.Title;
        typeLabel.Text = workout.Type;
        dateLabel.Text = $"Data: {workout.Date:dd MMMM yyyy}";
        durationLabel.Text = $"Durat?: {workout.DurationMinutes} minute";

        notesLabel.Text = workout.Notes;
        notesLabel.IsVisible = !string.IsNullOrWhiteSpace(workout.Notes);

        if (workout.Exercisess != null && workout.Exercisess.Any())
        {
            exerciseList.ItemsSource = workout.Exercisess;
            exerciseList.IsVisible = true;
        }
        else
        {
            exerciseList.IsVisible = false;
        }
    }
}
