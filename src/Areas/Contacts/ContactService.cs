using MeetingManager.Library.Models.Context.DTO;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace MeetingManager.Frontend.Blazor.Areas.Contacts
{
    public class ContactService
    {
        [Inject] private HttpClient? http { get; set; }

        public ContactService(HttpClient client)
        {
            http = client;
        }
        public async void ListAllContacts()
        {
            try
            {
                if (http != null)
                {
                    var result = await http.GetFromJsonAsync<List<Contact_DTO>>("contact/listcontacts");
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
