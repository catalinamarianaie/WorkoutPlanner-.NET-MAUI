using proiectMaui.Models;
using Syncfusion.Maui.Charts;

namespace proiectMaui;

public partial class StatisticsPage : ContentPage
{
    public StatisticsPage()
    {
        InitializeComponent();
        LoadStatistics();
    }

    private void LoadStatistics()
    {
        var workouts = WorkoutData.Workouts;

        if (workouts.Count == 0)
        {
            totalLabel.Text = "Nu exist? antrenamente.";
            durationLabel.Text = "";
            averageLabel.Text = "";
            commonLabel.Text = "";
            chart.Series.Clear();
            return;
        }

        // Statistici generale
        int total = workouts.Count;
        int totalDuration = workouts.Sum(w => w.DurationMinutes);
        double average = workouts.Average(w => w.DurationMinutes);

        var commonType = workouts
            .GroupBy(w => w.Type)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault()?.Key ?? "Nedefinit";

        totalLabel.Text = $"Numar total de antrenamente: {total}";
        durationLabel.Text = $"Durata totala: {totalDuration} minute";
        averageLabel.Text = $"Durata medie: {average:F1} minute";
        commonLabel.Text = $"Tipul cel mai frecvent: {commonType}";

        // Preg?te?te datele pentru grafic
        var dataPerDay = workouts
            .GroupBy(w => w.Date.Date)
            .OrderBy(g => g.Key)
            .Select(g => new ChartData
            {
                Label = g.Key.ToString("dd MMM"),
                Value = g.Sum(w => w.DurationMinutes)
            })
            .ToList();

        var columnSeries = new ColumnSeries
        {
            ItemsSource = dataPerDay,
            XBindingPath = "Label",
            YBindingPath = "Value"
        };

        chart.Series.Clear();
        chart.Series.Add(columnSeries);
    }

    private void OnRefreshClicked(object sender, EventArgs e)
    {
        LoadStatistics();
    }
}

// Clasa pentru datele din grafic
public class ChartData
{
    public string Label { get; set; }
    public double Value { get; set; }
}
