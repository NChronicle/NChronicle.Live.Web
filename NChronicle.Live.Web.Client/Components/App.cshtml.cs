using Microsoft.AspNetCore.Components;
using NChronicle.Live.Web.Shared;
using System.Net.Http;
using System.Threading.Tasks;

namespace NChronicle.Live.Web.Client.Components.Behind
{

    public class App : BaseComponent
    {

        protected ChronicleRecordDto[] Records;

        [Inject] private HttpClient httpClient { get; set; }

        protected override async Task OnInitAsync()
        {
            Records = await this.httpClient.GetJsonAsync<ChronicleRecordDto[]>("api/chroniclerecord");
        }

    }

}
