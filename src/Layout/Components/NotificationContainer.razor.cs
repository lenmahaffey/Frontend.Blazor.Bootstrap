using MeetingManager.Frontend.Blazor.Classes;
using MeetingManager.Frontend.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace MeetingManager.Frontend.Blazor.Layout.Components
{
    public partial class NotificationContainer : IDisposable
    {
        [Inject] NotificationService? notificationService { get; set; }
        [Parameter] public List<Message> Notifications { get; set; } = new List<Message>();

        protected override void OnInitialized()
        {
            notificationService!.MessageReceived += onMessageReceived;
            notificationService!.NotificationDeleted += onNotificationDeleted;
            base.OnInitialized();
        }

        void onMessageReceived(object? sender, Message m)
        {
            Notifications.Add(m);
            StateHasChanged();
        }

        void onNotificationDeleted(object? sender, Message message)
        {
            Notifications.Remove(message);
            StateHasChanged();
        }
        public void Dispose()
        {
            if (notificationService != null)
            {
                notificationService.MessageReceived -= onMessageReceived;
                notificationService.NotificationDeleted -= onNotificationDeleted;

            }
        }
    }
}
