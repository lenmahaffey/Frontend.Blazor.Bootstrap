using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.Frontend.Pages
{
    public partial class Graphs
    {
        [Inject] public IJSRuntime? Js { get; set; }
        private IJSObjectReference? _js;
        private ElementReference svg;

        protected async override Task OnInitializedAsync()
        {
            _js = await Js!.InvokeAsync<IJSObjectReference>("import", "./Pages/Graphs.razor.js");
            await _js.InvokeVoidAsync("drawBarChart", svg);
        }
    }
}
