using proiectMaui.Models;

namespace proiectMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Task.Run(async () =>
            {
                await WorkoutData.LoadAsync();
                await ExerciseTypes.LoadAsync();
            });

        }
    }
}
