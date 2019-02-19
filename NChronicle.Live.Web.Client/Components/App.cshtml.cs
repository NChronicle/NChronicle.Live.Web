using Microsoft.AspNetCore.Components;
using NChronicle.Live.Web.Shared;
using System.Net.Http;
using System.Threading.Tasks;

namespace NChronicle.Live.Web.Client.Components.Behind
{

    public class App : ComponentBase
    {

        [Inject] private HttpClient httpClient { get; set; }

        protected ChronicleRecordDto[] Records;

        protected override async Task OnInitAsync()
        {
            Records = await this.httpClient.GetJsonAsync<ChronicleRecordDto[]>("api/chroniclerecord");
        }

    }

}
