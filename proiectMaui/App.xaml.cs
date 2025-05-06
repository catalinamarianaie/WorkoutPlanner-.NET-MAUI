using proiectMaui.Models;

namespace proiectMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("🔴 EXCEPTIE NECAPTURATA: " + e.ExceptionObject?.ToString());
            };

            Task.Run(async () =>
            {
                await WorkoutData.LoadAsync();
                await ExerciseTypes.LoadAsync();
            });

        }
    }
}
