using MeetingManager.Frontend.Blazor.Classes;
using MeetingManager.Frontend.Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace MeetingManager.Frontend.Blazor.Areas.Demo
{
    public partial class Demo
    {
        [Inject] AppStateService? appStateService { get; set; }
        List<NavLinkGroup> navLinks { get; set; } = DemoSideNavLinks.Links;
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            setNavLinks();
        }

        void setNavLinks()
        {
            if (appStateService != null)
            {
                appStateService.SideNavLinks?.Invoke(this, navLinks);
            }
        }
    }
}
