using Microsoft.AspNetCore.Components;

namespace MeetingManager.Frontend.Blazor.Classes
{
    public class ToolTipOptions
    {
        public string Text { get; set; } = string.Empty;
        public ElementReference Element { get; set; }
    }
}
