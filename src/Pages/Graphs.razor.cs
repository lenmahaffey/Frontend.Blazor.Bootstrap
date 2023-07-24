using Blazor.Frontend.Classes;

namespace Blazor.Frontend.Pages
{
    public partial class Graphs
    {
        public List<BarChartData> data {get; set; } =
            new List<BarChartData>
            {
                { new BarChartData{ Name = "Rust", Value = 78.9  }},
                { new BarChartData { Name = "Kotlin", Value = 75.1 } },
                { new BarChartData { Name = "Python", Value = 68.0 } },
                { new BarChartData { Name = "TypeScript", Value = 67.0 } },
                { new BarChartData { Name = "Go", Value = 65.6 } },
                { new BarChartData { Name = "Swift", Value = 65.1 } },
                { new BarChartData { Name = "Javascript", Value = 61.9 } },
                { new BarChartData { Name = "C#", Value = 60.4 } },
                { new BarChartData { Name = "F#", Value = 59.6 } },
                { new BarChartData { Name = "Clojure", Value = 59.6 } },
            };
    }
}
