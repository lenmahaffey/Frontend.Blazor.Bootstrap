using MeetingManager.Library.Models.Context.DTO;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MeetingManager.Frontend.Blazor.Areas.Contacts.Pages
{
    public partial class Contacts
    {
        [Inject] ContactService? api { get; set; }
        [Inject] HttpClient http { get; set; } 
        IEnumerable<Contact_DTO>? contacts { get; set; }  
        protected override async Task OnParametersSetAsync() =>
             contacts = await http.GetFromJsonAsync<IEnumerable<Contact_DTO>>("contact/listcontacts");
    }
}
