using MeetingManager.Frontend.Blazor.Classes;

namespace MeetingManager.Frontend.Blazor.Layout
{
    public class TopNavLinks
    {
        public static List<NavLinkGroup> Links { get; } =
            new List<NavLinkGroup>()
            {
                {
                    new NavLinkGroup()
                    {
                        Title = "Contacts",
                        Links = new List<NavLink>()
                        {
                            new NavLink() { Label = "Contacts", Href = "/contacts"}
                        },
                    }
                },
            };
    }
}
