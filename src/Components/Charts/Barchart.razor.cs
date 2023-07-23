using Blazor.Frontend.Classes;
using BlazorBootstrap;
using Microsoft.AspNetCore.Components;

namespace Blazor.Frontend.Components.Charts
{
    public partial class BarChart
    {
        [Parameter] public List<BarChartData> data { get; set; } = new List<BarChartData>();
        private BlazorBootstrap.BarChart? barChart;
        private BlazorBootstrap.LineChart? lineChart;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await RenderManhattanAsync();

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task RenderManhattanAsync()
        {
            var data = new ChartData
            {
                Labels = this.data.Select(x => x.Name).ToList(),
                //Labels = new List<string> { "One", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" },
                Datasets = new List<IChartDataset>()
                {
                    new BarChartDataset()
                    {
                        Label = "India",
                        Data = this.data.Select(x => x.Value).ToList(),
                        BackgroundColor = new List<string>{ "rgb(88, 80, 141)" },
                        CategoryPercentage = 0.8,
                        BarPercentage = 1,
                    }
                }
            };

            var options = new BarChartOptions();

            options.Interaction.Mode = InteractionMode.Index;

            options.Plugins.Title.Text = "MANHATTAN";
            options.Plugins.Title.Display = true;
            options.Plugins.Title.Font.Size = 20;

            options.Responsive = true;

            options.Scales.X.Title.Text = "Overs";
            options.Scales.X.Title.Display = true;

            options.Scales.Y.Title.Text = "Runs";
            options.Scales.Y.Title.Display = true;

            await barChart.UpdateAsync(data, options);
        }

        private async Task RenderWormAsync()
        {
            var data = new ChartData
            {
                Labels = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" },
                Datasets = new List<IChartDataset>()
                {
                    new LineChartDataset()
                    {
                        Label = "India",
                        Data = new List<double>{ 9, 20, 29, 33, 50, 66, 75, 86, 91, 105, 120, 126, 141, 150, 156, 164, 177, 180, 184, 195 },
                        BackgroundColor = new List<string>{ "rgb(88, 80, 141)" },
                        BorderColor = new List<string>{ "rgb(88, 80, 141)" },
                        BorderWidth = new List<double>{2},
                        HoverBorderWidth = new List<double>{4},
                        PointBackgroundColor = new List<string>{ "rgb(88, 80, 141)" },
                        PointBorderColor = new List<string>{ "rgb(88, 80, 141)" },
                        PointRadius = new List<int>{0}, // hide points
                        PointHoverRadius = new List<int>{4},
                    },
                    new LineChartDataset()
                    {
                        Label = "England",
                        Data = new List<double>{ 1, 1, 8, 19, 24, 26, 39, 47, 56, 66, 75, 88, 95, 100, 109, 114, 124, 129, 140, 142 },
                        BackgroundColor = new List<string>{ "rgb(255, 166, 0)" },
                        BorderColor = new List<string>{ "rgb(255, 166, 0)" },
                        BorderWidth = new List<double>{2},
                        HoverBorderWidth = new List<double>{4},
                        PointBackgroundColor = new List<string>{ "rgb(255, 166, 0)" },
                        PointBorderColor = new List<string>{ "rgb(255, 166, 0)" },
                        PointRadius = new List<int>{0}, // hide points
                        PointHoverRadius = new List<int>{4},
                    }
                }
            };

            var options = new LineChartOptions();

            options.Interaction.Mode = InteractionMode.Index;

            options.Plugins.Title.Text = "WORM";
            options.Plugins.Title.Display = true;
            options.Plugins.Title.Font.Size = 20;

            options.Responsive = true;

            options.Scales.X.Title.Text = "Overs";
            options.Scales.X.Title.Display = true;

            options.Scales.Y.Title.Text = "Runs";
            options.Scales.Y.Title.Display = true;

            await lineChart.UpdateAsync(data, options);
        }
    }
}
