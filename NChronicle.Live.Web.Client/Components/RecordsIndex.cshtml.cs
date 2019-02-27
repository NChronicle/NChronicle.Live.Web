using Microsoft.AspNetCore.Components;
using NChronicle.Live.Web.Client.Components.Dialogs;
using NChronicle.Live.Web.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NChronicle.Live.Web.Client.Components.Behind
{
    public class RecordsIndex : BaseComponent
    {

        protected Dialog RecordsDetailDialog { get; set; }
        protected ChronicleRecordDto SelectedChronicleRecord { get; set; }
        protected ChronicleRecordDto[] Records;

        [Inject] private HttpClient httpClient { get; set; }

        protected override async Task OnInitAsync()
        {
            Records = await this.httpClient.GetJsonAsync<ChronicleRecordDto[]>("api/chroniclerecord");
        }

        protected void OnRecordSelect(ChronicleRecordDto selectedRecord)
        {
            Console.WriteLine($"--- Dialog is currently: {RecordsDetailDialog}");
            this.SelectedChronicleRecord = selectedRecord;
            this.StateHasChanged();
            Console.WriteLine($"--- Dialog is currently: {RecordsDetailDialog}");
            this.RecordsDetailDialog.ShowDialog();
        }

    }
}
