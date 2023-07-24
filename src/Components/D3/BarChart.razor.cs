using Blazor.Frontend.Classes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Components.D3
{
    public partial class BarChart
    {
        [Inject] public IJSRuntime? Js { get; set; }
        private IJSObjectReference? _js;
        ElementReference svg;
        private List<BarChartData> data { get; set; } = 
            new List<BarChartData> 
            {
                { new BarChartData{ Name = "Rust", Value = 78.9  } }, 
                { new BarChartData{ Name = "Kotlin", Value = 75.1} },
                { new BarChartData{ Name = "Python", Value = 68.0} },
                { new BarChartData{ Name = "TypeScript", Value = 67.0} },
                { new BarChartData{ Name = "Go", Value = 65.6} },
                { new BarChartData{ Name = "Swift", Value = 65.1} },
                { new BarChartData{ Name = "Javascript", Value = 61.9} },
                { new BarChartData{ Name = "C#", Value = 60.4} },
                { new BarChartData{ Name = "F#", Value = 59.6} },
                { new BarChartData{ Name = "Clojure", Value = 59.6} },
            };
        protected async override Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Components/D3/Barchart.razor.js");
            await _js.InvokeVoidAsync("DrawBarChart", data, DotNetObjectReference.Create(this));
        }

        [JSInvokable("ChartHasRendered")]
        public void ChartHasRendered()
        {
            StateHasChanged();
        }
    }
}
