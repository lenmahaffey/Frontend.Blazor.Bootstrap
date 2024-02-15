using MeetingManager.Frontend.Blazor.Classes;
using MeetingManager.Frontend.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace MeetingManager.Frontend.Blazor.Layout.Components
{
    public partial class AlertContainer : IDisposable
    {
        [Inject] AlertService? alertService { get; set; }
        List<Message> alerts { get; set; } = new List<Message>();
        protected override void OnInitialized()
        {
            alertService!.MessageReceived += onAlertReceived;
            alertService!.AlertDeleted += onAlertDeleted;
            base.OnInitialized();
        }

        void onAlertReceived(object? sender, Message message)
        {
            alerts.Add(message);
            StateHasChanged();
        }

        void onAlertDeleted(object? sender, Message message)
        {
            alerts.Remove(message);
            StateHasChanged();
        }

        public void Dispose()
        {
            if (alertService != null)
            {
                alertService.MessageReceived -= onAlertReceived;
                alertService.AlertDeleted -= onAlertDeleted;
            }
        }
    }
}
